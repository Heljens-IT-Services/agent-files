# Skills

Atomare Agentenfaehigkeiten. Workflows kombinieren mehrere Skills.

Die verbindliche Situationstabelle fuer die Auswahl einzelner Skills steht in [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md).

## Namenskonvention

- `code_`: programmiernahe Skills.
- `github_`: GitHub-nahe Skills.
- Dateinamen beschreiben den fachlichen Scope.

In diesem Repository gelten Branch-Checkout und Commit/Push als GitHub-nahe Skills.

## Verwendung

- Einzelnen Skill nutzen, wenn genau ein Arbeitsschritt gebraucht wird.
- Workflow nutzen, wenn mehrere Skills zusammenhaengend ausgefuehrt werden sollen.
- Skill-Dateien knapp halten: nur Zweck, Einsatzgrenze, Ablauf, Output und harte Qualitaetskriterien.

## Grundprinzip: atomare Skills

- Ein Skill verantwortet genau eine klar abgegrenzte Faehigkeit.
- Ein Skill fuehrt keine vorgelagerten oder nachgelagerten Skills heimlich mit aus.
- Wenn ein Arbeitsschritt weiteren Kontext, Klaerung, Analyse, Recherche, Planung, Umsetzung, Test oder Review braucht, wird der passende Skill explizit vorgelagert oder nachgelagert.
- Workflows kombinieren atomare Skills zu laengeren Ablaeufen.
- Skills duerfen fehlende Vorarbeit benennen, aber sie nicht stillschweigend ersetzen.

## Verbindliche Skill-Struktur

Skill-Dateien folgen dieser Struktur:

```markdown
# Skill: <Name>

## Zweck

## Verwenden

## Vorgehen

## Kommandos

## Grenzen

## Artefakt

## Output

## Qualitaetskriterien
```

### Abschnittsregeln

- `Zweck`: ein bis zwei Saetze zum fachlichen Nutzen.
- `Verwenden`: Trigger, Nicht-Trigger und Abgrenzung zu verwandten Skills oder Workflows.
- `Vorgehen`: konkrete Arbeitsschritte in Ausfuehrungsreihenfolge.
- `Kommandos`: optional; konkrete Tool- oder CLI-Kommandos fuer Skills, bei denen die korrekte Ausfuehrung wichtig ist.
- `Grenzen`: erlaubte und verbotene Aktionen, besonders bei Schreibzugriffen, GitHub, Docker, Datenbanken, externen Systemen oder Online-Recherche.
- `Artefakt`: nur verwenden, wenn der Skill Dateien erzeugt oder aktualisiert. Dann Pfad, Namensschema, Inhalt und Stil festlegen.
- `Output`: erwartete Chat-Ausgabe oder Datei-Ausgabe.
- `Qualitaetskriterien`: kurze, harte und pruefbare Regeln.

Wenn kein Artefakt entsteht, wird der Abschnitt `Artefakt` weggelassen.

## Schreibstil

- Knapp, operativ und eindeutig formulieren.
- Bulletpoints und nummerierte Schritte bevorzugen.
- Keine allgemeinen Agentenphilosophien dokumentieren.
- Bestehende ASCII-Schreibweise beibehalten: `ae`, `oe`, `ue`, `ss`.
