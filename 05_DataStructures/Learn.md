# Moduł 5: Typy Danych - Struct, Enum i Record

Język C# poza klasami (które są typami referencyjnymi) oferuje inne konstrukcje do modelowania danych, w zależności od potrzeb.

## 1. Typy Wartościowe vs Typy Referencyjne
- **Typy referencyjne (np. `class`)**: Przechowywane na **stercie** (Heap). Zmienna trzyma tylko "wskaźnik" (referencję) do miejsca w pamięci. Przekazując klasę do metody, przekazujesz pilot do telewizora – jeśli zmienisz coś w metodzie, zmieni się to oryginalnym obiekcie.
- **Typy wartościowe (np. `int`, `bool`, `struct`)**: Przechowywane na **stosie** (Stack). Zmienna trzyma bezpośrednią wartość. Przekazując ją, wykonuje się jej kopia.

## 2. Struktury (`struct`)
Struktury to typy wartościowe. Używamy ich do małych paczek danych, które nie potrzebują skomplikowanego dziedziczenia i których używamy bardzo często (wydajność).
```csharp
public struct Point2D
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point2D(double x, double y)
    {
        X = x;
        Y = y;
    }
}
```

## 3. Typy Wyliczeniowe (`enum`)
Pozwalają na nadanie nazw (etykiet) wartościom liczbowym, co niesamowicie poprawia czytelność kodu.
```csharp
public enum DeliveryStatus
{
    Pending,     // domyślnie 0
    InTransit,   // 1
    Delivered,   // 2
    Canceled     // 3
}

// Użycie:
DeliveryStatus currentStatus = DeliveryStatus.InTransit;

// Parsowanie ze stringa (np. pobranego od użytkownika):
if (Enum.TryParse<DeliveryStatus>("Delivered", out var parsedStatus))
{
    Console.WriteLine(parsedStatus); // Wyświetli: Delivered
}

// --- Flagi bitowe (Atrybut [Flags]) ---
// Pozwalają na łączenie wielu wartości enuma w jednej zmiennej. Wymagają potęg liczby 2.
[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4
}

// Łączenie uprawnień operatorem bitowym OR (|)
Permissions myPerms = Permissions.Read | Permissions.Write; 
// Sprawdzanie czy uprawnienie istnieje
bool canWrite = myPerms.HasFlag(Permissions.Write); 
```

## 4. Rekordy (`record`) (C# 9.0+)
Rekordy to wciąż (domyślnie) typy referencyjne, ale zaprojektowane specjalnie do tworzenia obiektów **niemutowalnych** (takich, których nie da się zmienić po utworzeniu) i operowania na danych.
Główna zaleta: Rekordy porównuje się po **wartościach**, a nie referencjach (jak klasy). Dwie klasy o identycznych właściwościach to zawsze dwa różne obiekty. Dwa rekordy o takich samych wartościach - zostaną uznane za identyczne (`==` zwróci `true`).

```csharp
// Najkrótszy zapis (Positional record):
public record Product(string Name, decimal Price);

// Użycie:
var p1 = new Product("Laptop", 5000);
// p1.Price = 4000; // BŁĄD! Właściwości są tylko do odczytu (Init-only).

// Nieniszcząca mutacja (słowo kluczowe with):
// Zamiast modyfikować stary obiekt, tworzymy jego nową, zmodyfikowaną kopię:
var p2 = p1 with { Price = 4500 }; 
Console.WriteLine(p2); // Product { Name = Laptop, Price = 4500 }
```

## 5. Krotki (Tuples) i ValueTuple
Krotki to lekki sposób na grupowanie kilku wartości, bez konieczności definiowania nowej klasy czy struktury. Często używane do zwracania wielu wartości z metody.

```csharp
// Użycie ValueTuple
(string Name, int Age) person = ("Jan", 30);
Console.WriteLine(person.Name); // Jan

// Dekonstrukcja krotki
var (imie, wiek) = person;
```

## 6. Rekordy jako struktury (`record struct` - C# 10+)
Tradycyjne rekordy (`record class`) są typami referencyjnymi. W C# 10 dodano `record struct`, co pozwala cieszyć się semantyką wartościową (jak w `struct`) oraz ułatwieniami z rekordów (jak wbudowane porównywanie czy słowo kluczowe `with`).

```csharp
public record struct Point3D(double X, double Y, double Z);
```

## 7. Typy Anonimowe (Anonymous Types)
Pozwalają na "ad-hoc" stworzenie obiektu do przechowania małej porcji danych. Są to zawsze typy referencyjne, a ich właściwości są tylko do odczytu. Najczęściej używane przy zapytaniach LINQ.

```csharp
var car = new { Make = "Ford", Model = "Mustang", Year = 1969 };
Console.WriteLine(car.Make);
```

## 8. Opakowywanie i Rozpakowywanie (Boxing / Unboxing)
- **Boxing**: Konwersja typu wartościowego (np. `int`, `struct`) na typ referencyjny (`object`). Wymaga to zaalokowania pamięci na stercie i skopiowania tam wartości (kosztowne wydajnościowo).
- **Unboxing**: Proces odwrotny - rzutowanie z `object` z powrotem na typ wartościowy.

```csharp
int i = 123;
object o = i;     // Boxing (niejawny)
int j = (int)o;   // Unboxing (jawny, rzutowanie)
```
