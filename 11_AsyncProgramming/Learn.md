# Moduł 11: Programowanie Asynchroniczne

Programowanie asynchroniczne (`async`/`await`) pozwala wykonywać zadania w tle (np. pobieranie plików, zapytania do bazy danych) **bez blokowania** głównego wątku aplikacji. Jest to absolutny standard we współczesnym C#.

## 1. Słowa kluczowe `async`, `await` oraz typ `Task`
Metoda asynchroniczna zazwyczaj zwraca typ `Task` (jeśli nic nie zwraca, odpowiednik `void`) lub `Task<T>` (jeśli zwraca wartość). 
Aby użyć `await` wewnątrz metody, musi być ona oznaczona modyfikatorem `async`.
Słowo `await` wstrzymuje wykonanie *danej metody* dopóki `Task` się nie zakończy, ale "oddaje sterowanie" wyżej, zapobiegając zamrożeniu aplikacji.

```csharp
public async Task<string> DownloadWebsiteAsync()
{
    Console.WriteLine("Rozpoczynam pobieranie...");
    // Symulacja długiej operacji, np. zapytania HTTP
    await Task.Delay(2000); 
    return "<html>...</html>";
}
```

## 2. Równoległe zadania: `Task.WhenAll` i `Task.WhenAny`
Jeśli musisz wykonać kilka operacji, nie czekaj na nie w pętli. Uruchom je razem!
```csharp
Task<int> task1 = PobierzDaneAsync(1);
Task<int> task2 = PobierzDaneAsync(2);

// Czeka aż OBA się zakończą
int[] results = await Task.WhenAll(task1, task2); 

// Czeka aż PIERWSZY z nich się zakończy
Task<int> winner = await Task.WhenAny(task1, task2);
```

## 3. Anulowanie zadań: `CancellationToken`
Aby móc przerwać asynchroniczną operację w trakcie jej trwania, potrzebujemy mechanizmu Tokenów.
```csharp
var cts = new CancellationTokenSource();
CancellationToken token = cts.Token;

// gdzieś w tle po 1 sekundzie chcemy to anulować:
cts.CancelAfter(1000); 

try {
    await DługaOperacjaAsync(token); // Metoda musi przyjąć i obsługiwać ten token!
} 
catch (TaskCanceledException) {
    Console.WriteLine("Anulowano!");
}
```

## 4. Metody `.Wait()` oraz `.Result` (Unikaj!)
W starym kodzie (lub jeśli musisz połączyć kod synchroniczny z asynchronicznym) czasem używa się np. `task.Wait()` by poczekać na wynik. **Należy tego unikać!** W środowiskach takich jak ASP.NET potrafi to zablokować główny wątek na śmierć (zjawisko tzw. *Deadlock*). Zawsze staraj się polegać na `await` przez całą ścieżkę aplikacji ("Async all the way").

## 5. Różnica pomiędzy Thread (Wątek) a Task (Zadanie)
- **Thread (Wątek):** Fizyczny twór w systemie operacyjnym. Ciężki, drogi w utworzeniu, zżera megabajty RAM-u na własny stos.
- **Task (Zadanie):** Lekka, abstrakcyjna obietnica C#, że dana praca "kiedyś się skończy". Jeden wątek potrafi obsłużyć dziesiątki tysięcy oczekujących Tasków asynchronicznych (dzięki strukturze zjawiska nazywanej maszyną stanów - *State Machine*).
