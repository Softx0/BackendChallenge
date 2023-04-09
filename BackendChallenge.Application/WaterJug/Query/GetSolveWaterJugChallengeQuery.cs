using BackendChallenge.Application.WaterJug.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.Application.WaterJug.Query
{
    public class GetSolveWaterJugChallengeQuery : IRequest<WaterJugResponseDto>
    {
        public int BucketX { get; set; }
        public int BucketY { get; set; }
        public int BucketZ { get; set; }
    }
}
