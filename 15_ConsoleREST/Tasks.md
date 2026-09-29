# Module 15 Tasks: Klient REST API (HttpClient)

## Zadanie 1: Klasyczny strzał GET (`GetStringAsync`)
W klasie statycznej zainicjalizuj instancję obiektu `HttpClient`. Wykorzystując najprostszą asynchroniczną polecajkę `.GetStringAsync(...)` strzel do darmowego i bezpiecznego testowego API: `https://jsonplaceholder.typicode.com/todos/1`. Wydrukuj otrzymany, darmowy surowy ciąg znaków (string) na konsoli w ramach testów, że Twój kod faktycznie łączy się ze światem!

## Zadanie 2: Odzyskiwanie żywych obiektów (`GetFromJsonAsync`)
Zadeklaruj gdzieś klasę publiczną `Todo`, posiadającą identyczne właściwości co te z zadania pierwszego (`UserId`, `Id`, `Title`, `Completed`). Skopiuj wywołanie i podmień uderzenie na potężną metodę `.GetFromJsonAsync<Todo>(...)` z przestrzeni nametagowej `System.Net.Http.Json`. Ciesz się żywym, silnie typowanym kodem C# wskrzeszonym natychmiast z internetu i wypisz właściwość `Title`.

## Zadanie 3: Przesyłanie POST z C# bezpośrednio na Serwer
Wygeneruj całkiem nowy żywy element klasy `Todo`. Podeślij ten element w locie na endpoint `https://jsonplaceholder.typicode.com/todos` w uderzeniu o architekturze `POST`, korzystając z analogicznej metody rozszerzającej `.PostAsJsonAsync(...)`. Zdobądź pełną odpowiedź zwracaną od metody typu `HttpResponseMessage`. Odczytaj pożądany kod statusu na ekran (`StatusCode`), aby udowodnić czy zgadza się on z pomyślnym przyjęciem `201 Created`.

## Zadanie 4: Wysyłanie nagłówków `Headers` (Uwierzytelnianie)
Niezwykle rzadko strzela się w internecie anonimowo. Skorzystaj z właściwości instancji klienta `DefaultRequestHeaders.Add(...)`. Zamontuj wewnątrz potężny fałszywy nagłówek o kluczu klienta `"Authorization"` oraz wielkim testowym stringu jako value: `"Bearer f4k3T0k3N"`. Następnie wystrzel prośbę ponownie. Oczywiście JSON Placeholder na to nie patrzy, jednakże sprawdź czy nic nie wybuchło.

## Zadanie 5: Bezwzględne rozbijanie Exceptions na Status Codes (`EnsureSuccessStatusCode`)
Strzel zwykłym `GetAsync(...)` w całkowicie nieprawdziwy link po stronie JSON Placeholdera, np. `https://jsonplaceholder.typicode.com/NIC_TUTAJ_NIE_MA`. Następnie na obiekcie wywołaj najsłynniejszą na .NET komendę weryfikującą: `.EnsureSuccessStatusCode();`. Odpal całość będąc schowanym w bloku obronnym `try-catch` by gładko i profesjonalnie przechwycić potwornego rodem `HttpRequestException` rzucanego przez wściekły kompilator wyłapujący zły status odpowiedzi.

## Zadanie 6: Odczytywanie w locie obcej winy JSON 
Gdy strzał się psuje, najczęściej nie korzysta się z `EnsureSuccess`, tylko odbiera się błędnego JSONa z komunikatem obcej platformy i deserializuje wprost do swojego obiektu, by np. wypisać błąd użytkownikowi. Po nieudanym `GetAsync` zczytaj JSON pod postacią surową (`.Content.ReadAsStringAsync()`) i udowodnij wydrukiem, że tam również obca platforma próbuje się z Tobą komunikować odrzucając odpowiedź obiektową w standardowym kodowaniu UTF8.

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 7: HttpClientFactory vs Kontener Wstrzykiwania Zależności (DI)
Użycie `new HttpClient()` jest potężnym błędem produkcyjnym rzucającym serwery na kolana zjawiskiem `Socket Exhaustion` (zajęcie portów). Pociągnij z powrotem mechanizm Kontenerów modułu 14. Skonfiguruj `ServiceCollection`, uderz nowo załadowaną paczkę instalacyjną (w .NET zainstaluj pakiet `Microsoft.Extensions.Http`), uderzając komendę `services.AddHttpClient();`.
Wstrzyknij profesjonalnie do serwisu typ `IHttpClientFactory` powołując żądane instancje do działania liniami `factory.CreateClient()`.

## Zadanie 8: Async/TPL z gigantyczną siecią
Będziesz teraz robił sztuczny wyścig w sieć (tzw. zjawisko DDoS, lecz tu z rozwagą!). Zbuduj tablicę liczb 1-10. Przekształć je poprzez wbudowane LINQ i mechanizm `Select` rzucając aż 10 wariantów delegata `GetAsync` na poszukiwanie taska: `"https://jsonplaceholder.typicode.com/posts/{id}"`. Użyj super maszynowni `await Task.WhenAll(...)` poznanej przy Asynchroniczności, zdobywając wszystkie wyścigi w błyskawicznym ułamku ms bez żadnego przyciętego działania i pętli zjawiska zjawisk "one by one".

## Zadanie 9: Rzutowanie wrogich kluczy (Attributes)
API często posługują się językiem i zjawiskiem składni Pythonowskiej, zwracając parametry w systemie snake_case: `user_id`. Twój C# brzydzi się czymś takim, odczytując tylko format `UserId`. Zbuduj na swojej testowej klasie atrybut `[JsonPropertyName("user_id")]` zdefiniowany przy serializacji wyłapujący błąd składni, spajając w pełni zautomatyzowane formaty odmiennych konwencji w jedno zgodne repozytorium. Wypisz załadowaną propercję w wariancie C#.

## Zadanie 10: Przenoszenie mechanizmów `Delegates` nad warstwę błędów Logów (Action)
Zadeklaruj na metodzie obrabiającej zapytania opcjonalny domyślny parametr wyzwalający zdarzenie awaryjne: `Action<string> logErrorHandler`. Przy nadejściu `HttpRequestException` odpal wywołanie mechanizmu handlera odsyłając na dół informację: `Wykryto kolosalny błąd API REST: {BŁĄD}!`. Na zewnątrz przetestuj go, wysyłając jako handler anonimową lambdę `=> Console.WriteLine(...)`.

## Zadanie 11: Mechanizmy zapytań URI z użyciem LINQ i Słowników
Wysyłanie stringów jak `?id=5&name=Bartek` rzeźbione na "brudno" stringami typu interpolowanego (`$"..?id={x}"`) to straszny nawyk. Stwórz słownik argumentów zapytania: `Dictionary<string, string>`. 
Użyj potężnych komend LINQ, sklejających zapytanie poprzez agregaty String.Join i operacje `x => $"{x.Key}={x.Value}"`, wytwarzając czytelny, gigantyczny generator ścieżki i sklejonego URI!

## Zadanie 12: Wycieki zasobów sprzętowych (Memory Management - IDisposable)
Metoda bazowa obiektu `.GetAsync` w tle zwraca `HttpResponseMessage`. Czytałeś w powiązanych artykułach przy zjawisku zarządania pamięcią, że powiązania sprzętowe, do których należy strumień sieciowy protokołu TCP w otwartym powiązaniu żądania bez zwalniania zmuszają GC (Garbage Collector) do niesamowitych katuszy. Udowodnij fakt zamknięcia odbieranego żądania pod weryfikatorem mechanizmu użycia `using var response = ...`, aby po przeczytaniu rzetelnie domknąć okno odpowiedzi protokołu (a nie liczyć, że usunie go maszyna odśmiecająca).
