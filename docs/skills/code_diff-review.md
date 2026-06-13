# Skill: Code Diff Review

## Zweck

Einen Aenderungssatz auf Scope, Korrektheit und Risiken pruefen.

## Verwenden

- Vor Commit oder Pull Request.
- Nach riskanten oder groesseren Aenderungen.
- Wenn unbeabsichtigte Neben- oder Formatierungsaenderungen moeglich sind.

## Vorgehen

1. Diff gegen Ziel und Scope abgleichen.
2. Arbeitsstatus und Diff lesen, z. B. `git status --short --branch`, `git diff --stat`, `git diff`, `git diff --cached --stat`, `git diff --cached` oder `git diff -- <pfad>`.
3. Staged und unstaged Aenderungen getrennt betrachten, wenn beides vorhanden ist.
4. Unerwartete Dateien, Hunks, Formatierungs-, Whitespace-, Line-ending-, Encoding-Aenderungen und Nebeneffekte suchen.
5. Regressionen, fehlende Tests und riskante Annahmen markieren.
6. Versandbereitschaft dreistufig bewerten: `versandbereit`, `versandbereit mit Hinweisen` oder `nicht versandbereit`.

## Grenzen

- Read-only arbeiten.
- Keine Dateien aendern.
- Keine Tests, Builds oder Anwendungen ausfuehren. Das gehoert zu `code_testen`.
- Keine Fehler beheben. Dafuer `code_implementieren` oder `code_refactoring` nutzen.
- Keine Formatierungs-, Whitespace-, Line-ending- oder Encoding-Probleme selbst korrigieren.
- Keine breite Analyse ersetzen. Tiefergehende Ursachen- oder Risikoanalyse gehoert zu `code_analyse`.
- Untracked files nicht reviewen, aber kurz erwaehnen, wenn sie im Arbeitsstatus auftauchen.

## Output

- Bewertung: `versandbereit`, `versandbereit mit Hinweisen` oder `nicht versandbereit`
- relevante Befunde
- staged/unstaged-Einordnung, wenn relevant
- Risiken
- notwendige Nacharbeit

## Qualitaetskriterien

- Echte Risiken vor Stilfragen.
- Scope-Abweichungen klar benennen.
- Nicht nur zusammenfassen, sondern bewerten.
- Blockierende und nicht-blockierende Befunde klar trennen.
- Unerwartete Formatierungs- oder Encoding-Aenderungen als Scope-Risiko markieren.
- Fehlende Tests risikobasiert bewerten, nicht pauschal als blockierend einstufen.
