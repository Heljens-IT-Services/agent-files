# AGENTS.md

## Zweck

Diese Datei ist der verbindliche Einstiegspunkt für AI-/Code-Agents in diesem Repository. Sie legt fest, welche Dokumente vor Änderungen zu berücksichtigen sind, wie Regeln priorisiert werden und welche Qualitätskriterien für Code-Änderungen gelten.

Projektspezifische Informationen stehen in `agents/Repository.md`. Technologieübergreifende Architekturregeln stehen in `agents/Architecture.md`. Technologiespezifische Regeln stehen in den passenden `agents/Architecture.*.md`-Dateien.

Der Ordner `agents/` enthält bewusst gepflegte Agent- und Engineering-Regeln. Der Ordner `docs/` ist für ergänzende Langform-Dokumentation wie ADRs, API-Spezifikationen, Domänenbeschreibungen, Betriebsdokumentation oder Diagramme gedacht.

## Pflichtlektüre vor Änderungen

Vor fachlichen oder strukturellen Änderungen gilt:

1. `agents/Repository.md` lesen, um Projektziel, Fachregeln, wichtige Pfade, Build-/Test-Kommandos und lokale Besonderheiten zu verstehen.
2. `agents/Architecture.md` lesen, um die allgemeinen Architektur-, Clean-Code- und Qualitätsregeln zu kennen.
3. Die passende Technologie-Datei lesen, zum Beispiel `agents/Architecture.Angular.md` für Angular oder `agents/Architecture.NETConsole.md` für .NET-Konsolenanwendungen.
4. Weitere lokale Dokumente wie `README.md`, `STRUCTURE.md`, ADRs, API-Spezifikationen oder Schema-Dateien lesen, wenn die Änderung deren Bereich berührt.

Wenn eine passende `agents/Architecture.*.md` fehlt, wird nach den vorhandenen Patterns des Repositories gearbeitet. Eine neue Technologie-Regeldatei wird nur ergänzt, wenn die Regel dauerhaft für mehrere Änderungen relevant ist.

## Regelpriorität

Bei widersprüchlichen Vorgaben gilt diese Reihenfolge:

1. Direkte User-Anweisung im aktuellen Task.
2. Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung.
3. `AGENTS.md`.
4. `agents/Repository.md`.
5. `agents/Architecture.md`.
6. Passende `agents/Architecture.*.md`.
7. Bestehender Code-Stil und lokale Patterns.

Repository-spezifische Regeln dürfen allgemeine Architekturregeln einschränken, müssen aber in `agents/Repository.md` oder einer lokalen ADR begründet sein.

## Arbeitsmodus

- Erst Kontext lesen, dann ändern. Annahmen werden anhand vorhandener Dateien, Tests und Konfiguration geprüft.
- Änderungen bleiben eng am Task. Keine beiläufigen Refactorings, Formatierungswellen oder Architekturumbauten ohne fachlichen Grund.
- Vorhandene User-Änderungen werden nicht zurückgesetzt, außer der User verlangt es ausdrücklich.
- Bestehende Patterns werden bevorzugt, solange sie nicht klar gegen dokumentierte Regeln verstoßen.
- Öffentliche Schnittstellen, Exportformate, Datenbankschemas und Konfigurationsverträge werden nur bewusst geändert und dokumentiert.
- Neue Abhängigkeiten brauchen einen klaren Nutzen, Wartbarkeitsperspektive und Kompatibilität mit der bestehenden Architektur.

## Clean-Code-Erwartungen

- Code beschreibt Fachlichkeit über klare Namen, kleine Einheiten und explizite Modelle.
- Funktionen und Methoden tun eine Sache auf einer Abstraktionsebene.
- Komplexe Bedingungen werden benannt, extrahiert oder in fachliche Policies/Services verschoben.
- Duplikation wird entfernt, wenn sie dieselbe fachliche Regel ausdrückt. Ähnliche, aber fachlich unterschiedliche Fälle werden nicht künstlich vereinheitlicht.
- Kommentare erklären warum etwas nötig ist, nicht was offensichtlich im Code steht.
- Fehlerfälle werden als Teil des normalen Designs behandelt, nicht als nachträgliche Sonderpfade.

## Tests und Verifikation

- Tests werden passend zum Risiko ergänzt oder angepasst.
- Fachlogik erhält schnelle Unit Tests.
- Workflow-, Infrastruktur- und Integrationsverhalten erhält Tests mit Fakes, Testservern oder kontrollierten Testdaten.
- Fehlerpfade, leere Daten, Timeouts, ungültige Eingaben und Berechtigungsfälle werden berücksichtigt, wenn sie vom Task berührt werden.
- Relevante Prüfungen werden ausgeführt. Nicht ausgeführte Prüfungen werden mit Grund genannt.

## Dokumentationspflege

- `agents/Repository.md` wird aktualisiert, wenn sich Projektziel, wichtige Pfade, Build-/Test-Kommandos, Fachregeln oder externe Verträge ändern.
- `agents/Architecture.md` und `agents/Architecture.*.md` werden angepasst, wenn eine Regel allgemein gelten soll.
- Struktur- oder Typenübersichten werden aktualisiert, wenn das Repository solche Dokumente verwendet.
- Entscheidungen mit langfristiger Wirkung werden als ADR oder in der naheliegendsten Dokumentation festgehalten.

## Abschlusskriterien

Eine Änderung gilt erst als abgeschlossen, wenn:

- der Code kompiliert bzw. die relevanten statischen Checks laufen,
- relevante Tests ausgeführt oder begründet ausgelassen wurden,
- betroffene Dokumentation aktualisiert wurde,
- Migrations-, Rollback- oder Kompatibilitätsfragen geklärt sind, sofern sie vom Task berührt werden,
- neue oder geänderte Projektdateien keine unbeabsichtigten Template-Platzhalter wie `<...>`, `TODO`, `TBD` oder Beispielwerte enthalten,
- offene Risiken oder nicht ausgeführte Prüfungen klar benannt sind.
