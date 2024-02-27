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
        [Route("/Trips")]
        public async Task<IActionResult> GetAllTrips()//[FromQuery] GetTripsRequest request
        {
            var response = await this.mediator.Send(new GetTripsRequest());//request
            return this.Ok(response);
        }
        [HttpGet]
        [Route("/Trips/{tripId}")]
        public async Task<IActionResult> GetById([FromRoute] int tripId)
        {

            var request = new GetTripByIdRequest()
            {
                TripId = tripId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route("/Trips")]
        public async Task<IActionResult> AddTrip([FromBody] AddTripRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpDelete]
        [Route("/Trips/{tripId}")]
        public async Task<IActionResult> DeleteById([FromRoute] int tripId)
        {

            var request = new DeleteTripByIdRequest()
            {
                TripId = tripId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("/Trips/{tripId}")]
        public async Task<IActionResult> PutById([FromBody] PutTripByIdRequest request, [FromRoute] int tripId)
        {

            if (request.TripId != tripId) { return BadRequest(request); }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
