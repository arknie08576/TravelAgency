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
    public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdRequest, GetReservationByIdResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetReservationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetReservationByIdResponse> Handle(GetReservationByIdRequest request, CancellationToken cancellationToken)
        {



            var query = new GetReservationQuery()
            {
                Id = request.ReservationId,
            };
            var Reservation = await this.queryExecutor.Execute(query);
            var mappedReservation = this.mapper.Map<Domain.Models.Reservation>(Reservation);

            var response = new GetReservationByIdResponse()
            {
                Data = mappedReservation

            };
            return response;

        }
    }
}
