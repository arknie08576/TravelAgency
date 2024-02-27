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
    public class PutUserByIdHandler : IRequestHandler<PutUserByIdRequest, PutUserByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutUserByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutUserByIdResponse> Handle(PutUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new PutUserByIdCommand() { Parameter = user };
            var UserFromDb = await this.commandExecutor.Execute(command);
            return new PutUserByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(UserFromDb)
            };
        }
    }
}
