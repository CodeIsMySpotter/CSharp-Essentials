# Module 9 Tasks: LINQ (Language Integrated Query)

## Zadanie 1: Filtrowanie i transformacja (Where + Select)
Zbuduj listę kilku słów (różnej długości). Użyj `Where`, by wybrać słowa dłuższe niż 5 znaków, a na wyniku użyj od razu `Select`, by zamienić te słowa na WIELKIE litery (`.ToUpper()`). Na koniec dodaj `.ToList()` i wypisz je.

## Zadanie 2: Sortowanie (OrderBy i OrderByDescending)
Stwórz listę liczb. Użyj LINQ, aby posortować ją najpierw malejąco, wypisać, a następnie posortować rosnąco i wypisać. 

## Zadanie 3: FirstOrDefault vs First
Zrób pustą `List<int> pustalista = new List<int>();`. Wyciągnij z niej element używając `.FirstOrDefault()` i wypisz (powinno pojawić się `0`). Następnie użyj `.First()` i otocz kod blokiem `try-catch` łapiącym `InvalidOperationException`. Zrozum, dlaczego `FirstOrDefault` jest bezpieczniejszy.

## Zadanie 4: Sprawdzanie kolekcji (Any / All)
Mając listę `int`, użyj metody `.Any(x => ...)` aby wypisać tekst "Lista zawiera liczby ujemne!" jeśli choć jedna będzie ujemna. Następnie sprawdź używając `.All(x => ...)` czy wszystkie liczby na liście są mniejsze niż 100.

## Zadanie 5: Grupowanie danych (GroupBy)
Stwórz typ anonimowy dla miast np. `new { Miasto = "Warszawa", Kraj = "Polska" }`. Stwórz listę kilku miast (z Polski, Niemiec itp.). Użyj `.GroupBy(x => x.Kraj)`. Przeiteruj przez wyniki (każdy element grupowania ma `.Key` z nazwą kraju oraz wewnątrz zawiera obiekty pasujące do tej grupy).

## Zadanie 6: Operatory agregujące (Max, Min, Average, Sum)
Bawiąc się prostą listą płac (np. `decimal`ów), wypisz z użyciem jednej linijki LINQ: Całkowity koszt (`Sum`), Najwyższą pensję (`Max`), Najniższą pensję (`Min`) i średnią płacę w firmie (`Average`).

## Zadanie 7: Unikalność (Distinct)
Podano listę `new List<int> { 1, 2, 2, 3, 3, 3, 4 }`. Użyj metody `.Distinct().ToList()` by pozbyć się powtórzeń. Wypisz czystą listę na ekranie.

## Zadanie 8: Deferred Execution (Odroczone wykonanie)
Stwórz listę `[1, 2, 3]`. Wykonaj zapytanie: `var query = list.Where(x => x > 1);`. 
NASTĘPNIE dodaj do oryginalnej listy `list.Add(5);`. 
Przeiteruj w pętli `foreach` po zmiennej `query`. Zauważ, że `5` również się wypisało pomimo dodania do listy PÓŹNIEJ niż wykonano zapytanie! Dzieje się tak, ponieważ `query` uruchamia filtrowanie dopiero przy starcie pętli `foreach`. 

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 9: Rekordy + LINQ (Analiza koszyka)
Utwórz rekord `Product(string Name, decimal Price, bool IsAvailable)`. Skompletuj `List<Product>`. Połącz `Where` (tylko dostępne produkty) z `Average` (`Average(p => p.Price)`), by policzyć jaka jest średnia cena obecnie dostępnych na stanie towarów.

## Zadanie 10: Delegaty + LINQ (Zewnętrzny Func)
LINQ bierze jako argument po prostu delegaty. Przygotuj na zewnątrz (przed zapytaniem) zmienną: `Func<int, bool> myCustomFilter = x => x % 3 == 0;`. Przekaż ją jako argument do metody `.Where(myCustomFilter)`. Zobacz, że zachowuje się dokładnie tak samo jak wpisanie lambdy wprost między nawiasy.

## Zadanie 11: Zdarzenia rzucające wyjątki a LINQ Single()
Użyj `Single()` na liście w celu znalezienia elementu po ID, ale zrób to na danych, gdzie przez pomyłkę podano dwoje ludzi z takim samym ID. `Single` natychmiast rzuci `InvalidOperationException` z komunikatem o więcej niż 1 pasującym elemencie. Wyłap go i wyświetl: "Naruszenie spójności bazy danych: Wykryto duplikat ID".

## Zadanie 12: Dictionary z LINQ (ToDictionary)
Mając listę obiektów `User(int Id, string Username)`, użyj metody rozszerzającej LINQ: `.ToDictionary(...)`. Jako pierwszy argument (lambdę) podaj z czego system ma wziąć **Klucz** (czyli `u => u.Id`), a jako drugi - z czego ma wziąć **Wartość** (`u => u.Username`). Zobaczysz błyskawiczną i bezpętlową transformację Listy na piękny, przeszukiwalny Słownik.
