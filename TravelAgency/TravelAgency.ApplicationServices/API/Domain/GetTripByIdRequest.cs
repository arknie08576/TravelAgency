using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain.Models;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class GetTripByIdRequest : IRequest<GetTripByIdResponse>
    {
        public int TripId { get; set; }
    }
}
