# COMMANDS.md

## Zweck

Diese Datei definiert die host-unabhaengige Slash-Command-Sprache fuer die veroeffentlichten Agent Files. Slash-Commands ergaenzen natuerliche Sprache um eine eindeutige Navigation, Detailanzeige und bewusste Auswahl von Skills und Workflows.

## Grundregeln

[MUST] Natuerliche User-Anfragen und die automatische kontextbezogene Auswahl von Skills und Workflows muessen weiterhin funktionieren.

[MUST] Ein Slash-Command muss als User-Anweisung innerhalb der bestehenden Sicherheits-, Berechtigungs-, Prioritaets-, Scope- und Rueckfrageregeln behandelt werden.

[MUST_NOT] Ein Slash-Command darf keine weitergehende Autorisierung ableiten, als seine dokumentierte Semantik und der konkrete User-Kontext hergeben.

[MUST] Die Command-Grammatik und die allgemeinen Aufloesungsregeln muessen ausschliesslich in dieser Datei gepflegt werden.

[MUST] Stabile IDs und direkte Aliase muessen ausschliesslich im jeweils zustaendigen Katalog gepflegt werden:

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

[MUST] Root-Commands, Subcommands, IDs und Aliase muessen in kanonischer Form aus Kleinbuchstaben, Ziffern und Bindestrichen bestehen.

[MUST] Die Aufloesung von Root-Commands, Subcommands, IDs und Aliasen muss ohne Beachtung der Gross-/Kleinschreibung erfolgen und im Ergebnis die kanonische Schreibweise ausgeben.

[MUST] Mehrere Tokens muessen durch Leerraum getrennt werden. Doppelte Anfuehrungszeichen duerfen Leerraum innerhalb eines Arguments erhalten.

[MUST] Optionen muessen mit `--` beginnen. Die Formen `--name value` und `--name=value` sind zulaessig, sofern der konkrete Command die Option dokumentiert.

[MUST] Nicht dokumentierte Optionen, doppelte nicht wiederholbare Optionen und nicht geschlossene Anfuehrungszeichen muessen als ungueltige Eingabe behandelt werden.

## Stabile IDs und Aliase

[MUST] Jeder veroeffentlichte Katalogeintrag muss genau eine stabile ID im zustaendigen Katalog besitzen.

[MUST] Eine stabile ID muss dem Muster `^[a-z0-9]+(?:-[a-z0-9]+)*$` entsprechen und innerhalb ihres Katalogs eindeutig sein.

[MUST] Die kanonischen Aufrufe eines Katalogeintrags muessen aus Root-Command, Aktion und stabiler ID gebildet werden, beispielsweise `/skills show code-lesen` oder `/workflows run bugfix`.

[ALLOW] Ein Katalogeintrag darf zusaetzlich einen direkten Alias aus einem oder mehreren Tokens wie `/finish` oder `/finish release` besitzen.

[MUST] Direkte Aliase muessen global eindeutig sein und duerfen weder Root-Commands noch Help-Aliase verdecken.

[MUST] Direkte Aliase muessen vor der Root-Command-Aufloesung gegen die vollstaendige normalisierte Eingabe abgeglichen werden. Beispielsweise bezeichnet `/finish` den Workflow `finish`, waehrend `/finish release` den Workflow `release` bezeichnet.

[MUST_IF] Wenn ein direkter Alias ein vollstaendiges Praefix eines anderen Alias ist, darf nur die exakte vollstaendige Tokenfolge ausgefuehrt werden. Nicht dokumentierte nachgestellte Tokens muessen als ungueltige Eingabe behandelt werden.

[MUST] Ein direkter Alias muss dieselbe Semantik und dieselben Grenzen wie der kanonische Aufruf seines Katalogeintrags behalten.

[MUST_NOT] Bei einer mehrdeutigen ID oder einem mehrdeutigen Alias darf der Agent keine Auswahl raten.

## Root-Commands

| Command | Syntax | Verhalten |
|---|---|---|
| Help | `/help`, `/?`, `/hilfe` | Zeigt die allgemeine Hilfe. |
| Kontext-Hilfe | `/help <command>` | Zeigt Syntax, Subcommands und Beispiele fuer einen Root-Command oder direkten Alias. |
| Skills | `/skills list`, `/skills show <skill-id>`, `/skills run <skill-id>` | Listet, beschreibt oder waehlt einen Skill aus. |
| Workflows | `/workflows list`, `/workflows show <workflow-id>`, `/workflows run <workflow-id>` | Listet, beschreibt oder startet einen Workflow. |
| Technologien | `/technologies list`, `/technologies show <technology-id>` | Listet oder beschreibt technologiespezifische Regeln. |

## Semantik

### `list`

[MUST] `list` muss die Eintraege des zugehoerigen Katalogs mit kanonischer ID, Name, Kurzbeschreibung und vorhandenem direkten Alias ausgeben.

[MUST_NOT] `list` darf keinen Skill oder Workflow ausfuehren.

### `show`

[MUST] `show` muss den durch die ID bezeichneten Katalogeintrag laden und dessen Zweck, Verwendung, Grenzen und Quelle knapp wiedergeben.

[MUST_NOT] `show` darf den bezeichneten Skill oder Workflow nicht ausfuehren.

### `run`

[MUST] `run` muss den bezeichneten Skill oder Workflow bewusst auswaehlen und nach dessen vollstaendigen Regeln ausfuehren.

[MUST] Fehlender Task-Kontext oder eine durch den ausgewaehlten Eintrag vorgeschriebene Rueckfrage muss weiterhin geklaert werden.

[MUST_IF] Wenn die ID gueltig ist, aber die Verwendungskriterien des Skills oder Workflows im aktuellen Kontext nicht erfuellt sind, muss der Agent die Ausfuehrung stoppen, die Unpassung benennen und auf einen passenden Eintrag oder eine natuerliche Anfrage verweisen.

[MUST_NOT] `run` darf Grenzen des ausgewaehlten Eintrags oder hoeherrangige Regeln nicht umgehen.

## Hilfe und Fehlerverhalten

[MUST] `/help` muss die verfuegbaren Root-Commands, Help-Aliase, die Grundsyntax und mindestens je ein Beispiel fuer `list`, `show` und `run` nennen.

[MUST] Direkte Aliase muessen in der allgemeinen Hilfe getrennt von Root-Commands mit ihrem Katalogtyp und kanonischen Aufruf ausgewiesen werden, beispielsweise `/finish` als Workflow-Alias fuer `/workflows run finish` und `/finish release` als Workflow-Alias fuer `/workflows run release`.

[MUST_NOT] Die allgemeine Hilfe darf direkte Skill- oder Workflow-Aliase als Root-Commands darstellen.

[MUST] `/help`, `/hilfe` und `/?` muessen ohne weiteres Argument zusaetzlich `README.md` und `PROJECT.md` lesen und unter `Repository-Kontext` deren aktuell relevante Kernaussagen knapp zusammenfassen.

[MUST] Der Repository-Kontext muss sich auf Zweck, Versionsbasis und fuer die Nutzung wesentliche fachliche oder technische Leitplanken beschraenken und in der Regel zwei bis vier kurze Punkte umfassen.

[MUST_NOT] Der Repository-Kontext darf ganze Abschnitte, Detailstrukturen oder fuer die aktuelle Orientierung irrelevante Inhalte aus `README.md` oder `PROJECT.md` nicht wiederholen.

[MUST_IF] Wenn `README.md` oder `PROJECT.md` fehlt oder nicht gelesen werden kann, muss die Hilfe dies knapp benennen und darf fehlende Inhalte nicht erfinden.

[MUST] `/help <command>` muss den Namen mit oder ohne fuehrenden Slash akzeptieren und die kanonische Syntax, Subcommands, Argumente, Aliase und Beispiele des Ziels nennen.

[MUST_IF] Wenn ein Root-Command ohne erforderlichen Subcommand eingegeben wird, muss die kontextspezifische Hilfe mit den gueltigen Subcommands ausgegeben werden.

[MUST_IF] Wenn ein erforderliches Argument fehlt, muss die Antwort die erwartete Syntax und die passende `list`-Alternative nennen.

[MUST_IF] Wenn ein Root-Command, Subcommand, eine ID oder ein Alias unbekannt ist, muss die Antwort die unbekannte Eingabe benennen und passende gueltige Kandidaten vorschlagen. Ohne hinreichend nahen Kandidaten muss sie auf `/help` oder den passenden `list`-Command verweisen.

[MUST_IF] Wenn eine Eingabe syntaktisch ungueltig oder mehrdeutig ist, muss die Antwort die Ausfuehrung stoppen, den Grund nennen und eine kanonische Beispielsyntax zeigen.

## Erweiterbarkeit

[MUST] Neue Kataloge muessen einen eindeutigen Root-Command, einen eigenen Katalog fuer stabile IDs und eine in dieser Datei definierte Semantik erhalten.

[MUST] Neue Subcommands und Optionen muessen rueckwaertskompatibel ergaenzt und vor ihrer Verwendung dokumentiert werden.

[MUST] Die Root-Namen `roles` und `actions` bleiben fuer spaetere Kataloge reserviert.

[MUST_NOT] Ein Host darf keine abweichende Bedeutung fuer einen dokumentierten Command oder Alias einfuehren.

## Beispiele

```text
/help
/help skills
/skills list
/skills show code-lesen
/skills run code-lesen
/workflows show finish
/workflows run finish
/finish
/finish release
/technologies show csharp-net
```
