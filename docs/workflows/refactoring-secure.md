# Workflow: Refactoring Secure

## Ziel

Bestehenden Code strukturell verbessern, ohne Verhalten zu veraendern, und die Aenderung bis zum Pull Request absichern.

## Verwenden

- Wenn Code wartbarer, lesbarer, weniger redundant oder klarer strukturiert werden soll.
- Wenn vor und nach dem Refactoring explizit belegt werden soll, dass bestehendes Verhalten erhalten bleibt.
- Wenn mehrere zusammenhaengende Refactoring-Ziele in einem gemeinsamen Scope bearbeitet werden sollen.
- Nicht verwenden, wenn fachliches Verhalten geaendert werden soll. Verhaltensaenderungen sind in diesem Workflow verboten.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `code_analyse`
- `code_implementierungsplanung`
- `code_refactoring`
- `code_testen`
- `code_diff-review`
- `github_commit-push`
- `github_pr-erstellen`

## Ablauf

1. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
2. Mit `code_analyse` im `Context-only-Modus` bestehenden Code, aktuelles Verhalten, Refactoring-Ziele und Verhaltensgrenzen erfassen.
3. Verhaltensbasis festhalten:
   - vorhandene Tests
   - relevante User-Flows
   - API-Kontrakte
   - Datenformate
   - Seiteneffekte
   - beobachtbares Verhalten
4. Mit `code_implementierungsplanung` die Refactoring-Ziele, Reihenfolge, Grenzen und Absicherungsstrategie planen.
5. Falls die bestehende Absicherung zu schwach ist, Tests mit dem Ziel ergaenzen oder anpassen, bestehendes Verhalten zu fixieren.
6. Mit `code_refactoring` die Strukturverbesserungen umsetzen.
7. Mit `code_testen` Verhalten und Regressionen gegen die zuvor festgehaltene Verhaltensbasis pruefen.
8. Mit `code_diff-review` sicherstellen, dass keine verdeckte Fachlogik oder unbeabsichtigte Verhaltensaenderung entstanden ist.
9. Kritische Funde korrigieren und die passende Pruefung wiederholen.
10. Erst nach bestandener Absicherung mit `github_commit-push` Commit und Push ausfuehren.
11. Mit `github_pr-erstellen` den Pull Request mit Refactoring-Zielen, Verhaltenserhalt, Teststatus und Review-Kontext erstellen.

## Ruecksprungregeln

- Wenn bestehendes Verhalten unklar ist, zurueck zu `code_analyse` im `Context-only-Modus`.
- Wenn Tests fehlen oder zu schwach sind, zurueck zur Testabsicherung im Ablauf.
- Wenn Tests wegen Refactoring fehlschlagen, zurueck zu `code_refactoring`.
- Wenn Tests wegen Umgebung nicht ausfuehrbar sind, Workflow blockieren, ausser der User erlaubt ausdruecklich einen PR mit dokumentiertem Verifikationsdefizit.
- Wenn `code_diff-review` eine Verhaltensaenderung findet, zurueck zu `code_refactoring` oder blockieren.
- Wenn das Refactoring fachliche Aenderungen erzwingt, Workflow blockieren.

## Endergebnis

- strukturell verbesserter Code
- erhaltenes und verifiziertes Verhalten
- ergaenzte oder angepasste Tests, falls fuer die Absicherung noetig
- dokumentierter Teststatus
- Commit und Push
- erstellter Pull Request

## Grenzen

- Keine Verhaltensaenderungen.
- Kein Wechsel in `bugfix.md` oder `feature-umsetzung.md` innerhalb dieses Workflows.
- Keine neuen Features.
- Keine fachliche Fehlerbehebung.
- Keine vorbereitenden Commits vor bestandener Absicherung.
- Mehrere Refactoring-Ziele sind erlaubt, wenn sie zusammenhaengen und getrennt pruefbar bleiben.
