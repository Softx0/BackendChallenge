using BackendChallenge.Domain.Entities;

namespace BackendChallenge.Application.WaterJug.Dto
{
    public class WaterJugResponseDto
    {
        public string Explanation { get; set; } = null!;
        public Jug BucketOne { get; set; } = new Jug();
        public Jug BucketTwo { get; set; } = new Jug();
    }
}
