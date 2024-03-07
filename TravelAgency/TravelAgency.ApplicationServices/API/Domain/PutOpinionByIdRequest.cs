using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class PutOpinionByIdRequest : IRequest<PutOpinionByIdResponse>, IUserRequest
    {
        public int OpinionId { get; set; }
        public int ReservationId { get; set; }
        public int Rating { get; set; }

        public string Description { get; set; }

        public DateOnly Date { get; set; }
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
