# Workflow: Instruction Improvement Issue

## Ziel

Einen Verbesserungsvorschlag fuer Agent Instructions, Skills oder Workflows aus einem konsumierenden Repository als GitHub-Issue in diesem Repository erfassen.

## Verwenden

- Wenn waehrend der Nutzung von Agent Instructions, Skills oder Workflows ein Verbesserungsvorschlag entsteht.
- Wenn der Vorschlag aus einem anderen Repository kommt, das diese Instruktionen referenziert.
- Nicht verwenden, wenn direkt an den Instruktionsdateien gearbeitet werden soll. Dann passenden Skill oder Workflow im `agent-files`-Repository verwenden.

## Verwendete Skills

- `anforderungsklaerung`
- `github_issue-erstellen`

## Ablauf

1. Verbesserungsvorschlag, betroffene Instruktion und Ursprungskontext knapp erfassen.
2. Mit `anforderungsklaerung` Ziel, Scope, Nicht-Ziele und Akzeptanzkriterien klaeren, falls der Vorschlag unscharf ist.
3. Ziel-Repository explizit auf `Heljens-IT-Services/agent-files` setzen.
4. Mit `github_issue-erstellen` ein strukturiertes Issue in `Heljens-IT-Services/agent-files` erstellen.
5. Im Issue das konsumierende Repository und die betroffene referenzierte Datei verlinken, wenn bekannt.
6. GitHub-Issue-Type passend setzen, typischerweise `Task` oder `Spike`.
7. Relationships setzen, wenn aus dem Kontext ein Parent, Child oder Blocker hervorgeht.

## Ruecksprungregeln

- Bei unklarem Verbesserungsvorschlag zurueck zu `anforderungsklaerung`.
- Bei fehlenden GitHub-Rechten oder unklarer Repository-Zuordnung stoppen und Blocker melden.
- Bei moeglichem Duplikat den Duplikatregeln aus `github_issue-erstellen` folgen.

## Endergebnis

- GitHub-Issue im Repository `Heljens-IT-Services/agent-files`
- Issue-Link
- gesetzter GitHub-Issue-Type
- gesetzte Relationships, falls vorhanden

## Grenzen

- Das Issue immer in `Heljens-IT-Services/agent-files` erstellen, nicht im konsumierenden Repository.
- Keine Aenderungen an Instruktionsdateien vornehmen.
- Keine Umsetzung planen, wenn nur ein Verbesserungsvorschlag erfasst werden soll.
