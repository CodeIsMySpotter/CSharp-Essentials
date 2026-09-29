# Moduł 7: Kolekcje (Collections)

Zwykłe tablice (ang. *Arrays*) są bardzo szybkie, ale mało elastyczne (mają stały rozmiar, który trzeba znać przy tworzeniu). W C# do dynamicznego zarządzania grupami danych korzystamy z **kolekcji** z przestrzeni nazw `System.Collections.Generic`.

## 1. `List<T>` - Dynamiczna Tablica
Najbardziej popularna kolekcja. Działa jak tablica, ale potrafi automatycznie rosnąć. Posiada metody takie jak `Add()`, `Remove()`, czy `Contains()`.

```csharp
List<string> names = new List<string>();
names.Add("Jan");
names.Add("Anna");
names.Remove("Jan");
// Iteracja jak po tablicy:
foreach(var name in names) { Console.WriteLine(name); }
```
**Złota zasada:** Modyfikowanie (dodawanie/usuwanie) elementów z listy w trakcie działania pętli `foreach` zakończy się błędem `InvalidOperationException`. Jeśli musisz usuwać podczas pętli, użyj `for` idącego od końca (od `.Count - 1` do `0`).

## 2. `Dictionary<TKey, TValue>` - Słownik (Mapa)
Przechowuje pary "Klucz - Wartość". Pozwala na błyskawiczne pobieranie wartości na podstawie klucza (bez konieczności przeszukiwania całej kolekcji). Każdy klucz w słowniku musi być unikalny.

```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();
ages.Add("Jan", 30);
ages["Anna"] = 25; // Szybszy zapis, dodaje lub nadpisuje

// Bezpieczne pobieranie wartości:
if (ages.TryGetValue("Jan", out int janAge)) {
    Console.WriteLine($"Wiek Jana to {janAge}");
}
// Użycie ages["KtosInny"] rzuci KeyNotFoundException jeśli klucza nie ma!
```

## 3. `HashSet<T>` - Zbiór
Kolekcja, która gwarantuje, że każdy jej element występuje **tylko raz**. Jest niesamowicie szybka do sprawdzania `.Contains()`.

```csharp
HashSet<int> numbers = new HashSet<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(1); // Ignorowane, "1" już tam jest. Rozmiar HashSetu to nadal 2.
```
HashSet posiada metody matematyczne np. `UnionWith` (suma zbiorów), `IntersectWith` (część wspólna), `ExceptWith` (różnica).

## 4. `Queue<T>` - Kolejka (FIFO - First In, First Out)
Działa jak kolejka w sklepie. Pierwszy element dodany jest pierwszym elementem zdjętym.
Metody: `Enqueue()` (dodaj na koniec), `Dequeue()` (zdejmij z początku), `Peek()` (podglądnij początek bez zdejmowania).

## 5. `Stack<T>` - Stos (LIFO - Last In, First Out)
Działa jak stos talerzy. Ostatni element dodany na górę stosu jest pierwszym, który możemy z niego zdjąć (np. cofanie operacji w przeglądarce, tzw. Undo).
Metody: `Push()` (dodaj na górę), `Pop()` (zdejmij z góry), `Peek()` (podglądnij górę).

## 6. `IEnumerable<T>` i `ICollection<T>` (Wstęp do Interfejsów)
Wszystkie kolekcje w C# implementują pewne wspólne interfejsy.
- Jeśli metoda przyjmuje `IEnumerable<string>`, to możesz jej przekazać zarówno `List<string>`, tablicę `string[]`, jak i `HashSet<string>`. `IEnumerable` potrafi tylko jedno: być przeiterowanym w pętli `foreach` (tylko do odczytu, nie pozwala dodawać).
- `ICollection<T>` rozszerza `IEnumerable<T>` m.in. o metody `.Add()`, `.Remove()` i właściwość `.Count`.
