# Workflow: Refactoring Secure

## Ziel

Bestehenden Code strukturell verbessern, ohne Verhalten zu verändern, und die Änderung bis zum Pull Request absichern.

## Verwenden

- Wenn Code wartbarer, lesbarer, weniger redundant oder klarer strukturiert werden soll.
- Wenn vor und nach dem Refactoring explizit belegt werden soll, dass bestehendes Verhalten erhalten bleibt.
- Wenn mehrere zusammenhängende Refactoring-Ziele in einem gemeinsamen Scope bearbeitet werden sollen.
- Nicht verwenden, wenn fachliches Verhalten geändert werden soll. Verhaltensänderungen sind in diesem Workflow verboten.

## Verwendete Skills

- `github-branch-checkout-from-default`
- `code-analysis`
- `code-implementation-planning`
- `code-refactoring`
- `code-testing`
- `code-diff-review`
- `pr-creation`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. Mit `github-branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
2. Mit `code-analysis` im `Context-only-Modus` bestehenden Code, aktuelles Verhalten, Refactoring-Ziele und Verhaltensgrenzen erfassen.
3. Verhaltensbasis festhalten:
   - vorhandene Tests
   - relevante User-Flows
   - API-Kontrakte
   - Datenformate
   - Seiteneffekte
   - beobachtbares Verhalten
4. Mit `code-implementation-planning` die Refactoring-Ziele, Reihenfolge, Grenzen und Absicherungsstrategie planen.
5. Falls die bestehende Absicherung zu schwach ist, Tests mit dem Ziel ergänzen oder anpassen, bestehendes Verhalten zu fixieren.
6. Mit `code-refactoring` die Strukturverbesserungen umsetzen.
7. Mit `code-testing` Verhalten und Regressionen gegen die zuvor festgehaltene Verhaltensbasis prüfen.
8. Mit `code-diff-review` sicherstellen, dass keine verdeckte Fachlogik oder unbeabsichtigte Verhaltensänderung entstanden ist.
9. Kritische Funde korrigieren und die passende Prüfung wiederholen.
10. Erst nach bestandener Absicherung mit dem Workflow `commit-push.md` Commit und Push ausführen.
11. Mit `pr-creation` den Pull Request mit Refactoring-Zielen, Verhaltenserhalt, Teststatus und Review-Kontext erstellen.

## Rücksprungregeln

- Wenn bestehendes Verhalten unklar ist, zurück zu `code-analysis` im `Context-only-Modus`.
- Wenn Tests fehlen oder zu schwach sind, zurück zur Testabsicherung im Ablauf.
- Wenn Tests wegen Refactoring fehlschlagen, zurück zu `code-refactoring`.
- Wenn Tests wegen Umgebung nicht ausführbar sind, Workflow blockieren, außer der User erlaubt ausdrücklich einen PR mit dokumentiertem Verifikationsdefizit.
- Wenn `code-diff-review` eine Verhaltensänderung findet, zurück zu `code-refactoring` oder blockieren.
- Wenn das Refactoring fachliche Änderungen erzwingt, Workflow blockieren.

## Endergebnis

- strukturell verbesserter Code
- erhaltenes und verifiziertes Verhalten
- ergänzte oder angepasste Tests, falls für die Absicherung nötig
- dokumentierter Teststatus
- Commit und Push
- erstellter Pull Request

## Grenzen

- Keine Verhaltensänderungen.
- Kein Wechsel in `bugfix.md` oder `issue-graph-umsetzung.md` innerhalb dieses Workflows.
- Keine neuen Features.
- Keine fachliche Fehlerbehebung.
- Keine vorbereitenden Commits vor bestandener Absicherung.
- Mehrere Refactoring-Ziele sind erlaubt, wenn sie zusammenhängen und getrennt prüfbar bleiben.
