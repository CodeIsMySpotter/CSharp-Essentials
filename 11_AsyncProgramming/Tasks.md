# Module 11 Tasks: Programowanie Asynchroniczne

## Zadanie 1: Podstawy `async/await` i `Task.Delay`
Napisz metodę asynchroniczną `MakeTeaAsync`, która zwraca `Task`. Metoda ma wypisać "Gotowanie wody...", po czym poczekać asynchronicznie (bez blokowania wątku) 2 sekundy używając `Task.Delay`, i na końcu wypisać "Woda ugotowana, herbata gotowa!". Wywołaj z użyciem `await` w głównej pętli.

## Zadanie 2: Zwracanie wartości z `Task<T>`
Stwórz metodę `CalculateHugeNumberAsync`, która ma opóźnienie 1.5 sekundy, a następnie zwraca liczbę (np. `42`). Metoda musi mieć sygnaturę `async Task<int>`. Odbierz wynik wywołania przy pomocy słowa kluczowego `await` i wypisz na ekranie.

## Zadanie 3: Kontynuacje (bez `await`) za pomocą `.ContinueWith`
Wywołaj metodę `CalculateHugeNumberAsync` z zadania 2, ale celowo **nie** używaj przed nią słowa `await`. Zamiast tego, od razu podepnij do zwróconego taska akcję: `mojTask.ContinueWith(t => Console.WriteLine(t.Result));`. Udowodnij, że główny wątek (lub inna linijka poniżej) rusza od razu, nie czekając na zakończenie liczenia.

## Zadanie 4: Zrównoleglanie zadań (`Task.WhenAll`)
Stwórz metodę `DownloadFakeDataAsync(int id, int delayMs)`, która czeka podany czas i zwraca id. 
W `Main` wystartuj (nie używaj await!) trzy różne pobierania, zachowując je jako trzy zmienne typu `Task<int>`. 
Na koniec zawołaj jedną, wspólną asynchroniczną linię `await Task.WhenAll(...)` i wypisz z niej wyniki (będą to połączone wyniki jako tablica).

## Zadanie 5: Wyścigi asynchroniczne (`Task.WhenAny`)
Wykorzystaj te same 3 zadania z symulacją pobierania, ale tym razem daj im zupełnie różne, nieprzewidywalne czasy z klasy `Random`. Przekaż wszystkie taski do funkcji `Task.WhenAny(...)`. Wynikiem `WhenAny` będzie najszybszy task. Wypisz z niego ID ("Serwer nr X opowiedział jako pierwszy").

## Zadanie 6: Anulowanie zadań (`CancellationToken`)
Przygotuj metodę `EndlessLoopAsync(CancellationToken token)`. Wewnątrz metody umieść nieskończoną pętlę `while(true)`. W każdym przejściu pętli upewnij się, że używasz metody `token.ThrowIfCancellationRequested()` oraz `await Task.Delay(500)`. 
Z poziomu zewnętrznego utwórz `CancellationTokenSource`, przekaż token do metody, a na zewnątrz, np. po naciśnięciu dowolnego klawisza, wywołaj `.Cancel()` przerywając nieskończoną pętlę bez siłowego ubijania aplikacji.

## Zadanie 7: Synchroniczne czekanie (.Wait i .Result) - Antywzorzec
Wywołaj jakąś powolną metodę asynchroniczną. Jednak w `Main` ZAMIAST `await` na jej końcu (takiego, które pozwala aplikacji dalej działać w tle) przypnij na siłę użycie metody `.Wait()`. Pamiętaj, że w klasycznej aplikacji konsolowej nie jest to tak tragiczne (robi to co Thread.Sleep), ale w aplikacjach UI/WEB wywołanie blokuje główny wątek zamrażając całkowicie interfejs. Zrozum ten antywzorzec.

## Zadanie 8: Obsługa błędów i wyjątków
Napisz metodę `ThrowErrorAsync`, która czeka 1 sekundę i rzuca wyciątek `InvalidOperationException`. Wywołaj to zadanie korzystając z `await` we wnętrzu potężnego bloku `try-catch`. Udowodnij sobie, że mimo asynchroniczności, wyjątki zachowują się logicznie i klasycznie wlatują prosto do bloku `catch`.

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 9: LINQ + Async (Równoległe mapowanie)
Utwórz tablicę lub listę 10 numerów identyfikacyjnych (od 1 do 10). Użyj operatora LINQ `.Select(id => PobierzDaneBazyAsync(id))`, aby błyskawicznie wygenerować 10 równoległych żądań asynchronicznych (utworzy to strukturę `IEnumerable<Task<string>>`). Przekaż ten zbiór zadań do `Task.WhenAll` by odczekać na złączenie wszystkich odpowiedzi. W ten sposób używasz pięknego połączenia potęgi LINQ i Asynchroniczności!

## Zadanie 10: Exception Management + AggregateException
Gdy używasz `Task.WhenAll()` a uszkodzeniu (wyjątkowi) ulegnie kilka tasków jednocześnie, kompilator po wyrzuceniu błędu zgrupowuje to w strukturze zwanej `AggregateException`. Uruchom 3 taski przez `WhenAll`, niech dwa z nich sypną błędami. Wyłap `AggregateException` i przeiteruj w pętli `foreach` po jego właściwości `.InnerExceptions`, aby wypisać pojedyncze komunikaty wszystkich błędów.

## Zadanie 11: Delegaty (Func) + Async (Dynamiczne operacje)
Utwórz słownik, który zmapuje nazwę operacji ("Download", "Upload", "Ping") na metodę asynchroniczną. Typem w słowniku powinno być np. `Dictionary<string, Func<Task<string>>>`. 
Odpytaj użytkownika o akcję i wykonaj odpowiedniego taska ze słownika logując efekt wykonania.

## Zadanie 12: Memory / GC (Zwalnianie zasobów z CancellationTokenSource)
Klasa `CancellationTokenSource` zarządza niezarządzanymi zasobami OS. Oznacza to, że po skończonej pracy NALEŻY zawołać na nim `.Dispose()`. Zmodyfikuj Zadanie 6 o anulowaniu. Zastosuj nowy typ konstrukcji `using var cts = new CancellationTokenSource();`, aby udowodnić sobie potężną kontrolę pamięciową tego elementu (GC samodzielnie zwolni uchwyt, kiedy praca zostanie wykonana).
