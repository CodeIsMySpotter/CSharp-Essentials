# Module 1 Tasks: Basics

The tasks in this module aim to verify your understanding of the basic concepts from the `Learn.md` file in a holistic way. Remember that in this module **we do not use conditional statements (`if`) or loops (`for`/`while`) yet**.

Perform all tasks in a single `Program.cs` file. Separate the code for subsequent tasks with comments (e.g., `// --- Task 1 ---`).

## Task 1: The Profile Builder
Declare a set of variables representing a user profile. You must use at least one type of: `string`, `int`, `double`, `char`, and `bool`. Then use **string interpolation** to format one large profile message (e.g., *"User J, age 25, height 1.8m. Is active: True"*) and print it to the console.

## Task 2: Array Operations
Create an array storing the names of 3 of your favorite books or games.
Declare an `int` variable storing the size of this array (use the `.Length` property).
Replace the second element of the array (index 1) with a new title.
Print the updated second element and the variable with the array length to the console.

## Task 3: Value vs. Reference Types in Action
Prove the difference between value and reference types:
1. Declare two variables of type `double`. Assign the second to the first, change the second, and prove (using `Console.WriteLine`) that the first remained unchanged.
2. Declare a 2-element array of type `string`. Create a second array variable and assign the first array to it. Change an element in the second array and print the corresponding element from the first array to prove that it also changed.

## Task 4: The String Reverser (Manual)
Declare an array of 3 characters (`char[]` type), e.g., containing the letters `['C', '#', '!']`.
Create a new string (`string`) based on this array, but in reverse order. Since we don't know loops yet, do it manually using string interpolation and appropriate array indices. Print the result to the console.

## Task 5: The Final Grade Calculator (StringBuilder)
Declare an array of type `double` containing any 3 grades (e.g., 4.5, 3.0, 5.0).
Calculate their average by adding them together "manually" (via indices `[0] + [1] + [2]`) and dividing by the length of the array (the `.Length` property).
Use the `StringBuilder` class to generate a professional student report consisting of 3 lines:
- Line 1: "--- Student Report ---"
- Line 2: The 3 grades printed and separated by commas (use array indices).
- Line 3: "Average: [insert calculated average here]".
At the very end, print the contents of the `StringBuilder` to the console.
