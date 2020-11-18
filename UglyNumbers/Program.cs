using System;
using System.Collections.Generic;

namespace UglyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Ugly numbers :::");
            int n = 10;
            Console.WriteLine($"Ugly({n}) --> {Ugly(n)}");
        }

        static int Ugly(int n)
        {
            int[] u = new int[n];
            u[0] = 1;

            int i2 = 0, i3 = 0, i5 = 0;
            int s = 1;

            while (s < n)
            {
                int m = GetMin(u[i2]*2, u[i3]*3, u[i5]*5 );
                if (m == u[i2] * 2) i2 += 1;
                if (m == u[i3] * 3) i3 += 1;
                if (m == u[i5] * 5) i5 += 1;
                u[s++] = m;
            }

            return u[n - 1];
        }
        
        private static int GetMin(int v1, int v2, int v3)
        {
            int[] vals = new int[3] { v1, v2, v3 };
            double mVal = Double.PositiveInfinity;

            for (int i = 0; i < 3; i++)
            {
                if (vals[i] < mVal)
                {
                    mVal = vals[i];
                }
            }
            return (int)mVal;
        }




    }
}
