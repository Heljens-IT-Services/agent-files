# Workflow: Instruction Improvement Issue

## Ziel

Einen Verbesserungsvorschlag fuer Agent Instructions, Skills oder Workflows aus einem konsumierenden Repository als GitHub-Issue in diesem Repository erfassen.

## Verwenden

- Wenn waehrend der Nutzung der zentralen `agent-files` Agent Instructions, Skills oder Workflows ein Verbesserungsvorschlag entsteht.
- Wenn der Vorschlag aus einem anderen Repository kommt, das diese Instruktionen referenziert.
- Nicht verwenden fuer projektspezifische Agent- oder Developer-Instruktionen anderer Repositories.
- Nicht verwenden, wenn direkt an den Instruktionsdateien gearbeitet werden soll. Dann passenden Skill oder Workflow im `agent-files`-Repository verwenden.

## Verwendete Skills

- `anforderungsklaerung`
- `github_issue-erstellen`

## Ablauf

1. Verbesserungsvorschlag, betroffene Instruktion und Ursprungskontext knapp erfassen.
2. Bei unscharfem Vorschlag mit `anforderungsklaerung` interaktiv nachfragen, bis Ziel, Scope, betroffene Instruktion und gewuenschter Zielzustand ausreichend klar sind.
3. Ziel-Repository explizit auf `Heljens-IT-Services/agent-files` setzen.
4. Im Issue das konsumierende Repository, die betroffene referenzierte Datei oder URL und den konkreten Nutzungskontext verlinken oder beschreiben, wenn bekannt.
5. GitHub-Issue-Type passend zum Kontext setzen: `Task`, `Story`, `Spike` oder `Epic`.
6. Relationships setzen, wenn aus dem Kontext ein Parent, Child oder Blocker hervorgeht.
7. Mit `github_issue-erstellen` ein strukturiertes Issue in `Heljens-IT-Services/agent-files` erstellen.

## Ruecksprungregeln

- Bei unklarem Verbesserungsvorschlag zurueck zu `anforderungsklaerung`.
- Wenn Ziel, Scope, betroffene Instruktion oder Zielzustand nicht klaerbar sind, Workflow blockieren.
- Bei fehlenden GitHub-Rechten oder unklarer Repository-Zuordnung stoppen und Blocker melden.
- Bei moeglichem Duplikat den Duplikatregeln aus `github_issue-erstellen` folgen.

## Endergebnis

- GitHub-Issue im Repository `Heljens-IT-Services/agent-files`
- Issue-Link
- gesetzter GitHub-Issue-Type
- gesetzte Relationships, falls vorhanden

## Grenzen

- Das Issue immer in `Heljens-IT-Services/agent-files` erstellen, nicht im konsumierenden Repository.
- Ausschliesslich fuer zentrale `agent-files`-Instruktionen verwenden.
- Keine Aenderungen an Instruktionsdateien vornehmen.
- Keine Umsetzung planen, wenn nur ein Verbesserungsvorschlag erfasst werden soll.
- Kein Issue aus einem unscharfen Verbesserungsvorschlag erstellen.
- Fehlendes konsumierendes Repository, fehlende Referenzdatei oder fehlender Nutzungskontext blockiert die Issue-Erstellung nicht.
