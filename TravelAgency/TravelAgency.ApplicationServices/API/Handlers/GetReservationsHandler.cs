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
    public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetReservationsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReservationsQuery();
            var Reservations = await this.queryExecutor.Execute(query);




            var mappedReservation = this.mapper.Map<List<Domain.Models.Reservation>>(Reservations);

            var response = new GetReservationsResponse()
            {
                Data = mappedReservation

            };
            return response;

        }


    }
}
