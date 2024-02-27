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
using TravelAgency.DataAccess.CQRS;
using TravelAgency.DataAccess.CQRS.Queries;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetTripsHandler : IRequestHandler<GetTripsRequest, GetTripsResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetTripsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetTripsResponse> Handle(GetTripsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTripsQuery();
            var Trips = await this.queryExecutor.Execute(query);




            var mappedTrip = this.mapper.Map<List<Domain.Models.Trip>>(Trips);

            var response = new GetTripsResponse()
            {
                Data = mappedTrip

            };
            return response;

        }


    }
}
