﻿using BackendChallenge.Application.WaterJug.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterJugsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public WaterJugsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetSolveWaterJugChallenge([FromQuery] GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery)
        {
            var result = await _mediator.Send(getSolveWaterJugChallengeQuery);
            return Ok(result);
        }
    }
}
