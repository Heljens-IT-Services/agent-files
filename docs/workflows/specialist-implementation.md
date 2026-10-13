# Workflow: Spezialisten-Implementierung

## Zweck

Eine geklärte und abgegrenzte technische Änderung innerhalb der eigenen Implementierungszuständigkeit ausführen.

## Owner

`softwareentwicklung_backend`, `softwareentwicklung_frontend` oder `softwareentwicklung_infrastruktur`, abhängig vom Auftrag.

## Verwenden

- Für beauftragte Code-, API-, UI- oder Infrastrukturänderungen mit festgelegtem Ziel und Scope.

## Verwendete Skills

- `code-reading`
- `code-analysis` bei bestehendem Verhalten oder Ursache
- `code-implementation`
- `code-refactoring` nur bei verhaltenserhaltendem Auftrag
- `code-minimization` nach lokaler Stabilisierung, sofern im aufrufenden Workflow vorgesehen

## Ablauf

1. Den übergebenen Plan, Scope, Nicht-Scope, Constraints und Akzeptanzkriterien prüfen.
2. Nur den eigenen Rollenindex und für die Aufgabe freigegebene Technologien verwenden.
3. Bestehenden Code und relevante Grenzen gezielt lesen; ungeklärte technische Strukturentscheidungen an `softwareentwicklung_architektur` zurückgeben.
4. Die zugewiesene Änderung im ausdrücklich freigegebenen Dateiscope umsetzen.
5. Eigene lokale Rückmeldung oder direkte Entwicklungschecks nur ausführen, wenn der Auftrag sie ausdrücklich als Implementierungsfeedback vorsieht; formale unabhängige Verifikation an `softwareentwicklung_qualitaetssicherung` übergeben.
6. Änderungen und Nachweise dem Koordinator zurückgeben.

## Grenzen

- Keine Issue- oder Projektplanung, keine selbständige Subdelegation und keine Arbeit außerhalb des zugewiesenen Scopes.
- Keine eigenständigen Git-, GitHub-, Commit-, Push-, PR-, Merge- oder Veröffentlichungsschritte.
- Keine formale Abnahme oder unabhängige Testverifikation.
- Bei fremder Zuständigkeit oder Planbruch stoppen und den Koordinator mit dem konkreten Befund informieren.

## Rückgabe

Ergebnis, geänderte Bereiche, Verifikation oder deren Auslassung, Abweichungen, Blocker und empfohlene nächste Rolle.
