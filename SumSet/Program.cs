using System;

namespace SumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Sum set problem :::");

            int sum = 3;
            int[] set = new int[] { 3, 7};
            if (Solution.Solve(set, sum))
                Console.WriteLine($"YES");
            else Console.WriteLine($"NO");
        }
    }


    class Solution
    {
        // F(i,z) = F(i-1, z - set[i - 1]) OR F(i-1, z)
        internal static bool Solve(int[] set, int sum)
        {
            bool[,] F = new bool[set.Length + 1, sum + 1];
            for (int i = 0; i < set.Length + 1; i++)
            {
                F[i, 0] = true;
            }
            

            bool a = false;
            for (int i = 1; i <= set.Length; i++)
            {
                for (int z = 0; z <= sum; z++)
                {
                    if ((z - set[i - 1]) < 0) a = false;
                    else a = F[i - 1, z - set[i - 1]];

                    F[i, z] = a || F[i - 1, z];
                }
            }
            return F[set.Length, sum];
        }

        internal static bool SolveRecursive(int[] set, int sum)
        {
            return SolveRecursive(set, set.Length, sum);
        }

        private static bool SolveRecursive(int[] set, int i, int z)
        {
            if (z < 0) return false;
            if (z == 0) return true;
            if (i == 0) return false;

            return SolveRecursive(set, i - 1, z - set[i - 1]) || SolveRecursive(set, i - 1, z);
        }

    }

}
