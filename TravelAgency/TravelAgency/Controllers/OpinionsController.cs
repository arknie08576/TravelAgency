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
        [HttpGet]
        [Route("{opinionId}")]
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
        [Route ("")]
        public async Task<IActionResult> AddOpinion([FromBody] AddOpinionRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpDelete]
        [Route("{opinionId}")]
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
        [Route("")]
        public async Task<IActionResult> PutById([FromBody] PutOpinionByIdRequest request)
        {
        //    public int OpinionId { get; set; }
        //public int ReservationId { get; set; }
        //public int Rating { get; set; }

        //public string Description { get; set; }

        //public DateOnly Date { get; set; }

        //var request = new PutOpinionByIdRequest()
        //    {
        //        OpinionId = opinionId,
        //        ReservationId = reservationId,
        //        Rating = rating,
        //        Description = description,
        //        Date = date
                
        //    };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

    }
}
