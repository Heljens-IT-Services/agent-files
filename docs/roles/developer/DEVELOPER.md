# DEVELOPER.md

Stand: 2026-08-11

## Zweck

Diese Datei definiert technologieübergreifende Developer-Regeln. Technologiespezifische Regeldateien werden über [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgelöst.

## Priorität innerhalb der Developer-Rolle

[PRIORITY] Bei widersprüchlichen Regeldateien innerhalb der Developer-Rolle gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. Passende spezialisierte Regeldatei aus [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md).
2. [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md).

[PRIORITY] Bei mehreren passenden `DEVELOPER.*.md`-Dateien hat die spezifischere Regel nur innerhalb ihres ausdrücklich beschriebenen Scopes Vorrang vor einer allgemeineren Regel.

## Architekturprinzipien

[MUST] Fachlogik muss von technischen Randthemen getrennt werden.

[MUST] Fachliche Regeln, Use Cases, Workflows, fachliche Fehler und fachliche Modelle müssen in der fachlichen Mitte des Systems liegen.

[MUST] Technische Details wie UI, HTTP, CLI, Persistenz, Dateisystem, externe APIs, Worker, Frameworks, Logging, Konfiguration und Dependency Injection müssen an den Systemrändern bleiben.

[MUST_NOT] Technische Einstiegspunkte wie Controllers, Endpoints, `Program.cs`, Worker-Handler oder CLI-Kommandos dürfen keine Fachlogik enthalten.

[MUST] Einstiegspunkte müssen Eingaben validieren, Use Cases oder Services aufrufen und Ergebnisse in die passende Ausgabeform mappen.

[MUST] Abhängigkeiten müssen nach innen zeigen: fachliche Schichten definieren Ports und Verträge, technische Schichten implementieren diese Ports.

[MUST_NOT] Externe DTOs, API-Contracts, Formularmodelle, Dateiformate und Persistenzmodelle dürfen nicht ungeprüft als interne Fachmodelle verwendet werden.

## Struktur und Verantwortlichkeiten

[SHOULD] Projektstrukturen sollen fachliche und technische Verantwortlichkeiten sichtbar machen. Abweichungen sind erlaubt, wenn ein bestehendes Projekt eine andere stabile Struktur vorgibt und die konkrete Änderung keine Strukturmigration ist.

[MUST] Wiederverwendbare, fachlich neutrale Bausteine müssen getrennt von fachlich spezifischen Features oder Use Cases liegen.

[MUST] Infrastrukturcode muss gekapselt werden.

[MUST_NOT] Views, Endpoints, CLI-Kommandos und fachliche Logik dürfen Infrastrukturcode nicht direkt ansprechen.

[MUST] Mapping an Systemgrenzen muss explizit sein, damit externe Verträge, technische Transportmodelle und interne Modelle entkoppelt bleiben.

[MUST] Konfiguration muss an der technischen Grenze geladen, typisiert gebunden und validiert werden.

[MUST_NOT] Fachliche Logik darf globale Konfiguration nicht direkt lesen.

[MUST] Fehlende Pflichtkonfiguration muss früh mit klarer Fehlermeldung scheitern.

[MUST] Öffentliche oder teamübergreifend genutzte Schnittstellen müssen stabile Contracts und dokumentierte Fehlerformen erhalten.

## Datenmodellierung

[MUST] Die technische `Id`-Spalte jeder Datenbanktabelle muss als Integer-Typ definiert werden. Abweichende Typen sind nicht zulässig.

## Clean Code

[MUST] Namen müssen fachlich, präzise und konsistent sein.

[MUST] Bezeichner, Variablen, Dateien, Klassen, Funktionen, Methoden, Parameter, Attribute, Konstanten, Module, Datenbanken, Tabellen, Spalten, Indizes, Views, Trigger, Stored Procedures, Datenbankfunktionen, Skripte sowie Namen und technische Schlüssel von Konfigurations- und Ressourcendateien müssen in Produktiv- und Testcode englisch sein.

[MUST_IF] Extern vorgegebene Namen müssen unverändert bleiben, wenn Verträge, Frameworks, Protokolle oder Fremdsysteme dies erfordern.

[MUST_NOT_IF] Die Sprachregel darf lokalisierte nutzersichtbare Werte nicht auf Englisch festlegen und bestehende öffentliche Verträge oder persistierte Schemata nicht ohne erforderliche Migration umbenennen.

[SHOULD] Ein Name soll erklären, warum ein Konzept existiert. Abweichungen sind erlaubt, wenn ein etabliertes Framework, Protokoll oder Fremdsystem einen anderen Namen vorgibt.

[MUST] Eine Funktion oder Methode muss eine klar erkennbare Aufgabe auf einer Abstraktionsebene erfüllen.

[SHOULD] Funktionen und Methoden sollen in der Regel nicht mehr als ca. 15 Zeilen fachlich relevanten Code enthalten; bei Überschreitung soll eine Trennung von Verantwortlichkeiten oder Extraktion von Hilfsmethoden geprüft werden.

[MUST] Klassen, Komponenten und Services müssen hohe Kohäsion und niedrige Kopplung haben.

[MUST] Öffentliche Typen, zentrale Einstiegspunkte, Klassen, Komponenten und Services müssen eine klar benennbare und begrenzte Hauptverantwortung haben.

[MUST_NOT] Klassen, Komponenten und Services dürfen nicht allein zur Einhaltung numerischer Größenrichtwerte so aufgeteilt werden, dass fachliche Zusammenhänge, Lesefluss oder Wartbarkeit schlechter werden.

[SHOULD] Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code sollen gelöscht werden, wenn sie im Scope der Aufgabe liegen.

[MUST_IF] Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code müssen im Arbeitsabschluss gemeldet werden, wenn sie auffallen und nicht im Scope der Aufgabe gelöscht werden.

## Dokumentation

[MUST_IF] Allgemeine Einstiegspunkte, komplexe Strukturen, Infrastruktur-Objekte, öffentliche Verträge und fachliche Regeln müssen im Quellcode dokumentiert werden, wenn ihr für Wartung, Nutzung oder Review notwendiger Zweck nicht aus Code und Namen hervorgeht.

[MUST] Kommentare müssen Domänenwissen, fachspezifisches Know-how, Absicht, Trade-offs oder nicht offensichtliche Constraints erklären.

[MUST_NOT] Kommentare dürfen den Code nicht lediglich wiederholen.

[ALLOW] README-Dateien, Architektur-Notizen, API-Beschreibungen, Beispielaufrufe oder externe Dokumentation dürfen Quellcode-Kommentare ergänzen.

[MUST_NOT_IF] Externe Dokumentation darf notwendiges Verständnis nicht ersetzen, wenn dieses Verständnis direkt am Code gebraucht wird.

## Design Patterns und Prinzipien

[ALLOW_IF] Design-Patterns und Code-Patterns dürfen eingesetzt werden, wenn sie Abhängigkeiten verringern, Redundanz vermeiden, Wartbarkeit verbessern, Skalierbarkeit ermöglichen, Fehleranfälligkeit verringern oder Testbarkeit verbessern.

[ALLOW_IF] Vererbung darf genutzt werden, wenn echte Substituierbarkeit vorliegt.

[MUST_IF] Mapper müssen externe DTOs von internen Modellen trennen, wenn Daten aus APIs, Dateien, Datenbanken oder UI-Formularen kommen.

[SHOULD] Facades, Application Services, Use Cases oder Component Services sollen Abläufe koordinieren, wenn Views, Endpoints oder CLI-Einstiege sonst Wissen über Datenzugriff, Validierung, Status oder technische Abläufe enthalten würden.

## UI- und Präsentationsregeln

[MUST] UI-Code muss Nutzerintentionen, sichtbare Zustände und fachliche Abläufe klar trennen.

[MUST] Views, Pages und Components dürfen keine Fachlogik, Datenzugriffslogik, Persistenzlogik oder technische Orchestrierung enthalten.

[MUST_IF] Sichtbare Zustände wie `loading`, `empty`, `error`, `disabled`, `readonly`, `dirty`, `saving` und `success` müssen explizit modelliert werden, wenn sie für den Nutzer relevant sind.

[MUST_NOT] UI-Code darf technische Fehler, interne IDs, Debug-Daten oder Infrastrukturdetails nicht ungefiltert sichtbar machen.

[MUST_NOT] Designsysteme und Komponentenbibliotheken dürfen nicht ohne ausdrückliche User-Anweisung installiert werden.

[MUST] Layout- und Styling-Änderungen müssen bestehende Design-, Abstands-, Typografie- und Komponenten-Konventionen respektieren.

[MUST_NOT] UI-Änderungen dürfen keine unnötigen Wrapper, neuen Styling-Konzepte oder redundanten Komponentenvarianten einführen.

[MUST] Interaktive UI muss semantische Elemente, Tastaturbedienung, Fokusführung, Labels und verständliche Fehlermeldungen berücksichtigen.

[MUST] UI-Tests müssen sichtbares Verhalten, Nutzerzustände, Rollen, Labels, Navigation oder stabile fachliche Ergebnisse prüfen.

[MUST_NOT] UI-Tests dürfen nicht primär DOM-Struktur, CSS-Klassen oder private Implementierungsdetails prüfen.

## Fehlerbehandlung

[PRIORITY] Fachliche Korrektheit und Fehlertransparenz haben Vorrang vor einem scheinbar erfolgreichen Anwendungslauf.

[SHOULD] Erwartbare fachliche Fehler sollen als explizite Ergebnis-, Status- oder Fehlerobjekte modelliert werden. Abweichungen sind erlaubt, wenn eine vorhandene API, Sprache oder Bibliothek einen anderen fachlich stabilen Fehlervertrag vorgibt.

[MUST] Erwartbare fachliche Fehler müssen Teil des normalen fachlichen Kontrollflusses bleiben.

[ALLOW_IF] Exceptions dürfen verwendet werden, wenn technische Fehler unerwartet sind, Invarianten verletzt wurden oder eine lokale Behandlung nicht sinnvoll ist.

[MUST] Validierungsfehler müssen nahe an der Eingabe erkannt und in eine stabile, fachlich verständliche Fehlerform übersetzt werden.

[MUST] Technische Fehler aus Infrastruktur, Netzwerk, Dateisystem, Persistenz oder externen APIs müssen an der technischen Grenze mit Kontext angereichert werden.

[MUST_IF] Wenn technische Fehler in fachliche oder schnittstellenspezifische Ergebnisse übersetzt werden, muss die Übersetzung die Fehlersemantik bewahren und darf keinen Erfolg vortäuschen.

[MUST_NOT] Ausfälle notwendiger Datenquellen dürfen nicht durch leere Ergebnisse, `null`, Defaultobjekte oder erfundene, hardcodierte, Mock-, Fake-, Sample- bzw. Demo-Daten als Erfolg dargestellt werden.

[ALLOW_IF] Ein Fallback darf verwendet werden, wenn ein expliziter fachlicher Vertrag Ersatzpfad und Semantik definiert, seine Aktivierung beobachtbar ist und Tests Aktivierung, Beobachtbarkeit sowie Grenzen nachweisen.

[MUST_IF] Wenn ein Ablauf ohne erforderliche Daten nicht fachlich korrekt fortgesetzt werden kann, muss der betroffene Ablauf mit einem diagnostizierbaren Fehlerzustand kontrolliert abgebrochen werden.

[MUST] Fehlerantworten an UI, CLI, HTTP-Clients oder andere Konsumenten müssen konsistent, maschinenlesbar und stabil sein.

[MUST_NOT] Fehlerantworten dürfen keine unbeabsichtigten internen Details enthalten.

[MUST] Logs müssen technische Ursachen und Diagnosekontext erklären.

[MUST_NOT] Logs dürfen fachliche Status-, Ergebnis- oder Fehlerobjekte nicht ersetzen.

[MUST_IF] Fehlerpfade müssen getestet werden, wenn sie fachlich relevant, sicherheitsrelevant oder für Nutzer bzw. Clients sichtbar sind.

## Security und Datenschutz

[MUST_NOT] Secrets, Tokens, personenbezogene Daten und interne Infrastrukturdetails dürfen nicht geloggt, hart codiert oder versioniert werden.

[MUST] Authentifizierung, Autorisierung und Mandantentrennung müssen an zentralen Grenzen geprüft werden.

[MUST] Eingaben aus UI, CLI, Dateien, Datenbanken und APIs müssen als unsicher behandelt werden, bis sie validiert wurden.

[MUST_NOT] Ausgaben dürfen keine unbeabsichtigten internen Diagnose-, Infrastruktur- oder Sicherheitsdetails enthalten.

[MUST] Abhängigkeiten müssen nach den Kriterien Wartbarkeit, Sicherheit, Lizenz, Kompatibilität und Projektbedarf ausgewählt und aktualisiert werden.

[PRIORITY] Sicherheitsupdates haben Vorrang vor kosmetischen Refactorings.

## Tests

[MUST] Reine Fachlogik muss mit Unit Tests abgesichert werden.

[MUST] Workflows müssen Tests für Happy Path, Fehlerpfade und fachlich kritische Abzweigungen erhalten.

[SHOULD] Infrastruktur-, Adapter- und Integrationslogik soll mit kontrollierten Testdaten und ohne instabile Live-Dienste getestet werden. Abweichungen sind erlaubt, wenn ein Task ausdrücklich Live-Integrationstests verlangt und die benötigten Zugangsdaten sowie Umgebung freigegeben sind.

[MUST_IF] Einstiegspunkte wie UI, CLI oder HTTP-API müssen getestet werden, wenn Routing, Eingabevalidierung, Ausgabeformat, Auth, Fehlerabbildung oder DI-Verkabelung projektrelevant sind.

[MUST] Tests müssen deterministisch, isoliert und lesbar sein.

[MUST] Zufall, Uhrzeit, Netzwerk und Dateisystem müssen in Tests kontrolliert werden.

[MUST] Tests müssen sichtbares Verhalten und fachliche Zustände prüfen.

[MUST_NOT] Tests dürfen private Implementierungsdetails nicht als primären Vertrag prüfen.

[SHOULD] Agents sollen den kleinsten sinnvollen Checkumfang ausführen. Abweichungen sind erlaubt, wenn die Änderung gemeinsame Vertrage, Startup, Routing, Persistenz, Security oder breite Nutzerflows betrifft.

[ALLOW_IF] Reine Dokumentations- und Content-Änderungen dürfen ohne Tests abgeschlossen werden, wenn sie Rendering, Routing, Metadaten und Linksyntax nicht betreffen.

[SHOULD] Unit-Tests sollen für isolierte Logik eingesetzt werden; E2E-Tests sollen für sichtbare Nutzerflows, Navigation, Persistenz, Startup und domainübergreifende Integration eingesetzt werden.

[MUST] Im Arbeitsabschluss müssen ausgeführte, ausgelassene oder fehlgeschlagene Checks samt Begründung genannt werden.
