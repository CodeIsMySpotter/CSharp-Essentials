# Moduł 12: Wielowątkowość i Zrównoleglanie (Multithreading & TPL)

Wielowątkowość w C# pozwala na uruchamianie wielu operacji w tym samym czasie. Służy przede wszystkim do operacji obciążających procesor (**CPU-Bound**), takich jak masowe przeliczanie matematyczne, generowanie grafiki, czy przetwarzanie ogromnych tablic. 

Zauważ, że w przypadku operacji sieciowych i baz danych powinieneś używać omówionego wcześniej Programowania Asynchronicznego (`async/await`), a nie wielowątkowości!

## 1. Klasy `Thread` i `ThreadPool`
Kiedyś wszystko opierało się na klasie `Thread`, co pozwalało odpalić nowy fizyczny wątek w systemie. Było to jednak ciężkie pamięciowo. Z tego powodu powstała pula wątków (`ThreadPool`), czyli koszyk gotowych, uśpionych wątków do ponownego użycia.
```csharp
Thread t = new Thread(() => Console.WriteLine("Praca..."));
t.Start();
t.Join(); // Czeka aż wątek skończy
```

## 2. Pętle Równoległe (Task Parallel Library - TPL)
Dzisiaj zamiast ręcznego tworzenia wątków, używamy TPL i wbudowanych super-szybkich pętli równoległych do przeliczania wielkich zbiorów.
```csharp
// Zamiast foreach (var x in lista)
Parallel.ForEach(lista, element => {
    // Obliczaj coś równolegle na wielu rdzeniach CPU!
});
```

## 3. Wyścigi Wątków (Race Conditions)
Jeżeli odpalisz wiele wątków i spróbujesz w nich jednocześnie zmieniać jedną zmienną, np. dodając `counter++`, wynik będzie błędny. Operacja `++` to tak naprawdę odczyt, dodanie i zapis. Różne rdzenie procesora wejdą sobie w drogę i nadpiszą swoje wyniki. 

## 4. Synchronizacja (Blokowanie dostępu - `lock`)
Aby temu zapobiec, możemy zablokować kawałek kodu, wpuszczając do niego w danym momencie tylko jeden wątek naraz. Najprostszą formą w C# jest `lock`.
```csharp
private static readonly object _locker = new object();

lock (_locker) 
{
    counter++; // Kod bezpieczny wątkowo
}
```

## 5. Prędkość a `Interlocked`
Użycie `lock` rozwiązuje sprawę, ale bardzo zwalnia (wątki czekają w kolejce, a zrównoleglenie traci sens). 
Dla prostych działań (np. liczników) procesor pozwala użyć operacji atomowych dzięki klasie `Interlocked`. Są niesamowicie szybkie i nie wymagają lockowania.
```csharp
Interlocked.Increment(ref counter);
```

## 6. Kolekcje współbieżne
Zwykłe zbiory np. `List<T>` czy `Dictionary` **NIE SĄ** bezpieczne wątkowo (tzw. Thread-Safe). Przy próbie zapisu przez dwa wątki rzucą błąd lub zniszczą strukturę pamięci. Zamiast nich w wielowątkowości używaj klasy z przestrzeni `System.Collections.Concurrent` takich jak `ConcurrentBag<T>`, `ConcurrentDictionary` czy `ConcurrentQueue`.

## 7. Błędy wielowątkowe (AggregateException i Closure)
- **AggregateException**: Ponieważ TPL (np. Parallel.For) wykonuje wiele akcji na raz, jeśli kilka z nich rzuci wyjątek, system nie wyrzuci jednego błędu. Zbije je wszystkie w "pojemnik" zwany AggregateException, który musisz rozpakować (właściwość .InnerExceptions), by zobaczyć co dokładnie wybuchło.
- **Closure Bug (Domknięcia w pętlach)**: Uruchamiając nową logikę poboczną (np. Thread lub Task) wewnątrz klasycznej pętli or(int i = 0...) z użyciem zmiennej i, wątek poboczny zobaczy końcową (lub losową) wartość i, a nie tę z momentu iteracji. Aby temu zaradzić, zawsze twórz zmienną tymczasową wewnątrz pętli: int temp = i;.
