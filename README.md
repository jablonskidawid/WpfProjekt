# WpfProjekt
Akademia C# - Projekt
- Aplikacja umożliwia dodawanie osób na uczelnię. Osobno przechowywane są dane o studentach i o innych pracownikach. Pracownik i Student dziedziczą po klasie osoba (klasa abstrakcyjna)
- W aplikacji można dodawać osoby w zakładce "Dodaj nową osobę" oraz dodawać, edytować i usuwać osoby w zakładce "Przeglądaj osoby"
- Dodawanie jest zabezpieczone przed wprowadzaniem znaków innych niż cyfry w polach na numer telefonu, numer indeksu i pensję.
- W przypadku podania złego pliku xml (do deseriaizacji) również następuje powiadomienie o błędzie.
-Listy pracowników i studentów przechowywane są w obiekcie klasy Listy. Pozwala to na serializację i deserializację dwóch list w jednym pliku.
- Klasy Student i Pracownik korzystają z (własnego) interfejsu IPrintable, który umożliwia wypisanie zawartości obiektów.
- W klasie Listy są dwie metody (polimorfizm) o nazwie dodaj, które w zależności od parametru dodają obiekt do listy studentów lub pracowników.
