# Architecture.md

Stand: 2026-04-30

## Zweck

Diese Datei definiert die technologieübergreifenden Architektur-, Clean-Code- und Qualitätsregeln dieses Repositories. Technologiespezifische Details stehen in den passenden `Architecture.*.md`-Dateien. Projektspezifische Fakten, Pfade, Fachregeln und Kommandos stehen in `Repository.md`.

## Architekturdateien

| Datei | Gilt für |
|---|---|
| `Architecture.md` | Technologieübergreifende Architektur-, Clean-Code- und Qualitätsregeln. |
| `Architecture.Angular.md` | Angular-Anwendungen mit klarer Trennung von View, State, lokaler Persistenz, Worker und Web API. |
| `Architecture.NETConsole.md` | .NET-10-Konsolenanwendungen mit Host, DI, SOLID, Konfiguration, Logging und Tests. |
| `Repository.md` | Projektspezifische Informationen, Fachregeln, Pfade und Kommandos. |

## Architekturprinzipien

- Fachlogik wird von technischen Randthemen getrennt. UI, Console, HTTP, Dateisystem, Datenbank und externe Dienste sind Adapter an den Rändern.
- Abhängigkeiten zeigen nach innen: Presentation und Infrastructure dürfen Application und Domain kennen, aber Domain kennt keine UI- oder Infrastrukturdetails.
- Seiteneffekte sind gebündelt: Netzwerk, Persistenz, Uhrzeit, Zufall, Prozessumgebung und Console-I/O werden über abstrahierte Services oder Adapter erreicht.
- Der Anwendungskern arbeitet mit fachlichen Modellen, Value Objects, klaren Interfaces und expliziten Ergebnissen statt mit losen Dictionaries, dynamischen Objekten oder ungeprüften Rohdaten.
- Fehler werden an Schichtgrenzen übersetzt. Technische Exceptions werden nicht unkontrolliert bis in fachliche Oberflächen durchgereicht.
- Konfiguration ist typisiert, validiert und dokumentiert. Secrets gehören nicht in versionierte Dateien.
- Logging beschreibt Entscheidungen, I/O und Fehlerkontext, aber keine sensiblen Daten.
- Architektur folgt dem aktuellen Bedarf. Abstraktionen werden eingeführt, wenn sie echte Komplexität reduzieren, Varianten kapseln oder fachliche Regeln ausdrücken.

## Clean Code

- Namen sind fachlich, präzise und konsistent. Ein Name soll erklären, warum ein Konzept existiert.
- Eine Funktion oder Methode erfüllt eine klar erkennbare Aufgabe auf einer Abstraktionsebene.
- Klassen, Komponenten und Services haben hohe Kohäsion und niedrige Kopplung.
- Öffentliche APIs sind klein, absichtlich und stabil. Interne Details bleiben gekapselt.
- Kontrollfluss bleibt lesbar: Guard Clauses sind erlaubt, tief verschachtelte Bedingungen werden vermieden.
- Duplikation wird entfernt, wenn sie dieselbe fachliche Regel ausdrückt. Zufällige Ähnlichkeit wird nicht überabstrahiert.
- Primitive Obsession wird vermieden, wenn Fachwerte eigene Regeln haben. Dann werden Value Objects, Records oder typisierte Modelle verwendet.
- Magische Werte werden benannt und dort abgelegt, wo ihre fachliche Bedeutung klar ist.
- Kommentare erklären Absicht, Trade-offs oder nicht offensichtliche Constraints. Sie wiederholen nicht den Code.
- Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code werden nicht stehen gelassen.

## Design Patterns und Prinzipien

- SOLID gilt als Richtlinie, nicht als Selbstzweck. Die wichtigste Wirkung ist verständliche Verantwortlichkeit und testbare Kopplung.
- KISS: Die einfachste tragfähige Lösung ist vorzuziehen.
- YAGNI: Erweiterungspunkte werden nicht gebaut, bevor eine reale Variation existiert oder konkret absehbar ist.
- DRY: Fachliche Regeln haben eine Quelle. Mechanische Ähnlichkeit allein ist kein Grund für Abstraktion.
- Tell, Don’t Ask: Fachliche Objekte und Services sollen Verhalten kapseln, statt überall Zustände auszulesen und extern zu entscheiden.
- Composition over Inheritance: Vererbung wird nur genutzt, wenn echte Substituierbarkeit vorliegt.
- Dependency Inversion: Anwendungsschichten hängen von Abstraktionen ab; Infrastruktur implementiert diese Abstraktionen.
- Ports and Adapters: Externe Systeme werden über Ports angesprochen und in Adaptern implementiert.
- Mapper trennen externe DTOs von internen Modellen, wenn Daten aus APIs, Dateien, Datenbanken oder UI-Formularen kommen.

## Standard-Schichten

Die konkrete Technologie-Datei darf Namen und Ordnerstruktur anpassen, aber die Verantwortung bleibt gleich:

- Presentation: UI, Console, API-Endpunkte, Routing, Formatierung und Benutzerinteraktion.
- Application: Use Cases, Workflows, Orchestrierung, Transaktionen, Commands und Queries.
- Domain: Fachmodelle, fachliche Regeln, Value Objects, reine Berechnungen.
- Infrastructure: HTTP, Datenbank, Dateisystem, externe Dienste, technische Parser und Persistenz.
- Cross-cutting: Logging, Konfiguration, Validierung, Telemetrie, Authentifizierung und Autorisierung.

## Daten, Verträge und Grenzen

- Externe DTOs bleiben an der jeweiligen Grenze und werden in interne Modelle gemappt.
- Datenverträge werden versioniert oder eindeutig dokumentiert, wenn externe Nutzer, Dateien, APIs oder Persistenz betroffen sind.
- Validierung erfolgt früh an Eingangsgrenzen und zusätzlich dort, wo fachliche Invarianten geschützt werden müssen.
- Nullability, optionale Felder und Defaults werden bewusst modelliert.
- Zeit, Zeitzonen, Kulturformate, Einheiten und Rundungsregeln werden explizit behandelt.
- Migrationen, Export-Schemas und API-Änderungen werden zusammen mit Tests und Dokumentation gepflegt.

## Fehlerbehandlung

- Erwartbare fachliche Fehler werden als Result, Status oder fachliche Exception modelliert.
- Unerwartete technische Fehler behalten Diagnoseinformationen und werden an Grenzen in verständliche Meldungen übersetzt.
- Retry, Timeout und Fallback sind explizite Architekturentscheidungen und werden nur dort genutzt, wo sie fachlich korrekt sind.
- Fehlerzustände sind testbar und werden nicht nur geloggt.

## Security und Datenschutz

- Secrets, Tokens, personenbezogene Daten und interne Infrastrukturdetails werden nicht geloggt.
- Authentifizierung, Autorisierung und Mandantentrennung werden an zentralen Grenzen geprüft.
- Eingaben aus UI, CLI, Dateien, Datenbanken und APIs gelten als unsicher, bis sie validiert wurden.
- Abhängigkeiten werden bewusst gewählt und aktualisiert. Sicherheitsupdates haben Vorrang vor kosmetischen Refactorings.
- Testdaten dürfen keine echten personenbezogenen oder vertraulichen Daten enthalten.

## Performance und Betrieb

- Performance-Optimierungen basieren auf beobachtbarem Bedarf oder klaren Größenordnungen.
- I/O, CPU-intensive Arbeit und Speicherverbrauch werden bei großen Datenmengen bewusst betrachtet.
- Caching braucht Invalidierungsregeln, Fehlerverhalten und Tests.
- Logging, Metriken und Traces sollen wichtige Use Cases und Fehlerpfade nachvollziehbar machen.
- Hintergrundprozesse, Worker und Polling müssen abbrechbar sein und Ressourcen freigeben.

## Versionspolitik

- Projekte verwenden stabile und unterstützte Versionen der jeweiligen Plattform.
- Bei Scaffold, Major Upgrade oder Plattformwechsel werden die offiziellen Release- und Kompatibilitätsseiten geprüft.
- Runtime-, Framework- und Tool-Versionen werden im Repository fixiert oder eindeutig dokumentiert.
- Major Upgrades erfolgen bewusst mit Migrationsnotizen, Testlauf und Rückfallplan.
- Preview-, RC- oder Experimental-Features werden nur genutzt, wenn ihr Risiko bewusst akzeptiert und dokumentiert ist.

## Tests

- Reine Fachlogik wird mit schnellen Unit Tests abgesichert.
- Adapter für HTTP, Dateisystem, Datenbank und externe Dienste werden mit Fakes, Testservern oder kontrollierten Testdaten getestet.
- Workflows erhalten Tests für Happy Path, Fehlerpfade und fachlich kritische Abzweigungen.
- Vertragsrelevante APIs, Exporte, Schemas und Migrationen erhalten gezielte Contract- oder Schema-Tests.
- UI- und Console-Verhalten wird dort getestet, wo Formatierung, Navigation oder Nutzerentscheidungen fachlich relevant sind.
- Tests dürfen externe Live-Dienste nicht voraussetzen. Live-Checks sind separat markiert und dürfen normale CI-Läufe nicht destabilisieren.
- Tests sollen deterministisch, isoliert und lesbar sein. Zufall, Uhrzeit, Netzwerk und Dateisystem werden kontrolliert.

## Dokumentation

- Architekturdateien beschreiben Regeln, Grenzen und wiederkehrende Entscheidungen.
- `Repository.md` beschreibt das konkrete Projekt und wird bei relevanten Struktur- oder Fachänderungen gepflegt.
- Architekturentscheidungen mit langfristiger Wirkung werden als ADR oder in der naheliegendsten Dokumentation festgehalten.
- Wenn eine Regel bewusst verletzt wird, wird der Grund dokumentiert.
