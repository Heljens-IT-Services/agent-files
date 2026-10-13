# DESIGNER.md

Stand: 2026-10-13

## Zweck

Diese Datei definiert technologieübergreifende Designer-Regeln für gestalterische Problemklärung, visuelle Exploration, Prototyping, Designentscheidungen und Design-Reviews.

## Verwendung als gemeinsame Fachbasis

Diese Datei enthält die gemeinsame Designfachbasis für `design_ux` und `design_ui`. Die expliziten Zuständigkeiten und Laufzeitagenten stehen in [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md). Diese Datei ist selbst keine spawnbare Rolle und löst keine zusätzliche Delegation aus.

## Grundverständnis

[MUST] Design muss ein konkretes Nutzer-, Produkt-, Kommunikations- oder Informationsproblem adressieren und darf nicht auf dekorative Gestaltung reduziert werden.

[MUST] Zielgruppe, Zweck, Nutzungskontext und relevante Constraints müssen vor wesentlichen Designentscheidungen ausreichend verstanden sein.

[MUST] Designentscheidungen müssen anhand von Nutzerziel, Verständlichkeit, Konsistenz, Wirkung oder technischen Randbedingungen begründbar sein.

[MUST] Gestaltung muss Funktion, Kommunikation oder ästhetischer Wirkung dienen, ohne wesentliche Nutzerziele unangemessen zu beeinträchtigen.

[MUST_NOT] Persönliche Geschmackspräferenzen des Agenten dürfen nicht als objektive Designregeln dargestellt werden.

[MUST] Neue Designrichtungen müssen Produktidentität, Zielgruppe und Nutzungskontext erkennbar berücksichtigen.

[MUST_NOT] Generische Designmuster dürfen nicht unreflektiert übernommen werden.

## Exploration

[MUST_IF] Der Lösungsraum einer Designaufgabe offen oder konzeptionell ist, müssen mehrere substanziell unterschiedliche Designrichtungen untersucht werden, bevor eine Richtung finalisiert wird.

[MUST_NOT] Scheinvarianten, die nur Farben, einzelne Abstände oder andere oberflächliche Details derselben Idee verändern, dürfen nicht als eigenständige Designrichtungen gezählt werden.

[MUST_IF] Mehrere Richtungen erforderlich sind, müssen sie sich in grundlegenden Gestaltungsentscheidungen unterscheiden.

[MUST] Eine erste visualisierte Lösung ist als Entwurf zu behandeln und darf nicht allein deshalb als finales Design gelten, weil sie technisch renderbar ist.

[MUST_IF] Ein Design technisch visualisiert werden kann, muss vor der Finalisierung mindestens eine explizite visuelle Review-Schleife stattfinden; relevante Review-Funde müssen in einer weiteren Iteration umgesetzt und anschließend erneut visuell geprüft werden.

[ALLOW_IF] Bei kleinen, stark eingeschränkten Designänderungen darf eine einzelne Richtung ausreichen, wenn die wesentlichen gestalterischen Entscheidungen bereits durch bestehenden Kontext oder klare Vorgaben feststehen.

## Visualisierung

[MUST_IF] Eine visuelle Arbeit mit den verfügbaren Werkzeugen renderbar oder anderweitig sichtbar machbar ist, muss der Agent das tatsächliche Ergebnis betrachten und darf die visuelle Qualität nicht ausschließlich aus Quelltext, Markup oder Beschreibungen ableiten.

[SHOULD] Für frühe Exploration soll das reibungsärmste geeignete renderbare Artefakt gewählt werden. Abweichungen sind erlaubt, wenn Interaktion, Medium oder Zielplattform eine andere Darstellung erfordern.

[ALLOW] Für browserdarstellbare Entwürfe dürfen eigenständige Single-File-HTML-Prototypen mit Inline-CSS, Inline-JavaScript, SVG, Canvas, Mock-Daten und simulierten Interaktionen verwendet werden.

[MUST] Explorative Prototypen müssen als temporäre oder klar vom Produktivcode getrennte Designartefakte behandelt werden.

[MUST_NOT] Für frühe Designexploration dürfen nicht allein zur Visualisierung unnötig Produktionsframeworks, Build-Systeme, Komponentenbibliotheken oder neue Abhängigkeiten eingeführt werden.

## Review und Iteration

[MUST] Ein Design-Review muss die Lösung gegen ihr Ziel und ihren Kontext bewerten und mindestens visuelle Hierarchie, Verständlichkeit, Konsistenz und erkennbare Schwächen betrachten.

[MUST_IF] Interaktion relevant ist, müssen Zustände, Feedback, Bedienbarkeit und wesentliche Nutzerflüsse in den Review einbezogen werden.

[MUST_IF] Responsive Verhalten, Barrierefreiheit oder verschiedene Darstellungsgrößen für den Nutzungskontext relevant sind, müssen sie in der visuellen Bewertung berücksichtigt werden.

[MUST_IF] Mehrere Designrichtungen vorliegen, müssen ihre wesentlichen Stärken, Schwächen und Trade-offs vergleichbar bewertet werden.

[MUST] Aus einem Review müssen konkrete nächste Designänderungen oder eine begründete Finalisierungsentscheidung hervorgehen.

[MUST_IF] Nach einem Review relevante Änderungen vorgenommen werden, muss die geänderte Fassung erneut visualisiert und gegen die betroffenen Review-Punkte geprüft werden.

## Rollenabgrenzung

[MUST_NOT] Ein rein explorativer, wegwerfbarer HTML-, CSS-, JavaScript-, SVG- oder sonstiger Designprototyp aktiviert allein keine weitere Rolle.

[MUST_IF] Eine Integration in Produktivcode, ein Produktionsframework oder die Anwendungsarchitektur beauftragt werden soll, muss der Koordinator den Umsetzungsschritt ausdrücklich einer passenden Softwareentwicklungsrolle zuweisen.

[MUST_IF] Formale Verifikation, Regression, Acceptance oder deterministische technische Checks erforderlich sind, muss der Koordinator diese Prüfung ausdrücklich `softwareentwicklung_qualitaetssicherung` zuweisen.

[MUST_NOT] Diese gemeinsame Fachbasis delegiert keine Arbeit und aktiviert weder Softwareentwicklung noch Qualitätssicherung. Ein Design-Review ersetzt keine unabhängig beauftragte Verifikation.

## Handoff

[MUST] Ein abgeschlossenes Design-Handoff muss die gewählte Richtung, wesentliche Designentscheidungen, bekannte Trade-offs und für die Umsetzung relevante Constraints enthalten.

[MUST_IF] Ein visueller Prototyp Teil des Handoffs ist, muss klar sein, welche Teile verbindliche Designabsicht und welche Teile lediglich Mock-, Demo- oder Explorationsmaterial darstellen.

[MUST_NOT] Explorative Mock-Daten, harte Beispielwerte oder vereinfachte Interaktionen dürfen stillschweigend als Produktionsanforderungen weitergegeben werden.
