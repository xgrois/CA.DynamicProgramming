using System;
using System.Diagnostics;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: 0-1 Knapsack problem :::\n\r");

            Console.WriteLine("Problem statement: maximize the value of the knapsack by introducing " +
                "a combination of elements\n\rthat do not exceed maximum knapsack capacity.\n\r");

            //int[] v = new int[] { 20, 5, 10, 40, 15, 25 }; // values of the elements
            //int[] w = new int[] { 1, 2, 3, 8, 7, 4 }; // weight of the elements

            //int Wmax = 10; // knapsack capacity

            //int[] v = new int[] { 20, 5, 10, 40, 15, 25 }; // values of the elements
            //int[] w = new int[] { 1, 2, 3, 8, 7, 4 }; // weight of the elements

            //int Wmax = 25; // knapsack capacity

            int[] v = new int[] { 20, 5, 10, 40, 15, 25, 10, 20, 30, 5, 50, 10, 60, 50, 40, 34, 35, 20, 21, 22, 20, 5, 10, 40, 15, 25, 10, 20, 30, 5 }; // values of the elements
            int[] w = new int[] { 1, 2, 3, 8, 7, 4, 1, 2, 3, 4, 5, 6, 7, 7, 3, 4, 9, 1, 9, 15, 1, 2, 3, 8, 7, 4, 1, 2, 3, 4 }; // weight of the elements

            int Wmax = 50; // knapsack capacity

            Console.WriteLine($"Values  = [{string.Join(", ", v)}].");
            Console.WriteLine($"Weights = [{string.Join(", ", w)}].");
            Console.WriteLine($"Knapsack capacity = {Wmax}.\n\r");

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int r1 = Knap.Recursive(v,w,v.Length,Wmax);
            stopwatch.Stop();

            Console.WriteLine($"Recursive solution ({stopwatch.ElapsedMilliseconds} ms):\tmax value in the knapsack is {r1}.\n\r");

            stopwatch.Restart();
            (int r2, int[,] DP) = Knap.DP(v, w, Wmax);
            stopwatch.Stop();
            Console.WriteLine($"DP solution ({stopwatch.ElapsedMilliseconds} ms):\t\tmax value in the knapsack is {r2}. \n\rDP matrix: \n\r");

            Knap.printMatrix(DP);

        }
    }

    public static class Knap
    {
        internal static int Recursive(int[] v, int[] w, int i, int left)
        {
            if (left < 0) return int.MinValue;

            if (left == 0 || i == 0) return 0;

            int inc = v[i - 1] + Recursive(v, w, i - 1, left - w[i - 1]);
            int exc = Recursive(v, w, i - 1, left);

            return (inc >= exc) ? inc : exc;
        }

        internal static (int, int[,]) DP(int[] v, int[] w, int left)
        {
            int[,] DP = new int[v.Length + 1, left + 1];

            for (int r = 1; r <= v.Length; r++)
            {
                for (int c = 1; c <= left; c++)
                {
                    int inc = (c - w[r - 1] < 0) ? 0 : DP[r - 1, c - w[r - 1]] + v[r - 1];
                    int exc = DP[r - 1, c];
                    DP[r, c] = Math.Max(inc, exc);
                }
            }
            return (DP[v.Length, left], DP);
        }

        public static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void printMatrix(int[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    
                    //string aux = string.Format("{00.0}", matrix[row, col]);
                    Console.Write(matrix[row, col].ToString().PadLeft(4, ' ') );
                }
                Console.WriteLine();
            }
        }

    }
}
