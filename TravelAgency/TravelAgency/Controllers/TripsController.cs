using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly IMediator mediator;
        public TripsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTrips([FromQuery] GetTripsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


    }
}
