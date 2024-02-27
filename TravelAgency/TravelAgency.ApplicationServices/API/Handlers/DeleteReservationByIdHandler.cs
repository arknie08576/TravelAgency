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


namespace TravelAgency.ApplicationServices.API.Handlers
{

    public class DeleteReservationByIdHandler : IRequestHandler<DeleteReservationByIdRequest, DeleteReservationByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteReservationByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteReservationByIdResponse> Handle(DeleteReservationByIdRequest request, CancellationToken cancellationToken)
        {
            var reservation = this.mapper.Map<Reservation>(request);
            var command = new DeleteReservationCommand()
            {
                Parameter = reservation,
                Id = request.ReservationId
            };

            var ReservationFromDb = await this.commandExecutor.Execute(command);
            return new DeleteReservationByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Reservation>(ReservationFromDb)
            };
        }


    }
}
