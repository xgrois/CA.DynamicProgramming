using System;
using System.Collections.Generic;

namespace LongestIncreasingSubsequence
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("::: Longest Increasing Subsequence :::");

            int[] v = new int[] { 10, 9, 2, 5, 3, 7, 101, 18  };
            Console.WriteLine($"LISLength([{string.Join(", ", v)}]) --> {ClassLIS.LISLengthDP(v)}");

            Console.WriteLine($"LIS([{string.Join(", ", v)}]) --> [{string.Join(", ", ClassLIS.LISDP(v))}]");

        }

    }

    public static class ClassLIS
    {
        #region Recursive solution (forward) (Only length of LIS)
        public static int LISLengthRecursive(int[] v)
        {
            return LISLengthRecursive(v, 0, int.MinValue);
        }
        public static int LISLengthRecursive(int[] v, int b, int prev)
        {
            if (b == v.Length) return 0;

            int include = ((v[b] > prev) ? 1 : 0) + LISLengthRecursive(v, b + 1, ((v[b] > prev) ? v[b] : prev));

            int exclude = LISLengthRecursive(v, b + 1, prev);

            return (include > exclude) ? include : exclude;
        }

        #endregion

        #region Recursive solution (backwards) (Only length of LIS)
        public static int LISLengthRecursiveBackwards(int[] v)
        {
            if (v.Length == 0) return 0;

            int maxL = LISLengthRecursiveBackwards(v, 0, v.Length - 1, int.MaxValue);

            return maxL;
        }
        private static int LISLengthRecursiveBackwards(int[] v, int b, int f, int prev)
        {
            if (b == f) return (v[f] < prev) ? 1 : 0;

            int include = ((v[f] < prev) ? 1 : 0) 
                + LISLengthRecursiveBackwards(v, b, f - 1, ((v[f] < prev) ? v[f] : prev));

            int exclude = 0 + LISLengthRecursiveBackwards(v, b, f - 1, prev);


            return (include > exclude) ? include : exclude;
        }
        #endregion

        #region Iterative-Recursive (IR) solution (length and sequence)
        public static int LISLengthIR(int[] v)
        {
            int Lmax = 0;

            for (int i = 0; i < v.Length; i++)
                ExploreLength(v, i, 0, ref Lmax);

            return Lmax;

        }

        private static void ExploreLength(int[] v, int pos, int L, ref int Lmax)
        {
            L += 1;
            if (Lmax < L) Lmax = L;
            for (int k = pos + 1; k < v.Length; k++)
                if (v[pos] < v[k]) ExploreLength(v, k, L, ref Lmax);

        }


        public static List<int> LISIR(int[] v)
        {
            int Lmax = 0;
            List<int> seqMax = new List<int>();
            for (int i = 0; i < v.Length; i++)
            {
                var seq = new List<int>();
                ExploreLengthAndSequence(v, i, 0, ref Lmax, seq, seqMax);
            }


            return seqMax;

        }

        private static void ExploreLengthAndSequence(int[] v, int pos, int L, ref int Lmax, List<int> seq, List<int> seqMax)
        {
            seq.Add(v[pos]);
            L += 1;
            if (Lmax < L)
            {
                Lmax = L;
                seqMax.Clear();
                foreach (var item in seq)
                {
                    seqMax.Add(item);
                }
            }
            for (int k = pos + 1; k < v.Length; k++)
            {
                if (v[pos] < v[k])
                {
                    ExploreLengthAndSequence(v, k, L, ref Lmax, seq, seqMax);
                    seq.RemoveAt(L);
                }
            }

        }

        #endregion

        #region Dynamic Programming solution (bottom-up) (length and sequence)
        public static int LISLengthDP(int[] v)
        {
            int L = v.Length;
            if (L == 0) return 0;

            int[] c = new int[L];
            for (int i = 0; i < L; i++)
            {
                c[i] = 1;
            }

            int maxL = 1;
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (v[j] < v[i])
                    {
                        c[i] = ((c[j] + 1) > c[i]) ? c[j] + 1 : c[i];

                        if (c[i] > maxL) maxL = c[i];
                    }
                }
            }

            return maxL;
        }

        public static int[] LISDP(int[] v)
        {
            int L = v.Length;
            if (L == 0) return new int[] { };

            int[] c = new int[L];
            int[] parentInd = new int[L];
            for (int i = 0; i < L; i++)
            {
                c[i] = 1;
                parentInd[i] = i;
            }

            int maxL = 1, maxInd = 0;
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (v[j] < v[i])
                    {
                        if ((c[j] + 1) > c[i])
                        {
                            c[i] = c[j] + 1;
                            parentInd[i] = j;
                        }

                        if (c[i] > maxL) { maxL = c[i];  maxInd = i; }
                    }
                }
            }

            // build subsequence (always length 1 or more)
            int f = maxL - 1;
            int[] subseq = new int[maxL];

            subseq[f--] = v[maxInd];

            int k = parentInd[maxInd];

            while (f >= 0)
            {
                subseq[f--] = v[k];
                k = parentInd[k];
            }

            return subseq;
        }
        #endregion
    }
}
