# Workflow: Issue Implementation

## Ziel

Eine einzelne Arbeitseinheit, ein einzelnes Issue oder ein klar geschnittenes Arbeitspaket implementieren, verifizieren, reviewen, committen und pushen.

## Verwenden

- Wenn ein einzelnes Issue oder Arbeitspaket innerhalb eines größeren Workflows umgesetzt werden soll.
- Wenn der Scope bereits aus Issue, Story, Planung oder Workflow-Kontext klar ist.
- Nicht verwenden, wenn ein Issue-Graph koordiniert, eine Gesamt-Reihenfolge bestimmt oder ein Pull Request erstellt werden soll. Dann `issue-graph-umsetzung.md` oder `issue-to-pr.md` nutzen.

## Verwendete Skills

- `github-branch-checkout-from-default`
- `issue-reading`
- `code-reading`
- `code-analysis`
- `code-implementation-planning`
- `code-implementation`
- `code-testing`
- `code-diff-review`

## Verwendete Workflows

- `commit-push.md`

## Ablauf

1. Arbeitseinheit aus vorhandenem Kontext übernehmen.
2. Prüfen, ob der aktuelle Arbeitsbranch zur Arbeitseinheit passt.
3. Falls die Arbeitseinheit ein Issue ist und der Issue-Kontext noch nicht geladen ist, mit `issue-reading` das konkrete Issue lesen.
4. Akzeptanzkriterien, Nicht-Ziele und Abschlussbedingung der Arbeitseinheit festhalten.
5. Mit `code-reading` relevanten Code und angrenzende Kontextdateien laden.
6. Mit `code-implementation-planning` den Umsetzungsweg für diese Arbeitseinheit festlegen.
7. Mit `code-implementation` die Änderung umsetzen.
8. Mit `code-testing` die Änderung verifizieren.
9. Mit `code-diff-review` den Änderungssatz auf Scope, Seiteneffekte, Regressionen und fehlende Tests prüfen.
10. Kritische Funde korrigieren und die passende Prüfung wiederholen.
11. Akzeptanzkriterien und Nicht-Ziele gegen den finalen Änderungsstand prüfen.
12. Mit dem Workflow `commit-push.md` Commit und Push für die abgeschlossene Arbeitseinheit ausführen.
13. Prüfen, dass der vollständige Änderungssatz dieser Arbeitseinheit committed und gepusht ist und keine zu dieser Arbeitseinheit gehörenden fachlichen Änderungen uncommitted verbleiben.
14. Bei Ausführung innerhalb eines Issue-Graphen den Fortschrittsanker aktualisieren und die Steuerung an den aufrufenden Workflow zurückgeben.
15. Falls die Arbeitseinheit ein Issue abschließt und der übergeordnete Kontext das sofortige Schließen ausdrücklich erlaubt, das Issue minimalistisch mit Ergebnis, Commit-Kontext und Teststatus kommentieren und schließen.

## Commit-Grenze

- Eine abgeschlossene Arbeitseinheit endet zwingend mit Commit und Push.
- Wenn die Arbeitseinheit einem Issue entspricht, muss ihr Änderungssatz mindestens einem eindeutig diesem Issue zuordenbaren Commit entsprechen.
- Mehrere logisch getrennte Commits für dasselbe Issue sind zulässig.
- Änderungen verschiedener Issues dürfen nicht absichtlich in demselben Commit vermischt werden, wenn dieser Workflow als Teil von `issue-graph-umsetzung.md` läuft.
- Der aufrufende Workflow darf erst zur nächsten Arbeitseinheit wechseln, wenn Commit und Push dieser Arbeitseinheit erfolgreich abgeschlossen wurden.
- Fehlgeschlagener Commit oder Push bedeutet, dass die Arbeitseinheit nicht abgeschlossen ist.

## Rücksprungregeln

- Bei unklarem Issue-Kontext zurück zu `issue-reading`.
- Bei unklarem Code-Kontext zurück zu `code-reading`.
- Bei unklarer Ursache, unklarem Verhalten, Risiko oder Seiteneffekt zu `code-analysis`.
- Bei zu großem oder unscharfem Scope zurück zu `code-implementation-planning`.
- Bei fehlgeschlagenen Tests zurück zu `code-implementation-planning` oder `code-implementation`.
- Bei `code-diff-review` mit Bewertung `nicht versandbereit` zurück zur passenden Umsetzung oder Planung.
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
- Wenn dieser Workflow direkt gestartet wird, muss vor der Implementierung ein passender Arbeitsbranch aktiv sein; andernfalls `github-branch-checkout-from-default` verwenden.
- Keine Nebenfunde umsetzen, außer sie blockieren die Arbeitseinheit.
- Issue nicht schließen, wenn der Abschluss über einen späteren PR-Merge erfolgen soll.
- Wenn dieser Workflow aus `issue-graph-umsetzung.md` aufgerufen wird, Scope-Issues standardmäßig nicht manuell schließen; der Graph-Workflow entscheidet die abschließende PR-Verlinkung und Schließsemantik.
- Eine abgeschlossene Arbeitseinheit darf nicht als Abschluss eines noch offenen Issue-Graphen kommuniziert werden.
