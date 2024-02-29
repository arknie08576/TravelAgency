using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : ApiControllerBase
    {
        private readonly ILogger<OpinionsController> _logger;
        public ReservationsController(IMediator mediator, ILogger<OpinionsController> logger) : base(mediator) 
        {
            _logger = logger;
            logger.LogInformation("We are in Reservations");
        }

        [HttpGet]
        [Route("/Reservations")]
        public async Task<IActionResult> GetAllReservations()//[FromQuery] GetReservationsRequest request
        {
            var response = await this.mediator.Send(new GetReservationsRequest());//request
            return this.Ok(response);
        }
        [HttpGet]
        [Route("/Reservations/{reservationId}")]
        public async Task<IActionResult> GetById([FromRoute] int reservationId)
        {

            var request = new GetReservationByIdRequest()
            {
                ReservationId = reservationId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route("/Reservations")]
        public async Task<IActionResult> AddReservation([FromBody] AddReservationRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpDelete]
        [Route("/Reservations/{reservationId}")]
        public async Task<IActionResult> DeleteById([FromRoute] int reservationId)
        {

            var request = new DeleteReservationByIdRequest()
            {
                ReservationId = reservationId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("/Reservations/{ReservationId}")]
        public async Task<IActionResult> PutById([FromBody] PutReservationByIdRequest request, [FromRoute] int reservationId)
        {

            if (request.ReservationId != reservationId) { return BadRequest(request); }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
