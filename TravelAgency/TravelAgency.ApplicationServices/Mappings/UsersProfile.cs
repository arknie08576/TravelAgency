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
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {

            CreateMap<DeleteUserByIdRequest, User>()
                .ForMember(x => x.Id, y => y.MapFrom(x => x.UserId));

            CreateMap<PutUserByIdRequest, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));

            CreateMap<AddUserRequest, User>()
               // .ForMember(x => x.Id, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));

            CreateMap<User, API.Domain.Models.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));


        }
    }
}
