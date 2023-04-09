using BackendChallenge.Application.WaterJug.Dto;
using BackendChallenge.Application.WaterJug.Interfaces;
using BackendChallenge.Application.WaterJug.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.Application.WaterJug.Handler
{
    public class GetSolveWaterJugChallengeQueryHandler : IRequestHandler<GetSolveWaterJugChallengeQuery, WaterJugResponseDto>
    {
        private readonly IWaterJug waterJugService;
        public GetSolveWaterJugChallengeQueryHandler(IWaterJug waterJugService)
        {
            this.waterJugService = waterJugService;
        }

        public async Task<WaterJugResponseDto> Handle(GetSolveWaterJugChallengeQuery request, CancellationToken cancellationToken)
        {
            var result = await waterJugService.GetSolveWaterJugChallenge(request);
            return result;
        }
    }
}
