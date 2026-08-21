# Workflow: Design Exploration

## Ziel

Eine offene oder visuell relevante Designaufgabe explorativ verstehen, mehrere belastbare Richtungen entwickeln, mit leichten Prototypen tatsächlich visualisieren, reviewen und iterativ zu einer begründeten Designrichtung führen.

## Verwenden

- Wenn eine neue Oberfläche, ein Layout, ein visueller Produktbereich, ein Informationsdesign oder eine interaktive Darstellung konzipiert werden soll.
- Wenn eine Designfrage mehrere plausible Lösungsrichtungen besitzt und nicht die erste Idee unmittelbar in Produktionscode überführt werden soll.
- Wenn ein bestehendes Design substanziell neu gedacht und vor der Implementierung exploriert werden soll.
- Bei kleinen, bereits stark vorgegebenen visuellen Änderungen darf stattdessen direkt ein passender Design-Skill verwendet werden.

## Verwendete Skills

- `requirements-clarification` bei unklaren Zielen oder Constraints
- `research` bei erforderlichem externen, Repository- oder Produktkontext
- `brainstorming`
- `design-prototyping`
- `design-review`

## Ablauf

1. Ziel, Zielgruppe, Nutzungskontext, Nicht-Ziele und relevante Constraints aus dem vorhandenen Kontext erfassen. Nur bei echten Lücken `requirements-clarification` verwenden.
2. Bestehenden Produkt-, Design-, Wettbewerbs- oder Referenzkontext nur dann mit `research` ergänzen, wenn er für die Designentscheidung tatsächlich benötigt wird.
3. Mit `brainstorming` bei offenem Lösungsraum mehrere substanziell unterschiedliche Designrichtungen entwickeln. Kleine, stark eingeschränkte Aufgaben dürfen mit einer Richtung starten.
4. Die Richtungen so beschreiben, dass ihre Unterschiede in Struktur, Schwerpunkt, Interaktion oder visueller Sprache erkennbar sind; reine Farb- oder Detailvarianten reichen nicht aus.
5. Mit `design-prototyping` die relevanten Richtungen als leichte, renderbare Artefakte visualisieren. Für browserdarstellbare frühe Entwürfe eigenständige Single-File-HTML-Prototypen mit Inline-CSS und Inline-JavaScript bevorzugen, wenn sie die Designfrage ausreichend abbilden.
6. Alle für die Auswahl relevanten Varianten tatsächlich rendern und mit `design-review` beurteilen.
7. Die Richtungen anhand von Nutzerziel, Verständlichkeit, Wirkung, Constraints und Review-Funden vergleichen und eine stärkste Richtung auswählen oder eine erforderliche subjektive Nutzerentscheidung sichtbar machen.
8. Die gewählte Richtung gezielt weiterentwickeln und mindestens eine neue Iteration erzeugen, sofern die erste Review relevante Verbesserungsmöglichkeiten gezeigt hat.
9. Die geänderte Fassung erneut rendern und mit `design-review` gegen die priorisierten Funde prüfen.
10. Weitere Iterationen nur fortsetzen, solange wesentliche Designprobleme bestehen oder eine zusätzliche Iteration einen klaren entscheidungsrelevanten Erkenntnisgewinn erwarten lässt.
11. Die finale Designrichtung mit Begründung, wesentlichen Entscheidungen, bekannten Trade-offs und umsetzungsrelevanten Constraints festhalten.
12. Nicht mehr benötigte explorative Varianten entfernen, sofern sie nicht ausdrücklich als Ergebnis, Vergleichsartefakt oder Handoff erhalten bleiben sollen.
13. Wenn eine produktive Umsetzung beauftragt ist, die gewählte Designrichtung an Developer-Verantwortung übergeben. Die Produktionsimplementierung ist nicht Bestandteil dieses Workflows.

## Rücksprungregeln

- Wenn Ziel oder Constraints widersprüchlich werden, zurück zu `requirements-clarification`.
- Wenn eine Designrichtung auf fehlendem oder fragwürdigem Kontext beruht, gezielt `research` nachladen und die betroffene Entscheidung erneut prüfen.
- Wenn Varianten nur oberflächlich voneinander abweichen, zurück zu `brainstorming` und strukturell unterschiedliche Richtungen bilden.
- Wenn ein Prototyp die relevante Designfrage nicht sichtbar macht, zurück zu `design-prototyping`.
- Wenn `design-review` wesentliche Probleme findet, die gewählte Richtung iterieren und erneut reviewen.
- Wenn ein Review wegen fehlender Visualisierung nur aus Quelltext möglich wäre, Workflow blockieren oder ein alternatives renderbares Artefakt erzeugen, sofern technisch möglich.

## Codex-Orchestrierung

- Gestalterische Exploration, Prototyping, visuelle Bewertung und Iteration: `designer`.
- Anforderungen oder fachlicher Scope bei echten Widersprüchen: `planner` oder `main/orchestrator`.
- Kontextrecherche: abhängig vom Gegenstand `designer` oder `main/orchestrator`.
- Produktive Integration in Anwendungscode: `developer` nach dem Design-Handoff.
- Formale Verifikation, Regression und Akzeptanzchecks: `tester`, wenn sie nach der Implementierung relevant sind.
- Externe Git-, GitHub- oder administrative Mutationen: `main/orchestrator`.

## Endergebnis

- tatsächlich visualisierte und reviewte Designrichtung
- bei offenem Lösungsraum nachvollziehbar explorierte Alternativen
- mindestens eine Review-Schleife für technisch visualisierbare Designarbeit
- finaler Prototyp oder klar dokumentierte Designentscheidung
- wesentliche Designbegründungen und Trade-offs
- klarer Handoff für eine optionale Produktionsimplementierung

## Grenzen

- Die erste renderbare Lösung ist nicht automatisch das Endergebnis.
- Keine Scheinexploration durch bloße Farb- oder Detailvarianten.
- Keine unnötige Produktionsarchitektur oder neue Abhängigkeit für frühe Prototypen.
- Keine produktive Implementierung innerhalb dieses Workflows.
- Keine formale Testverifikation durch den Design-Review ersetzen.
- Explorative Artefakte dürfen bewusst wegwerfbar sein und müssen nicht Produktionsstandards erfüllen.
