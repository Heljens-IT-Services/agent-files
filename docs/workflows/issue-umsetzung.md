# Workflow: Issue Umsetzung

## Ziel

Eine einzelne Arbeitseinheit, ein einzelnes Issue oder ein klar geschnittenes Arbeitspaket umsetzen, verifizieren, reviewen, committen und pushen.

## Verwenden

- Wenn ein einzelnes Issue oder Arbeitspaket innerhalb eines größeren Workflows umgesetzt werden soll.
- Wenn der Scope bereits aus Issue, Story, Planung oder Workflow-Kontext klar ist.
- Nicht verwenden, wenn ein Issue-Graph koordiniert, eine Gesamt-Reihenfolge bestimmt oder ein Pull Request erstellt werden soll. Dann `issue-graph-umsetzung.md` oder `issue-to-pr.md` nutzen.

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

1. Arbeitseinheit aus vorhandenem Kontext übernehmen.
2. Prüfen, ob der aktuelle Arbeitsbranch zur Arbeitseinheit passt.
3. Falls die Arbeitseinheit ein Issue ist und der Issue-Kontext noch nicht geladen ist, mit `github_issue-lesen` das konkrete Issue lesen.
4. Akzeptanzkriterien, Nicht-Ziele und Abschlussbedingung der Arbeitseinheit festhalten.
5. Mit `code_lesen` relevanten Code und angrenzende Kontextdateien laden.
6. Mit `code_implementierungsplanung` den Umsetzungsweg für diese Arbeitseinheit festlegen.
7. Mit `code_implementieren` die Änderung umsetzen.
8. Mit `code_testen` die Änderung verifizieren.
9. Mit `code_diff-review` den Änderungssatz auf Scope, Seiteneffekte, Regressionen und fehlende Tests prüfen.
10. Kritische Funde korrigieren und die passende Prüfung wiederholen.
11. Akzeptanzkriterien und Nicht-Ziele gegen den finalen Änderungsstand prüfen.
12. Mit dem Workflow `commit-push.md` Commit und Push für die abgeschlossene Arbeitseinheit ausführen.
13. Prüfen, dass der vollständige Änderungssatz dieser Arbeitseinheit committed und gepusht ist und keine zu dieser Arbeitseinheit gehörenden fachlichen Änderungen uncommitted verbleiben.
14. Falls die Arbeitseinheit ein Issue abschließt und der übergeordnete Kontext das sofortige Schließen ausdrücklich erlaubt, das Issue minimalistisch mit Ergebnis, Commit-Kontext und Teststatus kommentieren und schließen.

## Commit-Grenze

- Eine abgeschlossene Arbeitseinheit endet zwingend mit Commit und Push.
- Wenn die Arbeitseinheit einem Issue entspricht, muss ihr Änderungssatz mindestens einem eindeutig diesem Issue zuordenbaren Commit entsprechen.
- Mehrere logisch getrennte Commits für dasselbe Issue sind zulässig.
- Änderungen verschiedener Issues dürfen nicht absichtlich in demselben Commit vermischt werden, wenn dieser Workflow als Teil von `issue-graph-umsetzung.md` läuft.
- Der aufrufende Workflow darf erst zur nächsten Arbeitseinheit wechseln, wenn Commit und Push dieser Arbeitseinheit erfolgreich abgeschlossen wurden.
- Fehlgeschlagener Commit oder Push bedeutet, dass die Arbeitseinheit nicht abgeschlossen ist.

## Rücksprungregeln

- Bei unklarem Issue-Kontext zurück zu `github_issue-lesen`.
- Bei unklarem Code-Kontext zurück zu `code_lesen`.
- Bei unklarer Ursache, unklarem Verhalten, Risiko oder Seiteneffekt zu `code_analyse`.
- Bei zu großem oder unscharfem Scope zurück zu `code_implementierungsplanung`.
- Bei fehlgeschlagenen Tests zurück zu `code_implementierungsplanung` oder `code_implementieren`.
- Bei `code_diff-review` mit Bewertung `nicht versandbereit` zurück zur passenden Umsetzung oder Planung.
- Bei fehlgeschlagenem Commit oder Push zum Workflow `commit-push.md` zurückkehren; nicht zur nächsten Arbeitseinheit fortfahren.

## Endergebnis

- umgesetzte und verifizierte Arbeitseinheit
- erfüllte Akzeptanzkriterien
- dokumentierter Teststatus
- eindeutig zuordenbarer Commit-Kontext
- erfolgreicher Push
- keine zur Arbeitseinheit gehörenden uncommitted fachlichen Änderungen
- kommentiertes und geschlossenes Issue, falls die Arbeitseinheit ein Issue abschließt und der Kontext das sofortige Schließen erlaubt

## Grenzen

- Keinen Pull Request erstellen.
- Keinen Issue-Graph koordinieren.
- Keine Gesamt-Reihenfolge über mehrere Issues bestimmen.
- Keine Branch-Erstellung ausführen, wenn dieser Workflow als Teilworkflow aus `issue-graph-umsetzung.md`, `bugfix.md`, `refactoring-secure.md` oder einem anderen vorgelagerten Workflow mit bereits vorbereitetem Arbeitsbranch läuft.
- Wenn dieser Workflow direkt gestartet wird, muss vor der Implementierung ein passender Arbeitsbranch aktiv sein; andernfalls `github_branch-checkout-from-default` verwenden.
- Keine Nebenfunde umsetzen, außer sie blockieren die Arbeitseinheit.
- Issue nicht schließen, wenn der Abschluss über einen späteren PR-Merge erfolgen soll.
- Wenn dieser Workflow aus `issue-graph-umsetzung.md` aufgerufen wird, Scope-Issues standardmäßig nicht manuell schließen; der Graph-Workflow entscheidet die abschließende PR-Verlinkung und Schließsemantik.
