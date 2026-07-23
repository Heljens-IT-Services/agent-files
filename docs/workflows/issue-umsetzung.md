# Workflow: Issue Umsetzung

## Ziel

Eine einzelne Arbeitseinheit, ein einzelnes Issue oder ein klar geschnittenes Arbeitspaket umsetzen, verifizieren, reviewen, committen und pushen.

## Verwenden

- Wenn ein einzelnes Issue oder Arbeitspaket innerhalb eines groesseren Workflows umgesetzt werden soll.
- Wenn der Scope bereits aus Issue, Story, Planung oder Workflow-Kontext klar ist.
- Nicht verwenden, wenn ein Issue-Graph koordiniert, eine Gesamt-Reihenfolge bestimmt oder ein Pull Request erstellt werden soll. Dann `feature-umsetzung.md` oder `issue-to-pr.md` nutzen.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `code_lesen`
- `code_analyse`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `code_diff-review`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. Arbeitseinheit aus vorhandenem Kontext uebernehmen.
2. Pruefen, ob der aktuelle Arbeitsbranch zur Arbeitseinheit passt.
3. Falls die Arbeitseinheit ein Issue ist und der Issue-Kontext noch nicht geladen ist, mit `github_issue-lesen` das konkrete Issue lesen.
4. Akzeptanzkriterien, Nicht-Ziele und Abschlussbedingung der Arbeitseinheit festhalten.
5. Mit `code_lesen` relevanten Code und angrenzende Kontextdateien laden.
6. Mit `code_implementierungsplanung` den Umsetzungsweg fuer diese Arbeitseinheit festlegen.
7. Mit `code_implementieren` die Aenderung umsetzen.
8. Mit `code_testen` die Aenderung verifizieren.
9. Mit `code_diff-review` den Aenderungssatz auf Scope, Seiteneffekte, Regressionen und fehlende Tests pruefen.
10. Kritische Funde korrigieren und die passende Pruefung wiederholen.
11. Akzeptanzkriterien und Nicht-Ziele gegen den finalen Aenderungsstand pruefen.
12. Mit dem Workflow `commit-push.md` Commit und Push fuer die abgeschlossene Arbeitseinheit ausfuehren.
13. Falls die Arbeitseinheit ein Issue abschliesst und der Kontext das Schliessen erlaubt, das Issue minimalistisch mit Ergebnis, Commit-Kontext und Teststatus kommentieren und schliessen.

## Ruecksprungregeln

- Bei unklarem Issue-Kontext zurueck zu `github_issue-lesen`.
- Bei unklarem Code-Kontext zurueck zu `code_lesen`.
- Bei unklarer Ursache, unklarem Verhalten, Risiko oder Seiteneffekt zu `code_analyse`.
- Bei zu grossem oder unscharfem Scope zurueck zu `code_implementierungsplanung`.
- Bei fehlgeschlagenen Tests zurueck zu `code_implementierungsplanung` oder `code_implementieren`.
- Bei `code_diff-review` mit Bewertung `nicht versandbereit` zurueck zur passenden Umsetzung oder Planung.

## Endergebnis

- umgesetzte und verifizierte Arbeitseinheit
- erfuellte Akzeptanzkriterien
- dokumentierter Teststatus
- Commit und Push
- kommentiertes und geschlossenes Issue, falls die Arbeitseinheit ein Issue abschliesst und der Kontext das Schliessen erlaubt

## Grenzen

- Keinen Pull Request erstellen.
- Keinen Issue-Graph koordinieren.
- Keine Gesamt-Reihenfolge ueber mehrere Issues bestimmen.
- Keine Branch-Erstellung ausfuehren, wenn dieser Workflow als Teilworkflow aus `feature-umsetzung.md`, `bugfix.md`, `refactoring-secure.md` oder einem anderen vorgelagerten Workflow mit bereits vorbereitetem Arbeitsbranch laeuft.
- Wenn dieser Workflow direkt gestartet wird, muss vor der Implementierung ein passender Arbeitsbranch aktiv sein; andernfalls `github_branch-checkout-from-default` verwenden.
- Keine Nebenfunde umsetzen, ausser sie blockieren die Arbeitseinheit.
- Issue nicht schliessen, wenn der Abschluss ueber einen spaeteren PR-Merge erfolgen soll.
