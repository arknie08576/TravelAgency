using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class OpinionsController : ControllerBase
    {
        private readonly IMediator mediator;
        public OpinionsController(IMediator mediator) { 
        this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOpinions([FromQuery] GetOpinionsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


    }
}
