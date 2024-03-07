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
    public class ReservationsController : ApiControllerBase
    {
        private readonly ILogger<ReservationsController> _logger;
        public ReservationsController(IMediator mediator, ILogger<ReservationsController> logger, TravelAgencyContex _contex) : base(mediator, _contex) 
        {
            _logger = logger;
            logger.LogInformation("We are in Reservations");
        }

        [HttpGet]
        [Route("/Reservations")]
        public Task<IActionResult> GetAllReservations()//[FromQuery] GetReservationsRequest request
        {
            return this.HandleRequest<GetReservationsRequest, GetReservationsResponse>(new GetReservationsRequest());
        }
        [HttpGet]
        [Route("/Reservations/{reservationId}")]
        public Task<IActionResult> GetById([FromRoute] int reservationId)
        {

            var request = new GetReservationByIdRequest()
            {
                ReservationId = reservationId
            };
            return this.HandleRequest<GetReservationByIdRequest, GetReservationByIdResponse>(request);
        }
        [HttpPost]
        [Route("/Reservations")]
        public Task<IActionResult> AddReservation([FromBody] AddReservationRequest request)
        {
            return this.HandleRequest<AddReservationRequest, AddReservationResponse>(request);

        }
        [HttpDelete]
        [Route("/Reservations/{reservationId}")]
        public Task<IActionResult> DeleteById([FromRoute] int reservationId)
        {

            var request = new DeleteReservationByIdRequest()
            {
                ReservationId = reservationId
            };
            return this.HandleRequest<DeleteReservationByIdRequest, DeleteReservationByIdResponse>(request);
        }
        [HttpPut]
        [Route("/Reservations/{ReservationId}")]
        public Task<IActionResult> PutById([FromBody] PutReservationByIdRequest request)
        {

            return this.HandleRequest<PutReservationByIdRequest, PutReservationByIdResponse>(request);
        }

    }
}
