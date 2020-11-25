# Edit Distance

Use DP to solve the Edit Distance problem, i.e., given 2 strings s1, s2,
find the minimum number of modifications needed in s1 to be equal to s2.

The allowed modifications are: insert, remove, replace.

__Applications__
This problem is used as the core algorithm that shows you word suggestions as you type.

__Complexity__
* DP version (memo and tabular): polinomial.
* Recursive (forward and backward): exponential.

__References__

[[1]](https://en.wikipedia.org/wiki/Edit_distance) Edit distance, Wikipedia.

## Some Thoughts
This problem is considered Hard in literature.

As always, it is very important to derive the recursive solution first.
The recursive solution paves the way to the DP solution (either by memoization or tabulation).
In this problem, the backwards recursive solution gives you all the hints you need to build the DP table.

You can extract the following recurrence relation from the recursive solution:
DP[i,j] = some combination of previous values...

```c#
DP[i,j] = 1 + min( DP[i, j - 1], DP[i - 1, j], DP[i - 1, j - 1])  // If characters differ
DP[i,j] = DP[i - 1, j - 1]                                        // If characters are equal
```

__Recursive solution (backwards)__

```c#
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
```
## Some Notes

![Alt text](/EditDistance/example.png?raw=true "Notes")
