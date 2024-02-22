using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain.Models;

namespace TravelAgency.ApplicationServices.API.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {

            this.CreateMap<TravelAgency.DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));


        }
    }
}
