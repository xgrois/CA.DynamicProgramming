using System;

namespace PartitionSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Partition problem :::\n\r");
            Console.WriteLine("Problem statement: Given a set of positive integers, " +
                "find if it can be divided into two subsets with equal sum.\n\r");

            //int[] input = new int[] { 2, 2, 4, 2, 8, 6, 4, 2, 8 };
            //int[] input = new int[] { 2, 2, 4 };
            int[] input = new int[] { 2, 2, 4, 2 };
            Console.WriteLine($"Input: [{string.Join(", ",input)}]\n\r");

            Console.WriteLine($"Solution (recursive):{Partition.FindPartition(input)}");
            Console.WriteLine();

            (bool r1, bool[,] DP1) = Partition.FindDP(input);
            Console.WriteLine($"Solution (dp):       {r1}");
            Partition.Print(DP1); Console.WriteLine();

            (bool r2, bool[,] DP2) = Partition.FindDPOptimized(input);
            Console.WriteLine($"Solution (dp-opt):   {r2}");
            Partition.Print(DP2);
        }
    }

    public static class Partition
    {
        public static bool FindPartition(int[] v)
        {
            int sum = 0;
            for (int i = 0; i < v.Length; i++)
            {
                sum += v[i];
            }

            if (!isOdd(sum))
            {
                return false;
            }
            else
            {
                int acc = 0;
                int target = sum / 2;
                return FindPartition(v, v.Length - 1, acc, sum, target);
            }
            
        }
        public static bool FindPartition(int[] v, int i, int acc, int sum, int target)
        {
            if (acc > target) return false;
            if (i == -1) return (acc == target);

            // Include
            bool inc = FindPartition(v, i - 1, acc + v[i], sum, target);
            // Exclude
            bool exc = FindPartition(v, i - 1, acc, sum, target);

            return (inc || exc);
        }

        private static bool isOdd(int num)
        {
            return (num % 2 == 0);
        }


        public static (bool, bool[,]) FindDP(int[] v)
        {

            int vL = v.Length;
            int sum = 0;
            for (int i = 0; i < vL; i++)
                sum += v[i];

            if (!isOdd(sum)) return (false, new bool[0, 0]);

            bool[,] DP = new bool[vL + 1, sum + 1];
            for (int c = 0; c <= sum; c++)
                DP[0, c] = false;

            DP[0, sum/2] = true;

            for (int i = 1; i <= vL; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    DP[i, j] = ((j + v[i-1]) > sum) ? false : DP[i - 1, j + v[i - 1]] || DP[i - 1, j];
                }
            }

            return (DP[vL, 0], DP);
        }

        public static (bool, bool[,]) FindDPOptimized(int[] v)
        {

            int vL = v.Length;
            int sum = 0;
            for (int i = 0; i < vL; i++)
                sum += v[i];

            if (!isOdd(sum)) return (false, new bool[0,0]);

            int target = sum / 2;
            bool[,] DP = new bool[vL + 1, target + 1];
            for (int c = 0; c <= target; c++)
                DP[0, c] = false;

            DP[0, target] = true;

            for (int i = 1; i <= vL; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    bool t1 = ((j + v[i - 1]) > target) ? false : DP[i - 1, j + v[i - 1]];
                    bool t2 = DP[i - 1, j];
                    DP[i, j] = t1 || t2;
                }
            }

            return (DP[vL, 0], DP);
        }

        public static void Print(bool[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{((matrix[i,j]) ? "1" : "0")} ");
                }
                Console.WriteLine();
            }
        }

    }
}
