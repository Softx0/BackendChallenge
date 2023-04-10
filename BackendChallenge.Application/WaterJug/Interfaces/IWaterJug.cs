using BackendChallenge.Application.WaterJug.Dto;
using BackendChallenge.Application.WaterJug.Queries;

namespace BackendChallenge.Application.WaterJug.Interfaces
{
    public interface IWaterJug
    {
        Task<WaterJugResponseDto> GetSolveWaterJugChallenge(GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery);
    }
}
