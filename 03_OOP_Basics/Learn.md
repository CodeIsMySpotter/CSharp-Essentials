# Theory - Module 3: OOP Basics

In this module, we explore the object-oriented programming paradigm. C# is a fully object-oriented language, which means the code is based on **classes** and **objects** created from them.

## 1. Classes and Objects
A **class** is a template (blueprint) from which **objects** (instances) are created.
```csharp
// Class definition (template)
class Person
{
    // Class body
}

// Creating an object (instance) of this class
Person p = new Person();
```

## 2. Fields and Access Modifiers
A **field** is a variable defined directly within a class. To maintain *encapsulation*, fields are usually set as private (`private`).
Access modifiers determine who has access to a given element:
- `public` - access from anywhere.
- `private` - access only within the given class (default in C#).
- `protected` - access within the class and in classes inheriting from it.
- `internal` - access within the current project (Assembly).

```csharp
class Person
{
    private string name; // private field
}
```

## 3. Properties
To safely expose private fields to the outside, we use properties (in languages like Java, this is done via Get/Set methods).
In C#, **Auto-properties** are most commonly used:

```csharp
class Person
{
    // Property - under the hood, the compiler creates a private field for us!
    public string FirstName { get; set; }
    
    // Read-only (can only be assigned in a constructor)
    public string LastName { get; }
    
    // Custom getter / setter with logic:
    private int age;
    public int Age 
    { 
        get { return age; }
        set 
        { 
            if (value > 0)
                age = value;
        }
    }
}
```

## 4. Constructors
A **constructor** is a special method called when creating an object (using `new`). It is used to initialize initial values.
It has no return type and is named exactly the same as the class.

```csharp
class Person
{
    public string Name { get; set; }

    // Parameterless (default) constructor
    public Person()
    {
        Name = "Unknown";
    }

    // Parameterized constructor
    public Person(string name)
    {
        Name = name;
    }
}
```

## 5. Methods
**Methods** are simply functions belonging to a class. They define what a given object "can" do.

```csharp
class Person
{
    public string Name { get; set; }

    public void Introduce()
    {
        Console.WriteLine($"Hello, I'm {Name}!");
    }
}
```
