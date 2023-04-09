using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.Application.WaterJug.Dto
{
    public class WaterJugResponseDto
    {
        public string Explanation { get; set; } = null!;
        public int BucketX { get; set; }
        public int BucketY { get; set; }
    }
}
