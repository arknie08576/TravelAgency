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
            var reservation = await this.queryExecutor.Execute(query);
            if (reservation == null)
            {
                return new GetReservationByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)

                };

            }
            var mappedReservation = this.mapper.Map<Domain.Models.Reservation>(reservation);

            var response = new GetReservationByIdResponse()
            {
                Data = mappedReservation

            };
            return response;

        }
    }
}
