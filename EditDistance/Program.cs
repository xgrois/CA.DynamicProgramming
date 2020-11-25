using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Edit distance problem :::\n\r");

            string s1 = "autralopitecuss";
            string s2 = "australopitecus";

            //string s1 = "";
            //string s2 = "australopitecus";

            //string s1 = "bombazo";
            //string s2 = "sobao";

            var sw = Stopwatch.StartNew();
            Console.WriteLine($"Minimum number of operations (insertions, removes, replacements) " +
                $"from geek to gesk are: {EditDistance.ED(s1, s2)}");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            Console.WriteLine($"Minimum number of operations (insertions, removes, replacements) " +
                $"from geek to gesk are: {EditDistance.EDBack(s1, s2)}");
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            Console.WriteLine($"Minimum number of operations (insertions, removes, replacements) " +
                $"from geek to gesk are: {EditDistance.EDMemo(s1, s2)}");
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            Console.WriteLine($"Minimum number of operations (insertions, removes, replacements) " +
                $"from geek to gesk are: {EditDistance.EDDP(s1, s2)}");
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");

        }
    }

    public static class EditDistance
    {
        public static int ED(string s1, string s2)
        {
            return ED(s1, s2, 0, 0);
        }
        private static int ED(string s1, string s2, int m, int n)
        {
            // All remaining are inserts
            if (s1.Length == m)
                return s2.Length - n;

            // All removes
            if (s2.Length == n)
                return s1.Length - m;

            if (s1[m] == s2[n])
            {
                return ED(s1, s2, m + 1, n + 1);
            }
            else
            {
                int a = ED(s1, s2, m, n + 1); // if insert
                int b = ED(s1, s2, m + 1, n); // if remove
                int c = ED(s1, s2, m + 1, n + 1); // if replace

                return 1 + Math.Min(a, Math.Min(b, c));
            }

        }

        public static int EDBack(string s1, string s2)
        {
            return EDBack(s1, s2, s1.Length, s2.Length);
        }
        private static int EDBack(string s1, string s2, int m, int n)
        {
            // All remaining are inserts
            if (m ==  0)
                return n;

            // All removes
            if (n == 0)
                return m;

            if (s1[m - 1] == s2[n - 1])
            {
                return EDBack(s1, s2, m - 1, n - 1);
            }
            else
            {
                int a = EDBack(s1, s2, m, n - 1); // if insert
                int b = EDBack(s1, s2, m - 1, n); // if remove
                int c = EDBack(s1, s2, m - 1, n - 1); // if replace

                return 1 + Math.Min(a, Math.Min(b, c));
            }

        }

        public static int EDMemo(string s1, string s2)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            return EDMemo(s1, s2, 0, 0, dict); 
        }

        public static int EDMemo(string s1, string s2, int m, int n, Dictionary<string, int> dict)
        {

            // All remaining are inserts
            if (s1.Length == m)
                return s2.Length - n;

            // All removes
            if (s2.Length == n)
                return s1.Length - m;

            if (s1[m] == s2[n])
            {

                if (dict.ContainsKey($"{m + 1},{n + 1}"))
                    return dict[$"{m + 1},{n + 1}"];
                else { int x = EDMemo(s1, s2, m + 1, n + 1, dict); dict.Add($"{m + 1},{n + 1}", x); return x; }
            }
            else
            {
                int a, b, c;
                if (dict.ContainsKey($"{m},{n + 1}"))
                    a = dict[$"{m},{n + 1}"];
                else { a = EDMemo(s1, s2, m, n + 1, dict); dict.Add($"{m},{n + 1}", a); }
                if (dict.ContainsKey($"{m + 1},{n}"))
                    b = dict[$"{m + 1},{n}"];
                else {b = EDMemo(s1, s2, m + 1, n, dict); dict.Add($"{m + 1},{n}", b); }
                if (dict.ContainsKey($"{m + 1},{n + 1}"))
                    c = dict[$"{m + 1},{n + 1}"];
                else {c = EDMemo(s1, s2, m + 1, n + 1, dict); dict.Add($"{m + 1},{n + 1}", c); }

                return 1 + Math.Min(a, Math.Min(b, c));
            }

        }

        public static int EDDP(string s1, string s2)
        {
            int N = s1.Length;
            int M = s2.Length;
            int[,] DP = new int[N + 1, M + 1];

            for (int r = 0; r <= N; r++)
                DP[r, 0] = r;
            
            for (int c = 0; c <= M; c++)
                DP[0, c] = c;
            
            for (int r = 1; r <= N; r++)
            {
                for (int c = 1; c <= M; c++)
                {
                    if (s1[r - 1] == s2[c - 1]) DP[r, c] = DP[r - 1, c - 1];
                    else
                        DP[r, c] = 1 + Math.Min(DP[r, c - 1], Math.Min(DP[r - 1, c - 1], DP[r - 1, c]));
                    
                }
            }
            return DP[N, M];
        }
    }
}
