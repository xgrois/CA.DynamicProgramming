# Partition problem

Use DP to solve the Partition problem, i.e., given a set of positive integers,
find if it can be divided into two subsets with equal sum.

__Complexity__
* DP version (memo and tabular): pseudo-polinomial. O(n x sum(vector)/2). If the input vector has high numbers this becomes an issue.
* Recursive: exponential.

__References__

[[1]](https://en.wikipedia.org/wiki/Partition_problem) Partition problem, Wikipedia.

## Some Thoughts
This problem is considered Medium in literature.

As always, it is very important to derive the recursive solution first.
The recursive solution paves the way to the DP solution (either by memoization or tabulation).
In this problem, the recursive solution gives you all the hints you need to build the DP table.

However, it is very important to be careful with indexes in the recursive solution that will 
facilitate to transform it to the DP solution (otherwise it is a nightmare).

The general hint is to avoid using zero-based calls in the recursive solution.
E.g.:

```
if input vector = [3 2 8], then use in recursive function:
            F(3, other info)   // 1-based index
instead of
            F(2, other info)   // 0-based index

```

Another useful hint is to traverse the tree with indexes decreasing, i.e.:

```
                          F(4, 6)
                        /        \
                       /          \
    F(4 or less, 6 or less)        F(4 or less, 6 or less)
```

In this specific exercise I did not use both hints (because I learned those by doing this exercise xD).
However, it illustrates the importance of the recursive solution to derive a correct DP solution.
In this case, the DP table will not look as usual (increasing from top-down and left-right) because
I did not use hint 2 (I used an incremental accumulator up to sum, instead of starting from sum and decreasing).
However, it is nice the derived recurrence relation for the DP solution works as expected by the recurrence relation.

## Notes

![Alt text](/PartitionSum/notes.png?raw=true "Notes")


You can extract the following recurrence relation from the recursive solution:
DP[i,j] = some combination of previous values...

```c#
DP[i,j] = DP[i - 1, j] OR DP[i - 1, j + v[i - 1]] // if (j + v[i - 1] > sum) just false
```

__DP solution (optimized)__

The optimized version requires a smaller DP table.
Instead of going up to SUM, it just goes up to TARGET = SUM/2, since all those left values are always FALSE.

```c#
        public static bool FindDPOptimized(int[] v)
        {

            int vL = v.Length;
            int sum = 0;
            for (int i = 0; i < vL; i++)
                sum += v[i];

            if (!isOdd(sum)) return false;

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

            return DP[vL, 0];
        }
```

