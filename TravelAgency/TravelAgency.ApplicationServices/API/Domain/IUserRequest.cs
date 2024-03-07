using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public interface IUserRequest
    {
        //private User auser;

        public void SetUser(User u);
        public User GetUser();
    }

    
}
