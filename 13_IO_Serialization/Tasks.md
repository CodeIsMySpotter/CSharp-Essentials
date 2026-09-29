# Module 13 Tasks: Wejście/Wyjście (I/O) i Serializacja

## Zadanie 1: Prosty zapis pliku (Klasa `File`)
Stwórz folder używając klasycznej statycznej metody `Directory.CreateDirectory`. Następnie wywołaj instrukcję `File.WriteAllText(...)` by utworzyć nowy plik ".txt" i zapisać w nim Twoje imię. Potwierdź zajściem operacji sprawdzając czy fizycznie pojawił się na dysku obok projektu.

## Zadanie 2: Bezpieczne budowanie ścieżek (`Path`)
Przygotuj zmienne z nazwą folderu ("MojKatalog") oraz nazwą pliku ("dane.json"). Wykorzystaj bezpieczną instrukcję `Path.Combine(...)` by połączyć te oba stringi. System automatycznie uwzględni poprawne separatory ścieżki (slashe) bazujące na Twoim systemie operacyjnym! Wypisz na konsoli gotową wygenerowaną ścieżkę.

## Zadanie 3: Pisanie Strumieniowe (`StreamWriter`)
Wyobraź sobie, że piszesz wielki plik (log systemowy aplikacji). Zadeklaruj w nowoczesnym stylu blokowy wektor czyszczenia zasobów: `using var writer = new StreamWriter("logi.txt");`. Wrzuć w nim pętle 10 iteracyjną i wywołuj w niej `writer.WriteLine(...)`. 

## Zadanie 4: Czytanie Strumieniowe (`StreamReader`)
Utwórz obiekt czytający do pliku z Zadania 3: `using var reader = new StreamReader("logi.txt");`. Użyj pętli `while`. Instrukcja warunkowa brzmi: dopóki metoda `reader.ReadLine()` **nie zwraca null** (null oznacza koniec fizyczny pliku), przypisuj jej wynik i drukuj w konsoli na żywo wiersz po wierszu. 

## Zadanie 5: JSON Serializacja (Eksport)
Utwórz jakąś publiczną klasę (np. `Car` z marką, rocznikiem itp.) i zadeklaruj jej instancję w kodzie. Użyj silnika `JsonSerializer.Serialize(...)` by przetrawić potężny C# obiekt na płaski tekst JSON i natychmiast zapisz wygenerowanego stringa do pliku "auto.json" posługując się wiedzą z pierwszego zadania.

## Zadanie 6: JSON Deserializacja (Import / Ożywianie)
Z poziomu nowego zadania użyj polecenia `File.ReadAllText(...)` aby załadować ciąg tekstowy z pliku "auto.json". Teraz zawołaj odwrotne polecenie wskrzeszające: `JsonSerializer.Deserialize<Car>(text)`. Wypisz wartości nowo powstałego w pamięci RAM obiekta by potwierdzić sukces operacji.

## Zadanie 7: Opcje JSON'a (Pretty Print)
Zrób to samo co w Zadaniu 5. Dodaj jednakże dodatkowy parametr podczas wywołania `.Serialize(obiekt, opcje)`. Skonstruuj instancję `JsonSerializerOptions` z ustawioną właściwością `WriteIndented = true`. Zobacz fizyczny powstały dokument i uciesz oczy formatowaniem, które stało się perfekcyjnie wcięte i ludzkie dla oka.

## Zadanie 8: Atrybuty (`[JsonIgnore]`)
Zbuduj nową publiczną klasę `UserAccount`. Niech posiada właściwości takie jak Email oraz Haslo. Hasło oznacz specjalnym atrybutem nad właściwością, nazywającym się `[JsonIgnore]`. Zaserializuj go. Zajrzyj do pliku "uzytkownik.json" i przekonaj się o ogromnym bezpieczeństwie mechanizmu – silnik absolutnie przemilczał zrzuconą informację, zostawiając hasło bezpieczne tylko i wyłącznie wewnątrz obracającej się pamięci na serwerze!

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 9: Wyjątki przy operacjach I/O (File + Exceptions)
W środowiskach systemowych pliki to udręka w postaci problemów dostępu. Utwórz blok `try-catch`. W sekcji `try` spróbuj bezwzględnie przeczytać plik o chociażby wyimaginowanej nazwie używając `File.ReadAllText("NIGDZIENIEMA.txt")`. Silnik wrzuci wyjątek, ponieważ taki byt nie istnieje. Wyłap specyficzny wariant `FileNotFoundException` (uwaga, możesz też dla testu zablokować uprawnienia swojemu docelowemu plikowi i próbować chwytać błąd `UnauthorizedAccessException`).

## Zadanie 10: Asynchroniczność w Operacjach I/O (IO + Async)
Operacje dyskowe potrafią trawić program niezwykle długo z punktu widzenia działania rdzenia procesora. Na szczęście dysk SSD i klasa `File` wspierają pętle TPL i delegaty! Zaprojektuj klasę startową w Zadaniu 10 zwracającą `Task`. Zapisz ten sam plik I/O, ale zamiast metody blokującej - zastąp ją asynchronicznym wariantem awansowanym: `await File.WriteAllTextAsync(...)`. Zyskasz wydajność bez zblokowanego ekranu użytkownika.

## Zadanie 11: Magia LINQ sprzężonego ze strumiem (LINQ + IO)
Mając plik (np. "numery.txt" złożony z miliona liczb gdzie każda jest w nowej linii) użyj innej wspaniałej metody – `File.ReadLines()`. Wraca ona typu `IEnumerable<string>`. Odpala się ona ze swoistym Deferred Execution nie ładując wszystkiego w RAM. Dopnij wprost do jej powołania filtrator LINQ `.Where(n => ...)` na poszukiwanie liczb np. zaczynających się na "3". 
Natychmiast przepuść potok wygenerowany przez LINQ z powrotem do funkcji: `File.WriteAllLines("przefiltrowane.txt", ...)` – zobaczysz niesamowity zapis pliku z jednoczesnym generowaniem nowej listy.

## Zadanie 12: Wyjątki przy ożywianiu JSON (Wyjątki + Serialization)
Podaj z błędem napisanego JSON'a wprost w zmiennej systemowej, w którym zapomnisz zamknąć cudzysłowie: `string brokenJson = "{ \"Imie\": Jan }";` 
Rzuć to na pożarcie w paszczę komendy rzeźbiącej `.Deserialize()`. Kompilator oburzy się wyrzucając `JsonException`. Złap go i wyrzuć swoją upiększoną wiadomość.
