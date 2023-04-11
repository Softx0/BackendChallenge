using BackendChallenge.Domain.Entities;

namespace BackendChallenge.Application.WaterJug.Dto
{
    public class WaterJugResponseDto
    {
        public string Explanation { get; set; } = null!;
        public Jug? BucketLarger { get; set; } = new Jug();
        public Jug? BucketSmaller { get; set; } = new Jug();
    }
}
