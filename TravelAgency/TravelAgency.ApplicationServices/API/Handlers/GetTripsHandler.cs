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
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetTripsHandler : IRequestHandler<GetTripsRequest, GetTripsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Trip> TripRepository;
        private readonly IMapper mapper;
        public GetTripsHandler(IRepository<DataAccess.Entities.Trip> TripRepository, IMapper mapper)
        {
            this.TripRepository = TripRepository;
            this.mapper = mapper;

        }
        public async Task<GetTripsResponse> Handle(GetTripsRequest request, CancellationToken cancellationToken)
        {
            var trips = await this.TripRepository.GetAll();
            var mappedTrip = this.mapper.Map<List<Domain.Models.Trip>>(trips);

            var response = new GetTripsResponse()
            {
                Data = mappedTrip

            };
            return response;

        }


    }
}
