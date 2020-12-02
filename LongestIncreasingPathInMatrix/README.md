## Matrix longest increasing path problem

__Problem statement__

Given an integer matrix, find the length of the longest increasing path.

From each cell, you can either move to four directions: left, right, up or down.
You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).

__Difficulty in literature__

This problem is considered Hard in literature.

__Runtime Complexity__

* DP version (tabular): polynomial

__Space Complexity__

* DP version (tabular): we just need the input matrix and another matrix of the same size (dp).

__References__

[[1]](https://leetcode.com/problems/longest-increasing-path-in-a-matrix/) Find the longest path in a matrix, LeetCode.

## Notes

In this problem any cell may generate a tree of possible paths.
Processing all in that sense could be considered the exponential-recursive solution.

The idea is to avoid re-processing as possible (dynamic programming).
My solution will only re-process a path if we are increasing the lenght of it.

The idea is illustrated here:

![Alt text](/LongestIncreasingPathInMatrix/example01.JPG?raw=true "Example01")

![Alt text](/LongestIncreasingPathInMatrix/example02.JPG?raw=true "Example02")

and so on...

This idea is reflected in code as follows:

```c#
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
            ...
            // Process Right
            ...
            // Process Down
```

## LeetCode results

My code has been tested against LeetCode database and below are the results:

![Alt text](/LongestIncreasingPathInMatrix/letcode_result.JPG?raw=true "LeetCode")
