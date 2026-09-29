# Moduł 10: Zarządzanie Pamięcią (Memory Management)

W językach takich jak C++, programista sam musi przydzielać (alokować) i zwalniać pamięć. W C# robi to za nas automat zwany **Garbage Collector (GC)**. Niemniej jednak, musimy rozumieć jak działa, aby pisać wydajne aplikacje i unikać tzw. wycieków pamięci.

## 1. Stack (Stos) vs Heap (Sterta)
- **Stack (Stos):** Służy do przechowywania wywołań metod i zmiennych lokalnych (typów wartościowych - `int`, `struct`, `bool`). Jest bardzo szybki, czyści się sam natychmiast po wyjściu z metody.
- **Heap (Sterta):** Służy do przechowywania obiektów (typów referencyjnych - `class`, `string`, `List`). Jest wolniejszy. To właśnie stertę sprząta Garbage Collector.

## 2. Garbage Collector (GC)
Garbage Collector okresowo skanuje Stertę (Heap). Szuka obiektów, do których nie prowadzi już żadna zmienna/referencja w twoim programie. Jeśli uzna, że dany obiekt nie jest ci już potrzebny – bezpowrotnie usuwa go, zwalniając RAM.

GC działa w trybie pokoleń (Generations):
- **Gen 0:** Obiekty najmłodsze, świeżo stworzone. GC skanuje je bardzo często.
- **Gen 1:** Obiekty, które przetrwały jedno sprzątanie.
- **Gen 2:** Najstarsze obiekty. GC skanuje je najrzadziej (bo to długo trwa).

## 3. Wycieki Pamięci (Memory Leaks)
W C# "wyciek" oznacza, że programista sam (często przypadkiem) wciąż "trzyma" referencję do obiektu (np. w jakiejś statycznej liście lub publicznym Evencie), a GC myśli: *"O, ta lista wciąż ma do niego link! Nie mogę go usunąć!"*. Skutkiem jest nieustanne puchnięcie zużycia RAM.

## 4. Zasoby Niezarządzane (Pliki, Sieć, Bazy danych)
GC świetnie radzi sobie z obiektami stworzonymi w kodzie. Kompletnie nie radzi sobie jednak z zewnętrznymi zasobami (otwarty plik na Windowsie, połączenie TCP, połączenie z SQL). 
Aby zamknąć taki zasób, klasy te implementują interfejs `IDisposable`, wymuszający posiadanie metody `Dispose()`.

## 5. Blok `using`
Służy do automatycznego zwalniania zasobów niezarządzanych (wywołania `Dispose()`), na wypadek gdybyś zapomniał, albo gdyby program uległ awarii (wyskoczył wyjątek). Działa on pod spodem jak blok `try-finally`.

```csharp
// Stary zapis (przed C# 8.0)
using (var file = new StreamReader("plik.txt"))
{
    Console.WriteLine(file.ReadLine());
} // Tutaj C# sam wywołuje file.Dispose() (plik zostaje zamknięty)

// Nowy zapis (C# 8.0+)
using var file2 = new StreamReader("plik.txt");
Console.WriteLine(file2.ReadLine());
// file2.Dispose() odpali się samo na końcu klamer obecnej metody
```

## 6. Słowa kluczowe `ref` i `out`
Służą do przekazywania argumentów przez referencję. Domyślnie, typy wartościowe (`int`, `struct`) są kopiowane przy wejściu do metody (co zajmuje czas i podwaja pamięć). Używając `ref` możemy pracować na oryginale.
- `ref`: Zmienna musi być zainicjalizowana przed wejściem.
- `out`: Zmienna nie musi (często nie może) być zainicjalizowana, ale metoda ma BEZWZGLĘDNY obowiązek przypisać do niej wartość zanim się skończy. (np. w `int.TryParse`).
