using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain.Models;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class GetOpinionByIdRequest : IRequest<GetOpinionByIdResponse>
    {
        public int OpinionId { get; set; }
    }
}
