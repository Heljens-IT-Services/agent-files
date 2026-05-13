# AGENTS.md
Stand: 2026-05-13

## Zweck

Diese Datei definiert verbindliche Arbeitsregeln fuer AI-/Code-Agents in diesem Repository.

## Regelmarker

[MUST] Der Agent ist verpflichtet, die Regel zu befolgen.

[MUST_NOT] Der Agent darf die beschriebene Handlung nicht ausfuehren.

[ALLOW] Der Agent darf die Handlung ausfuehren, ist aber nicht dazu verpflichtet.

[ALLOW_IF] Der Agent darf die Handlung nur ausfuehren, wenn die genannte Bedingung erfuellt ist.

[SHOULD] Der Agent soll die Regel als Default- oder Praeferenzverhalten befolgen. Er darf davon abweichen, wenn der aktuelle Task einen konkreten fachlichen, technischen oder sicherheitsrelevanten Grund liefert.

[OPTIONAL] Der Agent ist ausdruecklich nicht verpflichtet, die Handlung auszufuehren.

[PRIORITY] Die Regel beschreibt einen Konflikt-, Auslegungs- oder Vorrangfall.

[MUST] Regelmarker sind Modalitaets-Annotationen. Die natuerliche Formulierung der Regel muss weiterhin vollstaendig, verstaendlich und operativ sein.

[MUST_NOT] Es duerfen keine weiteren Regelmarker eingefuehrt werden, solange einer der oben definierten Marker die beabsichtigte Modalitaet ausdrueckt.

## Pflichtlektuere

Agents lesen zu Beginn eines Tasks diese Dateien:

| Pfad | Zweck |
|---|---|
| `README.md` | Menschlicher Schnelleinstieg in Projekt, Setup und Kommandos. |
| `agent-files/agents/PROJECT.md` | Projektspezifischer Arbeitskontext, fachliche Leitplanken und Begriffe. |
| `agent-files/agents/DEVELOPER.md` | Technologieuebergreifende Entwicklungsregeln. |
| `agent-files/agents/DEVELOPER.*.md` | Passende technologie- oder kontextspezifische Entwicklerregeln. |

[MUST] Der Agent muss zu Beginn eines Tasks `README.md`, `agent-files/agents/PROJECT.md`, `agent-files/agents/DEVELOPER.md` und die fuer den Task passenden Dateien `agent-files/agents/DEVELOPER.*.md` lesen.

[ALLOW_IF] Der Agent darf Dateien unter `docs/` lesen, wenn ihr Inhalt fuer die konkrete Aufgabe erforderlich ist und die Datei im Repository vorhanden ist.

[OPTIONAL] Der Agent muss Dateien unter `docs/` nicht lesen, wenn der konkrete Task keinen Bezug zu diesen Dateien hat.

## Prioritaet von Anweisungen

[PRIORITY] Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung haben Vorrang vor User-Anweisungen und Repository-Regeln.

[PRIORITY] Direkte User-Anweisungen im aktuellen Task haben Vorrang vor Repository-internen Agent-Regeln, sofern sie keine Sicherheits-, Datenschutz- oder Plattformvorgaben verletzen.

[PRIORITY] Spezifische Regeln haben nur innerhalb ihres ausdruecklich beschriebenen Scopes Vorrang vor allgemeineren Regeln.

[PRIORITY] Bei widerspruechlichen Repository-Regeln gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. Passende `agent-files/agents/DEVELOPER.*.md`.
2. `agent-files/agents/DEVELOPER.md`.
3. `agent-files/AGENTS.md`.
4. `agent-files/agents/PROJECT.md`.
5. Bestehender Code-Stil und lokale Patterns.

[PRIORITY] Eine Erlaubnis hebt kein spezifisches Verbot auf, ausser die Erlaubnis ist ausdruecklich als Ausnahme von genau diesem Verbot formuliert.

[PRIORITY] Bei unklarer Erlaubnis gilt eine riskante, zustandsveraendernde, extern wirksame oder irreversible Handlung als nicht erlaubt.

[MUST] Wenn eine Regel unklar, widerspruechlich oder offensichtlich gefaehrlich ist, muss der Agent die Unklarheit benennen und eine sichere, eng begrenzte Alternative waehlen oder rueckfragen.

## Dokumentenpflege

[MUST_NOT] Der Agent darf `README.md`, `agent-files/agents/PROJECT.md`, `agent-files/agents/DEVELOPER.md` und `agent-files/agents/DEVELOPER.*.md` nicht automatisch mitpflegen.

[ALLOW_IF] Der Agent darf `README.md`, `agent-files/agents/PROJECT.md`, `agent-files/agents/DEVELOPER.md` und `agent-files/agents/DEVELOPER.*.md` anpassen, wenn der User die Anpassung ausdruecklich anordnet oder wenn die konkrete Aufgabe die Anpassung dieser Dateien zum Ziel hat.

[MUST] Wenn eine vorhandene Anweisung offensichtlich falsch, gefaehrlich oder irrefuehrend geworden ist, muss der Agent die Abweichung im Arbeitsabschluss kurz benennen.

[OPTIONAL] Der Agent muss Dateien unter `docs/` nicht als Pflichtdokumentation pflegen.

## README.md

[SHOULD] `README.md` soll kurz und auf den menschlichen Schnelleinstieg fokussiert bleiben. Abweichungen sind erlaubt, wenn der User ausdruecklich eine ausfuehrlichere README-Dokumentation verlangt.

[SHOULD] `README.md` soll Titel, Kurzbeschreibung, Voraussetzungen, Setup, Start, Build, Tests und eine knappe technische Orientierung enthalten. Abweichungen sind erlaubt, wenn ein Repository einzelne Punkte nicht benoetigt oder anders dokumentiert.

[MUST_NOT] `README.md` darf keine Agent-Regeln, keine Prozessdetails und keine ausfuehrliche Implementierungsdokumentation enthalten, wenn diese Inhalte in `agent-files/AGENTS.md`, `agent-files/agents/` oder `docs/` gehoeren.

## PROJECT.md

[SHOULD] `agent-files/agents/PROJECT.md` soll projektspezifischen Arbeitskontext, fachliche Leitplanken, stabile Begriffe, Abgrenzungen, projektspezifische Architekturgrenzen sowie Branching- und Arbeitskontext enthalten. Abweichungen sind erlaubt, wenn der Projektkontext diese Inhalte noch nicht liefert.

[MUST_NOT] `agent-files/agents/PROJECT.md` darf keine README-Dopplung, keine allgemeine Technikdokumentation, keine Issue-Informationen und keine ausufernden Strukturindizes enthalten.
