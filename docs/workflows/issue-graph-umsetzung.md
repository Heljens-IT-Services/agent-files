# Workflow: Issue Graph Implementation

## Ziel

Ein Issue mit seinen relevanten Issue-Beziehungen deterministisch bis zur verifizierten Implementierung und zum Pull Request bearbeiten. Vor der Umsetzung wird der relevante Issue-Graph vollständig erfasst, der Umsetzungsscope festgelegt und ein temporärer Orchestrierungsplan erzeugt. Die Umsetzung erfolgt anschließend ausschließlich entlang dieses Plans.

## Verwenden

- Wenn ein Issue fachlich und technisch unter Berücksichtigung seines Issue-Graphen umgesetzt werden soll.
- Wenn Ausgangs-Issue, relevante Issue-Beziehungen, Scope, Ausführungsreihenfolge, Implementierung, Verifikation, Commit/Push und Pull Request zusammenhängend bearbeitet werden sollen.
- Wenn mehrere Issues aufgrund von Parent/Child- oder Blocked-by-Beziehungen koordiniert werden müssen.
- Nicht verwenden, wenn nur Optionen abgewogen werden sollen. Dann `brainstorming` nutzen.

## Direkte Aliase

- `/implement <issue-number>`

`<issue-number>` muss als positive Ganzzahl mit optional vorangestelltem `#` angegeben werden, zum Beispiel `/implement #123`.

## Verwendete Skills

- `github-branch-checkout-from-default`
- `issue-reading`
- `brainstorming`
- `pr-creation`

## Verwendete Workflows

- `issue-umsetzung.md`

## Phasen

### Phase 1: Graph lesen

1. Mit `issue-reading` das Ausgangs-Issue inklusive relevanter Parent-, Child- und Blocked-by-Beziehungen lesen.
2. Child-Beziehungen vom Ausgangs-Issue rekursiv verfolgen, bis keine weiteren relevanten Child-Issues gefunden werden.
3. Blocked-by-Beziehungen für alle bereits scope-relevanten Knoten lesen und die blockierenden Issues als Abhängigkeitskontext erfassen.
4. Bereits besuchte Issues nicht erneut traversieren. Eine besuchte Menge anhand stabiler Repository-/Issue-Identität führen.
5. Zyklen in Beziehungen erkennen und sichtbar markieren.
6. Parent-Beziehungen oberhalb des Ausgangs-Issues nur als Kontext lesen; daraus nicht automatisch weitere Geschwister oder andere Teilbäume in den Umsetzungsscope aufnehmen.
7. Geschlossene Issues, externe Blocker, bereits erledigte Knoten und reine Container-Issues als solche klassifizieren.

### Phase 2: Scope bestimmen

1. Aus dem gelesenen Graphen die tatsächlich umzusetzenden Issue-Knoten bestimmen.
2. Parent/Child-Beziehungen bestimmen Zugehörigkeit und fachlichen Scope, aber nicht automatisch die Ausführungsreihenfolge.
3. Geschlossene Issues nicht erneut umsetzen.
4. Ein Parent- oder Container-Issue nicht zusätzlich als eigenes Arbeitspaket behandeln, wenn sein vollständiger Umsetzungsumfang durch aufgenommene Child-Issues abgedeckt ist.
5. Blockierende Issues außerhalb des fachlichen Graph-Scope nicht automatisch in den Umsetzungsscope aufnehmen.
6. Wenn ein offener externer Blocker die Umsetzung verhindert, den betroffenen Knoten als blockiert markieren.
7. Wenn Scope-Grenzen, Container-Semantik oder die Aufnahme eines Blockers nicht eindeutig bestimmbar sind, diese Unklarheit vor der Umsetzung klären.
8. Ergebnis der Phase ist eine explizite Menge aus:
   - umzusetzenden Issues
   - Kontext-Issues
   - bereits erledigten Issues
   - externen Blockern
   - aktuell blockierten Issues

### Phase 3: Arbeitsbranch und Orchestrierungsplan vorbereiten

1. Mit `github-branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen oder bestätigen.
2. Vor jeder Codeänderung einen Orchestrierungsplan als langlebigen Fortschrittsanker im unversionierten Git-Verwaltungsbereich des Arbeitsbaums erzeugen oder fortführen. Er koordiniert Issue-Knoten und ersetzt nicht deren technische Task-Pläne. Pfad und Dateiname müssen aus Repository und Ausgangs-Issues deterministisch ableitbar sein.
3. Der Orchestrierungsplan ist ein reines Runtime-Artefakt. Er muss Sitzungsunterbrechungen überstehen und darf nicht Bestandteil des fachlichen Repository-Änderungssatzes, eines Commits oder des Pull Requests werden.
4. Der Plan muss mindestens enthalten:
   - Ausgangs-Issue
   - alle gelesenen relevanten Issue-Knoten mit Status und Klassifikation
   - relevante Parent/Child- und Blocked-by-Beziehungen
   - finalen Umsetzungsscope
   - nicht umzusetzende Kontext- oder bereits erledigte Knoten mit Grund
   - externe und interne Blocker
   - blockierte Knoten mit Ursache
   - deterministische Umsetzungsreihenfolge beziehungsweise Ausführungswellen
   - vorgesehene Pull-Request-Schnitte
   - letzten abgeschlossenen Schritt mit Commit-, Push- und Pull-Request-Kontext
   - offenen oder nicht ausführbaren Rest-Scope
5. Die Reihenfolge anhand harter Abhängigkeiten bestimmen. Blocked-by-Beziehungen müssen vor der Umsetzung des blockierten Knotens erfüllt sein.
6. Wenn mehrere Knoten unabhängig voneinander ausführbar sind, eine stabile Reihenfolge festlegen und im Plan dokumentieren.
7. Zyklen in harten Abhängigkeiten blockieren die Planausführung. Den konkreten Zyklus benennen und nicht raten.
8. Der erzeugte Plan ist während der gesamten Umsetzung die maßgebliche Orchestrierungsgrundlage. Ihn nach jedem zustandsverändernden Schritt und bei neuen Graph-Erkenntnissen aktualisieren.

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

## External blockers
- #300 - blockiert #127; nicht im Umsetzungsscope

## Execution order
1. #124
2. #125
3. #126

## Blocked remainder
- #127 - wartet auf #300
```

### Phase 4: Nach Plan umsetzen

1. Den technischen Plan jedes terminalen Tasks als primäre Ausführungsgrundlage übernehmen. Nur bei offener technischer Richtung oder echtem Planbruch mit `brainstorming` Optionen vergleichen und den Orchestrierungsplan bei relevanten Auswirkungen aktualisieren.
2. Den Orchestrierungsplan in der festgelegten Reihenfolge abarbeiten.
3. Je ausführbarem Issue-Knoten genau eine abgeschlossene Arbeitseinheit bilden und dafür `issue-umsetzung.md` ausführen.
4. Ein nächstes Issue erst beginnen, wenn das vorherige Issue gemäß `issue-umsetzung.md` vollständig implementiert, verifiziert, reviewed, committed und gepusht wurde.
5. Jeder vollständig umgesetzte Issue-Knoten muss mindestens einem eindeutig zuordenbaren Commit entsprechen. Wenn ein Issue mehrere logisch getrennte Commits benötigt, sind mehrere Commits zulässig.
6. Änderungen verschiedener Issue-Knoten nicht absichtlich in demselben Commit vermischen.
7. Nach jedem Issue den Orchestrierungsplan gegen den tatsächlichen Zustand prüfen und aktualisieren.
8. Blockierte Knoten nicht überspringen und stillschweigend als abgeschlossen behandeln. Nur mit dem nächsten laut Plan unabhängigen ausführbaren Knoten fortfahren.

### Ausführungswellen und Pull-Request-Schnitte

1. Den Graphen in Ausführungswellen oder mehrere Pull Requests teilen, wenn ein einzelner Änderungssatz nicht sicher in einem Durchlauf umgesetzt, geprüft oder reviewed werden kann.
2. Jeder Pull-Request-Schnitt muss vollständige Arbeitseinheiten enthalten. Abhängige Schnitte dürfen erst beginnen, wenn der benötigte Vorgänger im jeweiligen Basisbranch enthalten ist.
3. Nach jedem Pull Request dessen Kontext und den verbleibenden Scope im Fortschrittsanker festhalten und den Workflow mit einem Arbeitsbranch für den nächsten Schnitt ab Phase 3 fortsetzen.
4. Ein abgeschlossener Pull-Request-Schnitt ist kein Abschluss des gesamten Issue-Graphen.

### Phase 5: Abschluss und Integritätsprüfung

1. Prüfen, dass jeder im Umsetzungsscope als abgeschlossen markierte Issue-Knoten vollständig implementiert, verifiziert und reviewed wurde.
2. Für jeden abgeschlossenen Issue-Knoten prüfen, dass der zugehörige Änderungssatz committed und auf den vorgesehenen Upstream gepusht wurde.
3. Commit-Historie und Orchestrierungsplan gegeneinander prüfen. Kein als umgesetzt markiertes Issue darf ohne eindeutig zuordenbaren Commit-Kontext verbleiben.
4. Prüfen, dass keine fachlichen Änderungen aus dem Umsetzungsscope uncommitted oder ungepusht verbleiben.
5. Lokalen Git-Arbeitsbaum prüfen. Vor PR-Erstellung muss der Arbeitsbaum frei von unbeabsichtigten staged, unstaged oder untracked fachlichen Änderungen sein.
6. Runtime-Artefakte im Arbeitsbaum entfernen. Den Fortschrittsanker im Git-Verwaltungsbereich bis zur abschließenden Integritätsprüfung behalten.
7. Danach den Git-Arbeitsbaum erneut prüfen. Runtime-Artefakte dürfen weder staged noch committed sein und nicht im Arbeitsbaum zurückbleiben.
8. Wenn der Arbeitsbaum nicht sauber ist, ein Commit oder Push fehlt oder ein Runtime-Artefakt im Arbeitsbaum liegt, die PR-Erstellung blockieren und den konkreten Restzustand beheben oder melden. Der unversionierte Fortschrittsanker im Git-Verwaltungsbereich darf für weitere Pull-Request-Schnitte bestehen bleiben.
9. Den finalen Issue-Scope und Teststatus für den Pull Request zusammenstellen.
10. Mit `pr-creation` den Pull Request mit Review-Kontext und den tatsächlich abgeschlossenen Issue-Verknüpfungen erstellen.
11. Das Ausgangs-Issue und weitere durch den PR vollständig abgeschlossene Scope-Issues so verlinken, dass GitHub sie beim Merge schließen kann. Nicht vollständig abgeschlossene oder extern blockierte Issues nur referenzieren.
12. Den Fortschrittsanker vor jeder Abschlussmeldung erneut gegen Issue-Graph, Commit-, Push- und Pull-Request-Status prüfen.
13. Solange ein ausführbarer Scope-Knoten offen ist, keine Abschlussmeldung ausgeben, sondern die Ausführung fortsetzen. Bei einer Unterbrechung ausschließlich den Zwischenstand und den Wiederaufnahmepunkt melden.
14. Erst wenn kein ausführbarer Rest-Scope verbleibt, den Fortschrittsanker entfernen und den sauberen Arbeitsbaum erneut prüfen.

## Rücksprungregeln

## Codex-Orchestrierung

- Graph- und Scope-Phasen: `planner`; der Hauptagent bleibt für die abschließende Scope-Entscheidung verantwortlich.
- Technische Arbeitseinheiten: sequenziell `developer`, danach `tester`.
- Commit und Push je Arbeitseinheit sowie PR-Schnitt: `main/orchestrator`.
- Schreibende Arbeitseinheiten werden nicht parallel auf demselben Worktree ausgeführt.
- Planbruch geht an `planner`; lokaler Implementierungsfehler an `developer`; widersprüchliche Akzeptanzkriterien an `planner` oder den Orchestrator.

- Bei unklarem Issue-Kontext zurück zu Phase 1 und `issue-reading`.
- Bei unklaren Issue-Beziehungen zurück zu Phase 1.
- Bei unklarem oder ausgeweitetem Scope zurück zu Phase 2.
- Bei widersprüchlichen Abhängigkeiten, neu erkannten Blockern oder Zyklen zurück zu Phase 3.
- Bei einem echten Planbruch zurück zu `brainstorming` oder zur gezielten Arbeitspaket-Planung in `issue-umsetzung.md`; anschließend den Orchestrierungsplan aktualisieren.
- Bei fehlgeschlagenen Tests gelten die Rücksprungregeln aus `issue-umsetzung.md`.
- Wenn ein externer Blocker nicht selbstständig gelöst werden kann, den betroffenen Knoten blockiert lassen und den nicht ausführbaren Rest-Scope sichtbar machen.
- Bei fehlendem Commit, fehlendem Push, schmutzigem Arbeitsbaum oder verbliebenen temporären Dateien zurück zu Phase 4 beziehungsweise zum passenden Cleanup-Schritt in Phase 5.

## Endergebnis

- vollständig gelesener und klassifizierter relevanter Issue-Graph
- explizit bestimmter Umsetzungsscope
- abgearbeiteter temporärer Orchestrierungsplan
- verifizierte Änderungen für alle ausführbaren Scope-Issues
- eindeutig pro Issue zuordenbarer Commit-/Push-Kontext
- entfernter temporärer Orchestrierungsplan und entfernte sonstige Runtime-Artefakte
- sauberer lokaler Git-Arbeitsbaum
- dokumentierter blockierter Rest-Scope, falls der Graph nicht vollständig ausführbar war
- erstellter Pull Request für den tatsächlich abgeschlossenen Scope

## Grenzen

- Ausgangs-Issue nicht manuell schließen, wenn der Abschluss über den Pull-Request-Merge erfolgen soll.
- Child- oder andere Scope-Issues während der Graph-Umsetzung nicht vorzeitig manuell schließen, wenn sie durch denselben Pull Request abgeschlossen werden sollen.
- Parent/Child-Beziehungen nicht als harte Ausführungsabhängigkeit interpretieren, sofern keine zusätzliche Blocked-by- oder fachlich eindeutige Abhängigkeit besteht.
- Eine Blocked-by-Kante zwischen einem reinen Container-Issue und einem eigenen Nachfahren ist ein Graphfehler, wenn sie eine Abschlussreihenfolge erzeugt. Die Kante sichtbar machen und den betroffenen Scope bis zur Korrektur nicht ausführen.
- Externe Blocker nicht allein aufgrund einer Blocked-by-Beziehung automatisch umsetzen.
- Keine Umsetzung beginnen, bevor ein belastbarer Orchestrierungsplan vorliegt.
- Den Fortschrittsanker niemals committen oder in den Pull Request aufnehmen.
- Keinen Pull Request erstellen, solange der Arbeitsbaum nicht sauber ist oder abgeschlossene Issue-Knoten ohne vollständigen Commit-/Push-Kontext existieren.
- Wenn automatisches Schließen nicht sicher ist, im PR-Kontext sichtbar machen.
