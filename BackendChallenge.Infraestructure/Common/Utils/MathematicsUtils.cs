using BackendChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.Infraestructure.Common.Utils
{
    public class MathematicsUtils
    {
        public static int MCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return MCD(b, a % b);
            }
        }

        public static bool GetEvenOrOddOfMCD(Jug jugLarge, Jug jugSmall)
        {
            return MCD(jugLarge.Value, jugSmall.Value) % 2 == 0;
        }
    }
}
