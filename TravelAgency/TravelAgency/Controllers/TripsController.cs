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
    public class TripsController : ApiControllerBase
    {
        private readonly ILogger<TripsController> _logger;
        public TripsController(IMediator mediator, ILogger<TripsController> logger, TravelAgencyContex _contex) : base(mediator, _contex)
        {
            _logger = logger;
            logger.LogInformation("We are in Trips");
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("/Trips")]
        public Task<IActionResult> GetAllTrips()//[FromQuery] GetTripsRequest request
        {
            return this.HandleRequest<GetTripsRequest, GetTripsResponse>(new GetTripsRequest());
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("/Trips/{tripId}")]
        public Task<IActionResult> GetById([FromRoute] int tripId)
        {

            var request = new GetTripByIdRequest()
            {
                TripId = tripId
            };
            return this.HandleRequest<GetTripByIdRequest, GetTripByIdResponse>(request);
        }
        [HttpPost]
        [Route("/Trips")]
        public Task<IActionResult> AddTrip([FromBody] AddTripRequest request)
        {
            return this.HandleRequest<AddTripRequest, AddTripResponse>(request);

        }
        [HttpDelete]
        [Route("/Trips/{tripId}")]
        public Task<IActionResult> DeleteById([FromRoute] int tripId)
        {

            var request = new DeleteTripByIdRequest()
            {
                TripId = tripId
            };
            return this.HandleRequest<DeleteTripByIdRequest, DeleteTripByIdResponse>(request);
        }
        [HttpPut]
        [Route("/Trips/{tripId}")]
        public Task<IActionResult> PutById([FromBody] PutTripByIdRequest request)
        {

            return this.HandleRequest<PutTripByIdRequest, PutTripByIdResponse>(request);
        }

    }
}
