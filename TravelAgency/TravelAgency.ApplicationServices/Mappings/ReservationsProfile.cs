using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.Mappings
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {

            CreateMap<DataAccess.Entities.Reservation, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.AdultsNumber, y => y.MapFrom(z => z.AdultsNumber))
                .ForMember(x => x.KidsNumber, y => y.MapFrom(z => z.KidsNumber))
                .ForMember(x => x.PricePaid, y => y.MapFrom(z => z.PricePaid));

            CreateMap<DeleteReservationByIdRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ReservationId));

            CreateMap<PutReservationByIdRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ReservationId))
                .ForMember(x => x.TripId, y => y.MapFrom(x => x.TripId))
                .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                .ForMember(x => x.AdultsNumber, y => y.MapFrom(x => x.AdultsNumber))
                .ForMember(x => x.PricePaid, y => y.MapFrom(x => x.PricePaid))
                .ForMember(x => x.KidsNumber, y => y.MapFrom(x => x.KidsNumber));

            CreateMap<AddReservationRequest, Reservation>()
               // .ForMember(x => x.Id, y => y.MapFrom(x => x.ReservationId))
                .ForMember(x => x.TripId, y => y.MapFrom(x => x.TripId))
                .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                .ForMember(x => x.AdultsNumber, y => y.MapFrom(x => x.AdultsNumber))
                .ForMember(x => x.PricePaid, y => y.MapFrom(x => x.PricePaid))
                .ForMember(x => x.KidsNumber, y => y.MapFrom(x => x.KidsNumber));

            CreateMap<Reservation, API.Domain.Models.Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.TripId, y => y.MapFrom(x => x.TripId))
                .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                .ForMember(x => x.AdultsNumber, y => y.MapFrom(x => x.AdultsNumber))
                .ForMember(x => x.PricePaid, y => y.MapFrom(x => x.PricePaid))
                .ForMember(x => x.KidsNumber, y => y.MapFrom(x => x.KidsNumber));


        }
    }
}
