## Count the number of ways to cover a distance

Use DP to solve this problem: 

Given a distance (0+ integer), count total number of ways to cover the distance using steps of 1, 2 and 3 sizes.

__Complexity__
* DP version (not memo, not tabular): linear O(n). You do not need a table.
* Recursive: exponential.

__References__

[[1]](https://www.geeksforgeeks.org/count-number-of-ways-to-cover-a-distance/) Count number of ways to cover a distance, GeeksforGeeks.

## Notes
I came up with the DP solution directly.
I spent some time thinking in the recursive way but no success. 
However, I was confident that the recurrence relation can be derived directly.
Thus, I made a spreadsheet for deriving it graphically and to illustrate the concept clearly.

Check below spreadsheet [here](https://docs.google.com/spreadsheets/d/1vCoQgzxHOoeWPAik4OKMYiuIVmDbHiewXW0xngnhxCs/edit?usp=sharing)

![Alt text](/WaysToCoverADistance/notes.JPG?raw=true "Notes")

__Recurrence relation:__

<img src="https://render.githubusercontent.com/render/math?math=F(n) = F(n-1) %2B F(n-2) %2B F(n-3)">

## Output example

![Alt text](/WaysToCoverADistance/output.JPG?raw=true "Output")
