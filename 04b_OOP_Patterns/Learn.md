# Moduł 4b: Wzorce Projektowe (Design Patterns)

Wzorce projektowe to uniwersalne, sprawdzone rozwiązania częstych problemów architektonicznych w programowaniu obiektowym. Pozwalają pisać kod czysty, skalowalny i czytelny dla innych programistów.

## 1. Singleton
Zapewnia, że w całym programie istnieje **tylko jedna** instancja danej klasy (np. główne ustawienia aplikacji, połączenie z bazą danych). Osiąga się to poprzez zablokowanie publicznego konstruktora i udostępnienie obiektu przez statyczną właściwość.

```csharp
public class Configuration
{
    private static Configuration _instance;
    
    // Prywatny konstruktor - nikt z zewnątrz nie zrobi 'new Configuration()'
    private Configuration() { }

    public static Configuration Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Configuration();
            }
            return _instance;
        }
    }

    public string DbConnectionString { get; set; } = "Server=myServer;Database=myDB;";
}
```

## 2. Fabryka (Factory Pattern)
Zamiast tworzyć obiekty bezpośrednio używając słowa `new` w kodzie klienckim, delegujemy to zadanie do specjalnej klasy "Fabryki". Przydaje się, gdy na podstawie jakiegoś parametru (np. `enum`) musimy zdecydować, którą klasę pochodną zwrócić.

```csharp
public static class EnemyFactory
{
    public static IEnemy CreateEnemy(string type)
    {
        switch (type.ToLower())
        {
            case "orc": return new Orc();
            case "troll": return new Troll();
            default: throw new ArgumentException("Nieznany przeciwnik");
        }
    }
}
```

## 3. Budowniczy (Builder Pattern)
Rozwiązuje problem konstruktorów, które przyjmują ogromną ilość parametrów (tzw. anty-wzorzec *Telescoping Constructor*). Pozwala konstruować skomplikowany obiekt krok po kroku w sposób czytelny, korzystając z tzw. *Fluent API*.

Sekretem tego wzorca jest to, że każda metoda modyfikująca (np. `SetColor`) na samym końcu **zwraca samą siebie** (`return this;`), dzięki czemu możemy "łączyć" wywołania za pomocą kropek.

### Przykład Implementacji:

```csharp
// 1. Docelowa klasa, którą chcemy zbudować
public class Car 
{
    public string Color { get; set; }
    public string Engine { get; set; }
    public string Seats { get; set; }
}

// 2. Klasa Budowniczego
public class CarBuilder
{
    // Budowniczy trzyma w środku "pusty" obiekt, który będzie konfigurować
    private Car _car = new Car();

    // Metoda konfigurująca - zwraca aktualnego buildera (this)!
    public CarBuilder SetColor(string color)
    {
        _car.Color = color;
        return this; 
    }

    public CarBuilder SetEngine(string engine)
    {
        _car.Engine = engine;
        return this;
    }

    public CarBuilder SetSeats(string seats)
    {
        _car.Seats = seats;
        return this;
    }

    // Ostatnia metoda zwraca już gotowy obiekt i kończy proces budowania
    public Car Build()
    {
        return _car;
    }
}
```

### Użycie w kodzie (Klient):
Zamiast pisać trudnego do rozczytania konstruktora: `new Car("Red", "V8", "Leather")`...
Robimy to tak:

```csharp
Car myCar = new CarBuilder()
                .SetColor("Red")
                .SetEngine("V8")
                .SetSeats("Leather")
                .Build();
```
