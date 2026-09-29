# Moduł 14: Dependency Injection (Wstrzykiwanie Zależności)

Wstrzykiwanie zależności (Dependency Injection, DI) to technika pozwalająca na tworzenie luźno powiązanych (loosely coupled) komponentów w aplikacji. Stanowi filar nowoczesnego C# i jest wbudowane w sam rdzeń platformy .NET.

## 1. Problem twardego powiązania (Tight Coupling)
Jeśli Klasa `A` w swoim środku samodzielnie tworzy obiekt klasy `B` poprzez `new B()`, to mówimy, że jest od niej twardo uzależniona.
```csharp
public class UserService
{
    private EmailSender _sender = new EmailSender(); // ZŁO!
}
```
Dlaczego to problem? Nie da się przetestować klasy `UserService` bez prawdziwego wysyłania maili. Trudno też w przyszłości podmienić powiadomienia na SMS.

## 2. Inversion of Control (IoC) i Constructor Injection
Zamiast tworzyć obiekty samodzielnie, klasa powinna **żądać** ich w konstruktorze pod postacią Interfejsów!
```csharp
public interface IMessageSender { void Send(); }

public class UserService
{
    private readonly IMessageSender _sender;

    // Konstruktor wymusza podanie zależności!
    public UserService(IMessageSender sender)
    {
        _sender = sender;
    }
}
```

## 3. Kontenery DI w .NET (ServiceCollection)
Nie musimy samodzielnie tworzyć dziesiątek obiektów (tzw. kompozycja). Używamy do tego fabryki - Kontenera (wymaga biblioteki `Microsoft.Extensions.DependencyInjection`).

```csharp
var services = new ServiceCollection();
// Uczymy system: "Gdy ktoś poprosi o IMessageSender, daj mu obiekt EmailSender"
services.AddTransient<IMessageSender, EmailSender>();
services.AddTransient<UserService>();

var provider = services.BuildServiceProvider();
// Kontener sprytnie zauważy, że UserService potrzebuje IMessageSender i złoży to sam!
var userService = provider.GetRequiredService<UserService>();
```

## 4. Cykle życia obiektów (Lifetimes)
Gdy rejestrujesz serwis, musisz określić jak długo ma on żyć:
- **`Transient`** – Za każdym razem gdy ktoś prosi o obiekt, dostanie jego absolutnie NOWĄ kopię (jak z `new`).
- **`Singleton`** – Zostanie utworzony TYLKO RAZ przy pierwszym żądaniu. Każdy element aplikacji przez całe jej działanie będzie współdzielił ten sam fizyczny obiekt.
- **`Scoped`** – Żyje tak długo, jak długo żyje tzw. Scope (używane głównie w aplikacjach WEB, gdzie jeden Scope = Jedno odpytanie od użytkownika przez przeglądarkę).

## 5. Mockowanie (Atuty dla testów)
Dzięki takiej architekturze, by przetestować `UserService`, nie uruchamiamy prawdziwej bazy czy poczty. Rejestrujemy w kontenerze po prostu klasę testową `MockEmailSender` podpinając pod interfejs `IMessageSender`. Gotowe!

## 6. Wstrzykiwanie Kolekcji i Wzorzec Fabryki
DI w .NET jest bardzo inteligentne. Jeżeli do interfejsu (np. IPlugin) zarejestrujesz kilka różnych klas, a potem w konstruktorze zażądasz IEnumerable<IPlugin>, kontener bez problemu złoży całą kolekcję wszystkich implementacji i wstrzyknie ją naraz!
Możesz także wstrzykiwać delegaty Func<IPlugin>, co działa jak bezpieczna Fabryka w locie (generowanie instancji na żądanie).

## 7. Obsługa błędów DI
Najpopularniejszy błąd kontenera to InvalidOperationException: Unable to resolve service.... Oznacza to, że zażądałeś w konstruktorze zależności, której wcześniej zapomniałeś dopisać (zarejestrować) w zbiorze ServiceCollection. Zawsze musisz zdefiniować regułę tworzenia każdego żądanego elementu!
