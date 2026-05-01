# DEVELOPER.md

Stand: 2026-05-01

## Zweck

Diese Datei definiert die technologieübergreifenden Architektur-, Clean-Code-, Qualitäts-, Fehlerbehandlungs-, Security- und Testregeln dieses Repositories. Technologiespezifische Details stehen in den passenden `DEVELOPER.<TECHNOLOGY>.md`-Dateien.

Diese Regeln gelten für alle Implementierungen, sofern keine passendere technologiespezifische Datei eine engere Vorgabe macht.

## Architekturprinzipien

- Fachlogik wird von technischen Randthemen getrennt.
- Fachliche Regeln, Use Cases, Workflows, fachliche Fehler und fachliche Modelle liegen in der fachlichen Mitte des Systems.
- Technische Details wie UI, HTTP, CLI, Persistenz, Dateisystem, externe APIs, Worker, Frameworks, Logging, Konfiguration und Dependency Injection bleiben an den Systemrändern.
- Einstiegspunkte wie Components, Pages, Controllers, Endpoints, `Program.cs`, Worker-Handler oder CLI-Kommandos enthalten keine Fachlogik. Sie validieren Eingaben, rufen Use Cases oder Services auf und mappen Ergebnisse in die passende Ausgabeform.
- Abhängigkeiten zeigen nach innen: fachliche Schichten definieren Ports und Verträge; technische Schichten implementieren diese Ports.
- Externe DTOs, API-Contracts, Formularmodelle, Dateiformate und Persistenzmodelle werden nicht ungeprüft als interne Fachmodelle verwendet.
- Mapping an Systemgrenzen ist explizit. Dadurch bleiben externe Verträge, technische Transportmodelle und interne Modelle entkoppelt.
- Fachlich relevante Zustände werden explizit modelliert, z. B. `loading`, `valid`, `invalid`, `saving`, `synced`, `dirty`, `conflict`, `failed` oder projektspezifische Statusmodelle.
- Lang laufende Operationen, externe Aufrufe, Worker-Jobs und Requests berücksichtigen Abbruch, Timeout und Wiederholbarkeit.

## Struktur und Verantwortlichkeiten

- Projektstrukturen machen fachliche und technische Verantwortlichkeiten sichtbar.
- Wiederverwendbare, fachlich neutrale Bausteine liegen getrennt von fachlich spezifischen Features oder Use Cases.
- Infrastrukturcode wird gekapselt und nicht direkt aus Views, Endpoints, CLI-Kommandos oder fachlicher Logik heraus angesprochen.
- Konfiguration wird an der technischen Grenze geladen, typisiert gebunden und validiert. Fachliche Logik liest keine globale Konfiguration direkt.
- Pflichtkonfiguration scheitert früh mit klarer Fehlermeldung.
- Secrets, Tokens und umgebungsspezifische Werte werden nicht hart codiert und nicht versioniert.
- Öffentliche oder teamübergreifend genutzte Schnittstellen erhalten stabile Contracts und dokumentierte Fehlerformen.

## Clean Code

- Namen sind fachlich, präzise und konsistent. Ein Name soll erklären, warum ein Konzept existiert.
- Eine Funktion oder Methode erfüllt eine klar erkennbare Aufgabe auf einer Abstraktionsebene.
- Klassen, Komponenten und Services haben hohe Kohäsion und niedrige Kopplung.
- Öffentliche Typen, zentrale Einstiegspunkte und wiederverwendbare Bausteine haben eine erkennbare, begrenzte Verantwortung.
- Kommentare sind an allgemeinen Einstiegspunkten, komplexeren Strukturen und an Infrastruktur-Objekten verpflichtend.
- Kommentare erklären Domänenwissen, fachspezifisches Know-How, Absicht, Trade-offs oder nicht offensichtliche Constraints. Sie wiederholen nicht den Code.
- Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code werden vorzugsweise gelöscht, mindestens gemeldet.

## Design Patterns und Prinzipien

- Es sollen geeignete Design-Patterns bzw. Code-Patterns angewendet werden, wenn diese eine der Bedingungen erfüllen:
    - Abhängigkeiten verringern
    - Redundanz verringern
    - Wartbarkeit verbessern
    - Skalierbarkeit verbessern
    - Fehleranfälligkeit verringern
    - Testbarkeit verbessern
- Composition over Inheritance: Vererbung wird nur genutzt, wenn echte Substituierbarkeit vorliegt.
- Dependency Inversion: Anwendungsschichten hängen von Abstraktionen ab; Infrastruktur implementiert diese Abstraktionen.
- Mapper trennen externe DTOs von internen Modellen, wenn Daten aus APIs, Dateien, Datenbanken oder UI-Formularen kommen.
- Facades, Application Services, Use Cases oder Component Services koordinieren Abläufe, wenn Views, Endpoints oder CLI-Einstiege sonst zu viel Wissen über Datenzugriff, Validierung, Status und technische Abläufe erhalten würden.
- Es gilt SOLID, insbesondere daraus das Single-Responsibility-Prinzip.

## Fehlerbehandlung

- Erwartbare fachliche Fehler werden bevorzugt als explizite Ergebnis-, Status- oder Fehlerobjekte modelliert. Sie sind Teil des normalen fachlichen Kontrollflusses.
- Exceptions werden für unerwartete technische Fehler, verletzte Invarianten oder nicht sinnvoll lokal behandelbare Fehler verwendet.
- Validierungsfehler werden nahe an der Eingabe erkannt und in eine stabile, fachlich verständliche Fehlerform übersetzt.
- Technische Fehler aus Infrastruktur, Netzwerk, Dateisystem, Persistenz oder externen APIs werden an der technischen Grenze mit Kontext angereichert und in fachliche oder schnittstellenspezifische Ergebnisse übersetzt, wenn der Aufrufer sinnvoll reagieren kann.
- Fehlerantworten an UI, CLI, HTTP-Clients oder andere Konsumenten sind konsistent, maschinenlesbar, stabil und enthalten keine unbeabsichtigten internen Details.
- Logs erklären technische Ursachen und Diagnosekontext, ersetzen aber keine fachlichen Status-, Ergebnis- oder Fehlerobjekte.
- Fehlerpfade werden getestet, wenn sie fachlich relevant, sicherheitsrelevant oder für Nutzer bzw. Clients sichtbar sind.

## Security und Datenschutz

- Secrets, Tokens, personenbezogene Daten und interne Infrastrukturdetails werden niemals geloggt.
- Authentifizierung, Autorisierung und Mandantentrennung werden an zentralen Grenzen geprüft.
- Eingaben aus UI, CLI, Dateien, Datenbanken und APIs gelten als unsicher, bis sie validiert wurden.
- Ausgaben enthalten keine unbeabsichtigten internen Diagnose-, Infrastruktur- oder Sicherheitsdetails.
- Abhängigkeiten werden bewusst gewählt und aktualisiert. Sicherheitsupdates haben Vorrang vor kosmetischen Refactorings.

## Tests

- Reine Fachlogik wird mit Unit Tests abgesichert.
- Workflows erhalten Tests für Happy Path, Fehlerpfade und fachlich kritische Abzweigungen.
- Infrastruktur-, Adapter- und Integrationslogik wird mit kontrollierten Testdaten und ohne instabile Live-Dienste getestet, sofern keine expliziten Integrationstests vorgesehen sind.
- Einstiegspunkte wie UI, CLI oder HTTP-API werden dort getestet, wo Routing, Eingabevalidierung, Ausgabeformat, Auth, Fehlerabbildung oder DI-Verkabelung projektrelevant sind.
- Tests sollen deterministisch, isoliert und lesbar sein. Zufall, Uhrzeit, Netzwerk und Dateisystem werden kontrolliert.
- Tests prüfen sichtbares Verhalten und fachliche Zustände, nicht private Implementierungsdetails.
