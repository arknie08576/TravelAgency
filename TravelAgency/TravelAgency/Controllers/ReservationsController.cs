using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReservationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllReservations([FromQuery] GetReservationsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


    }
}
