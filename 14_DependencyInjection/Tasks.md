# Module 14 Tasks: Dependency Injection

## Zadanie 1: Twarde Powiązanie (Tight Coupling)
Napisz klasę `PdfGenerator`. Napisz klasę `ReportService`, która wewnątrz metody operacyjnej bezpośrednio używa `new PdfGenerator()`. Wywołaj logikę. Zobacz w kodzie namacalnie powiązanie utrudniające jakiekolwiek modyfikacje, np. zastąpienie generatora wariantem Excela. 

## Zadanie 2: Ręczne wstrzykiwanie (Constructor Injection)
Wprowadź interfejs `IGenerator`. Zmuś `PdfGenerator` do jego implementacji. W klasie `ReportService` stwórz konstruktor pobierający parametr typu `IGenerator` i przypisujący go do pola `_generator` typu `readonly`. Stwórz odpowiednie obiekty ręcznie w nowej metodzie i wstrzyknij obiekt. Zobacz na czym polega "zależność zewnętrzna" w surowej postaci.

## Zadanie 3: Użycie Kontenera `ServiceCollection`
Upewnij się, że projekt posiada wgraną (przez nuget) paczkę `Microsoft.Extensions.DependencyInjection`. Powołaj nowy wektor `ServiceCollection`. Zarejestruj w nim obie Twoje klasy używając najprostszej wersji `.AddTransient()`. Zbuduj fabrykę używając `.BuildServiceProvider()`. Skompiluj program, zaciągnij działający Serwis Raportowania za pomocą polecenia `GetRequiredService` bez pisania słowa kluczowego `new`. 

## Zadanie 4: Rejestracja Transient
Napisz prostą usługę losującą Guid lub numer `Random`. Zarejestruj ją w kontenerze jako `AddTransient`. Powołaj ją używając GetRequiredService dwukrotnie. Wyświetl właściwości instancji na konsoli udowadniając fakt, że są to w 100% zjawiska odseparowane sprzętowo w pamięci operacyjnej (nowe kopie).

## Zadanie 5: Rejestracja Singleton
Skopiuj kod i klasę z zadania ubiegłego, jednakże zarejestruj maszynę losującą poleceniem `.AddSingleton()`. Skonstruuj dwie żądania pobrania i udowodnij, że liczby dla całego ekosystemu są nagle współdzielone między sobą tak samo, od pierwszej sekundy działania.

## Zadanie 6: Rejestracja Scoped
Zarejestruj nową usługę przez polecenie `.AddScoped()`. Kontener systemowy `.CreateScope()` tworzy bąbel o nazwie `using var scope = provider.CreateScope();`. W pobraniach z `scope.ServiceProvider` zademonstruj na ekranie fakt, że zmienne ze środka bloku `scope` widzą ten sam współdzielony Singleton, niemniej jednak kolejny postawiony obok niego `using var scope2` wygeneruje swoje zupełnie własne instancje usługi! Jest to serce logiki systemów WEBowych ASP.NET.

## Zadanie 7: Mockowanie logiki
Skorzystaj z zarejestrowanej potężnej maszyny `ReportService` domagającej się IGeneratora. Bez dotykania klasy serwisu napisz w locie w pliku konfiguracyjnym klasę `TestGenerator` używającą tylko wypisów ekranowych w konsoli, podepnij ją przez interfejs do mechanizmu rejestracji i patrz jak z chirurgiczną precyzją Twoja aplikacja odpytująca się odmienia przy najmniejszej bezkosztowej rejestracji w jednym pliku konfiguracyjnym!

## Zadanie 8: Grupowanie wielu interfejsów (`IEnumerable<T>`)
Możesz rejestrować setki instancji tego samego wariantu uderzając np. wielokrotnie w linię: `services.AddTransient<IPlugin, ...>`. Ciekawostką jest to, że potężny C# bezbłędnie poradzi sobie gdy Twoja kolejna klasa wymusi parametry: `public PluginExecutor(IEnumerable<IPlugin> wtyczki)`. Wygeneruje gigantyczną paczkę ładując wszystko do środka! Odpal program sprawdzając działanie pętli aktywującej wtyczki.

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 9: DI i łapanie potężnych błędów wyjątku DI
Błąd "Unable to resolve service" śni się programistom .NET po nocach. Zmuś jakąkolwiek nową usługę w konstruktorze by chciała typ, którego celowo "zapomnisz" dodać linijką `.AddTransient`. Spowoduje to wybuchnięcie zjawiska `.GetRequiredService`. Oczywiście nie polegaj na silniku C# - bądź profesjonalistą z bloku wyjątku z modułu 6 i omiń awarię wyrzucając swój błąd na konsoli posługując się systemowym błędem operacji inwalidnej z użyciem instrukcji `.Message`.

## Zadanie 10: Zależności Async
Czas na fuzję. Powołaj serwis wykonujący proces `async Task Przetwarzaj()`. Następnie powołaj logikę do głównego piku I/O uruchamiając go w formacie async, by przekonać się że świat wstrzykiwania DI i Async doskonale współgra razem na polu operacji asynchronicznych.

## Zadanie 11: Zależności IO 
Zarejestruj pod kątem DI niezwykle mądrą instancję `FileLogger : ILogger`. Pozwól jej domyślnie rejestrować całą logikę wywołań posługując się wytycznymi z instrukcji `StreamWriter` w rurze I/O. Dowód na profesjonalny, separowany architekturowo model użycia zapisu!

## Zadanie 12: Fabryka na Słowniku Funkcji z udziałem DI (Func) 
Wyzwij potężne moce użycia delegatu Func i Kolekcji C# aby zbudować niezwykle pożądaną uderzeniowo Fabrykę! Zarejestruj po stronie systemu kontener DI ze słownikiem `Dictionary<string, Func<IOperation>>` w której wstrzykniesz sobie mechanikę posługiwania odpowiednimi operacjami. Wywołaj je w systemie.
