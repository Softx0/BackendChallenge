using BackendChallenge.Application.WaterJug.Dto;
using BackendChallenge.Application.WaterJug.Interfaces;
using BackendChallenge.Application.WaterJug.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.Infraestructure.Services
{
    public class WaterJugService : IWaterJug
    {


        public static WaterJugResponseDto GetResiduo(GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery)
        {
            int cociente = Math.DivRem(getSolveWaterJugChallengeQuery.BucketX, getSolveWaterJugChallengeQuery.BucketY, out int residuo);

            WaterJugResponseDto result = new()
            {
                BucketX = cociente,
                BucketY = residuo
            };

            return result;
        }

        public async Task<WaterJugResponseDto> GetSolveWaterJugChallenge(GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery)
        {
            return await Task.FromResult(GetResiduo(getSolveWaterJugChallengeQuery));
        }
    }
}
