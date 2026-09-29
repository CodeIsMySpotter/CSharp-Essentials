# Moduł 8: Delegaty, Lambdy i Zdarzenia (Events)

Delegaty to jeden z najpotężniejszych mechanizmów w C#. Pozwalają traktować metody tak, jakby były zwykłymi zmiennymi – można je przekazywać jako parametry, przechowywać w listach i dynamicznie zmieniać.

## 1. Delegat (Delegate) - "Wskaźnik na metodę"
Delegat definiuje **sygnaturę** (zwracany typ i parametry). Zmienna typu delegata może przechowywać dowolną metodę, która do tej sygnatury pasuje.

```csharp
// 1. Definicja delegata (poza klasą lub wewnątrz)
public delegate void PrintDelegate(string message);

public class Program
{
    // Pasująca metoda
    static void PrintToConsole(string msg) => Console.WriteLine(msg);

    static void Main()
    {
        // 2. Przypisanie metody do delegata
        PrintDelegate printer = PrintToConsole;
        
        // 3. Wywołanie (dokładnie jak zwykłej metody)
        printer("Witaj świecie!");
    }
}
```

## 2. Wbudowane delegaty: `Action`, `Func`, `Predicate`
Ponieważ tworzenie własnych typów delegatów za każdym razem jest uciążliwe, C# posiada wbudowane generyczne delegaty do 99% zastosowań:

- **`Action`** – Metoda, która nic nie zwraca (`void`). Może przyjmować od 0 do 16 parametrów.
  ```csharp
  Action<string> logAction = Console.WriteLine;
  Action noParams = () => Console.WriteLine("Pusto!");
  ```
- **`Func`** – Metoda, która **zwraca wartość**. Ostatni typ generyczny to zawsze typ zwracany.
  ```csharp
  // Zwraca bool, przyjmuje int
  Func<int, bool> isEven = number => number % 2 == 0; 
  // Zwraca string, przyjmuje int i double
  Func<int, double, string> format = (i, d) => $"{i} - {d}";
  ```
- **`Predicate<T>`** – Metoda, która bierze jeden parametr i zawsze zwraca `bool`. Używana głównie przy przeszukiwaniu list.
  ```csharp
  Predicate<int> isPositive = n => n > 0;
  ```

## 3. Wyrażenia Lambda (`=>`)
Zamiast pisać osobną funkcję tylko po to, żeby podpiąć ją pod delegata, używamy "lambd" – czyli krótkich funkcji anonimowych pisanych "w locie".
```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4 };
// x wlatuje, i sprawdzamy czy x jest parzyste. Zwraca listę parzystych.
var evens = numbers.FindAll(x => x % 2 == 0);
```

## 4. Multicast Delegates
Jeden delegat (szczególnie `Action`) może trzymać **kilka metod naraz**. Używamy do tego operatora `+=`. Wywołanie delegata uruchomi wszystkie metody w kolejności dodania.
```csharp
Action notify = () => Console.WriteLine("Email wysłany");
notify += () => Console.WriteLine("SMS wysłany");
notify(); // Wypisze oba
```

## 5. Zdarzenia (Events)
Gdy udostępniamy delegata publicznie (np. `public Action OnClick;`), ktoś z zewnątrz może go wywołać, albo, co gorsza, użyć `=` zamiast `+=` i skasować innych subskrybentów.
Rozwiązaniem jest słowo kluczowe `event`.
```csharp
public class Button
{
    // event sprawia, że klasa z zewnątrz może używać tylko += oraz -=
    public event Action OnClick; 

    public void Click()
    {
        // Wywołujemy z samej klasy. Używamy ?. (null-conditional) aby nie rzucić NullReferenceException jeśli nie ma subskrybentów.
        OnClick?.Invoke();
    }
}
```

## 6. Standard `EventHandler`
W aplikacjach biznesowych i UI rzadko używamy gołego `Action` do eventów. Konwencja .NET mówi, że event powinien przekazywać:
1. `object sender` (Kto wywołał event - nadawca)
2. `EventArgs e` (Dodatkowe dane o evencie, z których można dziedziczyć)

```csharp
public event EventHandler<string> OnError;
// Wywołanie wewnątrz klasy: OnError?.Invoke(this, "Wystąpił krytyczny błąd");
```
