# Module 1: C# Basics - Theory & Concepts

C# is a strongly-typed, object-oriented language. This module covers the foundational building blocks you need to write any C# program.

## 1. Variables and Data Types

In C#, every variable must have a declared type. The compiler uses this type to determine how much memory to allocate and what operations are valid.

```csharp
// Common Value Types
int age = 28;                 // 32-bit integer
double height = 1.75;         // 64-bit floating-point number
float weight = 70.5f;         // 32-bit floating point (requires 'f' suffix)
decimal money = 100.50m;      // High-precision decimal (requires 'm' suffix), great for financial data
bool isStudent = true;        // Boolean (true or false)
char grade = 'A';             // Single character (uses single quotes)

// Common Reference Types
string name = "John Doe";     // Text (uses double quotes)
object genericBox = 42;       // The base type of all types in .NET
```

You can also use the `var` keyword when the compiler can clearly infer the type from the right side of the assignment:
```csharp
var city = "Warsaw"; // Compiler infers this is a string
var count = 10;      // Compiler infers this is an int
```

## 2. Value Types vs. Reference Types (Crucial Concept)

Understanding how C# manages memory is vital.
*   **Value Types** (e.g., `int`, `double`, `bool`, `char`, `structs`): Variables of these types directly contain their data. They are usually allocated on the **Stack**. When you assign one value type variable to another, the actual data is **copied**.
*   **Reference Types** (e.g., `string`, `arrays`, `classes`): Variables of these types store a **reference** (a memory address) to their data, which is allocated on the **Heap**. When you assign one reference type variable to another, you only copy the reference. Both variables now point to the exact same object in memory!

```csharp
// Value Type Example:
int a = 10;
int b = a;  // 'b' is a copy of 'a'
b = 20;     
// 'a' is still 10. 'b' is 20.

// Reference Type Example:
int[] array1 = new int[] { 1, 2, 3 };
int[] array2 = array1; // 'array2' points to the same array in memory!
array2[0] = 99;
// array1[0] is now ALSO 99!
```

## 3. Strings and String Manipulation

Strings in C# are **immutable**. This means once a string is created, it cannot be changed. Any operation that appears to modify a string actually creates a brand new string in memory.

### String Interpolation
The most modern and preferred way to format strings is using interpolation (prefixing the string with `$`).
```csharp
string firstName = "Jane";
string lastName = "Doe";
int age = 30;
string greeting = $"Hello, my name is {firstName} {lastName} and I am {age} years old.";
```

### StringBuilder
Because strings are immutable, combining many strings (e.g., in a loop) can be bad for performance. For heavy string manipulation, use `StringBuilder` from the `System.Text` namespace.
```csharp
using System.Text;

StringBuilder sb = new StringBuilder();
sb.Append("First line. ");
sb.AppendLine("Still the first line, but adding a line break after this.");
sb.AppendLine("Second line.");
string finalResult = sb.ToString();
```

## 4. Arrays

Arrays allow you to store multiple items of the same type in a single variable. They have a fixed size that must be defined when the array is created.

```csharp
// Declaration and Initialization
int[] numbers = new int[3]; // Creates an array of 3 integers, defaulting to 0
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;

// Shorthand initialization
string[] colors = { "Red", "Green", "Blue" };

// Accessing elements
string favoriteColor = colors[1]; // "Green" (arrays are 0-indexed)

// Getting the length
int totalColors = colors.Length; // 3
```
