using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class AddOpinionRequest : IRequest<AddOpinionResponse>
    {
        public int ReservationId { get; set; }
        public int Rating { get; set; }
       
        public string Description { get; set; }
        
        public DateOnly Date { get; set; }
        
      
    }
}
