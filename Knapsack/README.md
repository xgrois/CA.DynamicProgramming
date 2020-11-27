## 0-1 Knapsack problem

Use DP to solve the 0-1 Knapsack problem, i.e., maximize the value of the knapsack
by introducing a combination of elements that do not exceed maximum knapsack capacity.

__Complexity__
* DP version (memo and tabular): pseudo-polinomial. O(n x capacity). If the knapsack capacity is large this becomes an issue.
* Recursive: exponential.

__References__

[[1]](https://en.wikipedia.org/wiki/Knapsack_problem) Knapsack problem, Wikipedia.

## Some Thoughts
This problem is considered Medium in literature.

This is a well-known combinatorial optimization problem.

<img src="https://render.githubusercontent.com/render/math?math=\max_{} \sum_{i = 0}^{N-1} v_i x_i">

subject to:

<img src="https://render.githubusercontent.com/render/math?math=\sum_{i = 0}^{N-1} w_i x_i \leq C">
<img src="https://render.githubusercontent.com/render/math?math=x_i \in \{0,1\}">

## Notes

![Alt text](/Knapsack/notes.png?raw=true "Notes")


You can extract the following recurrence relation from the recursive solution:
DP[i,j] = some combination of previous values...

```c#
DP[i,j] = min( DP[i - 1, j] , DP[i - 1, j - w[i - 1]] ) // if (j - w[i - 1] < 0) just 0
```



## Output example

![Alt text](/PartitionSum/output.jpg?raw=true "Output")
