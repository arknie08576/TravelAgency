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

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {



            var query = new GetUserQuery()
            {
                Id = request.UserId,
            };
            var user = await this.queryExecutor.Execute(query);
            var mappedUser = this.mapper.Map<Domain.Models.User>(user);

            var response = new GetUserByIdResponse()
            {
                Data = mappedUser

            };
            return response;

        }
    }
}
