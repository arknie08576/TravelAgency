using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>, IUserRequest
    {
        public string Username { get; set; }
        private User user { get; set; }

        public void SetUser(User u)
        {
            user = u;
        }

        public User GetUser()
        {
            return user;
        }
    }
}
