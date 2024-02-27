using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;
        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("/Users")]
        public async Task<IActionResult> GetAllUsers()//[FromQuery] GetUsersRequest request
        {
            var response = await this.mediator.Send(new GetUsersRequest());//request
            return this.Ok(response);
        }
        [HttpGet]
        [Route("/Users/{userId}")]
        public async Task<IActionResult> GetById([FromRoute] int userId)
        {

            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route("/Users")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpDelete]
        [Route("/Users/{userId}")]
        public async Task<IActionResult> DeleteById([FromRoute] int userId)
        {

            var request = new DeleteUserByIdRequest()
            {
                UserId = userId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("/Users/{userId}")]
        public async Task<IActionResult> PutById([FromBody] PutUserByIdRequest request, [FromRoute] int userId)
        {

            if (request.UserId != userId) { return BadRequest(request); }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
