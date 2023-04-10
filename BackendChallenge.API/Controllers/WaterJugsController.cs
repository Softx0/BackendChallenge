using BackendChallenge.Application.WaterJug.Dto;
using BackendChallenge.Application.WaterJug.Queries;
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
        [ProducesResponseType(typeof(WaterJugResponseDto), Constants.StatusCode.Status200OK)]
        [ProducesResponseType(Constants.StatusCode.Status400BadRequest)]
        public async Task<IActionResult> GetSolveWaterJugChallenge([FromQuery] GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery)
        {
            var result = await _mediator.Send(getSolveWaterJugChallengeQuery);
            return Ok(result);
        }
    }
}
