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
    public class AddOpinionHandler : IRequestHandler<AddOpinionRequest, AddOpinionResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddOpinionHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddOpinionResponse> Handle(AddOpinionRequest request, CancellationToken cancellationToken)
        {
            if (request.GetUser() == null)
            {
                return new AddOpinionResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            if (request.GetUser().Role == UserRole.admin)
            {
                return new AddOpinionResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }

            var opinion = this.mapper.Map<Opinion>(request);
            var command = new AddOpinionCommand() { Parameter = opinion };
            var opinionFromDb = await this.commandExecutor.Execute(command);
            return new AddOpinionResponse()
            {
                Data = this.mapper.Map<Domain.Models.Opinion>(opinionFromDb)
            };
        }
    }
}
