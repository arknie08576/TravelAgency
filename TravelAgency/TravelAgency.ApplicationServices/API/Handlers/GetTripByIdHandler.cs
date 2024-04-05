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
    public class GetTripByIdHandler : IRequestHandler<GetTripByIdRequest, GetTripByIdResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetTripByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;

        }
        public async Task<GetTripByIdResponse> Handle(GetTripByIdRequest request, CancellationToken cancellationToken)
        {



            var query = new GetTripQuery()
            {
                Id = request.TripId,
            };
            var trip = await this.queryExecutor.Execute(query);
            if (trip == null)
            {
                return new GetTripByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)

                };

            }
            var mappedTrip = this.mapper.Map<Domain.Models.Trip>(trip);

            var response = new GetTripByIdResponse()
            {
                Data = mappedTrip

            };
            return response;

        }
    }
}
