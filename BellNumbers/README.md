## Bell Numbers

Use bottom-up DP to solve Bell numbers. This code uses Stirling numbers to calculate Bell numbers.
This is due to the following recurrence:

B(n) = sum_{k = 0}^{n} S(n,k)

__Complexity__
* DP version: polinomial.

__References__

[[1]](https://en.wikipedia.org/wiki/Stirling_numbers_of_the_second_kind) Stirling numbers of the second kind, Wikipedia.
[[2]](https://en.wikipedia.org/wiki/Bell_number) Bell number, Wikipedia.

## Notes

![Alt text](/BellNumbers/stirling_bell.png?raw=true "Relationship between Bell number and Stirling numbers")


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
