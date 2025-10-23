using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.DataAccess;

namespace TravelAgency.Controllers
{
    [Authorize]
    [ApiController]
    [Route ("[controller]")]
    public class OpinionsController : ApiControllerBase
    {
        
        private readonly ILogger<OpinionsController> _logger;
        public OpinionsController(IMediator mediator, ILogger<OpinionsController> logger, TravelAgencyContex _contex) : base(mediator, _contex) {

            _logger = logger;
            logger.LogInformation("We are in Opinions");
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("/Opinions")]
        public  Task<IActionResult> GetAllOpinions()//[FromQuery] GetOpinionsRequest request
        {
            
            return this.HandleRequest<GetOpinionsRequest, GetOpinionsResponse>(new GetOpinionsRequest());
        }

        [HttpGet]
        [Route("/Opinions/{opinionId}")]
        public Task<IActionResult> GetById([FromRoute] int opinionId)
        {
            
            var request = new GetOpinionByIdRequest()
            {
                OpinionId = opinionId
            };
            return this.HandleRequest<GetOpinionByIdRequest, GetOpinionByIdResponse>(request);
        }
        
        [HttpPost]
        [Route ("/Opinions")]
        public Task<IActionResult> AddOpinion([FromBody] AddOpinionRequest request)
        {



            return this.HandleRequest<AddOpinionRequest,AddOpinionResponse>(request);
            //if (!this.ModelState.IsValid)
            //{
            //    return this.BadRequest("BAD_REQUEST");
            //}

            //var response = await this.mediator.Send(request);
            //return this.Ok(response);

        }
        [HttpDelete]
        [Route("/Opinions/{opinionId}")]
        public Task<IActionResult> DeleteById([FromRoute] int opinionId)
        {

            var request = new DeleteOpinionByIdRequest()
            {
                OpinionId = opinionId
            };
            return this.HandleRequest<DeleteOpinionByIdRequest, DeleteOpinionByIdResponse>(request);
        }
        [HttpPut]
        [Route("/Opinions/{opinionId}")]
        public Task<IActionResult> PutById([FromBody] PutOpinionByIdRequest request)
        {

            
            return this.HandleRequest<PutOpinionByIdRequest, PutOpinionByIdResponse>(request);
        }

    }
}
