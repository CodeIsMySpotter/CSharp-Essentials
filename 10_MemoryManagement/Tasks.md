# Module 10 Tasks: Zarządzanie Pamięcią (Memory Management)

## Zadanie 1: Implementacja IDisposable
Stwórz klasę `DbConnection`, która implementuje interfejs `IDisposable`. W konstruktorze wypisz "Otwarto połączenie". Wymuś zaimplementowanie metody `Dispose()` i w niej wypisz "Zamknięto połączenie". Przetestuj w `Main` ręczne tworzenie i wywoływanie `Dispose()`.

## Zadanie 2: Konstrukcja `using` (Tradycyjna)
Zmodyfikuj użycie klasy `DbConnection` z Zadania 1. Zamiast wywoływać `.Dispose()` ręcznie, zamknij jej tworzenie w klamrach `using (...) { }`. Udowodnij komunikatami na ekranie, że po wyjściu z klamer połączenie zostanie automatycznie zamknięte.

## Zadanie 3: Konstrukcja `using` (Nowoczesna - C# 8.0)
Zrób to samo co wyżej, ale bez użycia klamer. Zadeklaruj `using var db = new DbConnection();`. Wypisz pod spodem jakiś inny tekst i zobacz, w którym dokładnie momencie kompilator samodzielnie wywoła zwalnianie (na końcu zakresu metody).

## Zadanie 4: GC.Collect()
Stwórz pętlę, która wygeneruje kilkadziesiąt tysięcy stringów (np. łącząc je `+`). Przed pętlą wypisz `GC.GetTotalMemory(false)`. Po pętli wypisz to samo. Następnie wymuś ręczne sprzątanie za pomocą `GC.Collect()` i po raz trzeci wypisz stan pamięci. Zobacz, ile RAM-u udało się odzyskać.

## Zadanie 5: Sprawdzanie Generacji Obiektu (Generations)
Stwórz jakikolwiek nowy obiekt (np. nową instancję `object` lub Listę). Użyj `GC.GetGeneration(obiekt)` by sprawdzić, do którego pokolenia trafił na starcie (powinno być 0). Następnie wymuś `GC.Collect()` i sprawdź generację tego obiektu jeszcze raz. Skoro przetrwał sprzątanie (nadal trzymasz do niego zmienną), jego generacja powinna awansować do 1.

## Zadanie 6: Wyciek Pamięci przez listę statyczną
Zdefiniuj w klasie pomocniczej statyczną listę `public static List<object> Leak = new();`. W metodzie `Main` stwórz w pętli tysiące obiektów i za każdym razem dodawaj je do listy `Leak`. Wymuś `GC.Collect()`. Zobaczysz, że pamięć nie zostanie wyczyszczona, ponieważ statyczna lista utrzymuje aktywne linki (referencje) do tych obiektów aż do zamknięcia programu.

## Zadanie 7: Słowo kluczowe `ref`
Napisz metodę `void DoubleValue(ref int number)`, która podwoi podaną liczbę (`number *= 2`). W `Main` stwórz zmienną `int x = 5;` i wywołaj metodę (pamiętaj o dopisaniu `ref` w wywołaniu). Wypisz zmienną `x` na ekran (dzięki ref zmieni się na 10 bez używania słowa `return`).

## Zadanie 8: Słowo kluczowe `out`
Napisz metodę `void GetDimensions(out int width, out int height)`, wewnątrz której po prostu przypisz zmiennym wartości (np. 1920 i 1080). W `Main` użyj składni wywołania `GetDimensions(out int w, out int h);` i wypisz obie zmienne na ekranie. Zauważ, że nie musiałeś ich nigdzie inicjalizować wcześniej.

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 9: Wyciek Pamięci przez zdarzenia (Eventy + GC)
Zdarzenia (Events) to drugie najczęstsze miejsce wycieków po listach statycznych!
Stwórz publiczny event w statycznej klasie np. `Publisher`. Następnie stwórz obiekt `Subscriber`, który w konstruktorze wpina swoją lokalną metodę do eventu (używając `+=`). Następnie wyrzuć `Subscriber` ze swojego kodu (np. `sub = null;`). 
Mimo użycia `GC.Collect()`, ten obiekt nie zostanie sprzątnięty, bo wciąż istnieje połączenie ze statycznego `Publishera`. Spróbuj opisać to w komentarzach w swoim kodzie. (M.in. dlatego zawsze pamiętamy o używaniu `-=`).

## Zadanie 10: Kolekcje + GC (.Clear vs null)
Stwórz gigantyczną listę obiektów. Wypisz zajętą pamięć. Następnie wykonaj operację `lista.Clear()`, zrób `GC.Collect()` i wypisz pamięć. Następnie zamiast `Clear`, użyj przypisania `lista = null;`, zrób znowu `GC.Collect()` i wypisz. Zauważ różnicę w działaniu samego odśmiecacza wobec kontenera listy.

## Zadanie 11: IDisposable + Wyjątki
Stwórz interfejs `IDisposable` na klasie `FileWriter`. W metodzie `Write()` celowo rzuć `InvalidOperationException`. 
Otocz użycie tej klasy klasycznym blokiem `try-catch`, ale bez użycia własnego `finally`. Zainicjalizuj obiekt przy użyciu deklaracji `using var file = new FileWriter()`. Zauważ na wyjściu konsoli (Dispose powinno wypisać "Zwalniam zasoby"), że kompilator zadbał o to, by sprzątanie wykonało się MOCĄ BLOKU USING pomimo wcześniejszej wysypki programu, działając niczym niewidzialny blok `finally`.

## Zadanie 12: Yield Return vs ToList (Wydajność pamięciowa w LINQ)
Napisz metodę `IEnumerable<int> GenerateNumbers()`, która w pętli od 1 do miliona oddaje liczby poprzez polecenie `yield return i;`. 
W `Main` użyj wywołania tej metody i następnie operacji `LINQ .Take(5)`. Ponieważ pętla połączy się leniwie z LINQ, zostanie wylosowanych i przekazanych do pamięci TYLKO 5 pierwszych obiektów, a program natychmiast ruszy dalej z zerowym niemal zużyciem. Skontrastuj to dopisaniem do wygenerowania końcówki `.ToList().Take(5)` i zaobserwuj, co dzieje się z pamięcią.
