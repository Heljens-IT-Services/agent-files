# AGENTS.md
Stand: 2026-07-22

## Zweck

Diese Datei definiert verbindliche Arbeitsregeln fuer AI-/Code-Agents.

## Definition Regelmarker

[MUST] Der Agent ist verpflichtet, die Regel zu befolgen.

[MUST_IF] Der Agent ist verpflichtet, die Regel zu befolgen, wenn die genannte Bedingung erfuellt ist.

[MUST_NOT] Der Agent darf die beschriebene Handlung nicht ausfuehren.

[MUST_NOT_IF] Der Agent darf die beschriebene Handlung nicht ausfuehren, wenn die genannte Bedingung erfuellt ist.

[ALLOW] Der Agent darf die Handlung ausfuehren, ist aber nicht dazu verpflichtet.

[ALLOW_IF] Der Agent darf die Handlung nur ausfuehren, wenn die genannte Bedingung erfuellt ist.

[SHOULD] Der Agent soll die Regel als Default- oder Praeferenzverhalten befolgen. Er darf davon abweichen, wenn der aktuelle Task einen konkreten fachlichen, technischen oder sicherheitsrelevanten Grund liefert.

[OPTIONAL] Der Agent ist ausdruecklich nicht verpflichtet, die Handlung auszufuehren.

[PRIORITY] Die Regel beschreibt einen Konflikt-, Auslegungs- oder Vorrangfall.

## Arbeiten mit Regelmarker

[MUST] Regelmarker sind Modalitaets-Annotationen. Die natuerliche Formulierung der Regel muss weiterhin vollstaendig, verstaendlich und operativ sein.

[MUST_NOT_IF] Der Agent darf keine weiteren Regelmarker einfuehren, solange einer der oben definierten Marker die beabsichtigte Modalitaet ausdrueckt.

## Pflichtlektuere

Agents verwenden zu Beginn eines Tasks diesen Regelkatalog. Verbindliche allgemeine Regeldateien muessen im aktuellen Kontext bekannt, vollstaendig und aktuell genug sein; kontextabhaengige oder technologiespezifische Dateien muessen im aktuellen Kontext bekannt, vollstaendig und aktuell genug sein, wenn ihr Scope fuer den aktuellen Task relevant ist.

| Pfad | Zweck |
|---|---|
| `README.md` | Menschlicher Schnelleinstieg in Projekt, Setup und Kommandos; bei Task-Relevanz zu beruecksichtigen. |
| `PROJECT.md` | Verbindliche projektspezifische Datei fuer Versionsbasis sowie fachliche und technische Leitplanken. |
| [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) | Verbindliche Arbeitsregeln, Pflichtlektuere, Regelmarker und Prioritaetslogik. |
| [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Lookup-Datei fuer Rollen und die Situationen, in denen ihre Regeldateien gelesen werden muessen. |
| [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) | Lookup-Datei fuer Skills und die Situationen, in denen ihre Regeldateien gelesen werden muessen. |
| [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md) | Lookup-Datei fuer Workflows und die Situationen, in denen ihre Regeldateien gelesen werden muessen. |

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen.

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass die Datei am Pfad `PROJECT.md` im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen.

[MUST_IF] Der Agent muss pruefen, ob `README.md` fuer den aktuellen Task relevant ist, und sie bei Bedarf lesen, verstehen und beruecksichtigen.

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md), [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) und [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug sind, und sie als Lookup-Dateien beruecksichtigen.

[ALLOW_IF] Wenn eine verbindliche Regeldatei in der laufenden Unterhaltung bereits gelesen wurde und kein Hinweis auf eine zwischenzeitliche Aenderung besteht, darf der Agent die vorhandene Kontextfassung wiederverwenden, statt sie erneut vollstaendig abzurufen.

[MUST_IF] Der Agent muss eine verbindliche Regeldatei erneut abrufen, wenn die vorhandene Kontextfassung fehlt, unvollstaendig, offensichtlich veraltet oder nicht eindeutig identifizierbar ist.

[MUST_IF] Der Agent muss die in den Lookup-Dateien verlinkten Rollen-, Skill- und Workflow-Dateien lesen und befolgen, wenn die dort beschriebene Situation fuer den aktuellen Task eintritt.

## Prioritaet von Anweisungen

### Globale Prioritaet

[PRIORITY] Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung haben Vorrang vor User-Anweisungen und Repository-Regeln.

[PRIORITY] Direkte User-Anweisungen im aktuellen Task haben Vorrang vor Repository-internen Agent-Regeln, sofern sie keine Sicherheits-, Datenschutz- oder Plattformvorgaben verletzen.

[PRIORITY] Spezifische Regeln haben nur innerhalb ihres ausdruecklich beschriebenen Scopes Vorrang vor allgemeineren Regeln.

[PRIORITY] Bei widerspruechlichen Repository-Regeln gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. `PROJECT.md`, sofern sie fuer den konkreten Scope einschlaegig ist.
2. Passende rollenbasierte Regeldateien gemaess der Prioritaetsreihenfolge ihrer Rolle.
3. [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).
4. Bestehender Code-Stil und lokale Patterns.

[PRIORITY] Eine Erlaubnis hebt kein spezifisches Verbot auf, ausser die Erlaubnis ist ausdruecklich als Ausnahme von genau diesem Verbot formuliert.

[PRIORITY] Bei unklarer Erlaubnis gilt eine riskante, zustandsveraendernde, extern wirksame oder irreversible Handlung als nicht erlaubt.

[MUST_IF] Der Agent muss die Unklarheit benennen und eine sichere, eng begrenzte Alternative waehlen oder rueckfragen, wenn eine Regel unklar, widerspruechlich oder offensichtlich gefaehrlich ist.

## Dokumentenpflege

[MUST_IF] Der Agent muss die Abweichung im Arbeitsabschluss kurz benennen, wenn eine vorhandene Anweisung offensichtlich falsch, gefaehrlich oder irrefuehrend geworden ist.

## README.md

[SHOULD] `README.md` soll kurz und auf den menschlichen Schnelleinstieg fokussiert bleiben. Abweichungen sind erlaubt, wenn der User ausdruecklich eine ausfuehrlichere README-Dokumentation verlangt.

[SHOULD] `README.md` soll Titel, Kurzbeschreibung, Voraussetzungen, Setup, Start, Build, Tests und eine knappe technische Orientierung enthalten. Abweichungen sind erlaubt, wenn ein Repository einzelne Punkte nicht benoetigt oder anders dokumentiert.

[ALLOW_IF] Der Agent darf `README.md` nur mitpflegen, wenn ausdruecklich verlangt.

[MUST_NOT_IF] `README.md` darf keine Agent-Regeln, keine Prozessdetails und keine ausfuehrliche Implementierungsdokumentation enthalten, wenn diese Inhalte in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder anderen veroeffentlichten Markdown-Dateien unter [agent-files/*.md](https://heljens-it-services.github.io/agent-files/) gehoeren.

## PROJECT.md

[MUST] `PROJECT.md` muss vorhanden sein und mindestens die Versionsbasis des konkreten Projekts enthalten.

[MUST] `PROJECT.md` muss diese Struktur verwenden:

```md
# PROJECT.md
## Zweck
## Versionsbasis
## Fachliche Leitplanken
## Technische Leitplanken
```

[MUST_IF] `PROJECT.md` muss mitgepflegt werden, wenn die Versionsbasis oder fachliche bzw. technische projektspezifische Leitplanken festgelegt, geaendert, praezisiert oder dokumentiert werden.

[MUST_NOT_IF] `PROJECT.md` darf allgemeine oder rollenbasierte Standardvorgaben nicht duplizieren, wenn diese bereits in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder passenden Rollenregeldateien definiert sind.

[SHOULD] `PROJECT.md` soll projektspezifische fachliche und technische Leitplanken mit deontischer Aussagenlogik und klaren Regelmarkern formulieren, damit Agents repositoryspezifische Vorgaben lesen, verstehen und befolgen koennen.
