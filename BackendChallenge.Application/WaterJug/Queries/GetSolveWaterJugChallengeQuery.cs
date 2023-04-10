using BackendChallenge.Application.WaterJug.Dto;
using MediatR;

namespace BackendChallenge.Application.WaterJug.Queries
{
    public class GetSolveWaterJugChallengeQuery : IRequest<WaterJugResponseDto>
    {
        public int BucketX { get; set; }
        public int BucketY { get; set; }
        public int BucketZ { get; set; }
    }
}
