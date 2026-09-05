# Workflow: Issue Acceptance Convergence

## Ziel

Die Akzeptanzkriterien eines angegebenen Root-Issues und seines vollständigen nativen Child-Graphen gegen den aktuellen integrierten Stand prüfen. Die Prüfung ist graphweit und ersetzt weder lokale Task-Verifikation noch den technischen Branch-/PR-Abschluss.

## Verwenden

- Wenn ein `Epic`, eine `Story` oder ein `Task` fachlich abschließend gegen den finalen integrierten Stand geprüft werden soll.
- Wenn ein früher bereits grünes Child erneut auf Regressionen und den aktuellen Gesamtstand geprüft werden muss.
- Nicht verwenden, um Gaps innerhalb dieses Workflows automatisch zu beheben. Remediation wird kontrolliert an Planung und Umsetzung zurückgegeben.
- Nicht verwenden, um Issues automatisch zu schließen oder `/finish` fachlich umzudeuten.

## Direkter Alias

- `/acceptance <issue-number>`

Der kanonische Aufruf lautet `/workflows run issue-acceptance-convergence <issue-number>`.

`<issue-number>` muss eine positive Ganzzahl mit optional vorangestelltem `#` sein, zum Beispiel `/acceptance #123`.

## Verwendete Skills

- `issue-reading`
- `code-testing`
- `code-analysis` bei nicht direkt prüfbaren oder widersprüchlichen Kriterien

## Ablauf

1. Das Root-Issue mit Body, Kommentaren, Status, nativen Type- und Relationship-Metadaten lesen.
2. Prüfen, dass der Root-Type `Epic`, `Story` oder `Task` ist. Andere Root-Typen werden als `BLOCKED` mit konkreter Begründung ausgewiesen.
3. Vom Root ausschließlich native Child-Beziehungen rekursiv nach unten verfolgen. Parent-Issues oberhalb des Roots werden nur als Kontext gelesen und nicht in die Acceptance-Menge aufgenommen.
4. Für jeden Knoten eine besuchte Menge anhand stabiler Repository-/Issue-Identität führen. Bereits besuchte Knoten nicht erneut expandieren; Zyklen als `BLOCKED`-Befund dokumentieren.
5. Root und jedes erreichte Child mit Nummer, Titel, Status, Type, URL sowie seinen Acceptance-relevanten Beziehungen erfassen.
6. Die Akzeptanzkriterien jedes erfassten Issues vollständig aus dem Issue-Kontext sammeln und für jedes Kriterium eine eigene Matrixzeile anlegen.
7. Kriterien nicht aus dem Status, einem früheren Testlauf, einem Commit oder dem Ergebnis eines anderen Issues als erfüllt ableiten.
8. Die Matrix in der nachgelagerten Bewertungsphase gegen den aktuellen finalen integrierten Stand prüfen.

## Scope-Regeln

- Nur Root und dessen rekursiv erreichbare Children bilden die Acceptance-Menge.
- Parent-Kontext oberhalb des Roots, Geschwister und nicht erreichbare Teilbäume bleiben außerhalb des Prüfscope.
- Ein geschlossenes Issue ist prüfbar, aber sein Status ist kein Acceptance-Nachweis.
- Parent-Kriterien werden unabhängig von Child-Ergebnissen geprüft.
- Ein Child wird bei jeder Acceptance-Runde erneut gegen den aktuellen integrierten Stand bewertet.

## Kriterienmatrix

Für jedes Kriterium wird mindestens folgende Zeile geführt:

| Issue | Kriterium | Status | Evidenz/Begründung | geprüfter Stand |
|---|---|---|---|---|
| #123 | <vollständiger Kriterientext> | `PASS` / `GAP` / `BLOCKED` | <konkrete Evidenz oder Blocker> | <Commit, Artefakt oder Prüfzeitpunkt> |

Fehlen Kriterien, ist das als Kontextlücke zu markieren und nicht als automatischer `PASS` zu werten. Die Kriterienmatrix muss Root und alle Children voneinander getrennt ausweisen.

## Rücksprungregeln

- Bei unklarem Root-Type, widersprüchlicher Hierarchie oder nicht prüfbarem Kriterium mit konkretem Grund `BLOCKED` ausweisen.
- Bei einem `GAP` an den definierten Remediation-/Konvergenzprozess zurückgeben.
- Nach einer Remediation die vollständige ursprüngliche Root-Menge erneut traversieren und prüfen.

## Endergebnis

- vollständig und zyklussicher erfasster Root-Child-Graph
- getrennte Kriterienmatrix für Root und jedes Child
- pro Kriterium ein eindeutiger Status mit Evidenz oder konkretem Blocker
- Gesamtstatus `PASS`, `GAP` oder `BLOCKED`
- keine automatische Issue-Schließung und keine stille Scope-Erweiterung

## Grenzen

- Keine Parent-Issues oberhalb des Roots automatisch prüfen.
- Keine Body-Links als native Child-Beziehungen interpretieren.
- Keine Akzeptanz aus Issue-, PR-, Commit- oder Teststatus allein ableiten.
- Keine Gaps automatisch implementieren oder neue Anforderungen erfinden.
