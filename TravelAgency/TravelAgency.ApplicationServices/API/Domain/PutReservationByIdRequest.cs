using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class PutReservationByIdRequest : IRequest<PutReservationByIdResponse>
    {
        public int ReservationId { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }
        public int AdultsNumber { get; set; }
        public int KidsNumber { get; set; }
        public int PricePaid { get; set; }
    }
}
