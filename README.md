# PokeDex Web Project

## Konfiguracja
- zmień atrybut *connection string* na własny w *./Web.config*
- zmień wartosci zmiennych w pliku *./Controller/ChallengesController*
  - *mailClient* na mail powiązany z aplikacją, który będzie wysyłał email
  - *emailPassword* na hasło do powyższego maila
- stwórz role *Admin*, *Leader*, *Trainer* w encji *CustomRoles* od strony bazy danych
  - zarejestruj konto, które ma być adminem
  - połącz id konta (*ApplicationUsers*) z id roli (*CustomRoles*) Admin w encji *CustomUserRoles* 

## Dziedzina Biznesowa
Pokedex, „encyklopedia pokemon”, urządzenie stworzone przez profesora Oaka jako bezcenne narzędzie, które przechowuje informacje dotyczące wszystkich pokemonów na świecie. Niestety, wraz z czasem oraz rozszerzającą się ekspansją technologiczną w uniwersum pokemon, Pokedex powoli zaczął być nazbyt przestarzały. Srebrna Konferencja wraz z profesorem Oakiem zleciła więc utworzenie nowego Pokedexu, z odświeżonym systemem, który miałby mieć dodane kilka nowych funkcji koordynujących pracę posiadacza – trenera.

## Cel Systemu
Celem systemu jest usprawnienie starego Pokedexu oraz zinformatyzowanie starych działań, które były wykonywane manualnie. W znaczny sposób ułatwiłoby to pracę trenera oraz odciążyło Srebrną Konferencję o ogrom „papierkowej roboty”.

## Zakres Odpowiedzialności Systemu
W skład zakresu systemu wchodzi baza danych, która gromadzi informacje na temat gatunków pokemonów. Ponadto, Pokedex przechowuje informacje na temat trenerów, profesorów i liderów, oraz ich pokemonów, a także posiada kluczowe dane dotyczące licencji posiadacza. Ułatwia również proces przyznawania odznak trenerom przez liderów. Aplikacja powinna być również interfejsem dla użytkowników systemu. 

## Wymagania Użytkownika
System Pokedexu ma przechowywać dotyczące poszczególnych osób, czyli Trenerów, Profesorów oraz Liderów. Dla każdych z wymienionych person chcemy mieć ich ID, imię, nazwisko, datę urodzenia oraz aktualną ilość pieniędzy. Dodatkowo dane Trenera mają zawierać informacje na temat ilości odznak, skompletowania pokedexu oraz dofinansowania ze Srebrnej Konferencji. Lider ma dodatkowe dane o specjalizacji, drugiej pracy, zarobków jako trener oraz odznaki, której broni. Profesor kryje informacje dotyczące lokalizacji jego laboratorium, specjalizacji oraz zarobków jako profesor. 
- Każda z osób posiada swoje Pokemony;
- Trener posiada Licencję trenerską;
- Trener ma możliwość pojedynkowania się z Liderem oraz rzucania mu Wyzwań;
-	Lider ma możliwość przyjmowania i odrzucania Wyzwań;
-	Lider w przypadku odrzucenia/ przyjęcia Wyzwania jest zmuszony do wypełnienia danych dotyczących rezultatów Wyzwania odmowy Wyzwania.
Ponadto, Pokedex przechowuje najbardziej oczywiste rzeczy, czyli dane dotyczące samych w sobie indywidualnych Pokemonów i ich wszystkich Gatunków Pokemonów. Pokemony dzielą się na te przeznaczone do Walki i/lub Kontestów oraz na te, które zostały Złapane lub Otrzymane.
Pokemonowi przechowujemy dane dotyczącego jego ID, pseudonimu, płci, poziomu, doświadczenia i szczęścia. Gatunek Pokemona dotyczy id gatunku, numer, nazwa, opis, gatunek oraz zdjęcie przedstawiające gatunek. 
-	Każdy Walczący Pokemon ma możliwość posiadania jednego Przedmiotu do trzymania;
-	Każdy Gatunek Pokemona  posiada swoje Bazowe Statystyki, potencjalne Zdolności z kwalifikatorem atrybutu nickname, potencjalne Ruchy, które może poznać oraz jeden lub dwa Typy;
-	Każdy Trzymany Przedmiot dziedziczy informacje po Przedmiocie.

Walczącym Pokemonom przechowujemy dane dotyczące wyćwiczonych ich tzw. Effort Values dotyczących każdej z bazowych statystyk. Kontesterowi zaś informacje o specjalizacji. Złapanym Pokemonom zawieramy dane o lokalizacji i użytym do złapania ballu. Zaś Otrzymanym Pokemonom o zadanych zastrzeżeniach dotyczącym pokemona oraz o jego ewentualnym koszcie. 
Trzymany Przedmiot zawiera dane o tym czy może zostać upuszczony przez co niektóre ataki. Przedmiot posiada zaś informacje o jego ID, nazwie i opisie. 
Bazowe Statystyki dotyczą informacji dotyczące id, bazowej statystki punktów życia, ataku, defensywy, specjalnego ataku, specjalnej defensywy oraz szybkości. Zdolność przechowuje dane o id, nazwie, opisie oraz czy jest to ukryta zdolność (eng. Hidden ability). Ruch zaś o id, nazwie i opisie. 
Każdy Ruch dzieli się na Ruch Ofensywny lub Ruch Statusowy. Zdarza się również, iż Ruch jest ruchem Ofensywno-Statusowym. Ruch Ofensywny zawiera informacje dotyczące czy jest to ruch kontaktowy, kategorię i bazowe obrażenia. Status zaś cel ruchu oraz jego efekt. 

## Scenariusz Przypadku Użycia
Proces pojedynku o odznakę rozpoczyna się od strony Trenera, który to rzuca Liderowi wyzwanie. Lider ma możliwość odrzucenia wzywania z wybranego przez siebie powodu, który zgadza się z regulaminem Srebrnej Konferencji. W przypadku negatywnego rozpatrzenia prośby, wpierw redaguje powód odrzucenia, a następnie informuje Trenera o odrzuceniu wyzwania poprzez wysłanie maila. W tym momencie gałąź procesu się kończy. Jednakże, jeśli akceptuje wyzwanie, to następuje przeprowadzenie pojedynku (poza systemem). Trener może wygrać bądź przegrać: jeśli zwycięży, to Lider wpierw redaguje raport dotyczący wygranej trenera, a następnie przyznaje mu odznakę; jeśli nie, to Lider tworzy raport dotyczący przegranej trenera. Następuje koniec procesu.   

## Diagram Analityczny
![alt text](https://i.imgur.com/p1jQSym.png)

## Diagram Projektowy
![alt text](https://i.imgur.com/PgzzBtF.png)

## Diagram Aktywności
![alt text](https://i.imgur.com/YpH4dDD.png)

## Diagram Stanów
![alt text](https://i.imgur.com/FkJ7yE7.png)
