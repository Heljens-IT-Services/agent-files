# AGENTS.md
Stand: 2026-08-21

## Zweck

Diese Datei definiert verbindliche Arbeitsregeln für AI-/Code-Agents.

## Definition Regelmarker

[MUST] Der Agent ist verpflichtet, die Regel zu befolgen.

[MUST_IF] Der Agent ist verpflichtet, die Regel zu befolgen, wenn die genannte Bedingung erfüllt ist.

[MUST_NOT] Der Agent darf die beschriebene Handlung nicht ausführen.

[MUST_NOT_IF] Der Agent darf die beschriebene Handlung nicht ausführen, wenn die genannte Bedingung erfüllt ist.

[ALLOW] Der Agent darf die Handlung ausführen, ist aber nicht dazu verpflichtet.

[ALLOW_IF] Der Agent darf die Handlung nur ausführen, wenn die genannte Bedingung erfüllt ist.

[SHOULD] Der Agent soll die Regel als Default- oder Präferenzverhalten befolgen. Er darf davon abweichen, wenn der aktuelle Task einen konkreten fachlichen, technischen oder sicherheitsrelevanten Grund liefert.

[OPTIONAL] Der Agent ist ausdrücklich nicht verpflichtet, die Handlung auszuführen.

[PRIORITY] Die Regel beschreibt einen Konflikt-, Auslegungs- oder Vorrangfall.

## Arbeiten mit Regelmarker

[MUST] Regelmarker sind Modalitäts-Annotationen. Die natürliche Formulierung der Regel muss weiterhin vollständig, verständlich und operativ sein.

[MUST_NOT_IF] Der Agent darf keine weiteren Regelmarker einführen, solange einer der oben definierten Marker die beabsichtigte Modalität ausdrückt.

## Pflichtlektüre

Zu Beginn eines Tasks gelten diese Einstiegsdateien:

| Pfad | Geltung | Zweck |
|---|---|---|
| [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) | Pflicht | Allgemeine Arbeitsregeln, Regelmarker und Prioritätslogik. |
| `PROJECT.md` im Repository-Root | Pflicht | Repositoryweite Versionsbasis und Leitplanken. |
| [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Pflicht | Lookup für kontextabhängige Rollenregeln. |
| [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) | Pflicht | Lookup für atomare Skills. |
| [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md) | Pflicht | Lookup für zusammengesetzte Workflows. |
| [COMMANDS.md](https://heljens-it-services.github.io/agent-files/COMMANDS.md) | Bei Slash-Commands | Grammatik, Auflösung und Fehlerbehandlung für Slash-Commands. |
| [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) | Bei Technologie-Commands oder technologiespezifischer Rollenarbeit | Rollenbewusster Lookup für technologiespezifische Regeldateien. |
| `README.md` | Bei Relevanz | Menschlicher Schnelleinstieg in Projekt, Setup und Kommandos. |

[MUST] Der Agent muss alle als Pflicht gekennzeichneten Einstiegsdateien zu Beginn eines Tasks im aktuellen Kontext vollständig und aktuell genug kennen und befolgen.

[MUST_IF] Wenn technologiespezifischer Kontext für eine bereits relevante Rolle im Task relevant ist, muss der Agent `TECHNOLOGIES.md` laden und nur die passenden Mappings dieser Rolle anwenden. Das Laden einer Technologie darf keine zusätzliche Rolle aktivieren.

[MUST_IF] Wenn der Agent innerhalb einer eigenständigen Teilsolution aktiv wird, muss er vor jeder lesenden oder schreibenden Aktivität, jedem Kommando und jeder Prüfung zusätzlich deren lokale `PROJECT.md` vollständig und aktuell genug kennen und befolgen.

[MUST_IF] Wenn die in der Spalte `Geltung` genannte Bedingung eintritt, muss der Agent die betreffende Einstiegsdatei im aktuellen Kontext vollständig und aktuell genug kennen und befolgen.

[ALLOW_IF] Bereits gelesene verbindliche Regeldateien dürfen wiederverwendet werden, wenn kein Hinweis auf eine zwischenzeitliche Änderung besteht.

[MUST_IF] Der Agent muss eine verbindliche Regeldatei erneut abrufen, wenn die vorhandene Kontextfassung fehlt, unvollständig, offensichtlich veraltet oder nicht eindeutig identifizierbar ist.

[MUST_IF] Wenn eine in den Lookup-Dateien beschriebene Situation für den aktuellen Task eintritt, muss der Agent die dort verlinkte Detaildatei lesen und befolgen.

Als optionale Regeldateien gelten Einstiegsdateien mit bedingter Geltung sowie über Lookup ausgewählte Detaildateien.

[MUST_IF] Wenn der Agent eine optionale Regeldatei einliest oder erneut abruft, muss er dem User unmittelbar kurz den Dokumenttitel mitteilen.

[ALLOW_IF] Mehrere gleichzeitig eingelesene optionale Regeldateien dürfen in einer Rückmeldung zusammengefasst werden, wenn jeder Dokumenttitel genannt wird.

## Dokumentierte Kommandos

[MUST] Der Agent muss dokumentierte Kommandos vor der Ausführung gegen den aktuellen Kontext prüfen und Platzhalter durch konkrete Werte ersetzen.

[MUST_NOT_IF] Dokumentierte Kommandos dürfen bei unaufgelösten Platzhaltern, ungeprüften destruktiven Zielen oder einer Zustandsänderung außerhalb des autorisierten Task-Scopes nicht ausgeführt werden.

## Sprache

[MUST] Quellcode-Kommentare und Dokumentation müssen standardmäßig auf Deutsch verfasst werden und Umlaute sowie `ß` korrekt verwenden.

[ALLOW_IF] Von dieser Sprache oder Schreibweise darf nur abgewichen werden, wenn ein Format, Protokoll, fremddefinierter Inhalt oder eine technische Einschränkung dies erfordert.

## Priorität von Anweisungen

### Globale Priorität

[PRIORITY] Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung haben Vorrang vor User-Anweisungen und Repository-Regeln.

[PRIORITY] Direkte User-Anweisungen im aktuellen Task haben Vorrang vor Repository-internen Agent-Regeln, sofern sie keine Sicherheits-, Datenschutz- oder Plattformvorgaben verletzen.

[PRIORITY] Spezifische Regeln haben nur innerhalb ihres ausdrücklich beschriebenen Scopes Vorrang vor allgemeineren Regeln.

[PRIORITY] Bei widersprüchlichen Repository-Regeln gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. Lokale `PROJECT.md` der Teilsolution innerhalb ihres Scopes.
2. `PROJECT.md` im Repository-Root.
3. Passende rollenbasierte Regeldateien gemäß der Prioritätsreihenfolge ihrer Rolle.
4. [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).
5. Bestehender Code-Stil und lokale Patterns.

[PRIORITY] Eine Erlaubnis hebt kein spezifisches Verbot auf, außer die Erlaubnis ist ausdrücklich als Ausnahme von genau diesem Verbot formuliert.

[PRIORITY] Bei unklarer Erlaubnis gilt eine riskante, zustandsverändernde, extern wirksame oder irreversible Handlung als nicht erlaubt.

[MUST_IF] Der Agent muss die Unklarheit benennen und eine sichere, eng begrenzte Alternative wählen oder rückfragen, wenn eine Regel unklar, widersprüchlich oder offensichtlich gefährlich ist.

[MUST_IF] Der Agent muss die Abweichung im Arbeitsabschluss kurz benennen, wenn eine vorhandene Anweisung offensichtlich falsch, gefährlich oder irreführend geworden ist.

## README.md

[SHOULD] `README.md` soll kurz und auf den menschlichen Schnelleinstieg fokussiert bleiben. Abweichungen sind erlaubt, wenn der User ausdrücklich eine ausführlichere README-Dokumentation verlangt.

[SHOULD] `README.md` soll Titel, Kurzbeschreibung, Voraussetzungen, Setup, Start, Build, Tests und eine knappe technische Orientierung enthalten, soweit diese Punkte für das Repository relevant sind.

[ALLOW_IF] Der Agent darf `README.md` nur mitpflegen, wenn ausdrücklich verlangt.

[MUST_NOT_IF] `README.md` darf keine Inhalte duplizieren, die in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder andere veröffentlichte Agent Files gehören.

## GitHub-Basiskonfiguration

[MUST_IF] Ein von Heljens gepflegtes Software-Repository GitHub Issue Forms nutzt, muss es den vollständigen [Issue-Template-Satz](https://heljens-it-services.github.io/agent-files/github/ISSUE_TEMPLATES.md) unverändert unter `.github/ISSUE_TEMPLATE` übernehmen.

[MUST_IF] Ein von Heljens gepflegtes Software-Repository unterstützte Abhängigkeitsquellen besitzt, muss es `.github/dependabot.yml` gemäß der [Dependabot-Leitplanke](https://heljens-it-services.github.io/agent-files/github/DEPENDABOT.md) pflegen.

## Codex-Custom-Agents

[MUST_IF] Wenn ein ausführendes Repository Codex-Custom-Agents unterstützt, müssen alle TOML-Dateien unter `.codex/agents/` inventarisiert und anhand ihres Feldes `name` auf die kanonischen Agent-Namen `planner`, `developer`, `tester` und `designer` geprüft werden.

[MUST_IF] Einer der kanonischen Agent-Namen im ausführenden Repository fehlt, muss die zugehörige Online-Vorlage nachgelagert unter dem kanonischen Pfad `.codex/agents/<agent-name>.toml` erstellt werden. Dies gilt für jeden fehlenden Agent einzeln und unabhängig davon, ob andere Custom Agents bereits vorhanden sind.

[MUST_IF] Der Agent `planner` fehlt, muss [planner.toml](https://heljens-it-services.github.io/agent-files/codex/agents/planner.toml) kopiert werden. Fehlt `developer`, muss [developer.toml](https://heljens-it-services.github.io/agent-files/codex/agents/developer.toml) kopiert werden. Fehlt `tester`, muss [tester.toml](https://heljens-it-services.github.io/agent-files/codex/agents/tester.toml) kopiert werden. Fehlt `designer`, muss [designer.toml](https://heljens-it-services.github.io/agent-files/codex/agents/designer.toml) kopiert werden.

[MUST_NOT_IF] Ein kanonischer Zielpfad bereits durch eine widersprüchliche Datei belegt ist, darf sie nicht stillschweigend überschrieben werden; der Konflikt muss gemeldet werden.

[MUST] Die online veröffentlichten Vorlagen unter `docs/codex/agents/` müssen inhaltsgleich mit den Mustervorlagen unter `.codex/agents/` gepflegt werden.

[MUST_NOT] Die TOML-Dateien dürfen die vollständigen Heljens-Rollen-, Skill- oder Workflow-Regeln nicht duplizieren. Sie bilden nur die Codex-Laufzeit ab und müssen auf die geltenden Einstiegsdateien, `PROJECT.md` und den relevanten Heljens-Kontext verweisen.

[MUST_IF] Eine Laufzeit keine Codex-Custom-Agents unterstützt, bleiben die veröffentlichten Rollen-, Skill- und Workflow-Regeln ohne diese Laufzeitabbildung vollständig maßgeblich.

[MUST_NOT] Schreibende SubAgents dürfen nicht unkoordiniert parallel auf demselben Worktree arbeiten.

## PROJECT.md

[MUST] Jedes Repository muss im Root eine `PROJECT.md` mit der repositoryweiten Versionsbasis und gemeinsamen Leitplanken besitzen.

[MUST_IF] Wenn ein Repository mehrere eigenständige Teilsolutions enthält, muss jede Teilsolution in ihrem Solution-Root eine lokale `PROJECT.md` mit ausschließlich scopespezifischen Ergänzungen oder Präzisierungen besitzen.

[MUST] Innerhalb einer Teilsolution gelten die Root- und die lokale `PROJECT.md`. Nicht widersprochene Root-Regeln bleiben wirksam.

[MUST] `PROJECT.md` muss diese Struktur verwenden:

```md
# PROJECT.md
## Zweck
## Versionsbasis
## Fachliche Leitplanken
## Technische Leitplanken
```

[MUST_IF] Der Scope einer `PROJECT.md` mehrere eigenständige Teilsolutions enthält, muss sie zusätzlich den Abschnitt `## Teilsolutions` besitzen.

[MUST_IF] `## Teilsolutions` erforderlich ist, muss der Abschnitt alle Teilsolutions vollständig in dieser Struktur aufführen:

```md
| Teilsolution | Pfad | PROJECT.md | Zweck |
|---|---|---|---|
| <Name> | `<relativer-pfad>/` | `<relativer-pfad>/PROJECT.md` | <Scope> |
```

[MUST_IF] Eine Teilsolution hinzugefügt, entfernt, umbenannt oder verschoben wird oder sich Pfad beziehungsweise Scope ihrer `PROJECT.md` wesentlich ändert, muss das Verzeichnis mitgepflegt werden.

[MUST_NOT] Eine vorhandene Teilsolution mit lokaler `PROJECT.md` darf im Verzeichnis fehlen.

[MUST_IF] `PROJECT.md` muss mitgepflegt werden, wenn die Versionsbasis oder fachliche bzw. technische projektspezifische Leitplanken festgelegt, geändert, präzisiert oder dokumentiert werden.

[MUST_NOT_IF] `PROJECT.md` darf keine bereits in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder Rollenregeldateien definierten Standardvorgaben duplizieren.

[MUST_NOT_IF] Eine lokale `PROJECT.md` darf repositoryweite Regeln der Root-`PROJECT.md` duplizieren.

[SHOULD] `PROJECT.md` soll projektspezifische Leitplanken mit deontischer Aussagenlogik und klaren Regelmarkern formulieren.
