﻿using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class OpinionsController : ApiControllerBase
    {
        
        private readonly ILogger<OpinionsController> _logger;
        public OpinionsController(IMediator mediator, ILogger<OpinionsController> logger) : base(mediator) {

            _logger = logger;
            logger.LogInformation("We are in Opinions");
        }

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
        public Task<IActionResult> PutById([FromBody] PutOpinionByIdRequest request, [FromRoute] int opinionId)
        {

            
            return this.HandleRequest<PutOpinionByIdRequest, PutOpinionByIdResponse>(request);
        }

    }
}
