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
    public class PutTripByIdHandler : IRequestHandler<PutTripByIdRequest, PutTripByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutTripByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutTripByIdResponse> Handle(PutTripByIdRequest request, CancellationToken cancellationToken)
        {
            var trip = this.mapper.Map<Trip>(request);
            var command = new PutTripByIdCommand() { Parameter = trip };
            var TripFromDb = await this.commandExecutor.Execute(command);
            return new PutTripByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Trip>(TripFromDb)
            };
        }
    }
}
