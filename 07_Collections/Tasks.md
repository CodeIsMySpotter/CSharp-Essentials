# Module 7 Tasks: Kolekcje (Collections)

## Zadanie 1: Lista (Podstawy)
Utwórz `List<int>`. Dodaj do niej w pętli liczby od 1 do 10. Następnie użyj metody `.Remove()` aby usunąć liczbę 5 oraz `.RemoveAt()` aby usunąć element na indeksie 0. Wypisz całą listę.

## Zadanie 2: Problem usuwania w pętli
Utwórz listę imion (np. 5 różnych). Zastosuj pętlę `foreach` i spróbuj w niej użyć `.Remove()` na jednym z imion (zobaczysz błąd `InvalidOperationException`). Następnie zakomentuj pętlę `foreach` i napisz poprawną pętlę `for` idącą **od tyłu** listy (od `Count - 1` do `0`), która bezpiecznie usunie np. wszystkie imiona zaczynające się na literę "A".

## Zadanie 3: Słownik (Dictionary) - Tłumacz
Zbuduj `Dictionary<string, string>`, który będzie służył za słownik polsko-angielski (np. klucz: "jabłko", wartość: "apple"). Dodaj 5 słów. Odpytaj użytkownika w pętli `while(true)` o polskie słowo i wypisuj mu tłumaczenie. Jeśli słowa nie ma w słowniku, użyj `.ContainsKey()` aby go poinformować: "Brak w słowniku". (Przerwij pętlę gdy wpisze "exit").

## Zadanie 4: Słownik - Zliczanie znaków
Pobierz od użytkownika zdanie. Stwórz `Dictionary<char, int>`. Przeiteruj pętlą po każdym znaku w zdaniu. Jeśli znaku nie ma w słowniku, dodaj go z wartością 1. Jeśli znak już jest, zwiększ jego wartość o 1. Na koniec wypisz, ile razy wystąpiła każda litera w tym zdaniu.

## Zadanie 5: HashSet - Unikalne losowanie
Użyj klasy `Random` do losowania liczb z przedziału 1-20. Dodawaj je do struktury `HashSet<int>` tak długo (użyj pętli `while`), aż w secie znajdzie się dokładnie 10 unikalnych liczb. Zobaczysz, że jeśli wypadnie powtórka, HashSet po prostu ją zignoruje. Wypisz zawartość setu.

## Zadanie 6: Kolejka (Queue)
Stwórz `Queue<string>` symulującą kolejkę pacjentów w przychodni. Dodaj (`Enqueue`) 3 osoby. Następnie zdejmij (`Dequeue`) pierwszą osobę i wypisz "Aktualnie obsługiwany: [imie]". Podglądnij (`Peek`) kto jest następny w kolejce bez usuwania go. Dodaj kogoś nowego i zdejmij wszystkich do końca w pętli `while (kolejka.Count > 0)`.

## Zadanie 7: Stos (Stack)
Zbuduj `Stack<string>`. Symulujmy historię przeglądarki. Wykonaj `Push()` dla stron "google.com", "facebook.com", "github.com". Odczytaj obecną stronę przez `Peek()`. Następnie użytkownik wciska "Cofnij", więc zdejmujesz (`Pop()`) szczyt i wypisujesz "Cofnięto. Obecna strona to: " + aktualny `Peek()`.

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 8: List + Złożone Typy (Record / Struct)
Zdefiniuj typ `record Product(int Id, string Name, decimal Price)`. Stwórz `List<Product>` i dodaj do niej 5 różnych produktów. Używając pętli `foreach` po liście oraz warunku `if`, znajdź i wypisz najdroższy produkt z listy.

## Zadanie 9: Dictionary + Enum + Konstruktor
Stwórz `enum OrderStatus { New, Processing, Shipped }`. Stwórz `class Order` z własnością `OrderStatus`. Następnie stwórz logikę grupującą: Zbuduj `Dictionary<OrderStatus, List<Order>>`. Wstaw tam po jednej początkowo pustej liście dla każdego statusu. Stwórz kilka zamówień, określ status każdego w konstruktorze, a następnie umieść je w odpowiednich listach w obrębie Twojego słownika.

## Zadanie 10: Dictionary + Exceptions (TryGetValue vs KeyNotFoundException)
Stwórz słownik z kodami PIN (Klucz: `string` numerkonta, Wartość: `int` pin). 
Napisz blok `try-catch`. Poproś usera o nr konta i odczytaj PIN bezpośrednio przez `int userPin = pins[numer];`. Jeśli poda błędny numer, kod rzuci `KeyNotFoundException`. Złap go i wyrzuć swój własny `AccountNotFoundException` dziedziczący po `Exception` z komunikatem "Konto nie istnieje".

## Zadanie 11: Zestaw wszystkiego (ValueTuple + Enum[Flags] + Queue)
Zdefiniuj `[Flags] enum Roles { None=0, Read=1, Write=2, Admin=4 }`.
Stwórz kolejkę krotek: `Queue<(string Username, Roles UserRoles)>`. Dodaj do kolejki 3 użytkowników o różnych rolach. 
W pętli opróżniającej kolejkę zdejmuj krotkę i rozpakuj (deconstruct) ją do dwóch zmiennych. Zastosuj instrukcję `switch` z logiką sprawdzającą flagi (korzystając z `.HasFlag()` lub w nowszym C# pattern matchingu), by wypisać co użytkownik może zrobić, a czego nie.
