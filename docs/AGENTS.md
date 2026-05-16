# AGENTS.md
Stand: 2026-05-13

## Zweck

Diese Datei definiert verbindliche Arbeitsregeln fuer AI-/Code-Agents in diesem Repository.

## Definition Regelmarker

[MUST] Der Agent ist verpflichtet, die Regel zu befolgen.

[MUST_IF] Der Agent ist verpflichtet, die Regel zu befolgen, wenn die genannte Bedingung erfuellt ist.

[MUST_NOT] Der Agent darf die beschriebene Handlung nicht ausfuehren.

[ALLOW] Der Agent darf die Handlung ausfuehren, ist aber nicht dazu verpflichtet.

[ALLOW_IF] Der Agent darf die Handlung nur ausfuehren, wenn die genannte Bedingung erfuellt ist.

[SHOULD] Der Agent soll die Regel als Default- oder Praeferenzverhalten befolgen. Er darf davon abweichen, wenn der aktuelle Task einen konkreten fachlichen, technischen oder sicherheitsrelevanten Grund liefert.

[OPTIONAL] Der Agent ist ausdruecklich nicht verpflichtet, die Handlung auszufuehren.

[PRIORITY] Die Regel beschreibt einen Konflikt-, Auslegungs- oder Vorrangfall.

## Arbeiten mit Regelmarker

[MUST] Regelmarker sind Modalitaets-Annotationen. Die natuerliche Formulierung der Regel muss weiterhin vollstaendig, verstaendlich und operativ sein.

[MUST_NOT] Der Agent darf keine weiteren Regelmarker einfuehren, solange einer der oben definierten Marker die beabsichtigte Modalitaet ausdrueckt.

## Pflichtlektuere

Agents lesen zu Beginn eines Tasks diese Dateien:

| Pfad | Zweck |
|---|---|
| `README.md` | Menschlicher Schnelleinstieg in Projekt, Setup und Kommandos. |
| `https://heljens-it-services.github.io/agent-files/AGENTS.md` | Verbindliche Arbeitsregeln, Pflichtlektuere, Regelmarker und Prioritaetslogik. |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.md` | Technologieuebergreifende Entwicklungsregeln. |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.CSharpNet.md` | Allgemeine C#- und .NET-Regeln. |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.Angular.md` | Angular-spezifische Entwicklungsregeln. |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.Html.md` | HTML- und Markup-Regeln. |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.Css.md` | CSS-, Styling- und UI-nahe Regeln. |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.TypeScript.md` | TypeScript-spezifische Entwicklungsregeln. |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.NetConsole.md` | Regeln fuer .NET-Konsolenanwendungen. |
| `https://heljens-it-services.github.io/agent-files/DEVELOPER.NetWebApi.md` | Regeln fuer .NET-Web-APIs. |

[MUST] Der Agent muss zu Beginn eines Tasks `README.md` lesen, verstehen und befolgen.

[MUST] Der Agent muss zu Beginn eines Tasks `https://heljens-it-services.github.io/agent-files/AGENTS.md` lesen, verstehen und befolgen.

[MUST] Der Agent muss zu Beginn eines Tasks `https://heljens-it-services.github.io/agent-files/DEVELOPER.md` lesen, verstehen und befolgen.

[MUST_IF] Die Datei am Pfad `https://heljens-it-services.github.io/agent-files/DEVELOPER.CSharpNet.md` muss zu Beginn eines Tasks gelesen, verstanden und befolgt werden, wenn C# oder .NET fuer das Repository relevant sind.

[MUST_IF] Die Datei am Pfad `https://heljens-it-services.github.io/agent-files/DEVELOPER.Angular.md` muss zu Beginn eines Tasks gelesen, verstanden und befolgt werden, wenn Angular fuer das Repository relevant ist.

[MUST_IF] Die Datei am Pfad `https://heljens-it-services.github.io/agent-files/DEVELOPER.Html.md` muss zu Beginn eines Tasks gelesen, verstanden und befolgt werden, wenn HTML oder Markup fuer das Repository relevant sind.

[MUST_IF] Die Datei am Pfad `https://heljens-it-services.github.io/agent-files/DEVELOPER.Css.md` muss zu Beginn eines Tasks gelesen, verstanden und befolgt werden, wenn CSS, Styling oder UI-nahe Praesentationsregeln fuer das Repository relevant sind.

[MUST_IF] Die Datei am Pfad `https://heljens-it-services.github.io/agent-files/DEVELOPER.TypeScript.md` muss zu Beginn eines Tasks gelesen, verstanden und befolgt werden, wenn TypeScript fuer das Repository relevant ist.

[MUST_IF] Die Datei am Pfad `https://heljens-it-services.github.io/agent-files/DEVELOPER.NetConsole.md` muss zu Beginn eines Tasks gelesen, verstanden und befolgt werden, wenn eine .NET-Konsolenanwendung fuer das Repository relevant ist.

[MUST_IF] Die Datei am Pfad `https://heljens-it-services.github.io/agent-files/DEVELOPER.NetWebApi.md` muss zu Beginn eines Tasks gelesen, verstanden und befolgt werden, wenn eine .NET-Web-API fuer das Repository relevant ist.

[ALLOW_IF] Der Agent darf Dateien unter `docs/` lesen, wenn ihr Inhalt fuer die konkrete Aufgabe erforderlich ist und die Datei im Repository vorhanden ist.

[OPTIONAL] Der Agent muss Dateien unter `docs/` nicht lesen, wenn der konkrete Task keinen Bezug zu diesen Dateien hat.

## Prioritaet von Anweisungen

[PRIORITY] Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung haben Vorrang vor User-Anweisungen und Repository-Regeln.

[PRIORITY] Direkte User-Anweisungen im aktuellen Task haben Vorrang vor Repository-internen Agent-Regeln, sofern sie keine Sicherheits-, Datenschutz- oder Plattformvorgaben verletzen.

[PRIORITY] Spezifische Regeln haben nur innerhalb ihres ausdruecklich beschriebenen Scopes Vorrang vor allgemeineren Regeln.

[PRIORITY] Bei widerspruechlichen Repository-Regeln gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. Passende `https://heljens-it-services.github.io/agent-files/DEVELOPER.*.md`.
2. `https://heljens-it-services.github.io/agent-files/DEVELOPER.md`.
3. `https://heljens-it-services.github.io/agent-files/AGENTS.md`.
4. Bestehender Code-Stil und lokale Patterns.

[PRIORITY] Eine Erlaubnis hebt kein spezifisches Verbot auf, ausser die Erlaubnis ist ausdruecklich als Ausnahme von genau diesem Verbot formuliert.

[PRIORITY] Bei unklarer Erlaubnis gilt eine riskante, zustandsveraendernde, extern wirksame oder irreversible Handlung als nicht erlaubt.

[MUST_IF] Der Agent muss die Unklarheit benennen und eine sichere, eng begrenzte Alternative waehlen oder rueckfragen, wenn eine Regel unklar, widerspruechlich oder offensichtlich gefaehrlich ist.

## Dokumentenpflege

[MUST_NOT] Der Agent darf `README.md`, `https://heljens-it-services.github.io/agent-files/DEVELOPER.md` und `https://heljens-it-services.github.io/agent-files/DEVELOPER.*.md` nicht automatisch mitpflegen.

[ALLOW_IF] Der Agent darf `README.md`, `https://heljens-it-services.github.io/agent-files/DEVELOPER.md` und `https://heljens-it-services.github.io/agent-files/DEVELOPER.*.md` anpassen, wenn der User die Anpassung ausdruecklich anordnet oder wenn die konkrete Aufgabe die Anpassung dieser Dateien zum Ziel hat.

[MUST_IF] Der Agent muss die Abweichung im Arbeitsabschluss kurz benennen, wenn eine vorhandene Anweisung offensichtlich falsch, gefaehrlich oder irrefuehrend geworden ist.

[OPTIONAL] Der Agent muss Dateien unter `docs/` nicht als Pflichtdokumentation pflegen.

## README.md

[SHOULD] `README.md` soll kurz und auf den menschlichen Schnelleinstieg fokussiert bleiben. Abweichungen sind erlaubt, wenn der User ausdruecklich eine ausfuehrlichere README-Dokumentation verlangt.

[SHOULD] `README.md` soll Titel, Kurzbeschreibung, Voraussetzungen, Setup, Start, Build, Tests und eine knappe technische Orientierung enthalten. Abweichungen sind erlaubt, wenn ein Repository einzelne Punkte nicht benoetigt oder anders dokumentiert.

[MUST_NOT] `README.md` darf keine Agent-Regeln, keine Prozessdetails und keine ausfuehrliche Implementierungsdokumentation enthalten, wenn diese Inhalte in `https://heljens-it-services.github.io/agent-files/AGENTS.md` oder anderen veroeffentlichten Markdown-Dateien unter `https://heljens-it-services.github.io/agent-files/*.md` gehoeren.

