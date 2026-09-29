# Module 8 Tasks: Delegaty, Lambdy i Zdarzenia

## Zadanie 1: Podstawy Delegatów
Zdefiniuj własny typ delegata `MathOperation`, który przyjmuje dwa `int`y i zwraca `int`. W klasie utwórz dwie statyczne metody: `Add` i `Multiply`, o pasujących sygnaturach. W `Run()` stwórz zmienną typu `MathOperation`, przypisz do niej najpierw `Add`, wykonaj ją wypisując wynik, a potem przypisz do tej samej zmiennej `Multiply` i również wypisz wynik.

## Zadanie 2: Delegat Action
Napisz metodę `RepeatAction`, która przyjmuje dwa parametry: `int count` oraz parametr funkcyjny `Action action`. Metoda ta powinna w pętli `for` wykonać przekazaną akcję dokładnie `count` razy. W głównej metodzie wywołaj to, przekazując jako akcję lambdę wpisującą na ekran wybrany przez Ciebie tekst.

## Zadanie 3: Delegat Func
Napisz metodę `TransformList`, która przyjmuje dwa parametry: dowolną listę liczb całkowitych (`List<int>`) oraz delegat transformujący (`Func<int, int>`). Metoda ta powinna przejść po liście wejściowej i zwrócić NOWĄ listę, w której każdy element został przekształcony podaną funkcją. Wywołaj ją, przekazując lambdę obliczającą kwadrat każdej liczby (`x => x * x`).

## Zadanie 4: Predicate i filtrowanie
Stwórz listę kilku różnych imion. Użyj wbudowanej na liście metody `FindAll()`. Jako argument (który z definicji jest typu `Predicate<string>`) przekaż jej wyrażenie lambda, by odnalazła tylko te imiona, które mają więcej niż 5 liter. Wynik zachowaj do nowej zmiennej i wypisz.

## Zadanie 5: Multicast Delegate
Stwórz jeden delegat typu `Action<string>` i nazwij go np. `logger`. Podepnij pod niego (`+=`) kolejno trzy różne lambdy:
1. Wypisującą otrzymaną wiadomość, ale powiększoną wielkimi literami.
2. Wypisującą informację o tym, z ilu znaków składa się wiadomość.
3. Wypisującą przed wiadomością aktualny czas.
Wywołaj `logger("Oto moja wazna wiadomosc")` TYLKO RAZ w kodzie, a na ekranie powinieneś zobaczyć wszystkie trzy efekty z racji dodania wielu funkcji do jednego delegata.

## Zadanie 6: Podstawy Eventów
Stwórz klasę `Timer`. W środku dodaj publiczne zdarzenie (słowo kluczowe `event`) typu `Action` o nazwie `OnTick`. Stwórz tam metodę `Start()`, która wykonuje prostą pętlę i wywołuje `OnTick?.Invoke()` w każdym przejściu (np. co symulowaną sekundę, używając `Thread.Sleep(500)`). Z poziomu `Task6` zasubskrybuj ten event, żeby wypisywał "Pik!" w konsoli.

## Zadanie 7: EventHandler i Argumenty Zdarzenia
Stwórz klasę `TemperatureSensor`. Powinna posiadać zdarzenie `public event EventHandler<int> TemperatureAlert`. Napisz metodę `ReadTemperature()`, w której zasymulujesz losową temperaturę. Jeżeli wylosuje więcej niż 80, użyj `Invoke(this, temperatura)`, by poinformować o tym na zewnątrz. Zasubskrybuj event z poziomu `Task7` i przetestuj reagowanie na komunikaty ostrzegawcze.

## Zadanie 8: Wyrejestrowanie (Odsubskrybowanie)
Wykorzystaj klasę `TemperatureSensor` z Zadania 7. Dodaj instancję czujnika. Następnie przygotuj dedykowaną, nazwaną (nie anonimową!) metodę (zgodną z `EventHandler<int>`) do logowania. 
Podepnij ją używając `+=`, wywołaj symulację, po czym natychmiast ją odepnij symbolem `-=`. Wywołaj odczyt ponownie, aby udowodnić, że subskrybent zniknął i powiadomienie nie jest już odbierane.

---
## Integracja z poprzednimi modułami (Utrwalanie)

## Zadanie 9: Kolekcje + Delegaty (Zliczanie po kluczu)
Stwórz listę, która trzyma obiekty klasy `Order(int Id, string Category)`. Dodaj tam 10 zamówień o 3 różnych kategoriach. Zaimplementuj logikę do agregacji tego w strukturę `Dictionary<string, int>`, posługując się chociażby pomocniczym systemem polegającym na delegacie `Action<Order>` służącym jako handler przetwarzający obiekty i incrementujący słownik.

## Zadanie 10: Słownik Funkcji (Dictionary + Func)
Zbuduj "kalkulator operacji matematycznych". Trzonem niech będzie `Dictionary<string, Func<double, double, double>>`. 
Pod kluczem np. `"+"` wstaw lambdę dodającą wartości, pod `"-"` odejmującą, itd. 
Pobierz operację od użytkownika. Jeżeli znaku nie będzie w słowniku, podłap generowany `KeyNotFoundException` i wyświetl własny komunikat z prośbą o inny znak (zamiast standardowego wyrzucenia błędu i wysypania apki).

## Zadanie 11: Zdarzenia rzucające wyjątki (Event + Exceptions)
Stwórz event typu `Action`. Podepnij pod niego 3 lambdy, gdzie pierwsza i trzecia wypisują tekst, ale DRUGA używa `throw new InvalidOperationException()`. 
Gdy wywołasz ten event (w otoczce `try-catch`), przekonasz się o potężnej niedogodności w .NET – nienaprawiony wyjątek w multicast delegacie przerywa cały potok, więc 3 lambda już nigdy nie wykona pracy. Wyłap ten wyjątek, wypisz komunikat. (Później ewentualnie możesz poczytać jak rozwiązać ten problem używając metody `.GetInvocationList()`).

## Zadanie 12: List + Action i Closure
Stwórz listę np. 100 000 losowych mniejszych cyfr. Zdefiniuj na boku (jako zwykłą zmienną lokalną) zmienną np. `int totalSum = 0;`. 
Zamiast korzystać z typowej pętli, użyj wbudowanej dla list, bardzo wydajnej metody `.ForEach(...)`. Jako argument podaj lambdę typu `Action<int>`, która zaktualizuje Twój `totalSum` o otrzymaną wartość. Obserwujesz w ten sposób potęgę tzw. zjawiska *closure* – funkcja wlatująca z zewnątrz widzi zmienną `totalSum` znajdującą się przed nią!
