using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess.CQRS.Commands;
using TravelAgency.DataAccess.CQRS;
using TravelAgency.DataAccess.Entities;
using TravelAgency.ApplicationServices.API.ErrorHandling;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class PutReservationByIdHandler : IRequestHandler<PutReservationByIdRequest, PutReservationByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutReservationByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutReservationByIdResponse> Handle(PutReservationByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.GetUser() == null)
            {
                return new PutReservationByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            if (request.GetUser().Login != "admin")
            {
                return new PutReservationByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            var Reservation = this.mapper.Map<Reservation>(request);
            var command = new PutReservationByIdCommand() { Parameter = Reservation };
            var ReservationFromDb = await this.commandExecutor.Execute(command);
            return new PutReservationByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Reservation>(ReservationFromDb)
            };
        }
    }
}
