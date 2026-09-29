# Theory - Module 4: Advanced OOP

In this module, we will explore the three pillars of object-oriented programming: Inheritance, Polymorphism, and Abstraction.

## 1. Inheritance
Allows a new class to inherit functionality from an existing class. The base class (parent) shares its methods and properties with the derived class (child).
In C#, you can only inherit from a single class (no multiple inheritance for classes).
We use the colon `:` symbol for inheritance.

```csharp
class Animal // Base class
{
    public string Name { get; set; }
    public void Sleep() { Console.WriteLine("Zzz..."); }
}

class Dog : Animal // Dog inherits from Animal
{
    public void Bark() { Console.WriteLine("Woof!"); }
}

// Usage:
Dog myDog = new Dog();
myDog.Sleep(); // Inherited method from Animal
myDog.Bark();  // Dog's own method
```

## 2. Polymorphism
Polymorphism allows objects of derived classes to be treated as if they were objects of the base class, while still retaining their specific behaviors.
This is achieved using the `virtual` (in the base class) and `override` (in the derived class) modifiers.

```csharp
class Animal
{
    // 'virtual' means: "I allow derived classes to override this method"
    public virtual void MakeSound() 
    {
        Console.WriteLine("Animal sound");
    }
}

class Dog : Animal
{
    // 'override' replaces the functionality of the original method
    public override void MakeSound()
    {
        Console.WriteLine("Woof woof!");
    }
}

// The magic of polymorphism:
Animal a = new Dog(); // Upcasting (implicit)
a.MakeSound(); // Prints "Woof woof!", even though the reference is Animal!
```

## 3. Abstract Classes
An abstract class is an "incomplete" class from which **an object cannot be instantiated** (`new`). It serves solely as a base for inheritance.
It can contain implemented methods as well as **abstract methods** (which require implementation in a derived class).

```csharp
abstract class Shape
{
    // Must be overridden by derived classes (implicitly 'virtual')
    public abstract double CalculateArea(); 
}

class Circle : Shape
{
    public double Radius { get; set; }
    public override double CalculateArea() => Math.PI * Radius * Radius;
}
```

## 4. Interfaces
An interface is a completely empty "contract". It tells "WHAT" needs to be done, but doesn't tell "HOW".
A class can implement (sign the contract for) **multiple interfaces**.
Interface names in C# conventionally start with a capital `I`.

```csharp
interface IMovable
{
    void Move(); // No implementation (no method body)
}

class Car : IMovable
{
    public void Move()
    {
        Console.WriteLine("The car is moving.");
    }
}
```

## 5. Casting (Upcasting and Downcasting)
In C#, objects of derived types can be assigned to variables of a base type (Upcasting - safe and automatic). Conversely, returning them to their specific type requires caution (Downcasting).
The `is` (checks) and `as` (casts or returns null) operators are used for this.

```csharp
Animal a = new Dog(); // Upcasting
// a.Bark(); // Compilation ERROR! Animal does not have a Bark() method.

// Safe downcasting using Pattern Matching (is):
if (a is Dog myDog)
{
    myDog.Bark(); // Now it works!
}
```
