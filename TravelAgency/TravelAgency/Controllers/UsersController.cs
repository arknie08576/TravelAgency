using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess;

namespace TravelAgency.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        public UsersController(IMediator mediator, ILogger<UsersController> logger, TravelAgencyContex _contex) : base (mediator, _contex)
        {
            _logger = logger;
            logger.LogInformation("We are in Users");
        }

        [HttpGet]
        [Route("/Users")]
        public Task<IActionResult> GetAllUsers()//[FromQuery] GetUsersRequest request
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(new GetUsersRequest());
        }
        [HttpGet]
        [Route("/Users/{username}")]
        public Task<IActionResult> GetById([FromRoute] string username)
        {

            var request = new GetUserByIdRequest()
            {
                Username = username
            };
            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/Users")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);

        }
        [HttpDelete]
        [Route("/Users/{userId}")]
        public Task<IActionResult> DeleteById([FromRoute] int userId)
        {

            var request = new DeleteUserByIdRequest()
            {
                UserId = userId
            };
            return this.HandleRequest<DeleteUserByIdRequest, DeleteUserByIdResponse>(request);
        }
        [HttpPut]
        [Route("/Users/{userId}")]
        public Task<IActionResult> PutById([FromBody] PutUserByIdRequest request)
        {

            return this.HandleRequest<PutUserByIdRequest, PutUserByIdResponse>(request);
        }

    }
}
