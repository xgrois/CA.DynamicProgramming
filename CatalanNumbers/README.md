# Catalan Numbers

Use DP to solve catalan independentist numbers.
Implements the recursive version for comparison.

__Complexity__
* DP version: polinomial.
* Recursive: exponential.

__References__

[[1]](https://en.wikipedia.org/wiki/Catalan_number) Catalan number, Wikipedia.

## Notes

![Alt text](/CatalanNumbers/Recursive_approach.png?raw=true "Recursive approach")

![Alt text](/CatalanNumbers/DP_approach.png?raw=true "DP approach")


## Code Snippet

```c#
        static BigInteger CatalanDynamicProgramming(int n)
        {
            BigInteger[] c = new BigInteger[n + 1];

            c[0] = 1;

            for (int k = 1; k <= n; k++)
            {
                for (int i = 0; i <= k - 1; i++)
                {
                    c[k] += c[i] * c[k - 1 - i];
                }
            }
            return c[n];

        }
```

## Some Thoughts
Need to use BigInteger data types since catalan numbers grow large pretty fast.
