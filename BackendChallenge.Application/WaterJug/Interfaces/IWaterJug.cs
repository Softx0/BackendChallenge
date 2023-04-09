using BackendChallenge.Application.WaterJug.Dto;
using BackendChallenge.Application.WaterJug.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.Application.WaterJug.Interfaces
{
    public interface IWaterJug
    {
        Task<WaterJugResponseDto> GetSolveWaterJugChallenge(GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery);
    }
}
