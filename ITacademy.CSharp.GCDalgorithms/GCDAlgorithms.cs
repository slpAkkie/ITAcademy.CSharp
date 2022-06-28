using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ITacademy.CSharp.GCDAlgorithms
{
    public static class GCDAlgorithms
    {
        /// <summary>
        /// Find the GCD for 2 numbers with Euclid method
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int FindGCDEuclid(int a, int b)
        {
            if (a == 0) return b;

            while (b > 0)
            {
                if (a > b) a -= b;
                else b -= a;
            }

            return a;
        }
    }
}
