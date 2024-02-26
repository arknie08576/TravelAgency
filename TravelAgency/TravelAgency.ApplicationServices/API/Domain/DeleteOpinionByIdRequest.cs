using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.ApplicationServices.API.Domain
{
    public class DeleteOpinionByIdRequest : IRequest<DeleteOpinionByIdResponse>
    {
        public int OpinionId { get; set; }
    }
}
