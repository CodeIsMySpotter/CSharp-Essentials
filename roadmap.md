# C# and .NET Ecosystem Learning Roadmap

This roadmap is designed to guide you through the C# language and the .NET ecosystem, roughly following the structure of "C# in a Nutshell". Each module will contain the theoretical foundations and a set of practical tasks.

## Module 1: C# Basics (Variables, Types, Strings, and Arrays)
*   **Concepts**: Value types vs. Reference types, numeric types, boolean, char, strings (manipulation, interpolation, StringBuilder), and basic arrays.
*   **Goal**: Understand basic data storage and manipulation in C#.
*   **Folder**: `01_Basics`

## Module 2: Control Flow (Branching and Looping)
*   **Concepts**: `if`, `else`, `switch` statements (including switch expressions), `for`, `while`, `do-while`, and `foreach` loops. Jump statements (`break`, `continue`, `return`).
*   **Goal**: Control the execution path of your programs.
*   **Folder**: `02_ControlFlow`

## Module 3: Object-Oriented Programming (Classes and Objects)
*   **Concepts**: Classes, constructors, fields, properties, methods, access modifiers (public, private, protected, internal), static members.
*   **Goal**: Understand encapsulation and the basic building blocks of OOP.
*   **Folder**: `03_OOP_Basics`

## Module 4: Advanced OOP (Inheritance, Polymorphism, and Interfaces)
*   **Concepts**: Inheritance, `virtual` and `override` methods, `abstract` classes, `sealed` classes, upcasting/downcasting, and Interfaces.
*   **Goal**: Master class hierarchies and abstraction.
*   **Folder**: `04_OOP_Advanced`

## Module 5: Structs, Enums, and Records
*   **Concepts**: Structs (value type semantics), Enums, Records (immutable data models).
*   **Goal**: Learn when to use alternatives to classes for representing data.
*   **Folder**: `05_DataStructures`

## Module 6: Error Handling and Exceptions
*   **Concepts**: `try`, `catch`, `finally`, throwing exceptions, custom exceptions, common exception types (`ArgumentNullException`, `InvalidOperationException`).
*   **Goal**: Write robust code that gracefully handles unexpected errors.
*   **Folder**: `06_Exceptions`

## Module 7: Collections and File I/O
*   **Concepts**: Generic collections (`List<T>`, `Dictionary<TKey, TValue>`). File and Directory manipulation (`File.ReadAllLines`, `File.WriteAllText`), reading/writing text files.
*   **Goal**: Work with data structures and persist data to files.
*   **Folder**: `07_Collections`

## Module 7b: General Test (Matura Level)
*   **Concepts**: Variables, Control Flow, OOP, Exceptions, Collections, and File I/O combined.
*   **Goal**: Solve a comprehensive, exam-level problem (e.g., reading a dataset from a file, parsing, filtering, and writing a report).
*   **Folder**: `07b_GeneralTest`

## Module 8: Delegates, Events, and Lambdas
*   **Concepts**: Delegates (`Action`, `Func`, `Predicate`), Lambda expressions (`=>`), Events (publish-subscribe pattern).
*   **Goal**: Understand functional programming elements in C# and event-driven programming.
*   **Folder**: `08_DelegatesAndEvents`

## Module 9: LINQ (Language Integrated Query)
*   **Concepts**: Query syntax vs. Method syntax, filtering (`Where`), projection (`Select`), ordering (`OrderBy`), grouping (`GroupBy`), aggregation (`Sum`, `Count`).
*   **Goal**: Query and manipulate collections declaratively.
*   **Folder**: `09_LINQ`

## Module 10: Memory Management and Pointers
*   **Concepts**: The Stack and the Heap, Garbage Collection (GC), `IDisposable`, the `using` statement, `ref`, `out`, `in` parameters, `Span<T>` and `Memory<T>`.
*   **Goal**: Understand how memory is allocated and freed to write high-performance applications.
*   **Folder**: `10_MemoryManagement`

## Module 11: Asynchronous Programming
*   **Concepts**: `Task`, `Task<T>`, `async` and `await`, `CancellationToken`, `Task.WhenAll`, `Task.WhenAny`.
*   **Goal**: Write non-blocking code for I/O bound operations.
*   **Folder**: `11_AsyncProgramming`

## Module 12: Multithreading and Synchronization
*   **Concepts**: `Thread`, Thread Pool, locking (`lock`, `Monitor`), `Mutex`, `SemaphoreSlim`, thread safety.
*   **Goal**: Run CPU-bound work concurrently and manage access to shared resources safely.
*   **Folder**: `12_Multithreading`

## Module 13: Serialization
*   **Concepts**: JSON serialization (`System.Text.Json`), XML serialization.
*   **Goal**: Serialize objects for storage, API communication or transmission.
*   **Folder**: `13_IO_Serialization`

## Module 14: .NET Ecosystem and Architecture
*   **Concepts**: NuGet package management, Dependency Injection (DI) container in .NET, Configuration, Logging.
*   **Goal**: Understand the tools and patterns used to build modern .NET applications.
*   **Folder**: `14_DotNetEcosystem`

---
*How to proceed: We will tackle these modules one by one. I will provide the theory, examples, and set up the corresponding directory with task descriptions for you to complete.*
