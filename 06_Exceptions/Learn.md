# Moduł 6: Wyjątki (Exceptions) i Obsługa Błędów

Często program musi poradzić sobie z sytuacją awaryjną (np. brak pliku na dysku, zerwane połączenie, błędne dane). W C# do kontrolowanego zarządzania takimi "awariami" używamy **Wyjątków (Exceptions)**. Zamiast zwracać kody błędów, rzucamy wyjątkami.

## 1. Łapanie Wyjątków: `try - catch - finally`
Dzięki temu blokowi program nie zawiesi się, gdy wystąpi błąd.
```csharp
try
{
    // Kod, który potencjalnie może zgłosić błąd
    int zero = 0;
    int result = 10 / zero;
}
catch (DivideByZeroException ex)
{
    // Ten kod wykona się TYLKO, gdy wystąpi DivideByZeroException
    Console.WriteLine($"Nie dziel przez zero! Komunikat: {ex.Message}");
}
catch (Exception ex)
{
    // Catch-all: Ten kod wykona się przy każdym INNYM błędzie
    Console.WriteLine($"Wystąpił nieznany błąd: {ex.Message}");
}
finally
{
    // Ten kod wykona się ZAWSZE (niezależnie czy błąd był, czy nie).
    // Służy najczęściej do zamykania połączeń (np. do bazy danych) lub plików.
    Console.WriteLine("Zakończono operację.");
}
```

## 2. Rzucanie (Zgłaszanie) Wyjątków: `throw`
Jeśli Twoja metoda napotka na błędne argumenty lub niepożądany stan, zamiast kontynuować błędne działanie, powinna od razu "rzucić" wyjątek. To mechanizm tzw. *Fail-Fast*.

```csharp
public void Deposit(decimal amount)
{
    if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), "Kwota wpłaty musi być dodatnia!");
    }
    // Dalsza logika...
}
```

## 3. Re-throwing: `throw;` vs `throw ex;`
Często chcemy tylko zalogować błąd i przekazać go wyżej, do metody wywołującej. 
**Złota zasada:** Zawsze używaj samego `throw;`. Użycie `throw ex;` kasuje oryginalny tzw. *Stack Trace* (ślad stosu - informację w jakiej linijce pliku zaczął się błąd).

```csharp
try 
{
    ProcessData();
}
catch (Exception ex)
{
    Logger.LogError(ex);
    throw; // DOBRZE: Zachowuje oryginalny StackTrace.
    // throw ex; // ŹLE: Wygląda jakby błąd zaczął się w tej linijce kodu (kasuje stos).
}
```

## 4. Filtry Wyjątków (Exception Filters)
Dodane w C# 6.0, pozwalają na łapanie wyjątków tylko wtedy, gdy spełniony jest dodatkowy warunek (słowo kluczowe `when`).

```csharp
try
{
    CallApi();
}
catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
{
    Console.WriteLine("Nie znaleziono zasobu (404).");
}
catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.InternalServerError)
{
    Console.WriteLine("Błąd serwera (500).");
}
```

## 5. InnerException (Wyjątki zagnieżdżone)
Czasami chwytamy nisko-poziomowy wyjątek (np. błąd SQL) i chcemy wyrzucić wyżej wyjątek biznesowy (np. błąd rejestracji), ale nie chcemy tracić informacji o oryginalnym błędzie. Przekazujemy wtedy stary wyjątek jako argument do nowego.

```csharp
try
{
    SaveToDatabase();
}
catch (SqlException ex)
{
    // Zamykamy bazodanowy błąd (ex) w nowym własnym wyjątku biznesowym
    throw new UserRegistrationException("Rejestracja użytkownika nie powiodła się.", ex);
}
```
Właściwość `InnerException` w nowym błędzie wyżej będzie zawierała dostęp do oryginalnego wyjątku z bazy SQL.

## 6. Własne Wyjątki (Custom Exceptions)
Jeśli standardowe wyjątki w .NET nie oddają natury biznesowej problemu, tworzymy własne poprzez dziedziczenie po klasie `Exception`. Ich nazwy zawsze powinny kończyć się słowem `Exception`.

```csharp
public class InsufficientFundsException : Exception
{
    // Podstawowy konstruktor
    public InsufficientFundsException() : base("Brak środków na koncie.") { }

    // Konstruktor z własną wiadomością
    public InsufficientFundsException(string message) : base(message) { }

    // Konstruktor do obsługi InnerException
    public InsufficientFundsException(string message, Exception inner) : base(message, inner) { }
}
```

## 7. Dobrze wiedzieć (Wydajność)
Rzucanie wyjątków jest bardzo wolne w porównaniu do zwykłych instrukcji warunkowych (`if`). Nie używaj wyjątków do sterowania zwykłą logiką (ang. *control flow*) aplikacji (np. do pętli lub walidacji logowania jeśli tego da się uniknąć). Wyjątki powinny być zarezerwowane dla sytuacji **wyjątkowych**. Jeśli możesz, używaj metod takich jak `int.TryParse` zamiast ujęcia `int.Parse` w `try-catch`.
