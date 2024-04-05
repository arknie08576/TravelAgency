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

    public class DeleteTripByIdHandler : IRequestHandler<DeleteTripByIdRequest, DeleteTripByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteTripByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteTripByIdResponse> Handle(DeleteTripByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.GetUser() == null)
            {
                return new DeleteTripByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            if (request.GetUser().Role == UserRole.user)
            {
                return new DeleteTripByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            var trip = this.mapper.Map<Trip>(request);
            var command = new DeleteTripCommand()
            {
                Parameter = trip,
                Id = request.TripId
            };

            var TripFromDb = await this.commandExecutor.Execute(command);
            return new DeleteTripByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Trip>(TripFromDb)
            };
        }


    }
}
