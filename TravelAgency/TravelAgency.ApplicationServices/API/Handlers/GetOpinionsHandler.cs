using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.ApplicationServices.API.Domain.Models;
using TravelAgency.DataAccess;
using TravelAgency.DataAccess.CQRS.Queries;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetOpinionsHandler : IRequestHandler<GetOpinionsRequest, GetOpinionsResponse>
    {
        
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetOpinionsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
           
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetOpinionsResponse> Handle(GetOpinionsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOpinionsQuery();
            var opinions = await this.queryExecutor.Execute(query);



           
            var mappedOpinion = this.mapper.Map<List<Domain.Models.Opinion>>(opinions);

            var response = new GetOpinionsResponse()
            {
                Data = mappedOpinion

            };
            return response;

        }


    }
}
