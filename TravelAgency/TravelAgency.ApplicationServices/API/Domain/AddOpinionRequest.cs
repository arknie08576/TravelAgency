using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class AddOpinionRequest : IRequest<AddOpinionResponse>, IUserRequest
    {

        public int ReservationId { get; set; }
        public int Rating { get; set; }
       
        public string Description { get; set; }
        
        public DateOnly Date { get; set; }
        private User user { get ; set; }

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
