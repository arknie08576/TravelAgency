using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess.CQRS;
using TravelAgency.DataAccess.CQRS.Commands;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class AddReservationHandler : IRequestHandler<AddReservationRequest, AddReservationResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddReservationHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddReservationResponse> Handle(AddReservationRequest request, CancellationToken cancellationToken)
        {
            var Reservation = this.mapper.Map<Reservation>(request);
            var command = new AddReservationCommand() { Parameter = Reservation };
            var ReservationFromDb = await this.commandExecutor.Execute(command);
            return new AddReservationResponse()
            {
                Data = this.mapper.Map<Domain.Models.Reservation>(ReservationFromDb)
            };
        }
    }
}
