﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess.Entities;


namespace TravelAgency.ApplicationServices.API.Mappings
{
    public class OpinionsProfile : Profile
    {
        public OpinionsProfile() {


            this.CreateMap<DeleteOpinionByIdRequest, Opinion>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.OpinionId));

            this.CreateMap<PutOpinionByIdRequest, Opinion>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.OpinionId))
                .ForMember(x => x.Date, y => y.MapFrom(x => x.Date))
                .ForMember(x => x.ReservationId, y => y.MapFrom(x => x.ReservationId))
                .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                .ForMember(x => x.Rating, y => y.MapFrom(x => x.Rating));

            this.CreateMap<AddOpinionRequest, Opinion>()
                .ForMember(x => x.Rating, y => y.MapFrom(x => x.Rating))
                .ForMember(x => x.Date, y => y.MapFrom(x => x.Date))
                .ForMember(x => x.ReservationId, y => y.MapFrom(x => x.Rating))
                .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
                .ForMember(x => x.ReservationId, y => y.MapFrom(x => x.ReservationId));

            this.CreateMap<Opinion, Domain.Models.Opinion>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Date, y => y.MapFrom(z => z.Date))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating));
               

        }
    }
}
