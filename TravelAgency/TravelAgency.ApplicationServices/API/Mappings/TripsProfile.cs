using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.ApplicationServices.API.Domain.Models;

namespace TravelAgency.ApplicationServices.API.Mappings
{
    public class TripsProfile : Profile
    {
        public TripsProfile()
        {

            this.CreateMap<TravelAgency.DataAccess.Entities.Trip, Trip>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HotelName, y => y.MapFrom(z => z.HotelName))
                .ForMember(x => x.HotelDescription, y => y.MapFrom(z => z.HotelDescription))
                .ForMember(x => x.Country, y => y.MapFrom(z => z.Country))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.PricePerAdult, y => y.MapFrom(z => z.PricePerAdult))
                .ForMember(x => x.PricePerKid, y => y.MapFrom(z => z.PricePerKid))
                .ForMember(x => x.StartDate, y => y.MapFrom(z => z.StartDate))
                .ForMember(x => x.StopDate, y => y.MapFrom(z => z.StopDate))
                .ForMember(x => x.Departure, y => y.MapFrom(z => z.Departure))
                .ForMember(x => x.Food, y => y.MapFrom(z => z.Food))
                .ForMember(x => x.RequiredDocuments, y => y.MapFrom(z => z.RequiredDocuments));

            this.CreateMap<DeleteTripByIdRequest, Trip>()
               .ForMember(x => x.Id, y => y.MapFrom(x => x.TripId));

            this.CreateMap<PutTripByIdRequest, Trip>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.TripId))
                .ForMember(x => x.HotelName, y => y.MapFrom(z => z.HotelName))
                .ForMember(x => x.HotelDescription, y => y.MapFrom(z => z.HotelDescription))
                .ForMember(x => x.Country, y => y.MapFrom(z => z.Country))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.PricePerAdult, y => y.MapFrom(z => z.PricePerAdult))
                .ForMember(x => x.PricePerKid, y => y.MapFrom(z => z.PricePerKid))
                .ForMember(x => x.StartDate, y => y.MapFrom(z => z.StartDate))
                .ForMember(x => x.StopDate, y => y.MapFrom(z => z.StopDate))
                .ForMember(x => x.Departure, y => y.MapFrom(z => z.Departure))
                .ForMember(x => x.Food, y => y.MapFrom(z => z.Food))
                .ForMember(x => x.RequiredDocuments, y => y.MapFrom(z => z.RequiredDocuments));

            this.CreateMap<AddTripRequest, Trip>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.TripId))
                .ForMember(x => x.HotelName, y => y.MapFrom(z => z.HotelName))
                .ForMember(x => x.HotelDescription, y => y.MapFrom(z => z.HotelDescription))
                .ForMember(x => x.Country, y => y.MapFrom(z => z.Country))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.PricePerAdult, y => y.MapFrom(z => z.PricePerAdult))
                .ForMember(x => x.PricePerKid, y => y.MapFrom(z => z.PricePerKid))
                .ForMember(x => x.StartDate, y => y.MapFrom(z => z.StartDate))
                .ForMember(x => x.StopDate, y => y.MapFrom(z => z.StopDate))
                .ForMember(x => x.Departure, y => y.MapFrom(z => z.Departure))
                .ForMember(x => x.Food, y => y.MapFrom(z => z.Food))
                .ForMember(x => x.RequiredDocuments, y => y.MapFrom(z => z.RequiredDocuments));

            this.CreateMap<Trip, Domain.Models.Trip>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HotelName, y => y.MapFrom(z => z.HotelName))
                .ForMember(x => x.HotelDescription, y => y.MapFrom(z => z.HotelDescription))
                .ForMember(x => x.Country, y => y.MapFrom(z => z.Country))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.PricePerAdult, y => y.MapFrom(z => z.PricePerAdult))
                .ForMember(x => x.PricePerKid, y => y.MapFrom(z => z.PricePerKid))
                .ForMember(x => x.StartDate, y => y.MapFrom(z => z.StartDate))
                .ForMember(x => x.StopDate, y => y.MapFrom(z => z.StopDate))
                .ForMember(x => x.Departure, y => y.MapFrom(z => z.Departure))
                .ForMember(x => x.Food, y => y.MapFrom(z => z.Food))
                .ForMember(x => x.RequiredDocuments, y => y.MapFrom(z => z.RequiredDocuments));

        }
    }
}
