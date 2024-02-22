using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        }
    }
}
