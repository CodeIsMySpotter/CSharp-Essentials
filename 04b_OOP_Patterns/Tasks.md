# Module 4b Tasks: Wzorce Projektowe

W tym zadaniu zaprojektujesz fabrykę statków kosmicznych. Celem jest ukrycie złożoności tworzenia obiektów przed programistą, który będzie używał Twojego kodu (klientem API). 

## Zadanie: Stocznia Galaktyczna (GDD)

Jako architekt oprogramowania w Stoczni Galaktycznej, musisz zbudować system do produkcji, logowania i konfigurowania statków kosmicznych. 

### Wymagania Systemowe (GDD):

1. **Główne Centrum Dowodzenia (Singleton):**
   - System musi posiadać Centrum Dowodzenia (`CommandCenter`), które prowadzi logi wyprodukowanych statków (np. trzyma listę nazw wyprodukowanych jednostek).
   - Biznes wymaga, aby istniało **absolutnie tylko jedno** Centrum Dowodzenia w całym programie. Jeśli dwóch programistów w różnych miejscach kodu spróbuje dostać się do Centrum, muszą zawsze trafić na ten sam obiekt z tą samą listą logów. Próba użycia słowa kluczowego `new CommandCenter()` musi skutkować błędem kompilacji.

2. **Konstruktor Statków (Builder):**
   - Zbudowanie statku kosmicznego (klasa `Spaceship`) jest procesem skomplikowanym. Statek ma wiele części: Typ Kadłuba, Rodzaj Silnika, System Uzbrojenia, Moduł Osłon (Shields).
   - Utwórz klasę `SpaceshipBuilder`, która pozwala na składanie statku krok po kroku, w sposób łańcuchowy (tzw. Fluent API), tak aby móc wywołać kod w stylu: `builder.SetHull("Titanium").SetEngine("Warp").Build()`.
   - Zadbaj o to, by wartości opcjonalne (jak uzbrojenie) miały jakieś wartości domyślne, jeśli nie zostaną ustawione przez Buildera.

3. **Zarządca Stoczni (Factory):**
   - Inni programiści piszący kod gry (np. odpowiadający za inwazję obcych) nie mają czasu na ręczne używanie Buildera i składanie części.
   - Wymagają oni specjalnej metody-fabryki (np. w klasie `ShipyardFactory`), do której mogą przekazać tylko jedno słowo (lub enum) - np. "Fighter", "Cargo" lub "Cruiser".
   - Fabryka w środku ma sama użyć odpowiednio skonfigurowanego `SpaceshipBuilder`, zbudować poprawny typ statku, **zapisać fakt jego produkcji w Singletonie (Centrum Dowodzenia)** i zwrócić gotowy statek.

### Twój Cel:
W `Program.cs` stwórz interfejs, w którym klient (Ty) tylko za pomocą `ShipyardFactory` tworzy flotę składającą się z jednego Myśliwca (Fighter) i jednego Frachtowca (Cargo). Następnie, pobierz instancję `CommandCenter` i wypisz na ekran, jakie statki zostały dotychczas wyprodukowane.
