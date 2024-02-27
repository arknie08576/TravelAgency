using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class DeleteReservationByIdRequest : IRequest<DeleteReservationByIdResponse>
    {
        public int ReservationId { get; set; }
    }
}
