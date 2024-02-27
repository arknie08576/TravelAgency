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
        [Route("/opinions")]
        public async Task<IActionResult> GetAllOpinions()//[FromQuery] GetOpinionsRequest request
        {
            var response = await this.mediator.Send(new GetOpinionsRequest());//request
            return this.Ok(response);
        }
        [HttpGet]
        [Route("/opinions/{opinionId}")]
        public async Task<IActionResult> GetById([FromRoute] int opinionId)
        {
            
            var request = new GetOpinionByIdRequest()
            {
                OpinionId = opinionId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route ("/opinions")]
        public async Task<IActionResult> AddOpinion([FromBody] AddOpinionRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpDelete]
        [Route("/opinions/{opinionId}")]
        public async Task<IActionResult> DeleteById([FromRoute] int opinionId)
        {

            var request = new DeleteOpinionByIdRequest()
            {
                OpinionId = opinionId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPut]
        [Route("/opinions/{opinionId}")]
        public async Task<IActionResult> PutById([FromBody] PutOpinionByIdRequest request, [FromRoute] int opinionId)
        {

            if (request.OpinionId != opinionId) { return BadRequest(request); }
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
