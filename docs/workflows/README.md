# Workflows

## Zweck

Workflows beschreiben zusammengesetzte Agentenablaeufe fuer Aufgaben, die mehrere atomare Skills in einer festen Reihenfolge kombinieren.

## Verwendung

- Einen Workflow verwenden, wenn mehrere zusammenhaengende Arbeitsschritte als ein konsistenter Ablauf ausgefuehrt werden sollen.
- Fuer Sonderfaelle einzelne Skills aus `../skills/` direkt einsetzen.
- Einen Skill direkt verwenden, wenn genau ein atomarer Arbeitsschritt gebraucht wird.

## Grundprinzip: Workflows kombinieren atomare Skills

- Ein Workflow orchestriert Skills, ersetzt aber deren Regeln nicht.
- Die im Workflow referenzierten Skills muessen gelesen und befolgt werden.
- Ein Workflow darf fehlende Vorarbeit, Blocker oder Rueckspruenge sichtbar machen.
- Wenn ein Workflow-Schritt unklar, blockiert oder nicht belastbar ist, greift die passende Ruecksprungregel.
- Extern wirksame Schritte bleiben an die Grenzen des jeweiligen Skills gebunden.

## Verbindliche Workflow-Struktur

Workflow-Dateien folgen dieser Struktur:

```markdown
# Workflow: <Name>

## Ziel

## Verwenden

## Verwendete Skills

## Verwendete Workflows

## Ablauf

## Ruecksprungregeln

## Endergebnis

## Grenzen
```

Wenn keine besonderen Workflow-Grenzen existieren, wird der Abschnitt `Grenzen` weggelassen.

Der Abschnitt `Verwendete Workflows` wird nur verwendet, wenn ein Workflow andere Workflows orchestriert. Alle anderen Abschnitte sind verpflichtend.

Workflows duerfen zusaetzliche fachliche Steuerungsabschnitte enthalten, wenn sie den Ablauf konkret pruefbar machen, zum Beispiel:

- `Reifekriterien`
- `Schnittkriterien`
- `Entscheidungskriterien`
- `Priorisierung`

## Abschnittsregeln

- `Ziel`: ein bis zwei Saetze zum End-to-End-Zweck.
- `Verwenden`: Trigger, Nicht-Trigger und Abgrenzung zu verwandten Workflows.
- `Verwendete Skills`: alle Skills in Ausfuehrungsnaehe auffuehren.
- `Verwendete Workflows`: andere Workflows auffuehren, wenn sie als abgegrenzte Teilschritte verwendet werden.
- `Ablauf`: Skill-Schritte in Ausfuehrungsreihenfolge benennen.
- `Ruecksprungregeln`: festlegen, wann zu welchem vorherigen Skill zurueckgegangen wird.
- `Endergebnis`: erwarteter Abschlusszustand des Workflows.
- `Grenzen`: workflow-spezifische Verbote oder Stop-Regeln, besonders bei extern wirksamen GitHub- oder Produktionsschritten.
- Zusatzabschnitte: nur verwenden, wenn sie konkrete Entscheidungen im Workflow steuern und nicht nur allgemeine Erklaerung liefern.

## Workflow-Regeln

- Workflows duerfen Skill-Regeln nicht duplizieren, abschwaechen oder ueberschreiben.
- Workflows orchestrieren Reihenfolge, Bedingungen und Rueckspruenge.
- Extern wirksame Schritte bleiben an die Grenzen des jeweiligen Skills gebunden.
- Wenn ein Workflow-Schritt blockiert, nicht improvisieren; Ruecksprungregel anwenden oder Blocker melden.
- Wenn ein benoetigter Skill nicht im Workflow steht, den Workflow nachschaerfen oder Abweichung begruenden.

## Verfuegbare Workflows

| Workflow | URL | Zweck |
|---|---|---|
| Bugfix | [bugfix.md](https://heljens-it-services.github.io/agent-files/workflows/bugfix.md) | Fehler untersuchen, beheben und absichern. |
| Feature Umsetzung | [feature-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/feature-umsetzung.md) | Feature fachlich und technisch umsetzen. |
| Instruction Improvement Issue | [instruction-improvement-issue.md](https://heljens-it-services.github.io/agent-files/workflows/instruction-improvement-issue.md) | Verbesserungsvorschlag fuer Agent Instructions, Skills oder Workflows im `agent-files`-Repository erfassen. |
| Insight To Issue | [insight-to-issue.md](https://heljens-it-services.github.io/agent-files/workflows/insight-to-issue.md) | Erkenntnis aus Brainstorming, Analyse, Research oder Nutzungskontext in ein GitHub-Issue ueberfuehren. |
| Issue To Sub Issues | [issue-to-sub-issues.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-sub-issues.md) | Grosses GitHub-Issue in mehrere Sub-Issues schneiden und als Child-Issues anlegen. |
| Issue To PR | [issue-to-pr.md](https://heljens-it-services.github.io/agent-files/workflows/issue-to-pr.md) | Ein einzelnes Ticket bis zur Pull-Request-Erstellung bearbeiten. |
| Issue Umsetzung | [issue-umsetzung.md](https://heljens-it-services.github.io/agent-files/workflows/issue-umsetzung.md) | Ein bestehendes Issue inklusive relevanter Issue-Beziehungen bis zur versandbereiten Aenderung bearbeiten. |
| Refactoring Mit Absicherung | [refactoring-mit-absicherung.md](https://heljens-it-services.github.io/agent-files/workflows/refactoring-mit-absicherung.md) | Refactoring mit Analyse, Tests und Review absichern. |
