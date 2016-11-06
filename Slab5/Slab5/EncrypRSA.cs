using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Slab5
{
    static class EncrypRSA
    {
        public static int findSimpl(Random rand, int min = 0, int max = 100)
        {
            int res = rand.Next(min, max);
            for (int i = 2; i < res; i++)
                if (res % i == 0) { res++; i = 2; }


            return res;            
        }

        public static BigInteger findprKey(BigInteger E)
        {
            BigInteger res = 4;
            for (;;)
            {
                if (BigInteger.GreatestCommonDivisor(res, E) == 1) break;
                else res++;
            }

            return res;
        }

        public static BigInteger findpubKey(BigInteger pr, BigInteger E)
        {
            BigInteger res = 3;
            for (res = 3; ; res++)
                if ((res * pr) % E == 1) break;

            return res;
        }
    }
}
