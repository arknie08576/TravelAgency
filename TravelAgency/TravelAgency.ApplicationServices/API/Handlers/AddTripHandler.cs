using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.ApplicationServices.API.ErrorHandling;
using TravelAgency.DataAccess.CQRS;
using TravelAgency.DataAccess.CQRS.Commands;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class AddTripHandler : IRequestHandler<AddTripRequest, AddTripResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddTripHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddTripResponse> Handle(AddTripRequest request, CancellationToken cancellationToken)
        {
            if (request.GetUser() == null)
            {
                return new AddTripResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            if (request.GetUser().Role == UserRole.user)
            {
                return new AddTripResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            var trip = this.mapper.Map<Trip>(request);
            var command = new AddTripCommand() { Parameter = trip };
            var TripFromDb = await this.commandExecutor.Execute(command);
            return new AddTripResponse()
            {
                Data = this.mapper.Map<Domain.Models.Trip>(TripFromDb)
            };
        }
    }
}
