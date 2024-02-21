using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.ApplicationServices.API.Domain.Models;
using TravelAgency.DataAccess;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetOpinionsHandler : IRequestHandler<GetOpinionsRequest, GetOpinionsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Opinion> opinionRepository;
        public GetOpinionsHandler(IRepository<DataAccess.Entities.Opinion> opinionRepository) { 
        this.opinionRepository = opinionRepository;
        }
        public Task<GetOpinionsResponse> Handle(GetOpinionsRequest request,CancellationToken cancellationToken)
        {
            var opinions = this.opinionRepository.GetAll();
            var domainOpinions = opinions.Select(x => new Domain.Models.Opinion()
            {
                Id = x.Id,
                Rating = x.Rating,
                Description = x.Description,
                Date = x.Date

            });
            var response = new GetOpinionsResponse()
            {
                Data = domainOpinions.ToList()

            };
            return Task.FromResult(response);

        }


    }
}
