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
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IRepository<DataAccess.Entities.User> UserRepository;
        private readonly IMapper mapper;
        public GetUsersHandler(IRepository<DataAccess.Entities.User> UserRepository, IMapper mapper)
        {
            this.UserRepository = UserRepository;
            this.mapper = mapper;

        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await this.UserRepository.GetAll();
            var mappedUser = this.mapper.Map<List<Domain.Models.User>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUser

            };
            return response;

        }


    }
}
