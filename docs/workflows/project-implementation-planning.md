# Workflow: Project Implementation Planning

## Ziel

Eine noch diskutierbare projektweite Zielvorstellung durch Human-geführte Klärung in einen freigegebenen Implementierungsplan oberhalb der Epic-Ebene überführen. Der Plan beschreibt große Implementierungsphasen und keine technische Story-/Task-Zerlegung.

## Verwenden

- Wenn ein Projektziel, mehrere Features oder ein gewünschter Zielzustand vor der Epic-Erstellung strukturiert werden sollen.
- Wenn Zielbild, Scope, Nicht-Ziele, Prioritäten, Randbedingungen oder wesentliche Produkt-/Architekturentscheidungen noch mit dem Human geklärt werden müssen.
- Nicht verwenden, um technische Arbeitspakete auf Datei-, Symbol- oder Task-Ebene zu planen. Dafür `code-implementation-planning` verwenden.
- Nicht verwenden, um automatisch GitHub-Issues oder Epics zu erzeugen. Die Materialisierung einer freigegebenen Phase ist ein nachgelagerter, eigener Schritt.

## Verwendete Skills

- `requirements-clarification`
- `brainstorming` bei mehreren plausiblen Produkt- oder Architekturentscheidungen

## Ablauf

1. Ausgangsvorstellung, bekannten Kontext und gewünschte Wirkung festhalten.
2. Interaktiv Zielbild, erwartete Fähigkeiten/Features, Scope, Nicht-Ziele, Prioritäten, Abhängigkeiten, Constraints und Erfolgskriterien klären.
3. Offene Produkt-, Architektur- oder Vorgehensentscheidungen sichtbar machen. Bei mehreren tragfähigen Richtungen `brainstorming` verwenden.
4. Prüfen, dass die Klärung belastbar ist: Ziel und Nicht-Ziele sind eindeutig, Scope-Grenzen sind benennbar, Prioritäten sind geordnet und wesentliche Entscheidungen sind entschieden oder ausdrücklich als Blocker dokumentiert.
5. Ein explizites Human-Gate durchführen. Nur eine ausdrückliche Freigabe des Humans darf den Status `READY` beziehungsweise `FINAL` begründen.
6. Nach Freigabe große Implementierungsphasen mit dem Phasenvertrag dieses Workflows formulieren.
7. Jede Phase gegen Zielbild, Scope, Nicht-Ziele, Abhängigkeiten/Constraints und Exit-/Akzeptanzkriterien prüfen.
8. Den Plan als Chat-Kontext ausgeben oder als langlebiges Artefakt dokumentieren, wenn der User dies verlangt oder der konkrete Projektworkflow es vorsieht.

## Human-Gate

Vor der finalen Phasenbildung muss der Human mindestens bestätigen:

- Zielbild und erwartete Fähigkeiten,
- Scope und Nicht-Ziele,
- Prioritäten und wesentliche Abhängigkeiten,
- relevante Produkt-/Architekturentscheidungen,
- dass die daraus gebildeten Phasen als Grundlage für Epic-Issues dienen dürfen.

Ohne diese Freigabe bleibt der Plan `DRAFT` oder `BLOCKED`; ein finaler oder belastbarer Plan darf nicht behauptet werden.

## Planvertrag

Ein freigegebener Plan enthält mindestens:

- Zielbild und erwarteten Zielzustand,
- vereinbarten Scope und Nicht-Ziele,
- Prioritäten, Constraints und wesentliche Entscheidungen,
- offene Punkte oder Blocker,
- geordnete große Implementierungsphasen,
- pro Phase Ziel, Scope, Nicht-Ziele, wesentliche Abhängigkeiten/Constraints und Exit-/Akzeptanzkriterien,
- Status `DRAFT`, `READY` oder `BLOCKED`, Freigabeentscheidung und Freigabekontext.

Phasen sind fachliche High-Level-Zielzustände oberhalb von Epics. Sie dürfen keine unnötige Mikroplanung für Stories, Tasks, Dateien oder Symbole enthalten.

## Rücksprungregeln

- Bei unklarem Ziel, Scope oder Nicht-Ziel zu `requirements-clarification` zurückkehren.
- Bei einer offenen Richtungsentscheidung zu `brainstorming` zurückkehren.
- Bei fehlender Human-Freigabe im Status `DRAFT` beziehungsweise `BLOCKED` verbleiben.

## Endergebnis

- geklärtes und vom Human freigegebenes Zielbild
- klar abgegrenzter projektweiter Implementierungsplan
- große, einzeln beschriebene Implementierungsphasen oberhalb der Epic-Ebene
- sichtbare offene Punkte und Blocker
- keine automatisch erzeugten Issues und keine technische Task-Mikroplanung

## Grenzen

- Keine implizite oder automatische Human-Freigabe.
- Keine neuen Anforderungen ohne Klärung in den Plan aufnehmen.
- Keine Epic-, Story- oder Task-Erstellung in diesem Workflow.
- Keine technische Detailplanung von Stories oder Tasks vorwegnehmen.
