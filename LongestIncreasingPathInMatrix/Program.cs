using System;

namespace LongestIncreasingPathInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Longest increasing path in a matrix :::\n\r");

            //int[][] matrix = null;
            //int[][] matrix = new int[0][];
            //int[][] matrix = new int[2][];

            //int[][] matrix = new int[1][] { new int[] { } };

            //int[][] matrix = new int[1][] { new int[] { 3 } };

            //int[][] matrix = new int[1][] { new int[] { 3, 2, 1, 3, 4, 5 } };

            //int[][] matrix = new int[3][] { new int[] { 3 }, new int[] { 5 }, new int[] { 1 } };

            //int[][] matrix = new int[][] { new int[] { 9, 9, 4 }, new int[] { 6, 6, 8 }, new int[] { 2, 1, 1 } };
            //int[][] matrix = new int[][] { new int[] { 3, 4, 5 }, new int[] { 3, 2, 6 }, new int[] { 2, 2, 1 } };

            //int[][] matrix = new int[][] {
            //    new int[] { 12, 13, 14, 15 },
            //    new int[] { 9, 9, 4, 3 },
            //    new int[] { 6, 6, 8, 2 },
            //    new int[] { 2, 1, 1, 1 } };

            int[][] matrix = new int[][] {
                new int[] { 12, 13, 14, 15 },
                new int[] { 9, 10, 9, 3 },
                new int[] { 6, 7, 8, 2 },
                new int[] { 2, 1, 1, 1 } };

            Console.WriteLine($"Result = {Longest(matrix)}");

        }

        private static bool IsAtLeast1x1Matrix(int[][] matrix)
        {
            if (matrix != null)
                if (matrix.Length >= 1)
                    if (matrix[0] != null)
                        if (matrix[0].Length >= 1)
                            return true;
            return false;
        }

        private static int Longest(int[][] matrix)
        {

            if (!IsAtLeast1x1Matrix(matrix)) return 0;

            // Matrix is 1x1 or greater

            int max = 1;
            int N = matrix.Length;
            int M = matrix[0].Length;

            int[][] dp = new int[N][];
            for (int r = 0; r < N; r++)
            {
                dp[r] = new int[M];

                for (int c = 0; c < M; c++)
                {
                    dp[r][c] = 1;
                }
            }


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    ProcessCell(i, j, matrix, dp, 1, ref max);
                }
            }

            PrintMatrix(dp);

            return max;
        }

        private static void ProcessCell(int i, int j, int[][] matrix, int[][] dp, int count, ref int max)
        {
            int N = matrix.Length;
            int M = matrix[0].Length;

            // Process Left
            if (isSafe(i, j - 1, N, M))
            {
                // Process only if we improve the results
                if ((matrix[i][j - 1] < matrix[i][j]) && (count + 1 > dp[i][j - 1]))
                {
                    dp[i][j - 1] = count + 1;
                    if (count + 1 > max) max = count + 1;
                    ProcessCell(i, j - 1, matrix, dp, count + 1, ref max);
                }

            }
            // Process Up
            if (isSafe(i - 1, j, N, M))
            {
                // Process only if we improve the results
                if ((matrix[i - 1][j] < matrix[i][j]) && (count + 1 > dp[i - 1][j]))
                {
                    dp[i - 1][j] = count + 1;
                    if (count + 1 > max) max = count + 1;
                    ProcessCell(i - 1, j, matrix, dp, count + 1, ref max);
                }

            }
            // Process Right
            if (isSafe(i, j + 1, N, M))
            {
                // Process only if we improve the results
                if ((matrix[i][j + 1] < matrix[i][j]) && (count + 1 > dp[i][j + 1]))
                {
                    dp[i][j + 1] = count + 1;
                    if (count + 1 > max) max = count + 1;
                    ProcessCell(i, j + 1, matrix, dp, count + 1, ref max);
                }

            }
            // Process Down
            if (isSafe(i + 1, j, N, M))
            {
                // Process only if we improve the results
                if ((matrix[i + 1][j] < matrix[i][j]) && (count + 1 > dp[i + 1][j]))
                {
                    dp[i + 1][j] = count + 1;
                    if (count + 1 > max) max = count + 1;
                    ProcessCell(i + 1, j, matrix, dp, count + 1, ref max);
                }

            }
        }

        private static bool isSafe(int i, int j, int N, int M)
        {
            // 0 <= i < N
            // 0 <= j < M
            return (0 <= i) && (i < N) && (0 <= j) && (j < M);
        }

        static void PrintMatrix(int[][] matrix)
        {
            if (!IsAtLeast1x1Matrix(matrix)) { Console.WriteLine("[]"); return; }

            int N = matrix.Length;
            int M = matrix[0].Length;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }

    }
}
