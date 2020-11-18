using System;

namespace FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Fibonacci numbers :::");
            int n = 9;
            Console.WriteLine($"Fibonacci({n}) --> {Fibonacci(n)}");
        }

        static int Fibonacci(int n)
        {
            if (n < 0) return -1;

            int[] f = new int[n + 1];
            f[0] = 0;

            if (n >= 1) f[1] = 1;

            if (n >= 2)
            {
                int i = 0, j = 1;
                for (int k = 2; k <= n; k++)
                {
                    f[k] = f[i++] + f[j++];
                }

            }

            return f[n];
        }
    }
}
