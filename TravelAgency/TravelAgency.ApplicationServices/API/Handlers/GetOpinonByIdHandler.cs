using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess.CQRS.Queries;
using TravelAgency.DataAccess.CQRS;
using MediatR;
using TravelAgency.ApplicationServices.API.ErrorHandling;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetOpinionByIdHandler : IRequestHandler<GetOpinionByIdRequest, GetOpinionByIdResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetOpinionByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetOpinionByIdResponse> Handle(GetOpinionByIdRequest request, CancellationToken cancellationToken)
        {

            

            var query = new GetOpinionQuery()
            {
               Id=request.OpinionId,
            };
            var opinion = await this.queryExecutor.Execute(query);
            if (opinion == null)
            {
                return new GetOpinionByIdResponse() { 
                Error=new ErrorModel(ErrorType.NotFound)
                
                };

            }
            var mappedOpinion = this.mapper.Map<Domain.Models.Opinion>(opinion);

            var response = new GetOpinionByIdResponse()
            {
                Data = mappedOpinion

            };
            return response;

        }
    }
}
