# DEVELOPER.md

Stand: 2026-05-13

## Zweck

Diese Datei definiert technologieuebergreifende Architektur-, Clean-Code-, Dokumentations-, Qualitaets-, Fehlerbehandlungs-, Security- und Testregeln dieses Repositories. Technologiespezifische Details stehen in den passenden `DEVELOPER.<TECHNOLOGY>.md`-Dateien. Projektspezifische Technologie- und Architekturentscheidungen stehen in `DEVELOPER.Project.md`.

[PRIORITY] Diese Regeln gelten fuer alle Implementierungen, sofern keine passendere technologiespezifische oder projektspezifische Regel innerhalb ihres ausdruecklichen Scopes eine engere Vorgabe macht.

## Architekturprinzipien

[MUST] Fachlogik muss von technischen Randthemen getrennt werden.

[MUST] Fachliche Regeln, Use Cases, Workflows, fachliche Fehler und fachliche Modelle muessen in der fachlichen Mitte des Systems liegen.

[MUST] Technische Details wie UI, HTTP, CLI, Persistenz, Dateisystem, externe APIs, Worker, Frameworks, Logging, Konfiguration und Dependency Injection muessen an den Systemraendern bleiben.

[MUST_NOT] Einstiegspunkte wie Components, Pages, Controllers, Endpoints, `Program.cs`, Worker-Handler oder CLI-Kommandos duerfen keine Fachlogik enthalten.

[MUST] Einstiegspunkte muessen Eingaben validieren, Use Cases oder Services aufrufen und Ergebnisse in die passende Ausgabeform mappen.

[MUST] Abhaengigkeiten muessen nach innen zeigen: fachliche Schichten definieren Ports und Vertraege, technische Schichten implementieren diese Ports.

[MUST_NOT] Externe DTOs, API-Contracts, Formularmodelle, Dateiformate und Persistenzmodelle duerfen nicht ungeprueft als interne Fachmodelle verwendet werden.

## Struktur und Verantwortlichkeiten

[SHOULD] Projektstrukturen sollen fachliche und technische Verantwortlichkeiten sichtbar machen. Abweichungen sind erlaubt, wenn ein bestehendes Projekt eine andere stabile Struktur vorgibt und die konkrete Aenderung keine Strukturmigration ist.

[MUST] Wiederverwendbare, fachlich neutrale Bausteine muessen getrennt von fachlich spezifischen Features oder Use Cases liegen.

[MUST] Infrastrukturcode muss gekapselt werden.

[MUST_NOT] Views, Endpoints, CLI-Kommandos und fachliche Logik duerfen Infrastrukturcode nicht direkt ansprechen.

[MUST] Mapping an Systemgrenzen muss explizit sein, damit externe Vertraege, technische Transportmodelle und interne Modelle entkoppelt bleiben.

[MUST] Konfiguration muss an der technischen Grenze geladen, typisiert gebunden und validiert werden.

[MUST_NOT] Fachliche Logik darf globale Konfiguration nicht direkt lesen.

[MUST] Fehlende Pflichtkonfiguration muss frueh mit klarer Fehlermeldung scheitern.

[MUST] Oeffentliche oder teamuebergreifend genutzte Schnittstellen muessen stabile Contracts und dokumentierte Fehlerformen erhalten.

## Clean Code

[MUST] Namen muessen fachlich, praezise und konsistent sein.

[SHOULD] Ein Name soll erklaeren, warum ein Konzept existiert. Abweichungen sind erlaubt, wenn ein etabliertes Framework, Protokoll oder Fremdsystem einen anderen Namen vorgibt.

[MUST] Eine Funktion oder Methode muss eine klar erkennbare Aufgabe auf einer Abstraktionsebene erfuellen.

[MUST] Klassen, Komponenten und Services muessen hohe Kohaesion und niedrige Kopplung haben.

[MUST] Oeffentliche Typen, zentrale Einstiegspunkte und wiederverwendbare Bausteine muessen eine erkennbare, begrenzte Verantwortung haben.

[SHOULD] Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code sollen geloescht werden, wenn sie im Scope der Aufgabe liegen.

[MUST_IF] Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code muessen im Arbeitsabschluss gemeldet werden, wenn sie auffallen und nicht im Scope der Aufgabe geloescht werden.

## Dokumentation

[MUST_IF] Notwendiges Verstaendnis muss mindestens im Quellcode dokumentiert werden, wenn es fuer Wartung, Nutzung oder Review einer Aenderung erforderlich ist.

[MUST_IF] Allgemeine Einstiegspunkte, komplexere Strukturen, Infrastruktur-Objekte, oeffentliche Vertraege und nicht offensichtliche fachliche Regeln muessen kommentiert werden, wenn ihr Zweck nicht aus Code und Namen hervorgeht.

[MUST] Kommentare muessen Domaenenwissen, fachspezifisches Know-how, Absicht, Trade-offs oder nicht offensichtliche Constraints erklaeren.

[MUST_NOT] Kommentare duerfen den Code nicht lediglich wiederholen.

[ALLOW] README-Dateien, Architektur-Notizen, API-Beschreibungen, Beispielaufrufe oder externe Dokumentation duerfen Quellcode-Kommentare ergaenzen.

[MUST_NOT] Externe Dokumentation darf notwendiges Verstaendnis nicht ersetzen, wenn dieses Verstaendnis direkt am Code gebraucht wird.

## Design Patterns und Prinzipien

[ALLOW_IF] Design-Patterns und Code-Patterns duerfen eingesetzt werden, wenn sie Abhaengigkeiten verringern, Redundanz vermeiden, Wartbarkeit verbessern, Skalierbarkeit ermoeglichen, Fehleranfaelligkeit verringern oder Testbarkeit verbessern.

[ALLOW_IF] Vererbung darf genutzt werden, wenn echte Substituierbarkeit vorliegt.

[MUST] Anwendungsschichten muessen von Abstraktionen abhaengen; Infrastruktur muss diese Abstraktionen implementieren.

[MUST_IF] Mapper muessen externe DTOs von internen Modellen trennen, wenn Daten aus APIs, Dateien, Datenbanken oder UI-Formularen kommen.

[SHOULD] Facades, Application Services, Use Cases oder Component Services sollen Ablaeufe koordinieren, wenn Views, Endpoints oder CLI-Einstiege sonst Wissen ueber Datenzugriff, Validierung, Status oder technische Ablaeufe enthalten wuerden.

[MUST] Code muss SOLID beachten, insbesondere das Single-Responsibility-Prinzip.

## UI- und Präsentationsregeln

[MUST] UI-Code muss Nutzerintentionen, sichtbare Zustände und fachliche Abläufe klar trennen.

[MUST] Views, Pages und Components dürfen keine Fachlogik, Datenzugriffslogik, Persistenzlogik oder technische Orchestrierung enthalten.

[MUST] Sichtbare Zustände wie `loading`, `empty`, `error`, `disabled`, `readonly`, `dirty`, `saving` und `success` müssen explizit modelliert werden, wenn sie für den Nutzer relevant sind.

[MUST_NOT] UI-Code darf technische Fehler, interne IDs, Debug-Daten oder Infrastrukturdetails nicht ungefiltert sichtbar machen.

[MUST_NOT] Designsysteme und Komponentenbibliotheken duerfen nicht ohne ausdrueckliche User-Anweisung installiert werden.

[MUST] Layout- und Styling-Änderungen müssen bestehende Design-, Abstands-, Typografie- und Komponenten-Konventionen respektieren.

[MUST_NOT] UI-Änderungen dürfen keine unnötigen Wrapper, neuen Styling-Konzepte oder redundanten Komponentenvarianten einführen.

[MUST] Interaktive UI muss semantische Elemente, Tastaturbedienung, Fokusführung, Labels und verständliche Fehlermeldungen berücksichtigen.

[MUST] UI-Tests müssen sichtbares Verhalten, Nutzerzustände, Rollen, Labels, Navigation oder stabile fachliche Ergebnisse prüfen.

[MUST_NOT] UI-Tests dürfen nicht primär DOM-Struktur, CSS-Klassen oder private Implementierungsdetails prüfen.

## Fehlerbehandlung

[SHOULD] Erwartbare fachliche Fehler sollen als explizite Ergebnis-, Status- oder Fehlerobjekte modelliert werden. Abweichungen sind erlaubt, wenn eine vorhandene API, Sprache oder Bibliothek einen anderen fachlich stabilen Fehlervertrag vorgibt.

[MUST] Erwartbare fachliche Fehler muessen Teil des normalen fachlichen Kontrollflusses bleiben.

[ALLOW_IF] Exceptions duerfen fuer unerwartete technische Fehler, verletzte Invarianten oder nicht sinnvoll lokal behandelbare Fehler verwendet werden.

[MUST] Validierungsfehler muessen nahe an der Eingabe erkannt und in eine stabile, fachlich verstaendliche Fehlerform uebersetzt werden.

[MUST] Technische Fehler aus Infrastruktur, Netzwerk, Dateisystem, Persistenz oder externen APIs muessen an der technischen Grenze mit Kontext angereichert werden.

[SHOULD] Technische Fehler sollen in fachliche oder schnittstellenspezifische Ergebnisse uebersetzt werden, wenn der Aufrufer dadurch eine definierte fachliche oder technische Reaktion ausloest.

[MUST] Fehlerantworten an UI, CLI, HTTP-Clients oder andere Konsumenten muessen konsistent, maschinenlesbar und stabil sein.

[MUST_NOT] Fehlerantworten duerfen keine unbeabsichtigten internen Details enthalten.

[MUST] Logs muessen technische Ursachen und Diagnosekontext erklaeren.

[MUST_NOT] Logs duerfen fachliche Status-, Ergebnis- oder Fehlerobjekte nicht ersetzen.

[MUST_IF] Fehlerpfade muessen getestet werden, wenn sie fachlich relevant, sicherheitsrelevant oder fuer Nutzer bzw. Clients sichtbar sind.

## Security und Datenschutz

[MUST_NOT] Secrets, Tokens, personenbezogene Daten und interne Infrastrukturdetails duerfen nicht geloggt, hart codiert oder versioniert werden.

[MUST] Authentifizierung, Autorisierung und Mandantentrennung muessen an zentralen Grenzen geprueft werden.

[MUST] Eingaben aus UI, CLI, Dateien, Datenbanken und APIs muessen als unsicher behandelt werden, bis sie validiert wurden.

[MUST_NOT] Ausgaben duerfen keine unbeabsichtigten internen Diagnose-, Infrastruktur- oder Sicherheitsdetails enthalten.

[MUST] Abhaengigkeiten muessen nach den Kriterien Wartbarkeit, Sicherheit, Lizenz, Kompatibilitaet und Projektbedarf ausgewaehlt und aktualisiert werden.

[PRIORITY] Sicherheitsupdates haben Vorrang vor kosmetischen Refactorings.

## Tests

[MUST] Reine Fachlogik muss mit Unit Tests abgesichert werden.

[MUST] Workflows muessen Tests fuer Happy Path, Fehlerpfade und fachlich kritische Abzweigungen erhalten.

[SHOULD] Infrastruktur-, Adapter- und Integrationslogik soll mit kontrollierten Testdaten und ohne instabile Live-Dienste getestet werden. Abweichungen sind erlaubt, wenn ein Task ausdruecklich Live-Integrationstests verlangt und die benoetigten Zugangsdaten sowie Umgebung freigegeben sind.

[MUST_IF] Einstiegspunkte wie UI, CLI oder HTTP-API muessen getestet werden, wenn Routing, Eingabevalidierung, Ausgabeformat, Auth, Fehlerabbildung oder DI-Verkabelung projektrelevant sind.

[MUST] Tests muessen deterministisch, isoliert und lesbar sein.

[MUST] Zufall, Uhrzeit, Netzwerk und Dateisystem muessen in Tests kontrolliert werden.

[MUST] Tests muessen sichtbares Verhalten und fachliche Zustaende pruefen.

[MUST_NOT] Tests duerfen private Implementierungsdetails nicht als primaeren Vertrag pruefen.

[SHOULD] Agents sollen den kleinsten sinnvollen Checkumfang ausfuehren. Abweichungen sind erlaubt, wenn die Aenderung gemeinsame Vertrage, Startup, Routing, Persistenz, Security oder breite Nutzerflows betrifft.

[OPTIONAL] Reine Dokumentationsaenderungen muessen nicht getestet werden.

[ALLOW_IF] Content-Aenderungen duerfen ohne Tests abgeschlossen werden, wenn sie Rendering, Routing, Metadaten und Linksyntax nicht betreffen.

[SHOULD] Unit-Tests sollen fuer isolierte Logik eingesetzt werden; E2E-Tests sollen fuer sichtbare Nutzerflows, Navigation, Persistenz, Startup und domainuebergreifende Integration eingesetzt werden.

[MUST] Im Arbeitsabschluss muessen ausgefuehrte, ausgelassene oder fehlgeschlagene Checks samt Begruendung genannt werden.
