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

Zu Beginn eines Tasks gelten diese Einstiegsdateien:

| Pfad | Geltung | Zweck |
|---|---|---|
| [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) | Pflicht | Allgemeine Arbeitsregeln, Regelmarker und Prioritaetslogik. |
| `PROJECT.md` | Pflicht | Projektspezifische Versionsbasis und Leitplanken. |
| `README.md` | Bei Relevanz | Menschlicher Schnelleinstieg in Projekt, Setup und Kommandos. |

[MUST] Der Agent muss alle als Pflicht gekennzeichneten Einstiegsdateien zu Beginn eines Tasks im aktuellen Kontext vollstaendig und aktuell genug kennen und befolgen.

[MUST_IF] Der Agent muss `README.md` lesen und beruecksichtigen, wenn ihr Inhalt fuer den aktuellen Task relevant ist.

[ALLOW_IF] Wenn eine verbindliche Regeldatei in der laufenden Unterhaltung bereits gelesen wurde und kein Hinweis auf eine zwischenzeitliche Aenderung besteht, darf der Agent die vorhandene Kontextfassung wiederverwenden, statt sie erneut vollstaendig abzurufen.

[MUST_IF] Der Agent muss eine verbindliche Regeldatei erneut abrufen, wenn die vorhandene Kontextfassung fehlt, unvollstaendig, offensichtlich veraltet oder nicht eindeutig identifizierbar ist.

## Task-Typ-basierte Kontextsteuerung

[MUST] Der Agent muss vor der eigenstaendigen Task-Ausfuehrung genau einen primaeren Task-Typ anhand des beabsichtigten Hauptergebnisses bestimmen und die zugehoerige Task-Datei lesen und befolgen.

| Task-Typ | Task-Datei | Als primaeren Typ verwenden, wenn |
|---|---|---|
| `Coding` | [TASK.Coding.md](https://heljens-it-services.github.io/agent-files/TASK.Coding.md) | Codeaenderung, technischer Plan oder technische Codebewertung das Hauptergebnis ist. |
| `Testing` | [TASK.Testing.md](https://heljens-it-services.github.io/agent-files/TASK.Testing.md) | Test-, Build- oder Verifikationsstatus ohne beabsichtigte Aenderung das Hauptergebnis ist. |
| `GitHub` | [TASK.GitHub.md](https://heljens-it-services.github.io/agent-files/TASK.GitHub.md) | Branch-, Commit-, Push- oder Pull-Request-Aktion das Hauptergebnis ist. |
| `Issue` | [TASK.Issue.md](https://heljens-it-services.github.io/agent-files/TASK.Issue.md) | GitHub-Issue-Arbeit oder issue-getriebene Umsetzung das Hauptergebnis ist. |
| `General` | [TASK.General.md](https://heljens-it-services.github.io/agent-files/TASK.General.md) | Erklaerung, Klaerung, Brainstorming, Research oder Dokumentation das Hauptergebnis ist. |

[MUST] Der Agent muss den primaeren Task-Typ nach dem Hauptergebnis und nicht allein nach verwendeten Tools, erwaehnten Technologien oder einzelnen Arbeitsschritten waehlen.

[ALLOW_IF] Der Agent darf genau einen sekundaeren Task-Typ bestimmen, wenn der Task ein eindeutig abgrenzbares zweites Ergebnis erfordert, das der primaere Task-Typ nicht abdeckt.

[MUST_IF] Der Agent muss die zustaendigen Teil-Scope-Grenzen im Arbeitskontext festhalten und auch die sekundaere Task-Datei lesen und befolgen, wenn er einen sekundaeren Task-Typ verwendet.

[MUST_NOT] Der Agent darf keinen sekundaeren Task-Typ allein deshalb waehlen, weil ein passender Skill oder Workflow Arbeitsschritte aus einem anderen Task-Typ enthaelt.

[MUST_NOT] Der Agent darf nicht mehr als einen sekundaeren Task-Typ verwenden.

[MUST_IF] Wenn eine in einer geladenen Task- oder Lookup-Datei beschriebene Situation eintritt, muss der Agent den dort verlinkten Zusatzkontext lesen und befolgen.

## Dokumentierte Kommandos

[MUST] Der Agent muss dokumentierte Kommandos vor der Ausfuehrung gegen den aktuellen Kontext pruefen und Platzhalter wie Branch-Namen, Pfade oder Remote-Namen passend ersetzen.

[MUST_NOT_IF] Der Agent darf dokumentierte Kommandos nicht ausfuehren, wenn Platzhalter unaufgeloest sind, ein destruktives Ziel nicht eindeutig geprueft ist oder die Zustandsaenderung den autorisierten Task-Scope ueberschreitet.

## Prioritaet von Anweisungen

### Globale Prioritaet

[PRIORITY] Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung haben Vorrang vor User-Anweisungen und Repository-Regeln.

[PRIORITY] Direkte User-Anweisungen im aktuellen Task haben Vorrang vor Repository-internen Agent-Regeln, sofern sie keine Sicherheits-, Datenschutz- oder Plattformvorgaben verletzen.

[PRIORITY] Spezifische Regeln haben nur innerhalb ihres ausdruecklich beschriebenen Scopes Vorrang vor allgemeineren Regeln.

[PRIORITY] Bei widerspruechlichen Repository-Regeln gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. `PROJECT.md`, sofern sie fuer den konkreten Scope einschlaegig ist.
2. Primaere Task-Datei.
3. Sekundaere Task-Datei innerhalb ihres ausdruecklich abgegrenzten Teil-Scopes.
4. Passende rollen- und technologiebasierte Regeldateien gemaess der Prioritaetsreihenfolge ihrer Rolle.
5. Passende Skill-Datei innerhalb ihrer atomaren Handlung.
6. Passende Workflow-Datei fuer Reihenfolge und Rueckspruenge des Gesamtablaufs.
7. [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).
8. Bestehender Code-Stil und lokale Patterns.

[PRIORITY] Eine Erlaubnis hebt kein spezifisches Verbot auf, ausser die Erlaubnis ist ausdruecklich als Ausnahme von genau diesem Verbot formuliert.

[PRIORITY] Bei unklarer Erlaubnis gilt eine riskante, zustandsveraendernde, extern wirksame oder irreversible Handlung als nicht erlaubt.

[MUST_IF] Der Agent muss die Unklarheit benennen und eine sichere, eng begrenzte Alternative waehlen oder rueckfragen, wenn eine Regel unklar, widerspruechlich oder offensichtlich gefaehrlich ist.

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
