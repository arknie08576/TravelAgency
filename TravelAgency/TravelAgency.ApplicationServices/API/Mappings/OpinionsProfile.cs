using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain.Models;

namespace TravelAgency.ApplicationServices.API.Mappings
{
    public class OpinionsProfile : Profile
    {
        public OpinionsProfile() {

            this.CreateMap<TravelAgency.DataAccess.Entities.Opinion, Opinion>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Date, y => y.MapFrom(z => z.Date))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Rating, y => y.MapFrom(z => z.Rating));
               

        }
    }
}
