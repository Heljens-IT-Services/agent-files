# Workflow: Issue To Sub Issues Flat

## Ziel

Ein Issue genau eine Ebene in klare Child-Issues zerlegen.

## Verwenden

- Für bewusst flache Zerlegung.
- Als atomarer Teilworkflow von `issue-to-sub-issues.md`.
- Nicht verwenden, wenn das Ausgangs-Issue bereits terminal ist.

## Verwendete Skills

- `issue-reading`
- `requirements-clarification`
- `brainstorming`
- `code-implementation-planning`
- `issue-creation`
- `type-setting`
- `relationship-setting`

## Ablauf

1. Ausgangs-Issue und vorhandene direkte Children lesen.
2. Ziel, Scope und Akzeptanzkriterien klären, falls sie für einen Schnitt nicht ausreichen.
3. Vorhandene passende Child-Issues wiederverwenden.
4. Falls nötig mit `brainstorming` den Schnitt bestimmen.
5. Genau eine Child-Ebene planen. Für Task-Children mit `code-implementation-planning` einen technischen Ausführungsplan ableiten und in den [kanonischen Task-Issue-Vertrag](../github/ISSUE_TEMPLATES.md#task-issue-vertrag) überführen.
6. Fehlende Child-Issues erstellen und ihren Type setzen. Wesentliche offene Entscheidungen sichtbar lassen und den betroffenen Task nicht als terminal behandeln.
7. Parent/Child-Beziehungen setzen.
8. Erforderliche `blocked by`-Beziehungen setzen.
9. Die erzeugte Ebene zurücklesen und prüfen.

## Schnittkriterien

- ein klares Ziel pro Child-Issue
- eigenständig verständlich und kleiner als der Parent
- klarer Scope und Nicht-Scope
- belastbare Abschluss- oder Akzeptanzkriterien
- keine semantischen Duplikate
- Parent/Child nicht als Ausführungsreihenfolge interpretieren
- Type kontextbasiert bestimmen
- Task-Children erfüllen den kanonischen Task-Issue-Vertrag oder sind ausdrücklich als nicht terminal erkennbar

## Codex-Orchestrierung

- Zerlegung, Schnittkriterien und fachliche Parent/Child-Entscheidung: `planner`.
- Issue-Erstellung und Relationship-Mutationen: `main/orchestrator` nach der Planner-Prüfung.
- Unklare Ziele oder Schnitte gehen zurück an `planner`; keine parallelen Schreibmutationen auf demselben Issue-Graphen.

## Endergebnis

- genau eine verifizierte Child-Ebene
- gesetzte Types und Beziehungen

## Grenzen

- Keine zweite Ebene erzeugen.
- Keine Umsetzung starten.
- Ausgangs-Issue nicht schließen.
- Keine künstliche Zerlegung erzeugen.
