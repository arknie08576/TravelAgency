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

    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdRequest, DeleteUserByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteUserByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteUserByIdResponse> Handle(DeleteUserByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.GetUser() == null)
            {
                return new DeleteUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            if (request.GetUser().Login != "admin")
            {
                return new DeleteUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            var user = this.mapper.Map<User>(request);
            var command = new DeleteUserCommand()
            {
                Parameter = user,
                Id = request.UserId
            };

            var UserFromDb = await this.commandExecutor.Execute(command);
            return new DeleteUserByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(UserFromDb)
            };
        }


    }
}
