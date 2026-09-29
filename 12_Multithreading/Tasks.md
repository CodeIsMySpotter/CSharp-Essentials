# Module 12 Tasks: Wielowątkowość i Zrównoleglanie

## Zadanie 1: Klasyczny Wątek
Napisz metodę wypisującą 10 razy w konsoli znak "-". Uruchom ją w dedykowanym obiekcie nowo powstałego `new Thread()`. Wywołaj z niego metodę `.Start()`. Bezpośrednio po starcie pętli wydrukuj 10 znaków "+". Uruchom aplikację. Zauważ, w jaki sposób obydwa wątki drukują swoje znaki, przeplatając wynik.

## Zadanie 2: ThreadPool
Utwórz metodę symulującą uciążliwe sprawdzanie (np. pętla z `Thread.Sleep(500)` na 3 interwały). Kolejkuj ją w domyślnej puli systemowej używając `ThreadPool.QueueUserWorkItem(...)`. 

## Zadanie 3: Race Condition (Wyścig wątków z błędem)
Zdefiniuj statyczną zmienną `int totalSum = 0`. W zadaniu uruchom pętlę generującą 10 zupełnie nowych wątków. Każdy z wątków uruchamia pętlę podbijającą 100 000 razy zmienną: `totalSum++`. 
Gdy wszystkie wątki skończą się dodawać, wynikiem powinno być `1 000 000`. Ku twojemu zdziwieniu wynik będzie mniejszy, losowy i błędny. Obserwujesz klasyczny i niezwykle trudny w debugowaniu błąd wielowątkowy.

## Zadanie 4: Synchronizacja (`lock`)
Skopiuj cały mechanizm usterki z Zadania 3. Przygotuj globalnego kłódkę: `private static readonly object _lockObj = new object();`. Owij zjawisko podbijania (`totalSum++`) w klamry bloku `lock(_lockObj)`. Przetestuj, że wynik wraca do wzorowego pułapu za cenę wydajności.

## Zadanie 5: Synchronizacja bezblokująca (`Interlocked`)
Skopiuj klasę znowu i zamiast używać obciążającego procesor zjawiska "lock", zastąp podbijanie klasą bezpośredniej modyfikacji rzędu sprzętowego procesora: `Interlocked.Increment(ref totalSum);`. Przetestuj wzorowy rezultat.

## Zadanie 6: Task Parallel Library (Pętla Parallel.For)
Przygotuj bardzo ciężkie wyliczenia (np. zawiłe obroty w klasie `Math`). Użyj konstrukcji `Parallel.For(0, 1000000, i => { ... })`. Porównaj chociażby orientacyjnie to wykonanie względem klasycznej pętli `for`.

## Zadanie 7: Parallel.ForEach i Kolekcje
Zbuduj potężną listę np. 50 000 identyfikatorów z ciągami znaków do haszowania. Użyj nowej, najwydajniejszej konstrukcji: `Parallel.ForEach(bazaId, id => { ... })` w celu zrównoleglenia zadań do każdego fizycznego rdzenia serwera w tym samym momencie. 

## Zadanie 8: Anulowanie/Wstrzymanie Parallel Loop
Zbuduj pętlę `Parallel.For`. Parametr przekazywanej tam anonimowej metody obsługuje tak naprawdę typ pomocniczy: `(i, state) => ...`. Mając obiekt `state`, skorzystaj z reguły `if`, aby sprawdzić, czy numer jest podzielny przez chociażby równe 43 255. Kiedy w końcu uderzysz w cyfrę - zatrzymaj zrównolegloną rzeź poprzez polecenie `state.Break();`.

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 9: Kolekcje współbieżne (`ConcurrentBag`) + TPL
Stwórz zwykłą `List<int>`. Wewnątrz pętli `Parallel.For(0, 1000, ...)` dodawaj pozycje na tę listę używając operacji `.Add()`. Otrzymasz drastyczne uszkodzenie (wyjątek IndexOutOfRangeException na listingu). Zamień kolekcję na `ConcurrentBag<int>` wykorzystaną przy asystowaniu z biblioteki `System.Collections.Concurrent`. Zweryfikuj naprawienie architektury.

## Zadanie 10: Wyjątki `AggregateException` z pętli równoległych
Pętla `Parallel.ForEach` zachowuje się tak samo bezwzględnie, kiedy wiele rdzeni na raz zrzuca błędy (np. `DivideByZeroException` w co którymś rekordzie bazy). Podobnie jak przy Async, kompilator połączy błędy rzucone przez różne wątki robocze w jeden wielki `AggregateException`. Przećwicz łapanie go z pętli Parallel i iterowanie po liście ubytków.

## Zadanie 11: Task.Run() jako brama do ThreadPool (Integracja z Async)
To, co w Async'u jest powolnym pytaniem do API, w TPL jest ogromnie procesorową pracą w systemie. Jeżeli piszesz aplikację GUI i użytkownik wciśnie "Przelicz model 3D", nie możesz zablokować mu przycisku ani pętli renderowania programu. Opakuj obciążającą metodę procesorową w operację asynchroniczną poprzez nakładkę oddelegowującą obliczenia do puli wątków w tle: `await Task.Run(() => MojePrzeliczanieNaBierzaco());`.

## Zadanie 12: Domknięcia pętli względem delegatów (Poważny Closure Bug)
Zbuduj w klasycznej metodzie `Main` zwykłą pętlę `for(int i = 0; i < 5; i++)`. W jej wnętrzu twórz i uruchamiaj nowe obiekty `Thread`. W każdym wątku wypisuj `Console.WriteLine(i);`. Ze względu na upośledzenie mechanizmu "Closure", program wcale nie wypisze 0, 1, 2, 3, 4, lecz losowe liczby lub tylko i wyłącznie liczbę `5`. Napraw ten popularny i morderczy błąd w kodowaniu na serwerach kopiując `i` do zupełnie odciętej od środowiska zmiennej lokalnej (np. `int tmp = i;`) w każdej nowej iteracji tuż pod barierą definicji `for`.
