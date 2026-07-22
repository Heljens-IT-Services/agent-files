# Workflow: Insight To Issue

## Ziel

Aus einer vorhandenen Erkenntnis ein strukturiertes GitHub-Issue erstellen.

## Verwenden

- Wenn aus Brainstorming, Analyse, Research, Anforderungsklaerung, User-Beobachtung oder Nutzungskontext ein neues GitHub-Issue entstehen soll.
- Wenn eine Erkenntnis issue-reif gemacht und in GitHub erfasst werden soll.
- Nicht verwenden, wenn die Erkenntnis eine Verbesserung an Agent Instructions, Skills oder Workflows betrifft. Dann `instruction-improvement-issue.md` nutzen.
- Nicht verwenden, wenn nur eine Issue-Grundlage ohne Erstellung gewuenscht ist, ausser der User verlangt das explizit.

## Verwendete Skills

- `brainstorming`
- `research`
- `anforderungsklaerung`
- `code_analyse`
- `github_issue-erstellen`
- `github_type-setzen`
- `github_relationship-setzen`

## Ablauf

1. Ursprung und Art der Erkenntnis bestimmen: Brainstorming, Analyse, Research, Anforderung, User-Beobachtung oder Nutzungskontext.
2. Pruefen, ob die Erkenntnis anhand der passenden Reifekriterien issue-reif ist.
3. GitHub-Issue-Type als Empfehlung aus dem Kontext ableiten, wenn die Reifekriterien klar auf `Task`, `Story`, `Spike` oder `Epic` zeigen.
4. Ziel-Repository bestimmen; Default ist das fachlich relevante Ziel-Repository, ausser der User gibt ein anderes Repository vor.
5. Falls Kontext fehlt, den passenden vorgelagerten Skill nutzen: `anforderungsklaerung`, `brainstorming`, `research` oder `code_analyse`.
6. Mit `github_issue-erstellen` daraus ein GitHub-Issue erstellen.
7. Mit `github_type-setzen` den finalen nativen GitHub-Issue-Type setzen.
8. Mit `github_relationship-setzen` native Relationships setzen, wenn sie aus dem Kontext hervorgehen.

## Reifekriterien

Gemeinsame Mindestkriterien:

- Thema
- Relevanz
- Zielzustand
- Scope und Nicht-Ziele
- passender GitHub-Issue-Type: `Task`, `Story`, `Spike` oder `Epic`

User- oder Product-Issue:

- betroffene Nutzerrolle
- Problem oder Beduerfnis
- gewuenschter Zielzustand
- Akzeptanz- oder Erfolgskriterien
- Scope und Nicht-Ziele

Technical Issue:

- betroffener technischer Bereich
- beobachtetes Problem oder gewuenschte technische Aenderung
- Zielzustand
- technische Randbedingungen oder Risiken
- Verifikationsidee
- Scope und Nicht-Ziele

Spike:

- Fragestellung
- Erkenntnisziel
- Untersuchungsgrenze
- erwartetes Ergebnis, z. B. Entscheidung, Empfehlung, Prototyp oder Dokumentation
- Timebox oder Abbruchkriterium, falls relevant

Epic:

- uebergeordnetes Ziel
- grober Scope
- erwartete Teilbereiche oder Child-Issues
- Nicht-Ziele
- Nutzen oder strategische Begruendung

## Ruecksprungregeln

- Bei unklarem Ziel zurueck zu `anforderungsklaerung`.
- Bei offenen Loesungsrichtungen zurueck zu `brainstorming`.
- Bei fehlenden externen Fakten zurueck zu `research`.
- Bei fehlender technischer Bewertung zurueck zu `code_analyse`.
- Wenn die passenden Reifekriterien nicht erfuellt sind, zurueck zu `anforderungsklaerung`.
- Bei unklarem GitHub-Issue-Type nicht raten, sondern zurueck zu `anforderungsklaerung`.
- Bei unklarer Relationship-Richtung nicht raten, sondern zurueck zu `anforderungsklaerung`.
- Wenn die Erkenntnis Agent Instructions, Skills oder Workflows betrifft, zu `instruction-improvement-issue.md` wechseln; dort ist das Ziel-Repository festgelegt.

## Endergebnis

- erstelltes GitHub-Issue
- Issue-Link
- klarer Scope
- nachvollziehbarer fachlicher und technischer Kontext

## Grenzen

- Kein Issue erstellen, wenn die passenden Reifekriterien nicht erfuellt sind.
- Ziel-Repository nicht still wechseln; Default ist das fachlich relevante Ziel-Repository, ausser der User gibt ein anderes Repository vor.
- Keine Erkenntnisse zu Agent Instructions, Skills oder Workflows in diesem Workflow erfassen; dafuer `instruction-improvement-issue.md` verwenden.
