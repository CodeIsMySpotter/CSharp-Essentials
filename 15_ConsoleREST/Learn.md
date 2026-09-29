# Moduł 15: Klient REST API (`HttpClient`)

Prawie każda aplikacja dzisiaj musi komunikować się z Internetem. Niezależnie czy to pobranie kursu walut, weryfikacja użytkownika czy logowanie awarii – wszystko dzieje się przez ustandaryzowany protokół komunikacyjny HTTP i interfejsy REST API.

## 1. Architektura REST API
System po drugiej stronie (Serwer) odbiera tzw. Żądania (Requests) za pomocą słów (metod HTTP):
- `GET` - Daj mi zasób.
- `POST` - Utwórz nowy zasób (i przyjmij dane z Ciała/Body).
- `PUT` / `PATCH` - Zaktualizuj zasób.
- `DELETE` - Usuń zasób.

W odpowiedzi serwer zawsze rzuca **Kod Statusu (Status Code)** (np. `200 OK`, `404 Not Found`, `500 Server Error`).

## 2. Klasa `HttpClient` (Podstawy)
Do komunikacji sieciowej w C# używamy klasy `HttpClient`.

```csharp
// Najprostszy przykład:
using var client = new HttpClient();
string result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");
Console.WriteLine(result);
```
> **WAŻNE!** W prawdziwych, ogromnych aplikacjach nie używamy instrukcji `using` ani `new HttpClient()` za każdym razem! Może to doprowadzić do zjawiska "Socket Exhaustion" (wypalenia portów w systemie na płycie głównej). `HttpClient` powinno się współdzielić lub używać dedykowanego rozwiązania `IHttpClientFactory`.

## 3. Pobieranie całych Obiektów C# (Moduł `System.Net.Http.Json`)
Ponieważ komunikacja w 99% odbywa się za pomocą JSON, Microsoft stworzył dedykowane, potężne metody rozszerzające wewnątrz `System.Net.Http.Json` ucinające setki linii zbędnego kodu!
```csharp
// Pobiera JSON z sieci i NATYCHMIAST odwraca go (Deserializacja) do żywego, pięknego obiektu C#!
Post post = await client.GetFromJsonAsync<Post>("https://jsonplaceholder.typicode.com/posts/1");
```

## 4. Wysyłanie do API (Żądanie `POST`)
Odwrotna operacja to wrzucenie danych do Internetu:
```csharp
var nowyPost = new Post { Title = "Mój tytuł", Body = "Cześć!" };
// Sama zamieni C# -> JSON i natychmiast wyśle w sieć na serwer z metodą POST!
HttpResponseMessage response = await client.PostAsJsonAsync("https://jsonplaceholder.typicode.com/posts", nowyPost);

if (response.IsSuccessStatusCode) {
    Console.WriteLine("Dodano na serwer!");
}
```

## 5. Dodawanie Nagłówków (Headers)
Praktycznie każde API jest zablokowane. By przejść, potrzebujesz nagłówka z odpowiednim kodem uwierzytelnienia.
```csharp
client.DefaultRequestHeaders.Add("Authorization", "Bearer MÓJ_SEKRETNY_KLUCZ");
```

## 6. Szybkie wyłapywanie błędów
Odpowiedź zwracana w typie `HttpResponseMessage` ma doskonałą metodę pomocniczą do walidacji. Jeśli strzelisz gdzieś i wyrzuci np. 404 albo 500, metoda natychmiastowo zrzuci agresywny wyciątek `HttpRequestException`.
```csharp
var odp = await client.GetAsync("https://adres.com");
odp.EnsureSuccessStatusCode(); // Jeśli nie było zielono (200-299), wybucha wyciątek!
```

## 7. IHttpClientFactory
Jak wspomniano wyżej, zjawisko uderzania masowo 
ew HttpClient() generuje katastrofalny dla serwerów wyciek i zamrożenie dostępnych kanałów transmisyjnych (Socket Exhaustion). Dlatego w dojrzałych aplikacjach do zbioru DI (ServiceCollection) dodaje się services.AddHttpClient(), a następnie w klasach żąda się wstrzyknięcia interfejsu IHttpClientFactory. Następnie by wysłać zapytanie robi się po prostu ar client = factory.CreateClient();.

## 8. Formatowanie zwrotek (JsonPropertyName)
API publiczne w internecie często pisane są np. w Pythonie i zwracają JSON w formacie tzw. snake_case (np. "user_name": "Anna"). Twój kod C# korzysta jednak z konwencji PascalCase (UserName). Aby połączyć te światy przy automatycznej deserializacji, używaj w C# atrybutu [JsonPropertyName("user_name")] nad swoją właściwością klasową.
