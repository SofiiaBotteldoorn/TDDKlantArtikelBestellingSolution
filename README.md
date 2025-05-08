TDDKlantArtikelBestelling UnitTests

Dit project is opgebouwd met Test-Driven Development (TDD) en bestaat uit meerdere klassen die samen een eenvoudig bestelsysteem simuleren. 

=STRUCTUUR=
- Persoon.cs
  Bevat de klasse Persoon met een lijst van voornamen en een familienaam. De klasse valideert dat namen niet leeg, niet dubbel en correct geformatteerd zijn (alleen letters en koppeltekens). Namen worden getrimd en hoofdletterongevoelig vergeleken.

- Klant.cs
  Klant is een subklasse van Persoon met extra eigenschappen: klantId (moet positief zijn) en email (moet geldig zijn volgens een basis-Regex).

- Artikel.cs
  Een Artikel heeft een naam, prijs exclusief btw en btwpercentage. De klasse valideert dat de naam geldig is, de prijs positief is, en het btwpercentage tussen 0.01 en 100 ligt. PrijsInclusiefBtw() berekent de prijs inclusief btw.

- Bestelling.cs
  Een bestelling bevat meerdere artikels. Artikels kunnen dubbel voorkomen. De klasse telt het aantal artikels en berekent het totaalbedrag inclusief btw.

=TESTS=

Voor elke klasse zijn uitgebreide MSTest-unit tests geschreven, ondergebracht in het testproject TDDKlantArtikelBestellingTest. Er wordt getest op:

- Ongeldige en geldige invoer
- Null-checks
- Dubbele voornamen of artikels
- Verwerking van spaties en hoofdlettergevoeligheid
- Correcte berekening van bedragen

Deze oefening is bedoeld als demonstratie van:

- Werken met TDD
- OOP in C# (overerving, validatie, encapsulation)
- Gebruik van List<T>, Regex en String-manipulatie
- Testscenario's systematisch opstellen

## 🛠️ Tools
- Taal: C#
- Visual Studio 2022
- MSTest (unit testing framework)
