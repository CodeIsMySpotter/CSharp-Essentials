# Moduł 9: LINQ (Language Integrated Query)

LINQ to potężna technologia wbudowana w C#, pozwalająca w bardzo czytelny i zwięzły sposób odpytywać i manipulować dowolnymi kolekcjami (i nie tylko). Dzięki LINQ, zamiast pisać zagnieżdżone pętle `foreach` i warunki `if`, możesz opisać, **co** chcesz uzyskać, a nie **jak**.

Wymaga dodania `using System.Linq;`.

## 1. Dwie składnie LINQ
W C# można używać dwóch różnych sposobów na pisanie LINQ:
- **Query Syntax (składnia zapytań)** – przypomina SQL.
- **Method Syntax (składnia metod)** – oparta na wywołaniach metod i lambdach. Ta jest najpopularniejsza i jej będziemy używać!

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

// Query Syntax:
var evenQuery = from n in numbers where n % 2 == 0 select n;

// Method Syntax (Zalecana!):
var evenMethod = numbers.Where(n => n % 2 == 0);
```

## 2. Metody rozszerzające (Najważniejsze)

### a) Filtrowanie (`Where`)
Znajduje i przepuszcza tylko te elementy, które spełniają dany warunek (Predicate).
```csharp
var adults = users.Where(u => u.Age >= 18);
```

### b) Transformacja / Mapowanie (`Select`)
Bierze każdy element i zamienia go na coś innego (często służy do wyciągania pojedynczej właściwości z obiektu).
```csharp
var justNames = users.Select(u => u.Name); // z List<User> robi List<string>
```

### c) Sortowanie (`OrderBy`, `OrderByDescending`, `ThenBy`)
Zwraca posortowaną kolekcję.
```csharp
var sortedUsers = users.OrderBy(u => u.LastName).ThenBy(u => u.FirstName);
```

## 3. Elementy i Sprawdzanie
### a) Zwracanie konkretnego elementu
- **`First()`** - Pierwszy element. Rzuca wyjątek, jeśli pusto!
- **`FirstOrDefault()`** - Pierwszy element lub `null` (domyślna wartość), jeśli pusto. Najbezpieczniejsze!
- **`Single()`** - Zwraca jedyny element. Rzuca wyjątek jeśli pusto, LUB jeśli jest ich WIĘCEJ niż 1!
- **`SingleOrDefault()`** - Jak wyżej, ale bez wyjątku gdy pusto.

### b) Weryfikacja
- **`Any()`** - Zwraca `true`, jeśli kolekcja nie jest pusta, ALBO jeśli jakikolwiek element spełnia warunek (`users.Any(u => u.Age < 18)`).
- **`All()`** - Zwraca `true` tylko jeśli **wszystkie** elementy spełniają warunek.

## 4. Agregacja i Analiza
- **`Count()`** - Liczy elementy (zamiast propercji `.Count` z list, używaj na kolekcjach `IEnumerable`).
- **`Sum(x => x.Price)`** - Sumuje wartości.
- **`Min()` / `Max()` / `Average()`** - Wiadomo.
- **`Distinct()`** - Zwraca tylko unikalne wartości (odfiltrowuje duplikaty).

## 5. Grupowanie (`GroupBy`)
Dzieli kolekcję na mniejsze, pogrupowane "podkolekcje" po wspólnym kluczu. Zwraca typ `IGrouping`.
```csharp
var groupedByRole = users.GroupBy(u => u.Role);
foreach (var group in groupedByRole) {
    Console.WriteLine($"Rola: {group.Key}, Ilość: {group.Count()}");
}
```

## 6. Słownik Odroczonego Wykonania (Deferred Execution)
Złota zasada LINQ: **Zapytania LINQ nie wykonują się od razu!**
```csharp
var query = numbers.Where(n => n > 10); 
// W tym miejscu pętla filtrująca w ogóle jeszcze nie ruszyła!
```
Uruchomi się ona dopiero w momencie:
1. Użycia `foreach` po zmiennej `query`.
2. Użycia metody wyciągającej dane natychmiast: **`.ToList()`**, **`.ToArray()`**, **`.Count()`**, **`.First()`** itp.
