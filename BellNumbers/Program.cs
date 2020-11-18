using System;
using System.Collections.Generic;
using System.Numerics;

namespace BellNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Bell numbers :::");

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"Bell({i}) --> {BellStirling(i)}");
            }


        }

        /// <summary>
        /// Bell number using bottom-up Dynamic Programming.
        /// It is based on the recurrence relation using Stirling numbers
        /// B(n) = sum_{k = 0}^{n} S(n,k)
        /// </summary>
        /// <param name="n">nth number in Bell sequence</param>
        /// <returns></returns>
        static BigInteger BellStirling(int n)
        {
            List<BigInteger> prevRow = new List<BigInteger>();
            List<BigInteger> currRow = new List<BigInteger>();

            // Progressively compute Stirling rows
            // Only two lists are needed (prev row, current row)
            // Update them as progression is neeeded
            int k = 0;
            BigInteger Snk = 0;
            prevRow.Add(0); prevRow.Add(1);
            for (int i = 2; i <= n; i++)
            {
                currRow.Add(0);
                for (k = 1; k < i; k++)
                {
                    Snk = prevRow[k - 1] + k * prevRow[k];
                    currRow.Add(Snk);
                    prevRow[k - 1] = currRow[k - 1]; // overrite values that won't be needed
                }
                currRow.Add(1);

                // Terminate to copy prevRow <-- currRow
                // Note that it is easier to read this code
                // if I just copy all values in a loop
                // However I overrite all values I can during
                // previous loop so now I only need to copy last values
                prevRow[k - 1] = currRow[k - 1];
                prevRow.Add(1);

                // Now that prevRow has currentRow values
                // Clean currRow for next level
                currRow.Clear();
            }

            // B(n) = sum_{k = 0}^{n} S(n,k)
            BigInteger b = 0;
            foreach (var s in prevRow)
                b += s;

            return b;
        }

        /// <summary>
        /// Bell number using bottom-up Dynamic Programming.
        /// It is based on the recurrence relation using Bell triangle
        /// </summary>
        /// <param name="n">nth number in Bell sequence</param>
        /// <returns></returns>
        static BigInteger BellAitken(int n)
        {

            List<BigInteger> prevRow = new List<BigInteger>();
            List<BigInteger> currRow = new List<BigInteger>();

            prevRow.Add(1);
            int last = 0;
            for (int i = 2; i <= n; i++)
            {
                currRow.Add(prevRow[last++]);
                for (int j = 1; j <= i - 1; j++)
                    currRow.Add(prevRow[j - 1] + currRow[j - 1]);

                prevRow.Add(0);
                for (int k = 0; k < i; k++)
                    prevRow[k] = currRow[k];

                currRow.Clear();

            }
            return prevRow[last];
        }
    }

}
