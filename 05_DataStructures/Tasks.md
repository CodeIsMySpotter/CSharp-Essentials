# Module 5 Tasks: Data Structures (Struct, Enum, Record)

W tym module przećwiczymy konstrukcje takie jak klasy, struktury, enumeratory (enum) oraz rekordy, realizując 15 osobnych zadań w osobnych plikach.

## Zadanie 1: Definicja Enum dla Statusu
Zdefiniuj typ `enum OrderStatus` reprezentujący stany zamówienia: `New`, `InProgress`, `Completed`, `Canceled`. Wypisz wartości enuma na konsolę.

## Zadanie 2: Struktura współrzędnych
Stwórz strukturę (`struct`) `Coordinates` posiadającą właściwości `X` i `Y` (typu `double`). Struktura powinna być niemutowalna (tylko do odczytu). Utwórz instancję i wypisz jej wartości.

## Zadanie 3: Rekord dla dokumentu
Zdefiniuj typ `record DeliveryDocument`, który ma `Id` (int), `Address` (string) oraz właściwość `Location` (typu `Coordinates` z Zadania 2). Porównaj dwie instancje z takimi samymi danymi przy użyciu operatora `==`.

## Zadanie 4: Typy wartościowe vs referencyjne
Zdefiniuj klasę `PointClass` oraz strukturę `PointStruct`. Stwórz instancje obu typów, przypisz je do nowych zmiennych, zmodyfikuj wartości nowych zmiennych, a następnie wypisz na ekran wartości oryginałów, aby zaobserwować różnice w kopiowaniu referencji vs wartości.

## Zadanie 5: Enum z atrybutem [Flags]
Stwórz enum `UserPermissions` z atrybutem `[Flags]` (flagi bitowe): `None` (0), `Read` (1), `Write` (2), `Execute` (4). Przypisz do zmiennej uprawnienia `Read` oraz `Write`. Sprawdź i wypisz na konsolę (np. używając `HasFlag`), czy występuje uprawnienie `Execute`.

## Zadanie 6: Nieniszcząca mutacja rekordu (with)
Na podstawie rekordu `DeliveryDocument` (stwórz nową podobną definicję dla tego zadania) utwórz nowe zamówienie ze zmienionym adresem, korzystając ze słowa kluczowego `with`. Wypisz na ekran stary i nowy rekord (pokaż, że pierwszy się nie zmienił).

## Zadanie 7: Konstruktory w strukturach
Stwórz strukturę `Rectangle` z konstruktorem przyjmującym `width` i `height`. Jeśli któraś wartość jest ujemna, rzuć wyjątek `ArgumentException`. Zbuduj poprawny obiekt i wypisz go.

## Zadanie 8: Parsowanie Enum ze stringa
Symuluj pobranie od użytkownika statusu jako `string` (np. `"Completed"`). Użyj `Enum.TryParse` aby bezpiecznie zamienić tekst na typ `OrderStatus` (Zadanie 1) i wypisz zrekonstruowany status.

## Zadanie 9: Składnia pozycyjna rekordów
Utwórz rekord `Product` z wykorzystaniem krótkiej składni pozycyjnej (np. `record Product(int Id, string Name);`). Utwórz instancję, zrób dekonstrukcję do osobnych zmiennych (deconstruct) i wypisz je.

## Zadanie 10: Inicjalizacja tablic (struktury a klasy)
Stwórz tablicę dla struktur `Coordinates` (Zadanie 2) na 10 elementów. Pokaż, że wszystkie wartości domyślnie są zainicjalizowane `0` bez używania słowa `new` (wystarczy pętla wypisująca wartości). Następnie pokaż, że dla tablicy obiektów `PointClass` obiekty w tablicy wynoszą początkowo `null`.

## Zadanie 11: Zwracanie wielu wartości za pomocą krotek (ValueTuple)
Napisz metodę, która przyjmuje tablicę liczb całkowitych i zwraca krotkę (ValueTuple) zawierającą wartość minimalną i maksymalną z tej tablicy. Wywołaj metodę, użyj dekonstrukcji do osobnych zmiennych `min` i `max`, a następnie wypisz je na konsolę.

## Zadanie 12: Zastosowanie `record struct`
Zdefiniuj `record struct` o nazwie `Vector3` z polami `X`, `Y` i `Z`. Pokaż, że instancje tego typu domyślnie są porównywane po wartościach (utwórz dwa wektory o takich samych parametrach i użyj `==`). Następnie utwórz nowy wektor na bazie jednego z nich, modyfikując pole `Z` za pomocą operatora `with`.

## Zadanie 13: Typy anonimowe (Anonymous Types)
Wyobraź sobie, że dostałeś bardzo złożony obiekt (np. klasę o 20 właściwościach) i potrzebujesz z niego wyciągnąć tylko dwie do wypisania. Stwórz typ anonimowy posiadający właściwości `Title` (np. `"Harry Potter"`) i `Year` (`1997`). Wypisz te wartości z typu anonimowego.

## Zadanie 14: Zjawisko Boxing i Unboxing
Stwórz zmienną typu wartościowego, na przykład `double` o wartości `3.14`. Wykonaj proces _boxing_ przypisując ją do typu `object`. Następnie wykonaj _unboxing_ próbując zrzutować ją (błędnie) na typ `int` – zobaczysz wyjątek `InvalidCastException`. Popraw _unboxing_ zrzutowując na poprawny typ `double` i wypisz wynik.

## Zadanie 15: Porównanie wbudowanych metod w `record`
Utwórz rekord (tradycyjny `record class`) reprezentujący pracownika: `record Employee(string Name, int Salary)`. Utwórz instancję tego rekordu i wypisz ją bezpośrednio do konsoli: `Console.WriteLine(employee);`. Zauważysz, że kompilator domyślnie wygenerował przydatną reprezentację napisową (metodę `ToString()`), w przeciwieństwie do zwykłych klas, które wypisują tylko nazwę swojego typu.

## Zadanie 16: Pętla foreach i instrukcja switch (Enum)
Wykorzystaj enum `OrderStatus` z Zadania 1. Utwórz tablicę zawierającą kilka różnych statusów zamówienia. Przeiteruj po tablicy za pomocą pętli `foreach` i dla każdego statusu użyj instrukcji `switch` (lub wyrażenia `switch`), aby wypisać dedykowany komunikat dla danego stanu.

## Zadanie 17: Tablica rekordów i pętla for
Wykorzystaj rekord `Product` z Zadania 9. Utwórz tablicę 5 różnych produktów. Używając klasycznej pętli `for`, przeiteruj po tablicy i wypisz na konsolę tylko te produkty, których `Id` jest liczbą parzystą (użyj operatora modulo `%`).

## Zadanie 18: Pętla while i nieniszcząca mutacja (with)
Zdefiniuj `record struct Player(string Name, int Health)`. Utwórz instancję gracza z np. 100 punktami zdrowia. W pętli `while` (wykonującej się dopóki gracz żyje, czyli `Health > 0`) symuluj otrzymywanie obrażeń: w każdej iteracji twórz nowy stan gracza z mniejszą ilością zdrowia (np. o 15), korzystając ze słowa kluczowego `with`. Wypisz zdrowie po każdym uderzeniu.

## Zadanie 19: Flagi bitowe w pętli do-while
Zdefiniuj zmienną przechowującą uprawnienia bazując na `UserPermissions` z Zadania 5 (na start przypisz `None`). Używając pętli `do-while` symuluj nadawanie kolejnych uprawnień. W każdej iteracji (np. 3 razy) dodaj nowe uprawnienie za pomocą operatora bitowego OR (`|`). Po zakończeniu pętli wypisz końcowy zestaw uprawnień.

## Zadanie 20: Krotki w pętli foreach i warunki
Utwórz tablicę krotek `(string Name, int Age)` reprezentujących osoby. Użyj pętli `foreach`, aby przejść przez wszystkie elementy. Podczas iteracji dokonaj dekonstrukcji krotki na osobne zmienne i użyj instrukcji `if`, aby wypisać na konsolę tylko te osoby, które mają 18 lub więcej lat.
