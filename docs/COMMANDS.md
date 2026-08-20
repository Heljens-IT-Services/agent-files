# COMMANDS.md

## Zweck

Diese Datei definiert die host-unabhängige Slash-Command-Sprache für Navigation, Detailanzeige und bewusste Auswahl veröffentlichter Katalogeinträge.

## Grundregeln

[MUST] Natürliche User-Anfragen und die automatische kontextbezogene Auswahl von Skills und Workflows müssen weiterhin funktionieren.

[MUST] Ein Slash-Command muss als User-Anweisung innerhalb der bestehenden Sicherheits-, Berechtigungs-, Prioritäts-, Scope- und Rückfrageregeln behandelt werden.

[MUST_NOT] Ein Slash-Command darf keine weitergehende Autorisierung ableiten, als seine dokumentierte Semantik und der konkrete User-Kontext hergeben.

[MUST] Die Command-Grammatik und die allgemeinen Auflösungsregeln müssen ausschließlich in dieser Datei gepflegt werden.

[MUST] Stabile IDs und direkte Aliase müssen ausschließlich im jeweils zuständigen Katalog gepflegt werden:

- Skills in [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md)
- Workflows in [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md)
- Technologien in [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md)

## Grammatik

```ebnf
input       = spacing, "/", root, { spacing, token }, spacing ;
root        = name | "?" ;
token       = option | quoted | bare ;
option      = "--", name, [ "=", value ] ;
quoted      = '"', { character - '"' }, '"' ;
bare        = character - spacing, { character - spacing } ;
name        = letter-or-digit, { letter-or-digit | "-" } ;
value       = quoted | bare ;
spacing     = { " " | tab } ;
```

[MUST] Root-Commands, Subcommands, IDs und Aliase müssen in kanonischer Form aus Kleinbuchstaben, Ziffern und Bindestrichen bestehen.

[MUST] Die Auflösung von Root-Commands, Subcommands, IDs und Aliasen muss ohne Beachtung der Groß-/Kleinschreibung erfolgen und im Ergebnis die kanonische Schreibweise ausgeben.

[MUST] Mehrere Tokens müssen durch Leerraum getrennt werden. Doppelte Anführungszeichen dürfen Leerraum innerhalb eines Arguments erhalten.

[MUST] Optionen müssen mit `--` beginnen. Die Formen `--name value` und `--name=value` sind zulässig, sofern der konkrete Command die Option dokumentiert.

[MUST] Nicht dokumentierte Optionen, doppelte nicht wiederholbare Optionen und nicht geschlossene Anführungszeichen müssen als ungültige Eingabe behandelt werden.

## Stabile IDs und Aliase

[MUST] Jeder veröffentlichte Katalogeintrag muss genau eine stabile ID im zuständigen Katalog besitzen.

[MUST] Eine stabile ID muss dem Muster `^[a-z0-9]+(?:-[a-z0-9]+)*$` entsprechen und innerhalb ihres Katalogs eindeutig sein.

[MUST] Die kanonischen Aufrufe eines Katalogeintrags müssen aus Root-Command, Aktion und stabiler ID gebildet werden, beispielsweise `/skills show code-reading` oder `/workflows run bugfix`.

[ALLOW] Ein Katalogeintrag darf zusätzlich einen oder mehrere direkte Aliase aus einem oder mehreren Tokens wie `/finish` oder `/release` besitzen.

[MUST] Direkte Aliase müssen global eindeutig sein und dürfen weder Root-Commands noch Help-Aliase verdecken.

[ALLOW] Ein direkter Alias darf erforderliche Positionsargumente als Platzhalter wie `<issue-number>` dokumentieren.

[MUST] Direkte Aliase müssen vor der Root-Command-Auflösung gegen die vollständige normalisierte Eingabe und die dokumentierte Alias-Syntax abgeglichen werden.

[MUST] Die öffentliche Command-Sprache verwendet ausschließlich englische Aliase, stabile IDs und Syntax-Platzhalter. Die bisherigen deutschen Aliase und IDs werden ohne Deprecated-Übergangsphase entfernt.

[MUST_IF] Wenn ein Alias Positionsargumente definiert, müssen Anzahl, Reihenfolge und Format der Argumente in der Detaildatei des Katalogeintrags dokumentiert und bei der Auflösung validiert werden.

[MUST_IF] Wenn ein Alias Präfix eines anderen Alias ist, darf nur eine exakte vollständige Tokenfolge oder eine vollständig passende dokumentierte Alias-Syntax aufgelöst werden; nicht dokumentierte weitere Tokens sind ungültig.

[MUST] Ein direkter Alias muss dieselbe Semantik und dieselben Grenzen wie der kanonische Aufruf seines Katalogeintrags behalten.

[MUST_NOT] Bei einer mehrdeutigen ID oder einem mehrdeutigen Alias darf der Agent keine Auswahl raten.

## Root-Commands

| Command | Syntax | Verhalten |
|---|---|---|
| Help | `/help`, `/?` | Zeigt die allgemeine Hilfe. |
| Kontext-Hilfe | `/help <command>` | Zeigt Syntax, Subcommands und Beispiele für einen Root-Command oder direkten Alias. |
| Skills | `/skills list`, `/skills show <skill-id>`, `/skills run <skill-id> [<argument> ...]` | Listet, beschreibt oder wählt einen Skill aus. Zusätzliche Argumente sind nur zulässig, wenn der Skill sie dokumentiert. |
| Workflows | `/workflows list`, `/workflows show <workflow-id>`, `/workflows run <workflow-id> [<argument> ...]` | Listet, beschreibt oder startet einen Workflow. Zusätzliche Argumente sind nur zulässig, wenn der Workflow sie dokumentiert. |
| Technologien | `/technologies list`, `/technologies show <technology-id>` | Listet oder beschreibt technologiespezifische Regeln. |

## Semantik

### `list`

[MUST] `list` muss die Einträge des zugehörigen Katalogs mit kanonischer ID, Name, Kurzbeschreibung und vorhandenem direkten Alias ausgeben.

[MUST_NOT] `list` darf keinen Skill oder Workflow ausführen.

### `show`

[MUST] `show` muss den durch die ID bezeichneten Katalogeintrag laden und dessen Zweck, Verwendung, Grenzen und Quelle knapp wiedergeben.

[MUST_NOT] `show` darf den bezeichneten Skill oder Workflow nicht ausführen.

### `run`

[MUST] `run` muss den bezeichneten Skill oder Workflow bewusst auswählen und nach dessen vollständigen Regeln ausführen.

[MUST] Fehlender Task-Kontext oder eine durch den ausgewählten Eintrag vorgeschriebene Rückfrage muss weiterhin geklärt werden.

[MUST_IF] Wenn ein Skill Positionsargumente dokumentiert, muss `run` sie in derselben Anzahl, Reihenfolge und demselben Format wie seine direkten Aliase akzeptieren.

[MUST_IF] Wenn ein Workflow Positionsargumente dokumentiert, muss `run` sie in derselben Anzahl, Reihenfolge und demselben Format wie seine direkten Aliase akzeptieren.

[MUST_NOT] Nicht dokumentierte Positionsargumente dürfen an `run` oder direkte Aliase übergeben werden.

[MUST_IF] Wenn die Verwendungskriterien einer gültigen ID nicht erfüllt sind, muss der Agent stoppen, die Unpassung benennen und auf einen passenden Eintrag oder eine natürliche Anfrage verweisen.

[MUST_NOT] `run` darf Grenzen des ausgewählten Eintrags oder höherrangige Regeln nicht umgehen.

## Hilfe und Fehlerverhalten

[MUST] `/help` muss die verfügbaren Root-Commands, Help-Aliase, die Grundsyntax und mindestens je ein Beispiel für `list`, `show` und `run` nennen.

[MUST] Die allgemeine Hilfe muss direkte Aliase getrennt von Root-Commands mit Katalogtyp und kanonischem Aufruf ausweisen.

[MUST_NOT] Die allgemeine Hilfe darf direkte Skill- oder Workflow-Aliase als Root-Commands darstellen.

[MUST] `/help` und `/?` müssen ohne weiteres Argument zusätzlich `README.md` und `PROJECT.md` lesen und unter `Repository-Kontext` deren aktuell relevante Kernaussagen knapp zusammenfassen.

[MUST] Der Repository-Kontext muss sich auf Zweck, Versionsbasis und für die Nutzung wesentliche fachliche oder technische Leitplanken beschränken und in der Regel zwei bis vier kurze Punkte umfassen.

[MUST_NOT] Der Repository-Kontext darf ganze Abschnitte, Detailstrukturen oder für die aktuelle Orientierung irrelevante Inhalte aus `README.md` oder `PROJECT.md` nicht wiederholen.

[MUST_IF] Wenn `README.md` oder `PROJECT.md` fehlt oder nicht gelesen werden kann, muss die Hilfe dies knapp benennen und darf fehlende Inhalte nicht erfinden.

[MUST] `/help <command>` muss den Namen mit oder ohne führenden Slash akzeptieren und die kanonische Syntax, Subcommands, Argumente, Aliase und Beispiele des Ziels nennen.

[MUST_IF] Wenn ein Root-Command ohne erforderlichen Subcommand eingegeben wird, muss die kontextspezifische Hilfe mit den gültigen Subcommands ausgegeben werden.

[MUST_IF] Wenn ein erforderliches Argument fehlt, muss die Antwort die erwartete Syntax und die passende `list`-Alternative nennen.

[MUST_IF] Bei unbekanntem Root-Command, Subcommand, ID oder Alias muss die Antwort passende gültige Kandidaten nennen oder auf `/help` beziehungsweise den passenden `list`-Command verweisen.

[MUST_IF] Wenn eine Eingabe syntaktisch ungültig oder mehrdeutig ist, muss die Antwort die Ausführung stoppen, den Grund nennen und eine kanonische Beispielsyntax zeigen.

## Erweiterbarkeit

[MUST] Neue Kataloge müssen einen eindeutigen Root-Command, einen eigenen Katalog für stabile IDs und eine in dieser Datei definierte Semantik erhalten.

[MUST] Neue Subcommands und Optionen müssen rückwärtskompatibel ergänzt und vor ihrer Verwendung dokumentiert werden.

[MUST] Die Root-Namen `roles` und `actions` bleiben für spätere Kataloge reserviert.

[MUST_NOT] Ein Host darf keine abweichende Bedeutung für einen dokumentierten Command oder Alias einführen.

## Beispiele

```text
/help
/help skills
/skills list
/skills show code-reading
/skills run code-reading
/skills run code-refactoring
/refactor
/skills run code-testing
/testing
/testing e2e
/skills run code-testing all
/workflows show feature-finish
/workflows run feature-finish
/workflows run issue-graph-implementation 123
/workflows run issue-sanitize 123
/workflows run issue-to-sub-issues 123
/workflows run issue-to-sub-issues 123 flat
/implement #123
/sanitize 123
/sub-issues #123
/sub-issues 123 flat
/finish
/release
/technologies show csharp-net
```
