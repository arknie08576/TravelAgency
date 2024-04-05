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

    public class DeleteOpinionByIdHandler : IRequestHandler<DeleteOpinionByIdRequest, DeleteOpinionByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteOpinionByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteOpinionByIdResponse> Handle(DeleteOpinionByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.GetUser() == null)
            {
                return new DeleteOpinionByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };

            }

            var opinion = this.mapper.Map<Opinion>(request);
            var command = new DeleteOpinionCommand() { 
                Parameter = opinion,
                Id = request.OpinionId
            };

            var opinionFromDb = await this.commandExecutor.Execute(command);
            return new DeleteOpinionByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Opinion>(opinionFromDb)
            };
        }


    }
}
