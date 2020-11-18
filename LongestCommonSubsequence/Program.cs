using System;
using System.Collections.Generic;
using System.Linq;

namespace CA.DP.LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Longest common subsequence(s) :::\n\r");

            //string seq1 = "";
            //string seq2 = "";
            //string seq1 = "bd";
            //string seq2 = "abcd";
            //string seq1 = "longest";
            //string seq2 = "nomg";
            //string seq1 = "abcdefghij";
            //string seq2 = "cdgi";
            //string seq1 = "abdace";
            //string seq2 = "babce";
            string seq1 = "ABCBDAB";
            string seq2 = "BDCABA";
            //string seq1 = "ABCBDAB";
            //string seq2 = "BRACADABRA";
            //string seq1 = "chiguanchunorpres";
            //string seq2 = "chichiguaguaporres";
            //string seq1 = "chiguanchunorpr";
            //string seq2 = "chichiguaguapo";
            //string seq1 = "poiuqwerlkjhasdf";
            //string seq2 = "lkjhasdfpoiuqwer";
            //string seq1 = "iojdsiojfac";
            //string seq2 = "vreipvegfhraos";
            //string seq1 = "ikokd";
            //string seq2 = "vid8iov";
            Console.WriteLine(seq1 + ", " + seq2 + "\n\r");

            char[] s1 = seq1.ToCharArray();
            char[] s2 = seq2.ToCharArray();

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            int n1 = LCSLengthRecursive(s1, 0, s2, 0);
            watch.Stop();
            Console.WriteLine("LCS length using a recursive function (top down):");
            Console.WriteLine($"LCS length: {n1}. Elapsed time: {watch.ElapsedMilliseconds} ms\n\r");

            watch.Restart();
            int n2 = LCSLengthRecursiveMemoization(s1, 0, s2, 0, new Dictionary<string, int>());
            watch.Stop();
            Console.WriteLine("LCS length using a recursive function with memoization (top down):");
            Console.WriteLine($"LCS length: {n2}. Elapsed time: {watch.ElapsedMilliseconds} ms\n\r");

            watch.Restart();
            int[,] X = new int[s1.Length + 1, s2.Length + 1];
            int n3 = LCSLengthDynamicProgramming(s1, s2, X);
            watch.Stop();
            Console.WriteLine("LCS length using dynamic programming (bottom up):");
            Console.WriteLine($"LCS length: {n3}. Elapsed time: {watch.ElapsedMilliseconds} ms\n\r");

            watch.Restart();
            X = new int[s1.Length + 1, s2.Length + 1];
            List<Stack<char>> seqs = LCSSequencesDynamicProgramming(s1, s2, X);
            watch.Stop();
            Console.WriteLine("LCS length and sequence(s) using dynamic programming (bottom up):");
            Console.WriteLine($"LCS length: {n3}. Elapsed time: {watch.ElapsedMilliseconds} ms. Sequence(s):");
            PrintSequences(seqs);
            Console.WriteLine("\n\rDP matrix:");
            PrintDPTable(X, seq1, seq2);

        }

        static int LCSLengthRecursive(char[] seq1, int i, char[] seq2, int j)
        {
            if ((i == seq1.Length) || (j == seq2.Length))
                return 0;

            if (seq1[i] == seq2[j])
                return 1 + LCSLengthRecursive(seq1, i+1, seq2, j+1);
            else
                return Math.Max(LCSLengthRecursive(seq1, i+1, seq2, j), LCSLengthRecursive(seq1, i, seq2, j+1));
        }

        static int LCSLengthRecursiveMemoization(char[] seq1, int i, char[] seq2, int j, Dictionary<string,int> dict)
        {
            if ((i == seq1.Length) || (j == seq2.Length))
            {
                return 0;
            }

            int x = 0, y = 0;
            if (seq1[i] == seq2[j])
            {
                if (dict.ContainsKey($"{i+1},{j+1}"))
                    x = dict[$"{i+1},{j+1}"];
                else
                {
                    x = LCSLengthRecursiveMemoization(seq1, i + 1, seq2, j + 1, dict);
                    dict[$"{i+1},{j+1}"] = x;
                }
                    
                return 1 + x;
            }
            else
            {
                if (dict.ContainsKey($"{i+1},{j}"))
                    x = dict[$"{i+1},{j}"];
                else
                {
                    x = LCSLengthRecursiveMemoization(seq1, i + 1, seq2, j, dict);
                    dict[$"{i+1},{j}"] = x;
                }
                if (dict.ContainsKey($"{i},{j+1}"))
                    y = dict[$"{i},{j+1}"];
                else
                {
                    y = LCSLengthRecursiveMemoization(seq1, i, seq2, j+1, dict);
                    dict[$"{i},{j+1}"] = y;
                }
                return Math.Max(x, y);
            }
                
        }

        static int LCSLengthDynamicProgramming(char[] seq1, char[] seq2, int[,] X)
        {

            for (int i = 0; i < seq1.Length; i++)
            {
                for (int j = 0; j < seq2.Length; j++)
                {
                    if (seq1[i] == seq2[j])
                        X[i + 1, j + 1] = X[i, j] + 1;
                    else
                        X[i + 1, j + 1] = Math.Max(X[i + 1, j], X[i, j + 1]);
                }
            }

            return X[seq1.Length, seq2.Length];
        }

        static List<Stack<char>> LCSSequencesDynamicProgramming(char[] seq1, char[] seq2, int[,] X)
        {
            // Compute X DP matrix
            int LCSLength = LCSLengthDynamicProgramming(seq1, seq2, X);

            // Once X is computed, you can get all LCS subsequences
            int r = seq1.Length;
            int c = seq2.Length;
            List<Stack<char>> seqs = new List<Stack<char>>();

            seqs.Add(new Stack<char>());

            GenerateAllSubsequences(X, r, c, seq1, seq2, seqs, 0);

            return seqs;
            
        }

        static void GenerateAllSubsequences(int[,] X, int r, int c, char[] seq1, char[] seq2, List<Stack<char>> seqs, int path)
        {

            if ((c == 0 || r == 0))
                return;
            
            if (seq1[r - 1] == seq2[c - 1])
            {
                // Add letter to current subsequence
                // Subsequence "id" is "path"
                seqs[path].Push(seq1[r - 1]);

                // Move diagonal
                GenerateAllSubsequences(X, r - 1, c - 1, seq1, seq2, seqs, path);
            }
            else
            {
                // Only allowed to Move Up 
                if ((X[r - 1, c] == X[r, c]) && (X[r, c - 1] < X[r, c]))
                    GenerateAllSubsequences(X, r - 1, c, seq1, seq2, seqs, path);
                
                // Only allowed to Move Left
                else if ((X[r, c - 1] == X[r, c]) && (X[r - 1, c] < X[r, c]))
                    GenerateAllSubsequences(X, r, c - 1, seq1, seq2, seqs, path);
                
                else
                {
                    int num = seqs[path].Count;
                    // Either Left or Up

                    // Continue with current path (Up)
                    GenerateAllSubsequences(X, r - 1, c, seq1, seq2, seqs, path);

                    // Create a new branch from current path (Left)
                    // Copy all elements at this point (num) in parent "path" to new path
                    seqs.Add(new Stack<char>()); // create a new stack

                    for (int i = 0; i < num; i++)
                        seqs[seqs.Count - 1].Push(seqs[path].ElementAt(seqs[path].Count - 1 - i));
                    
                    GenerateAllSubsequences(X, r, c - 1, seq1, seq2, seqs, seqs.Count - 1);
                }
            }


        }

        static void PrintDPTable(int[,] X, string seq1, string seq2)
        {
            int N = X.GetLength(0);
            int M = X.GetLength(1);

            Console.Write("\0 ");
            Console.Write("\0 ");
            for (int i = 0; i < seq2.Length; i++)
                Console.Write($"{seq2[i]} ");
            
            Console.Write("\n\r");

            Console.Write("\0 ");
            for (int i = 0; i < N; i++)
            {
                if (i > 0) Console.Write($"{seq1[i-1]} ");
                for (int j = 0; j < M; j++)
                    Console.Write($"{X[i, j]} ");

                Console.WriteLine();
            }
        }

        static void PrintSequences(List<Stack<char>> seqs)
        {
            foreach (var stk in seqs)
            {
                foreach (var letter in stk)
                    Console.Write(letter);
                
                Console.WriteLine();
            }
        }

    }
}
