﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.ApplicationServices.API.Domain.Models;

namespace TravelAgency.ApplicationServices.API.Mappings
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {

            this.CreateMap<TravelAgency.DataAccess.Entities.Reservation, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.AdultsNumber, y => y.MapFrom(z => z.AdultsNumber))
                .ForMember(x => x.KidsNumber, y => y.MapFrom(z => z.KidsNumber))
                .ForMember(x => x.PricePaid, y => y.MapFrom(z => z.PricePaid));

            this.CreateMap<DeleteReservationByIdRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ReservationId));

            this.CreateMap<PutReservationByIdRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ReservationId))
                .ForMember(x => x.TripId, y => y.MapFrom(x => x.TripId))
                .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                .ForMember(x => x.AdultsNumber, y => y.MapFrom(x => x.AdultsNumber))
                .ForMember(x => x.PricePaid, y => y.MapFrom(x => x.PricePaid))
                .ForMember(x => x.KidsNumber, y => y.MapFrom(x => x.KidsNumber));

            this.CreateMap<AddReservationRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.ReservationId))
                .ForMember(x => x.TripId, y => y.MapFrom(x => x.TripId))
                .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                .ForMember(x => x.AdultsNumber, y => y.MapFrom(x => x.AdultsNumber))
                .ForMember(x => x.PricePaid, y => y.MapFrom(x => x.PricePaid))
                .ForMember(x => x.KidsNumber, y => y.MapFrom(x => x.KidsNumber));

            this.CreateMap<Reservation, Domain.Models.Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.TripId, y => y.MapFrom(x => x.TripId))
                .ForMember(x => x.UserId, y => y.MapFrom(x => x.UserId))
                .ForMember(x => x.AdultsNumber, y => y.MapFrom(x => x.AdultsNumber))
                .ForMember(x => x.PricePaid, y => y.MapFrom(x => x.PricePaid))
                .ForMember(x => x.KidsNumber, y => y.MapFrom(x => x.KidsNumber));


        }
    }
}
