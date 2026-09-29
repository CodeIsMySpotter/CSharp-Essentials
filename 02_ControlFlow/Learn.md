# Module 2: Control Flow

This module teaches you how to control the execution path of your C# application using branching and looping.

## 1. Branching (If, Else, Switch)

The `if` statement evaluates a boolean expression and executes the code block if it is true.

```csharp
int score = 85;

if (score >= 90)
{
    Console.WriteLine("Grade: A");
}
else if (score >= 80)
{
    Console.WriteLine("Grade: B");
}
else
{
    Console.WriteLine("Grade: C");
}
```

The `switch` statement is cleaner when evaluating a single variable against many possible constant values.
In modern C# (C# 8.0+), you can use **switch expressions** which are much more concise and return a value directly:

```csharp
char grade = 'B';
// Classic Switch
switch (grade)
{
    case 'A': Console.WriteLine("Excellent"); break;
    case 'B': Console.WriteLine("Good"); break;
    default: Console.WriteLine("Unknown"); break;
}

// Switch Expression (Modern C#)
string feedback = grade switch
{
    'A' => "Excellent",
    'B' => "Good",
    _ => "Unknown" // _ is the default/discard
};
```

## 2. Looping (For, Foreach, While, Do-While)

Loops allow you to repeat a block of code.

**`for` loop**: Best when you know exactly how many times you want to iterate.
```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iteration {i}");
}
```

**`foreach` loop**: The most common loop in C#. Used to iterate over arrays and collections safely.
```csharp
string[] names = { "Anna", "Bob", "Charlie" };
foreach (string name in names)
{
    Console.WriteLine(name);
}
```

**`while` loop**: Executes as long as the condition is true. Condition is checked *before* the block.
```csharp
int counter = 0;
while (counter < 3)
{
    Console.WriteLine(counter);
    counter++;
}
```

**`do-while` loop**: Similar to `while`, but the condition is checked *after* the block. It guarantees the code runs at least once.
```csharp
int attempts = 0;
do
{
    attempts++;
} while (attempts < 1);
```

## 3. Jump Statements (Break, Continue)
- `break`: Exits the loop immediately.
- `continue`: Skips the rest of the current iteration and jumps to the next one.

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 3) continue; // Skips printing 3
    if (i == 7) break;    // Stops the loop completely when i is 7
    Console.WriteLine(i); 
}
```
