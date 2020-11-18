using System;
using System.Numerics;

namespace CatalanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Catalan numbers :::");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Catalan({i}) --> {CatalanRecursive(i)}");
            }
            
        }

        /// <summary>
        /// Nth catalan number using top-down recursion
        /// Complexity: exponential (tree recursion)
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static BigInteger CatalanRecursive(int n)
        {
            if (n == 0 || n == 1) return 1;

            BigInteger x = 0;
            for (int i = 0; i < n; i++)
            {
                x = x + CatalanRecursive(i) * CatalanRecursive(n - 1 - i);
            }
            return x;
        }

        /// <summary>
        /// Nth catalan number using bottom up Dynamic Programming
        /// O(n x n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static BigInteger CatalanDynamicProgramming(int n)
        {
            BigInteger[] c = new BigInteger[n+1];

            c[0] = 1;

            for (int k = 1; k <= n; k++)
            {
                for (int i = 0; i <= k-1; i++)
                {
                    c[k] += c[i] * c[k - 1 - i];
                }
            }
            return c[n];

        }

    }
}
