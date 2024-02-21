using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess;

namespace TravelAgency.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IRepository<DataAccess.Entities.User> UserRepository;
        public GetUsersHandler(IRepository<DataAccess.Entities.User> UserRepository)
        {
            this.UserRepository = UserRepository;
        }
        public Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var Users = this.UserRepository.GetAll();
            var domainUsers = Users.Select(x => new Domain.Models.User()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Login = x.Login,
                Email = x.Email



            });
            var response = new GetUsersResponse()
            {
                Data = domainUsers.ToList()

            };
            return Task.FromResult(response);

        }
    }
}
