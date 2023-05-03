using BackendChallenge.Application.WaterJug.Dto;
using BackendChallenge.Application.WaterJug.Interfaces;
using BackendChallenge.Application.WaterJug.Queries;
using MediatR;

namespace BackendChallenge.Application.WaterJug.Handler
{
    public class GetSolveWaterJugChallengeQueryHandler : IRequestHandler<GetSolveWaterJugChallengeQuery, List<WaterJugResponseDto>>
    {
        private readonly IWaterJug waterJugService;
        public GetSolveWaterJugChallengeQueryHandler(IWaterJug waterJugService)
        {
            this.waterJugService = waterJugService;
        }

        public Task<List<WaterJugResponseDto>> Handle(GetSolveWaterJugChallengeQuery request, CancellationToken cancellationToken)
        {

            if ((request.BucketX > request.BucketZ) && (request.BucketY > request.BucketZ))
                throw new ArgumentException("No Solution");


            var result = waterJugService.GetSolveWaterJugChallenge(request);
            return result;
        }
    }
}
