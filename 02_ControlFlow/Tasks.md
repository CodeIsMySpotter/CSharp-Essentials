# Module 2 Tasks: Control Flow

The following 5 tasks test your ability to combine conditional statements and loops. Complete them in the provided functions `Task1()` to `Task5()` in the `Program.cs` file.

## Task 1: Number Classifier (If / Else)
Declare a variable `int number = -14;` (you can test other values too).
Write logic using `if`, `else if`, and `else` that will print to the screen:
- Whether the number is positive, negative, or zero.
- And (if it's not zero) whether it is even or odd (use the modulo operator `%`, e.g., `number % 2 == 0`).

## Task 2: The Modern Calculator (Switch Expression)
Declare variables: `double a = 15;`, `double b = 4;`, and `char operation = '+';`.
Use the modern **Switch Expression** to calculate the result based on the operation character (`+`, `-`, `*`, `/`).
Ensure that when dividing by `0`, the result is `0` (or print an error using an `if` block inside or before the switch). Assign the result to a variable and print it.

## Task 3: Number Search (While / Break)
Declare an array: `int[] numbers = { 4, 8, 15, 16, 23, 42 };`.
Declare the target number: `int target = 16;`.
Use a `while` loop to search the array. If you find the number, print its index and use the `break` statement to stop the loop. If the loop reaches the end and the number is not there, do not print anything.

## Task 4: Positive Sum (Foreach / Continue)
Declare an array: `int[] mixedNumbers = { -5, 10, -3, 20, 0, 15 };`.
Create a variable `int sum = 0;`.
Iterate over the array with a `foreach` loop. If the number is negative, use the `continue` statement to skip the iteration. If it is positive, add it to the sum. At the end, print the sum.

## Task 5: FizzBuzz (For loop)
A classic interview task!
Use a `for` loop to iterate through numbers from 1 to 100 inclusive.
For each number:
- If it is divisible by 3 and 5 (i.e., by 15), print "FizzBuzz"
- If it is divisible only by 3, print "Fizz"
- If it is divisible only by 5, print "Buzz"
- Otherwise, print the number itself.
