# Module 6 Tasks: Wyjątki (Exceptions) i Obsługa Błędów

## Zadanie 1: Podstawy try-catch
Napisz program proszący użytkownika o podanie liczby. Użyj metody `int.Parse()`. Otocz wywołanie blokiem `try-catch`. Wyłap `FormatException` jeśli użytkownik poda litery i wypisz "Podano nieprawidłowy format". Jeśli wpisze poprawną liczbę, wypisz ją na ekran.

## Zadanie 2: Różne typy wyjątków
Stwórz tablicę 3-elementową. Zapytaj użytkownika o indeks (od 0 do 5) oraz dzielnik. Oblicz wartość: `100 / tablica[indeks] / dzielnik`. Zabezpiecz kod łapiąc OSOBNO wyjątki: `IndexOutOfRangeException` (zły indeks), `DivideByZeroException` (zły dzielnik) oraz ogólny `Exception` dla reszty nieprzewidzianych błędów.

## Zadanie 3: Użycie bloku finally
Napisz metodę `ReadData()`, która wewnątrz bloku `try` rzuca `InvalidOperationException`. Następnie dodaj blok `catch` i blok `finally`. W bloku `finally` wypisz "Zwalnianie zasobów operacyjnych...". Udowodnij wywołując metodę w programie, że komunikat z `finally` wypisze się pomimo wcześniejszego wystąpienia błędu.

## Zadanie 4: Wyrzucanie wyjątków (Fail-Fast)
Napisz metodę `SetAge(int age)`. Metoda na samym początku powinna sprawdzić, czy `age < 0` lub `age > 120`. Jeśli tak jest, powinna natychmiastowo rzucić `ArgumentOutOfRangeException`. Wywołaj metodę w `Main` z błędną wartością (np. 150) i złap ten wyjątek, wyświetlając w bloku catch właściwość `ex.Message`.

## Zadanie 5: Własny wyjątek (Custom Exception)
Stwórz klasę `InvalidPasswordException` dziedziczącą po `Exception`. Następnie napisz metodę `RegisterUser(string password)`. Jeśli przekazane hasło ma mniej niż 8 znaków, rzuć swój własny wyjątek z komunikatem "Hasło jest zbyt krótkie!". Przetestuj działanie w programie głównym.

## Zadanie 6: Re-throwing i StackTrace
Napisz metodę `MethodA`, która rzuca jakikolwiek wyjątek (np. `throw new Exception("Błąd A");`). Następnie stwórz `MethodB`, która wywołuje `MethodA` ujętą w bloku `try-catch`. Wewnątrz `catch` w `MethodB` wpisz słowo `throw;`. 
W sekcji `Main` wywołaj `MethodB` w osobnym bloku `try-catch` i wypisz na konsolę właściwość `ex.StackTrace`. 
Potem wróć do `MethodB` i zmień `throw;` na `throw ex;`. Zobacz, jak w `Main` zmieniła się zawartość logowanego śladu stosu (powinieneś stracić informację o tym, że problem powstał w `MethodA`).

## Zadanie 7: Filtry wyjątków (when)
Napisz metodę, która pobiera z klawiatury od użytkownika liczbowy kod błędu HTTP. Wygeneruj wyjątek `Exception` (lub np. `HttpRequestException`, jeśli potrafisz go skonstruować). Użyj tylko jednego bloku `try`, ale napisz kilka bloków `catch (Exception ex) when (...)` do wyłapania i logowania specyficznych sytuacji, np. kodu 404 (wypisz: "Nie znaleziono") oraz 500 (wypisz: "Błąd serwera").

## Zadanie 8: InnerException (Opakowywanie wyjątków)
Wyobraź sobie procedurę odczytu pliku konfiguracyjnego. Napisz blok `try` rzucający ręcznie wyjątek `FileNotFoundException`. W pasującym bloku `catch`, złap go, ale zamiast go obsługiwać, wyrzuć całkowicie nowy wyjątek (np. `ApplicationException`), przekazując pierwotny wyjątek `FileNotFoundException` do jego konstruktora (jako InnerException). W procedurze nadrzędnej (np. `Main`) wyłap ten `ApplicationException` i używając instrukcji `if` odczytaj oraz wypisz właściwość `InnerException`.

## Zadanie 9: Unikanie wyjątków (Wydajność)
Masz podany zmienną: `string input = "abc";`. Napisz fragment kodu, który NIE UŻYWA struktury `try-catch`, a pomimo to bezpiecznie próbuje zamienić tego stringa na liczbę typu integer, w razie niepowodzenia ustawiając wartość zmiennej na domyślną `0`. (Podpowiedź: użyj metody `.TryParse()`).

---

## Projekt Zaliczeniowy: Silnik Transakcji Bankowych (GDD)

Twoim ostatecznym celem w tym module jest stworzenie małego rdzenia systemu bankowego, realizującego przelewy środków. 

### Zadanie 10: Klasy i Wyjątki Bankowe
Stwórz własny wyjątek `InsufficientFundsException` (dziedziczący po `Exception`). Stwórz też klasę `Account` z polem `Balance` (stan konta typu `decimal`).

### Zadanie 11: Metoda Transfer
Napisz w `Account` metodę `Transfer(Account target, decimal amount)`. 
- Jeżeli `amount > 10000`, system ma uznać przelew za podejrzany (Anti-Fraud) i natychmiast rzucić wbudowany wyjątek `InvalidOperationException`.
- Jeżeli `Balance < amount`, rzuć swój wyjątek `InsufficientFundsException`.
- W przeciwnym razie odejmij kwotę z bieżącego konta i dodaj do konta `target`.

### Zadanie 12: Obsługa i Audyt
W metodzie `Main` stwórz dwa konta, przypisz im początkowe środki i uruchom proces przelewu dużej kwoty, używając pełnego bloku `try-catch-finally`.
Złap w oddzielnych blokach `catch` błąd "Anti-Fraud" oraz "Brak Środków", wypisując odpowiednie ostrzeżenia dla użytkownika. 
W bloku `finally` wypisz obowiązkowo komunikat *"Zakończono połączenie transakcyjne z bazą danych."*, aby zagwarantować, że niezależnie od wyniku (sukces czy awaria) zostawimy poprawny ślad audytowy i zamkniemy zasoby.
