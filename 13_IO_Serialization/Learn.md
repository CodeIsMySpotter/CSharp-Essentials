# Moduł 13: Wejście/Wyjście (I/O) i Serializacja

Zapisywanie danych do plików oraz ładowanie ich z powrotem to fundament większości systemów. Przestrzeń nazw `System.IO` dostarcza wszystkich niezbędnych narzędzi.

## 1. Operacje na ścieżkach, plikach i folderach
C# ułatwia proste zarządzanie I/O za pomocą tzw. klas statycznych "pomocników": `Path`, `File` oraz `Directory`.
```csharp
// Path.Combine uodparnia na złe ukośniki (w Windows to \, a w Linux /)
string filePath = Path.Combine("C:\\Katalog", "dane.txt");

if (!Directory.Exists("C:\\Katalog"))
{
    Directory.CreateDirectory("C:\\Katalog");
}

// Najprostszy sposób zapisu i odczytu całych plików:
File.WriteAllText(filePath, "Witaj świecie!");
string tekst = File.ReadAllText(filePath);
```

## 2. Strumienie (Streams)
Kiedy plik ma np. 2 Gigabajty, użycie `File.ReadAllText` wyrzuci brak pamięci RAM. Wtedy wchodzą **Strumienie (Stream)**, pozwalające zaciągać plik kawałek po kawałku. Ponieważ otwarty plik to zasób sprzętowy (OS trzyma na nim blokadę - tzw. *lock*), zawsze używamy z nimi instrukcji `using`!

```csharp
using var writer = new StreamWriter("duzy_plik.txt");
writer.WriteLine("Pierwsza linia"); // Pisze na bieżąco, nie ładując całości w RAM

using var reader = new StreamReader("duzy_plik.txt");
string line = reader.ReadLine(); // Odczyta jeden wiersz
```

## 3. Serializacja (JSON)
Gdy masz w kodzie rozbudowany obiekt, powiedzmy `List<User>`, nie będziesz pisał pętli sklejającej go do tekstu własnoręcznie. Użyjesz **Serializacji**. To proces zmiany z obiektu C# (w pamięci) na płaski ciąg znaków, a **Deserializacja** działa w odwrotną stronę.

Standardem zapisu w programowaniu jest format **JSON**. W C# używamy wbudowanej klasy `JsonSerializer` z `System.Text.Json`.
```csharp
var osoba = new { Imie = "Jan", Wiek = 30 };

// C# Obiekt -> string (JSON)
string json = JsonSerializer.Serialize(osoba); 
// json to: {"Imie":"Jan","Wiek":30}

// String JSON -> C# Obiekt (musimy podać w trójkątnych nawiasach Oczekiwany Typ)
var ozywiony = JsonSerializer.Deserialize<TypOsoba>(json);
```

## 4. Opcje Serializacji i Atrybuty
Możesz sterować tym jak klasa zachowuje się podczas "przerabiania na płasko":
- `[JsonIgnore]` – ignoruje pole (np. pole Hasło - nigdy nie chcemy wyeksportować go do JSONa pliku!).
- `[JsonPropertyName("name")]` – w kodzie masz `Imie`, a w JSON wymusisz zmianę klucza na `"name"`.
- Klasa konfiguracji w kodzie: `new JsonSerializerOptions { WriteIndented = true }` – sprawi, że JSON będzie wygenerowany przejrzyście w wielu enterach z wcięciami, idealnie do odczytu przez człowieka.
