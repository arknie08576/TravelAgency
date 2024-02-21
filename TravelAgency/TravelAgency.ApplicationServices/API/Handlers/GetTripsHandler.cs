using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetTripsHandler : IRequestHandler<GetTripsRequest, GetTripsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Trip> TripRepository;
        public GetTripsHandler(IRepository<DataAccess.Entities.Trip> TripRepository)
        {
            this.TripRepository = TripRepository;
        }
        public Task<GetTripsResponse> Handle(GetTripsRequest request, CancellationToken cancellationToken)
        {
            var Trips = this.TripRepository.GetAll();
            var domainTrips = Trips.Select(x => new Domain.Models.Trip()
            {
                Id = x.Id,
                HotelName=x.HotelName,
                HotelDescription= x.HotelDescription,
                Country=x.Country,
                City=x.City,
                PricePerAdult=x.PricePerAdult,
                PricePerKid=x.PricePerKid,
                StartDate=x.StartDate,
                StopDate=x.StopDate,
                Departure=x.Departure,
                Food=x.Food,
                RequiredDocuments=x.RequiredDocuments



    });
            var response = new GetTripsResponse()
            {
                Data = domainTrips.ToList()

            };
            return Task.FromResult(response);

        }
    }
}
