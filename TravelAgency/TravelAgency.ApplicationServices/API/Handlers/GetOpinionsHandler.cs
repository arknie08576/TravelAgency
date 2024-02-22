using AutoMapper;
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
        private readonly IMapper mapper;
        public GetOpinionsHandler(IRepository<DataAccess.Entities.Opinion> opinionRepository, IMapper mapper)
        {
            this.opinionRepository = opinionRepository;
            this.mapper = mapper;

        }
        public async Task<GetOpinionsResponse> Handle(GetOpinionsRequest request, CancellationToken cancellationToken)
        {
            var opinions = await this.opinionRepository.GetAll();
            var mappedOpinion = this.mapper.Map<List<Domain.Models.Opinion>>(opinions);

            var response = new GetOpinionsResponse()
            {
                Data = mappedOpinion

            };
            return response;

        }


    }
}
