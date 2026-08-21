# Workflow: Issue Graph Implementation

## Ziel

Ein Issue mit seinem relevanten Issue-Graph deterministisch und vollständig bis zur verifizierten Implementierung und zu genau einem finalen Pull Request bearbeiten. Vor der Umsetzung wird der relevante Issue-Graph vollständig erfasst, der Umsetzungsscope festgelegt und ein temporärer Orchestrierungsplan erzeugt. Anschließend wird der vollständige Scope auf genau einem Arbeitsbranch sequenziell abgearbeitet.

## Verwenden

- Wenn ein Issue fachlich und technisch unter Berücksichtigung seines Issue-Graphen vollständig umgesetzt werden soll.
- Wenn Ausgangs-Issue, relevante Issue-Beziehungen, Scope, Ausführungsreihenfolge, Implementierung, Verifikation, Commit/Push und ein finaler Pull Request zusammenhängend bearbeitet werden sollen.
- Wenn mehrere Issues aufgrund von Parent/Child- oder Blocked-by-Beziehungen koordiniert werden müssen.
- Nicht verwenden, wenn der relevante Graph vor der Umsetzung nicht vollständig und deterministisch ausführbar ist.

## Direkte Aliase

- `/implement <issue-number>`

`<issue-number>` muss als positive Ganzzahl mit optional vorangestelltem `#` angegeben werden, zum Beispiel `/implement #123`.

## Verwendete Skills

- `github-branch-checkout-from-default`
- `issue-reading`
- `pr-creation`

## Verwendete Workflows

- `issue-implementation.md`

## Phasen

### Phase 1: Graph lesen

1. Mit `issue-reading` das Ausgangs-Issue inklusive relevanter Parent-, Child- und Blocked-by-Beziehungen lesen.
2. Child-Beziehungen vom Ausgangs-Issue rekursiv verfolgen, bis keine weiteren relevanten Child-Issues gefunden werden.
3. Blocked-by-Beziehungen für alle scope-relevanten Knoten lesen und als Ausführungsabhängigkeiten erfassen.
4. Bereits besuchte Issues nicht erneut traversieren. Eine besuchte Menge anhand stabiler Repository-/Issue-Identität führen.
5. Parent-Beziehungen oberhalb des Ausgangs-Issues nur als Kontext lesen; daraus nicht automatisch weitere Geschwister oder andere Teilbäume in den Umsetzungsscope aufnehmen.
6. Geschlossene Issues und reine Container-Issues als solche klassifizieren.

### Phase 2: Scope und Ausführbarkeit bestimmen

1. Aus dem gelesenen Graphen die tatsächlich umzusetzenden Issue-Knoten bestimmen.
2. Parent/Child-Beziehungen bestimmen Zugehörigkeit und fachlichen Scope, aber nicht automatisch die Ausführungsreihenfolge.
3. Geschlossene Issues nicht erneut umsetzen.
4. Ein Parent- oder Container-Issue nicht zusätzlich als eigenes Arbeitspaket behandeln, wenn sein vollständiger Umsetzungsumfang durch aufgenommene Child-Issues abgedeckt ist.
5. Die Ausführungsreihenfolge anhand harter Abhängigkeiten bestimmen. Ein blockierter Knoten darf erst umgesetzt werden, nachdem seine Blocked-by-Abhängigkeiten erfüllt sind.
6. Wenn mehrere Knoten unabhängig voneinander ausführbar sind, eine stabile Reihenfolge festlegen.
7. Vor jeder Codeänderung sicherstellen, dass der vollständige Umsetzungsscope mit genau einem Arbeitsbranch und einem finalen Pull Request deterministisch ausführbar ist.
8. Wenn ein externer Blocker, ein Abhängigkeitszyklus, eine unklare Scope-Grenze oder eine andere Unstimmigkeit diese vollständige Ausführung verhindert, vor der Implementierung stoppen und den konkreten Grund melden. Keine partielle Umsetzung beginnen und keinen alternativen Ausführungsmodus ableiten.
9. Ergebnis der Phase ist eine explizite Menge aus:
   - umzusetzenden Issues
   - Kontext-Issues
   - bereits erledigten Issues
   - deterministischer Ausführungsreihenfolge

### Phase 3: Arbeitsbranch und Orchestrierungsplan vorbereiten

1. Mit `github-branch-checkout-from-default` genau einen geeigneten Arbeitsbranch von der Standardbasis erstellen oder bestätigen.
2. Vor jeder Codeänderung einen Orchestrierungsplan als langlebigen Fortschrittsanker im unversionierten Git-Verwaltungsbereich des Arbeitsbaums erzeugen oder fortführen. Er koordiniert Issue-Knoten und ersetzt nicht deren technische Task-Pläne. Pfad und Dateiname müssen aus Repository und Ausgangs-Issue deterministisch ableitbar sein.
3. Der Orchestrierungsplan ist ein reines Runtime-Artefakt. Er muss Sitzungsunterbrechungen überstehen und darf nicht Bestandteil des fachlichen Repository-Änderungssatzes, eines Commits oder des Pull Requests werden.
4. Der Plan muss mindestens enthalten:
   - Ausgangs-Issue
   - alle gelesenen relevanten Issue-Knoten mit Status und Klassifikation
   - relevante Parent/Child- und Blocked-by-Beziehungen
   - finalen Umsetzungsscope
   - nicht umzusetzende Kontext- oder bereits erledigte Knoten mit Grund
   - deterministische Umsetzungsreihenfolge
   - letzten abgeschlossenen Schritt mit Commit- und Push-Kontext
5. Der erzeugte Plan ist während der gesamten Umsetzung die maßgebliche Orchestrierungsgrundlage. Ihn nach jedem zustandsverändernden Schritt aktualisieren.

Empfohlene Struktur des Fortschrittsankers:

```markdown
# Issue Graph Execution Plan

## Root
- #123

## Scope
- #124 - ready
- #125 - blocked by #124
- #126 - ready

## Context only
- #123 - container; vollständig durch Child-Issues abgedeckt
- #120 - parent context

## Execution order
1. #124
2. #125
3. #126

## Progress
- last completed: none
```

### Phase 4: Nach Plan umsetzen

1. Den Orchestrierungsplan in der festgelegten Reihenfolge vollständig abarbeiten.
2. Je Issue-Knoten genau eine abgeschlossene Arbeitseinheit bilden und dafür `issue-implementation.md` ausführen.
3. Ein nächstes Issue erst beginnen, wenn das vorherige Issue gemäß `issue-implementation.md` vollständig implementiert, verifiziert, reviewed, committed und gepusht wurde.
4. Jeder vollständig umgesetzte Issue-Knoten muss mindestens einem eindeutig zuordenbaren Commit entsprechen. Wenn ein Issue mehrere logisch getrennte Commits benötigt, sind mehrere Commits zulässig.
5. Änderungen verschiedener Issue-Knoten nicht absichtlich in demselben Commit vermischen.
6. Nach jedem Issue den Orchestrierungsplan gegen den tatsächlichen Zustand prüfen und aktualisieren.
7. Während dieser Phase keinen Pull Request erstellen. Der Pull Request gehört ausschließlich in Phase 5 nach vollständiger Abarbeitung des Umsetzungsscope.
8. Erkennt die Umsetzung eine Unstimmigkeit, durch die der vorab festgelegte Scope nicht mehr vollständig nach diesem Workflow ausführbar ist, stoppen und den konkreten Zustand melden. Nicht selbstständig in einen alternativen Workflow, eine partielle Umsetzung oder mehrere Pull Requests wechseln.

### Phase 5: Abschluss und finaler Pull Request

1. Prüfen, dass jeder Issue-Knoten im Umsetzungsscope vollständig implementiert, verifiziert und reviewed wurde.
2. Für jeden Issue-Knoten prüfen, dass der zugehörige Änderungssatz committed und auf den vorgesehenen Upstream gepusht wurde.
3. Commit-Historie und Orchestrierungsplan gegeneinander prüfen. Kein umgesetztes Issue darf ohne eindeutig zuordenbaren Commit-Kontext verbleiben.
4. Prüfen, dass keine fachlichen Änderungen aus dem Umsetzungsscope uncommitted oder ungepusht verbleiben.
5. Lokalen Git-Arbeitsbaum prüfen. Vor PR-Erstellung muss der Arbeitsbaum frei von unbeabsichtigten staged, unstaged oder untracked fachlichen Änderungen sein.
6. Runtime-Artefakte im Arbeitsbaum entfernen. Den Fortschrittsanker im Git-Verwaltungsbereich bis zur abschließenden Integritätsprüfung behalten.
7. Danach den Git-Arbeitsbaum erneut prüfen. Runtime-Artefakte dürfen weder staged noch committed sein und nicht im Arbeitsbaum zurückbleiben.
8. Wenn der Arbeitsbaum nicht sauber ist oder ein Commit beziehungsweise Push fehlt, die PR-Erstellung blockieren und den konkreten Restzustand beheben oder melden.
9. Den finalen Issue-Scope und Teststatus für den Pull Request zusammenstellen.
10. Mit `pr-creation` genau einen Pull Request für den vollständigen Umsetzungsscope erstellen.
11. Das Ausgangs-Issue und weitere durch den PR vollständig abgeschlossene Scope-Issues so verlinken, dass GitHub sie beim Merge schließen kann.
12. Den Fortschrittsanker gegen Issue-Graph, Commit-, Push- und Pull-Request-Status prüfen und danach entfernen.
13. Den sauberen Arbeitsbaum erneut prüfen und erst danach den Workflow als abgeschlossen melden.

## Codex-Orchestrierung

- Graph- und Scope-Phasen: `planner`; der Hauptagent bleibt für die abschließende Scope- und Ausführbarkeitsentscheidung verantwortlich.
- Technische Arbeitseinheiten: sequenziell `developer`, danach `tester`.
- Commit und Push je Arbeitseinheit sowie der finale Pull Request: `main/orchestrator`.
- Schreibende Arbeitseinheiten werden nicht parallel auf demselben Worktree ausgeführt.
- Lokale Implementierungs- oder Testfehler werden innerhalb von `issue-implementation.md` behandelt.
- Erkennt eine Rolle eine Unstimmigkeit, die den vorab festgelegten vollständigen Ablauf ungültig macht, geht die Steuerung an den Orchestrator zurück und der Workflow stoppt mit dem konkreten Grund.

## Endergebnis

- vollständig gelesener und klassifizierter relevanter Issue-Graph
- explizit bestimmter und vorab vollständig ausführbarer Umsetzungsscope
- genau ein Arbeitsbranch für den vollständigen Umsetzungsscope
- vollständig abgearbeiteter temporärer Orchestrierungsplan
- verifizierte Änderungen für alle Scope-Issues
- eindeutig pro Issue zuordenbarer Commit-/Push-Kontext
- entfernter temporärer Orchestrierungsplan und entfernte sonstige Runtime-Artefakte
- sauberer lokaler Git-Arbeitsbaum
- genau ein finaler Pull Request für den vollständigen Umsetzungsscope

## Grenzen

- Genau einen Arbeitsbranch für den vollständigen Umsetzungsscope verwenden.
- Während der Graph-Umsetzung keine Pull Requests erstellen.
- Genau einen Pull Request nach vollständiger Umsetzung des gesamten Scope erstellen.
- Keine Pull-Request-Schnitte, gestapelten Pull Requests, Ausführungswellen oder partiellen Graph-Umsetzungen innerhalb dieses Workflows planen oder ausführen.
- Sonderfälle nicht innerhalb von `/implement` lösen. Wenn der vollständige Scope nicht nach diesem Ablauf ausführbar ist, vor der Implementierung stoppen oder bei einer erst später erkannten grundlegenden Unstimmigkeit die weitere Ausführung stoppen und den Grund melden.
- Ausgangs-Issue nicht manuell schließen, wenn der Abschluss über den Pull-Request-Merge erfolgen soll.
- Child- oder andere Scope-Issues während der Graph-Umsetzung nicht vorzeitig manuell schließen, wenn sie durch denselben Pull Request abgeschlossen werden sollen.
- Parent/Child-Beziehungen nicht als harte Ausführungsabhängigkeit interpretieren, sofern keine zusätzliche Blocked-by- oder fachlich eindeutige Abhängigkeit besteht.
- Blockierende Issues außerhalb des fachlichen Graph-Scope nicht allein aufgrund einer Blocked-by-Beziehung automatisch umsetzen.
- Keine Umsetzung beginnen, bevor ein belastbarer Orchestrierungsplan vorliegt.
- Den Fortschrittsanker niemals committen oder in den Pull Request aufnehmen.
- Keinen Pull Request erstellen, solange der Arbeitsbaum nicht sauber ist oder abgeschlossene Issue-Knoten ohne vollständigen Commit-/Push-Kontext existieren.
- Wenn automatisches Schließen nicht sicher ist, im PR-Kontext sichtbar machen.
