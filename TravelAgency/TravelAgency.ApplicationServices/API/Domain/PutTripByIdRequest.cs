﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class PutTripByIdRequest : IRequest<PutTripByIdResponse>, IUserRequest
    {
        public int TripId { get; set; }
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PricePerAdult { get; set; }
        public int PricePerKid { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly StopDate { get; set; }
        public string Departure { get; set; }
        public string Food { get; set; }
        public string RequiredDocuments { get; set; }
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
