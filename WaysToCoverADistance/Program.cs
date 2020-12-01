using System;
using System.Diagnostics;

namespace WaysToCoverADistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Counting the number of ways to cover a distance :::");
            Console.WriteLine("::: (Using steps of 1, 2 and 3)                     :::\n\r");

            int n = 30;

            Stopwatch watch = new Stopwatch();
            watch.Start();
            int r1 = CountOfRecursive(n);
            Console.WriteLine($"CountOfRecursive({n}) = {r1}. Elapsed time (ms): {watch.ElapsedMilliseconds}");
            watch.Stop();

            watch.Restart();
            int r2 = CountOfDP(n);
            watch.Stop();
            Console.WriteLine($"CountOfDP({n})        = {r2}. Elapsed time (ms): {watch.ElapsedMilliseconds}");

        }

        static int CountOfRecursive(int n)
        {

            if (n == 0 || n == 1) return 1;
            if (n == 2) return 2;

            return (CountOfRecursive(n - 1) + CountOfRecursive(n - 2) + CountOfRecursive(n - 3));
        }

        static int CountOfDP(int n)
        {
            int result = 0;

            if (n == 0 || n == 1) result = 1;
            if (n == 2) result = 2;

            int f0 = 1, f1 = 1, f2 = 2;
            for (int i = 3; i <= n; i++)
            {
                result = f0 + f1 + f2;
                f0 = f1;
                f1 = f2;
                f2 = result;
            }

            return result;
        }

    }
}
