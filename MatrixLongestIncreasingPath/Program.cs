using System;

namespace MatrixLongestIncreasingPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Longest +1 increasing path in an NxN matrix :::\n\r");

            Console.WriteLine("Problem statement: Given an NxN matrix with all entries different," +
                "\n\rcalculate the longest path where a path is defined as a strictly + 1 increasing sequence.\n\r");

            Console.WriteLine("NOTE: Our particular solution can also solve rectangular (NxM) matrices.\n\r");

            //int[,] matrix = new int[3, 3] { { 3, 7, 1 }, { 8, 6, 2 }, { 4, 5, 9 } };
            //int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrix = new int[4, 5] {
                { 60, 10, 40, 50, 20 },
                { 59, 11, 39, 15, 16 },
                { 58, 12, 13, 14, 17 },
                { 57, 56,  1,  2, 18 } };

            //int[,] matrix = new int[3, 1] { { 3 }, { 2 }, { 1 } };

            Console.WriteLine($"Result = {Longest(matrix)}");

        }

        private static int Longest(int[,] matrix)
        {
            int max = 0;
            int N = matrix.GetLength(0);
            int M = matrix.GetLength(1);
            int[,] dp = new int[N, M];
            for (int r = 0; r < N; r++)
            {
                max = 1;
                for (int c = 0; c < M; c++)
                {
                    dp[r, c] = 1;
                }
            }
            

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    SetCurrent(i, j, matrix, dp, 1, ref max);
                }
            }

            PrintMatrix(dp);

            return max;
        }

        private static void SetCurrent(int i, int j, int[,] matrix, int[,] dp, int count, ref int max)
        {
            int num = matrix[i, j];

            if (count + 1 > dp[i, j])
            {
                if (IsNeighSmaller(num, i, j - 1, matrix, dp))
                {
                    dp[i, j - 1] = count + 1;
                    if (count + 1 > max) max = count + 1;
                    SetCurrent(i, j - 1, matrix, dp, count + 1, ref max);
                }
                else if (IsNeighSmaller(num, i - 1, j, matrix, dp))
                {
                    dp[i - 1, j] = count + 1;
                    if (count + 1 > max) max = count + 1;
                    SetCurrent(i - 1, j, matrix, dp, count + 1, ref max);
                }
                else if (IsNeighSmaller(num, i, j + 1, matrix, dp))
                {
                    dp[i, j + 1] = count + 1;
                    if (count + 1 > max) max = count + 1;
                    SetCurrent(i, j + 1, matrix, dp, count + 1, ref max);
                }
                else if (IsNeighSmaller(num, i + 1, j, matrix, dp))
                {
                    dp[i + 1, j] = count + 1;
                    if (count + 1 > max) max = count + 1;
                    SetCurrent(i + 1, j, matrix, dp, count + 1, ref max);
                }

            }

        }

        private static bool IsNeighSmaller(int num, int neigh_i, int neigh_j, int[,] matrix, int[,] dp)
        {
            int N = matrix.GetLength(0);
            int M = matrix.GetLength(1);

            if (((neigh_i < 0) || (neigh_i >= N)) || ((neigh_j < 0) || (neigh_j >= M))) // out of bounds
                return false;

            if (matrix[neigh_i, neigh_j] + 1 == num) return true;
            else return false;

        }

        static void PrintMatrix(int[,] matrix)
        {
            int N = matrix.GetLength(0);
            int M = matrix.GetLength(1);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
