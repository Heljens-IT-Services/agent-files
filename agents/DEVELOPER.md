# DEVELOPER.md

Stand: 2026-05-01

## Zweck

Diese Datei definiert die technologieuebergreifenden Architektur-, Clean-Code-, Dokumentations-, Qualitaets-, Fehlerbehandlungs-, Security- und Testregeln dieses Repositories. Technologiespezifische Details stehen in den passenden `DEVELOPER.<TECHNOLOGY>.md`-Dateien. Projektspezifische Technologie- und Architekturentscheidungen stehen in `DEVELOPER.Project.md`.

Diese Regeln gelten fuer alle Implementierungen, sofern keine passendere technologiespezifische oder projektspezifische Datei eine engere Vorgabe macht.

## Architekturprinzipien

Fachlogik wird von technischen Randthemen getrennt. Fachliche Regeln, Use Cases, Workflows, fachliche Fehler und fachliche Modelle liegen in der fachlichen Mitte des Systems.

Technische Details wie UI, HTTP, CLI, Persistenz, Dateisystem, externe APIs, Worker, Frameworks, Logging, Konfiguration und Dependency Injection bleiben an den Systemraendern. Einstiegspunkte wie Components, Pages, Controllers, Endpoints, `Program.cs`, Worker-Handler oder CLI-Kommandos enthalten keine Fachlogik. Sie validieren Eingaben, rufen Use Cases oder Services auf und mappen Ergebnisse in die passende Ausgabeform.

Abhaengigkeiten zeigen nach innen: fachliche Schichten definieren Ports und Vertraege, technische Schichten implementieren diese Ports. Externe DTOs, API-Contracts, Formularmodelle, Dateiformate und Persistenzmodelle werden nicht ungeprueft als interne Fachmodelle verwendet.

## Struktur und Verantwortlichkeiten

Projektstrukturen machen fachliche und technische Verantwortlichkeiten sichtbar. Wiederverwendbare, fachlich neutrale Bausteine liegen getrennt von fachlich spezifischen Features oder Use Cases.

Infrastrukturcode wird gekapselt und nicht direkt aus Views, Endpoints, CLI-Kommandos oder fachlicher Logik heraus angesprochen. Mapping an Systemgrenzen ist explizit, damit externe Vertraege, technische Transportmodelle und interne Modelle entkoppelt bleiben.

Konfiguration wird an der technischen Grenze geladen, typisiert gebunden und validiert. Fachliche Logik liest keine globale Konfiguration direkt. Pflichtkonfiguration scheitert frueh mit klarer Fehlermeldung.

Oeffentliche oder teamuebergreifend genutzte Schnittstellen erhalten stabile Contracts und dokumentierte Fehlerformen.

## Clean Code

Namen sind fachlich, praezise und konsistent. Ein Name soll erklaeren, warum ein Konzept existiert.

Eine Funktion oder Methode erfuellt eine klar erkennbare Aufgabe auf einer Abstraktionsebene. Klassen, Komponenten und Services haben hohe Kohaesion und niedrige Kopplung. Oeffentliche Typen, zentrale Einstiegspunkte und wiederverwendbare Bausteine haben eine erkennbare, begrenzte Verantwortung.

Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code werden vorzugsweise geloescht, mindestens gemeldet.

## Dokumentation

Dokumentation findet mindestens im Quellcode statt. Allgemeine Einstiegspunkte, komplexere Strukturen, Infrastruktur-Objekte, oeffentliche Vertraege und nicht offensichtliche fachliche Regeln werden kommentiert.

Kommentare erklaeren Domaenenwissen, fachspezifisches Know-how, Absicht, Trade-offs oder nicht offensichtliche Constraints. Sie wiederholen nicht den Code.

README-Dateien, Architektur-Notizen, API-Beschreibungen, Beispielaufrufe oder externe Dokumentation ergaenzen Quellcode-Kommentare, ersetzen sie aber nicht, wenn das notwendige Verstaendnis direkt am Code gebraucht wird.

## Design Patterns und Prinzipien

Design-Patterns und Code-Patterns werden eingesetzt, wenn sie Abhaengigkeiten verringern, Redundanz vermeiden, Wartbarkeit verbessern, Skalierbarkeit ermoeglichen, Fehleranfaelligkeit verringern oder Testbarkeit verbessern.

Composition over Inheritance: Vererbung wird nur genutzt, wenn echte Substituierbarkeit vorliegt.

Dependency Inversion: Anwendungsschichten haengen von Abstraktionen ab; Infrastruktur implementiert diese Abstraktionen.

Mapper trennen externe DTOs von internen Modellen, wenn Daten aus APIs, Dateien, Datenbanken oder UI-Formularen kommen.

Facades, Application Services, Use Cases oder Component Services koordinieren Ablaeufe, wenn Views, Endpoints oder CLI-Einstiege sonst zu viel Wissen ueber Datenzugriff, Validierung, Status und technische Ablaeufe erhalten wuerden.

Es gilt SOLID, insbesondere daraus das Single-Responsibility-Prinzip.

## Fehlerbehandlung

Erwartbare fachliche Fehler werden bevorzugt als explizite Ergebnis-, Status- oder Fehlerobjekte modelliert. Sie sind Teil des normalen fachlichen Kontrollflusses.

Exceptions werden fuer unerwartete technische Fehler, verletzte Invarianten oder nicht sinnvoll lokal behandelbare Fehler verwendet.

Validierungsfehler werden nahe an der Eingabe erkannt und in eine stabile, fachlich verstaendliche Fehlerform uebersetzt. Technische Fehler aus Infrastruktur, Netzwerk, Dateisystem, Persistenz oder externen APIs werden an der technischen Grenze mit Kontext angereichert und in fachliche oder schnittstellenspezifische Ergebnisse uebersetzt, wenn der Aufrufer sinnvoll reagieren kann.

Fehlerantworten an UI, CLI, HTTP-Clients oder andere Konsumenten sind konsistent, maschinenlesbar, stabil und enthalten keine unbeabsichtigten internen Details. Logs erklaeren technische Ursachen und Diagnosekontext, ersetzen aber keine fachlichen Status-, Ergebnis- oder Fehlerobjekte.

Fehlerpfade werden getestet, wenn sie fachlich relevant, sicherheitsrelevant oder fuer Nutzer bzw. Clients sichtbar sind.

## Security und Datenschutz

Secrets, Tokens, personenbezogene Daten und interne Infrastrukturdetails werden niemals geloggt, hart codiert oder versioniert.

Authentifizierung, Autorisierung und Mandantentrennung werden an zentralen Grenzen geprueft. Eingaben aus UI, CLI, Dateien, Datenbanken und APIs gelten als unsicher, bis sie validiert wurden.

Ausgaben enthalten keine unbeabsichtigten internen Diagnose-, Infrastruktur- oder Sicherheitsdetails.

Abhaengigkeiten werden bewusst gewaehlt und aktualisiert. Sicherheitsupdates haben Vorrang vor kosmetischen Refactorings.

## Tests

Reine Fachlogik wird mit Unit Tests abgesichert. Workflows erhalten Tests fuer Happy Path, Fehlerpfade und fachlich kritische Abzweigungen.

Infrastruktur-, Adapter- und Integrationslogik wird mit kontrollierten Testdaten und ohne instabile Live-Dienste getestet, sofern keine expliziten Integrationstests vorgesehen sind.

Einstiegspunkte wie UI, CLI oder HTTP-API werden dort getestet, wo Routing, Eingabevalidierung, Ausgabeformat, Auth, Fehlerabbildung oder DI-Verkabelung projektrelevant sind.

Tests sollen deterministisch, isoliert und lesbar sein. Zufall, Uhrzeit, Netzwerk und Dateisystem werden kontrolliert. Tests pruefen sichtbares Verhalten und fachliche Zustaende, nicht private Implementierungsdetails.

Tests werden risikobasiert ausgefuehrt. Agents sollen nicht nach jeder kleinen Aenderung automatisch volle Unit-, Build- oder E2E-Suites starten, sondern den kleinsten sinnvollen Checkumfang waehlen. Reine Dokumentationsaenderungen brauchen keine Tests. Content-Aenderungen brauchen nur dann Tests, wenn Rendering, Routing, Metadaten oder Linksyntax betroffen sind. Unit-Tests sind bevorzugt fuer isolierte Logik; E2E-Tests fuer sichtbare Nutzerflows, Navigation, Persistenz, Startup und domainuebergreifende Integration. Im Abschluss werden ausgefuehrte und bewusst ausgelassene Checks samt Begruendung genannt.
