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
    public class PutOpinionByIdHandler : IRequestHandler<PutOpinionByIdRequest, PutOpinionByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public PutOpinionByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<PutOpinionByIdResponse> Handle(PutOpinionByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.GetUser() == null)
            {
                return new PutOpinionByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            if (request.GetUser().Login == "admin")
            {
                return new PutOpinionByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }
            var opinion = this.mapper.Map<Opinion>(request);
            var command = new PutOpinionByIdCommand() { Parameter = opinion };
            var opinionFromDb = await this.commandExecutor.Execute(command);
            return new PutOpinionByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Opinion>(opinionFromDb)
            };
        }
    }
}
