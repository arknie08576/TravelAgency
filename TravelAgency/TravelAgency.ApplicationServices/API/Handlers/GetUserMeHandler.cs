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
    public class GetUserMeHandler : IRequestHandler<GetUserMeRequest, GetUserMeResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetUserMeHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetUserMeResponse> Handle(GetUserMeRequest request, CancellationToken cancellationToken)
        {



            var query = new GetUserMeQuery();
                if(request.GetUser()!=null)
            {
                query.Login = request.GetUser().Login;

            }

            var user = await this.queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetUserMeResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)

                };

            }
            var mappedUser = this.mapper.Map<Domain.Models.User>(user);

            var response = new GetUserMeResponse()
            {
                Data = mappedUser

            };
            return response;

        }
    }
}
