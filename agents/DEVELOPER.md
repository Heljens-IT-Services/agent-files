# DEVELOPER.md

Stand: 2026-04-30

## Zweck

Diese Datei definiert die technologieübergreifenden Architektur-, Clean-Code- und Qualitätsregeln dieses Repositories. Technologiespezifische Details stehen in den passenden `DEVELOPER.<TECHNOLOGY>.md`-Dateien.

## Architekturprinzipien

- Fachlogik wird von technischen Randthemen getrennt.

## Clean Code

- Namen sind fachlich, präzise und konsistent. Ein Name soll erklären, warum ein Konzept existiert.
- Eine Funktion oder Methode erfüllt eine klar erkennbare Aufgabe auf einer Abstraktionsebene.
- Klassen, Komponenten und Services haben hohe Kohäsion und niedrige Kopplung.
- Kommentare sind an allgemeinen Einstiegspunkten, komplexeren Strukturen und an Infrastruktur-Objekten verpflichtend.
- Kommentare erklären Domänenwissen, fachspezifisches Know-How, Absicht, Trade-offs oder nicht offensichtliche Constraints. Sie wiederholen nicht den Code.
- Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code werden vorzugsweise gelöscht, mindestens gemeldet.

## Design Patterns und Prinzipien

- Es sollen geeignete Design-Patterns bzw. Code-Patterns angewendet werden, wenn diese eine der Bedingungen erfüllen:
    - Abhängigkeiten verringern
    - Redundanz verringen 
    - Wartbarkeit verbessern
    - Skalierbarkeit verbessern
    - Fehleranfälligkeit verringern
- Composition over Inheritance: Vererbung wird nur genutzt, wenn echte Substituierbarkeit vorliegt.
- Dependency Inversion: Anwendungsschichten hängen von Abstraktionen ab; Infrastruktur implementiert diese Abstraktionen.
- Mapper trennen externe DTOs von internen Modellen, wenn Daten aus APIs, Dateien, Datenbanken oder UI-Formularen kommen.
- Es gilt SOLID, insbesondere daraus das Single-Responsibility-Prinzip.

## Fehlerbehandlung

- Erwartbare fachliche Fehler werden als Result oder Exception modelliert.

## Security und Datenschutz

- Secrets, Tokens, personenbezogene Daten und interne Infrastrukturdetails werden niemals geloggt.
- Authentifizierung, Autorisierung und Mandantentrennung werden an zentralen Grenzen geprüft.
- Eingaben aus UI, CLI, Dateien, Datenbanken und APIs gelten als unsicher, bis sie validiert wurden.
- Abhängigkeiten werden bewusst gewählt und aktualisiert. Sicherheitsupdates haben Vorrang vor kosmetischen Refactorings.

## Tests

- Reine Fachlogik wird mit Unit Tests abgesichert.
- Workflows erhalten Tests für Happy Path, Fehlerpfade und fachlich kritische Abzweigungen.
- Tests sollen deterministisch, isoliert und lesbar sein. Zufall, Uhrzeit, Netzwerk und Dateisystem werden kontrolliert.
