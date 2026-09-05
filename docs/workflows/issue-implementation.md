# Workflow: Issue Implementation

## Ziel

Eine einzelne Arbeitseinheit, ein einzelnes Issue oder ein klar geschnittenes Arbeitspaket implementieren, verifizieren, reviewen, committen und pushen.

Die lokale Task-Verifikation dieses Workflows bleibt vom separaten, graphweiten Acceptance-Workflow abgegrenzt. Eine übergeordnete Acceptance-Prüfung wird durch `issue-graph-implementation.md` beziehungsweise einen ausdrücklichen `/acceptance`-Aufruf gesteuert.

## Verwenden

- Wenn ein einzelnes Issue oder Arbeitspaket innerhalb eines größeren Workflows umgesetzt werden soll.
- Wenn der Scope bereits aus Issue, Story, Planung oder Workflow-Kontext klar ist.
- Nicht verwenden, wenn ein Issue-Graph koordiniert, eine Gesamt-Reihenfolge bestimmt oder ein Pull Request erstellt werden soll. Dann `issue-graph-implementation.md` oder `issue-to-pr.md` nutzen.

## Verwendete Skills

- `github-branch-checkout-from-default`
- `issue-reading`
- `code-reading`
- `code-analysis`
- `code-implementation-planning`
- `code-implementation`
- `code-refactoring`
- `design-review` bei relevanter visueller Designer-Verantwortung
- `code-testing`
- `code-diff-review`

## Verwendete Workflows

- `design-exploration.md` bei offener gestalterischer Richtungsentscheidung
- `commit-push.md`

## Ablauf

1. Arbeitseinheit aus vorhandenem Kontext übernehmen.
2. Prüfen, ob der aktuelle Arbeitsbranch zur Arbeitseinheit passt.
3. Falls die Arbeitseinheit ein Issue ist und der Issue-Kontext noch nicht geladen ist, mit `issue-reading` das konkrete Issue lesen.
4. Bei einem terminalen Task dessen technischen Plan als primäre Ausführungsgrundlage übernehmen. Bei einer anderen klaren Arbeitseinheit Ziel, Scope, Nicht-Scope, Arbeitspakete, Akzeptanzkriterien und Verifikation aus dem vorhandenen Kontext festhalten.
5. Geltende Agent- und Repository-Regeln sowie mit `code-reading` ausschließlich die unmittelbar relevanten Dateien und Referenzimplementierungen laden.
6. Wenn die Arbeitseinheit Designer-Verantwortung enthält, prüfen, ob die Designrichtung bereits belastbar geklärt und visuell reviewt ist. Bei offenem gestalterischem Lösungsraum oder fehlendem belastbarem Design-Handoff `design-exploration.md` ausführen und dessen Handoff als Designkontext für die technische Planung übernehmen. Keine erneute Exploration erzwingen, wenn ein belastbares Design bereits vorliegt.
7. Technischen Plan, Design-Handoff soweit vorhanden, Repository-Zustand und geltende Regeln auf Konsistenz prüfen. Nur bei fehlender technischer Ausführbarkeit, wesentlichen offenen technischen oder architektonischen Entscheidungen, neuem technischem Risiko oder echtem Planbruch mit `code-implementation-planning` gezielt nachplanen.
8. Das nächste geplante Arbeitspaket mit `code-implementation` oder bei reinem Verhaltenserhalt mit `code-refactoring` im definierten Scope umsetzen.
9. Die für das Arbeitspaket vorgesehene Verifikation mit `code-testing` ausführen.
10. Einen lokalen Implementierungsfehler anhand des konkreten Fehleroutputs im unveränderten Scope korrigieren und nur die relevante Prüfung wiederholen. Nicht allein wegen eines lokalen Fehlers vollständig neu planen.
11. Arbeitspakete in der geplanten Reihenfolge wiederholen, bis der technische Plan abgearbeitet ist.
12. Wenn die fertige Arbeitseinheit ein visuelles oder interaktives Ergebnis mit Designer-Verantwortung enthält, das tatsächlich implementierte Ergebnis rendern und mit `design-review` gegen Ziel, Design-Handoff und relevante Constraints prüfen. Lokale Umsetzungsabweichungen im bestehenden Design-Scope an `developer` zurückgeben und nach der Korrektur erneut reviewen; ein grundlegendes Problem der Designrichtung an `design-exploration.md` zurückgeben.
13. Mit `code-testing` die vollständige Task-Verifikation und alle Akzeptanzkriterien prüfen.
14. Mit `code-diff-review` den finalen Änderungssatz gegen Scope, Nicht-Scope, Akzeptanzkriterien, Seiteneffekte, Regressionen und fehlende Prüfungen reviewen.
15. Kritische Funde im unveränderten Scope korrigieren und die passende Prüfung wiederholen.
16. Mit dem Workflow `commit-push.md` Commit und Push für die abgeschlossene Arbeitseinheit ausführen.
17. Prüfen, dass der vollständige Änderungssatz dieser Arbeitseinheit committed und gepusht ist und keine zu dieser Arbeitseinheit gehörenden fachlichen Änderungen uncommitted verbleiben.
18. Sobald die Arbeitseinheit vollständig umgesetzt, verifiziert, reviewed, committed und gepusht ist, im zugehörigen GitHub-Issue einen kurzen persistenten Abschlusskommentar hinterlegen. Der Kommentar muss auf Deutsch den Umsetzungsstatus, den relevanten Commit-Kontext, den Verifikationsstatus und – solange der finale Pull Request oder Merge noch aussteht – diesen offenen Abschluss enthalten. Das Issue nicht über diesen Kommentar schließen.
19. Für den Kommentar `gh issue comment <issue-number> --body "..."` verwenden. Der Inhalt muss mindestens diesem Muster folgen:

    ```text
    Umsetzung abgeschlossen.
    Commit: <commit-sha>
    Verifikation: erfolgreich|mit Hinweisen|fehlgeschlagen.
    Issue bleibt bis zum finalen PR/Merge geöffnet.
    ```

20. Bei Ausführung innerhalb eines Issue-Graphen erst nach erfolgreichem Kommentar den Fortschrittsanker aktualisieren und die Steuerung an den aufrufenden Workflow zurückgeben.
21. Ein Issue nur schließen, wenn der übergeordnete Kontext dies ausdrücklich erlaubt; die bestehende Schließlogik über den finalen Pull Request bleibt ansonsten maßgeblich.

## Planbruch

In Analyse oder Planung zurückspringen, wenn:

- wesentliche Produkt-, Architektur-, Scope- oder Vorgehensentscheidungen fehlen,
- erwartete Dateien, APIs oder Referenzimplementierungen fehlen oder wesentlich abweichen,
- der Plan geltenden Regeln widerspricht oder die Akzeptanzkriterien nicht erreichen kann,
- die erforderliche Änderung den definierten Scope wesentlich überschreitet,
- eine Prüfung einen grundlegenden fachlichen oder architektonischen Widerspruch statt eines lokalen Implementierungsfehlers zeigt.

## Commit-Grenze

- Eine abgeschlossene Arbeitseinheit endet zwingend mit Commit und Push.
- Wenn die Arbeitseinheit einem Issue entspricht, muss ihr Änderungssatz mindestens einem eindeutig diesem Issue zuordenbaren Commit entsprechen.
- Mehrere logisch getrennte Commits für dasselbe Issue sind zulässig.
- Änderungen verschiedener Issues dürfen nicht absichtlich in demselben Commit vermischt werden, wenn dieser Workflow als Teil von `issue-graph-implementation.md` läuft.
- Der aufrufende Workflow darf erst zur nächsten Arbeitseinheit wechseln, wenn Commit und Push dieser Arbeitseinheit erfolgreich abgeschlossen wurden.
- Fehlgeschlagener Commit oder Push bedeutet, dass die Arbeitseinheit nicht abgeschlossen ist.

## Rücksprungregeln

## Codex-Orchestrierung

- Technischer Plan und offene technische oder architektonische Richtungsentscheidungen: `planner`.
- Gestalterische Richtungsentscheidungen, Design-Exploration, Design-Handoff und visueller Design-Review: `designer`.
- Code-Lesen, Analyse, Produktivimplementierung und Refactoring: `developer`.
- Formale Task-Verifikation und Teststatus: `tester`.
- Commit und Push: `main/orchestrator`; der Workflow lässt keine unkoordinierten parallelen Schreibzugriffe zu.
- Planbruch geht abhängig vom Gegenstand an `planner`, `designer` oder den Orchestrator; lokale Implementierungs- oder Testfehler gezielt an `developer` beziehungsweise `tester`.

- Bei unklarem Issue-Kontext zurück zu `issue-reading`.
- Bei unklarem Code-Kontext zurück zu `code-reading`.
- Bei unklarer Ursache, unklarem Verhalten, Risiko oder Seiteneffekt zu `code-analysis`.
- Bei offener gestalterischer Richtung oder einem grundlegenden Problem der Designrichtung zu `design-exploration.md`.
- Bei zu großem oder unscharfem Scope sowie einem technischen Planbruch zurück zu `code-implementation-planning`.
- Bei lokalen Implementierungs- oder Testfehlern zurück zu `code-implementation` und anschließend die relevante Prüfung wiederholen.
- Bei `design-review` mit lokaler Umsetzungsabweichung zurück zu `code-implementation` und anschließend erneut `design-review`; bei grundlegendem Richtungsproblem zurück zu `design-exploration.md`.
- Bei `code-diff-review` mit Bewertung `nicht versandbereit` zurück zur passenden Umsetzung oder Planung.
- Bei fehlgeschlagenem Commit oder Push zum Workflow `commit-push.md` zurückkehren; nicht zur nächsten Arbeitseinheit fortfahren.

## Endergebnis

- umgesetzte und verifizierte Arbeitseinheit
- erfüllte Akzeptanzkriterien
- bei relevanter Designer-Verantwortung visuell reviewte Produktivimplementierung
- dokumentierter Teststatus
- eindeutig zuordenbarer Commit-Kontext
- erfolgreicher Push
- keine zur Arbeitseinheit gehörenden uncommitted fachlichen Änderungen
- persistenter deutscher Abschlusskommentar mit Status-, Commit- und Verifikationskontext

## Grenzen

- Keinen Pull Request erstellen.
- Keinen Issue-Graph koordinieren.
- Keine Gesamt-Reihenfolge über mehrere Issues bestimmen.
- Keine Branch-Erstellung ausführen, wenn dieser Workflow als Teilworkflow aus `issue-graph-implementation.md`, `bugfix.md`, `refactoring-secure.md` oder einem anderen vorgelagerten Workflow mit bereits vorbereitetem Arbeitsbranch läuft.
- Wenn dieser Workflow direkt gestartet wird, muss vor der Implementierung ein passender Arbeitsbranch aktiv sein; andernfalls `github-branch-checkout-from-default` verwenden.
- Keine Nebenfunde umsetzen, außer sie blockieren die Arbeitseinheit.
- Issue nicht schließen, wenn der Abschluss über einen späteren PR-Merge erfolgen soll.
- Nach erfolgreichem Commit und Push keinen nächsten Graph-Knoten beginnen und keinen Fortschrittsanker als abgeschlossen markieren, bevor der persistente Issue-Kommentar erfolgreich erstellt wurde.
- Wenn dieser Workflow aus `issue-graph-implementation.md` aufgerufen wird, Scope-Issues standardmäßig nicht manuell schließen; der Graph-Workflow entscheidet die abschließende PR-Verlinkung und Schließsemantik.
- Eine abgeschlossene Arbeitseinheit darf nicht als Abschluss eines noch offenen Issue-Graphen kommuniziert werden.
