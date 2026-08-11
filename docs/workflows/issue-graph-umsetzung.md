# Workflow: Issue Graph Umsetzung

## Ziel

Ein Issue mit seinen relevanten Issue-Beziehungen strukturiert bis zur verifizierten Implementierung und zum Pull Request bearbeiten.

## Verwenden

- Wenn ein Issue fachlich und technisch unter Berücksichtigung seines Issue-Graphen umgesetzt werden soll.
- Wenn Ausgangs-Issue, relevante Issue-Beziehungen, Planung, Implementierung, Verifikation, Commit/Push und Pull Request zusammenhängend bearbeitet werden sollen.
- Nicht verwenden, wenn nur Optionen abgewogen werden sollen. Dann `brainstorming` nutzen.

## Direkte Aliase

- `/umsetzen <issue-nummer>`
- `/umsetzung <issue-nummer>`

`<issue-nummer>` muss als positive Ganzzahl mit optional vorangestelltem `#` angegeben werden, zum Beispiel `/umsetzen #123` oder `/umsetzung 123`.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `brainstorming`
- `github_pr-erstellen`

## Verwendete Workflows

- `issue-umsetzung.md`

## Ablauf

1. Mit `github_issue-lesen` das Ausgangs-Issue inklusive relevanter Parent-, Child- und Blocked-by-Beziehungen lesen.
2. Issue-Graph für Scope, Reihenfolge und Abhängigkeiten berücksichtigen.
3. Alle Child-Issues des Ausgangs-Issues in den Umsetzungsumfang aufnehmen.
4. Bei blockierten Issues prüfen, ob der Blocker im Rahmen dieses Workflows selbstständig gelöst werden kann.
5. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
6. Falls die Richtung noch offen ist, mit `brainstorming` Optionen vergleichen.
7. Arbeitspakete aus Ausgangs- und Child-Issues in Umsetzungsreihenfolge festlegen.
8. Je Arbeitspaket den Workflow `issue-umsetzung.md` ausführen.
9. Mit `github_pr-erstellen` den Pull Request mit Review-Kontext und Issue-Verknüpfungen erstellen; Ausgangs-Issue so verlinken, dass GitHub es beim Merge schließen kann.

## Rücksprungregeln

- Bei Architekturkonflikten zurück zu `brainstorming` oder zur Arbeitspaket-Planung in `issue-umsetzung.md`.
- Bei unklaren Anforderungen zurück zu `github_issue-lesen`.
- Bei unklaren Issue-Beziehungen zurück zu `github_issue-lesen`.
- Bei widersprüchlichen Abhängigkeiten zurück zur Arbeitspaket-Reihenfolge.
- Bei fehlgeschlagenen Tests gelten die Rücksprungregeln aus `issue-umsetzung.md`.
- Wenn ein Blocker nicht selbstständig gelöst werden kann, Workflow blockieren und Grund nennen.

## Endergebnis

- verifizierte Änderung für den Issue-Graphen
- dokumentierter Teststatus
- Commit und Push
- kommentierte und geschlossene Child-Issues
- erstellter Pull Request

## Grenzen

- Ausgangs-Issue nicht manuell schließen.
- Ausgangs-Issue über PR-Verlinkung schließen lassen, wenn der PR gemergt wird.
- Wenn automatisches Schließen nicht sicher ist, im PR-Kontext sichtbar machen.
