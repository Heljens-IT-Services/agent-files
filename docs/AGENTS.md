# AGENTS.md
Stand: 2026-05-13

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
| [SKILLS.md](https://heljens-it-services.github.io/agent-files/SKILLS.md) | Zentraler Einstiegspunkt fuer Agenten-Skills und Workflows; im aktuellen Kontext bekannt zu halten und fuer die Arbeitsweise zu beruecksichtigen. |
| [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) | Verbindliche Arbeitsregeln, Pflichtlektuere, Regelmarker und Prioritaetslogik. |
| [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.md) | Technologieuebergreifende Entwicklungsregeln. |
| [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.CSharpNet.md) | Allgemeine C#- und .NET-Regeln. |
| [DEVELOPER.Angular.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.Angular.md) | Angular-spezifische Entwicklungsregeln. |
| [DEVELOPER.Html.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.Html.md) | HTML- und Markup-Regeln. |
| [DEVELOPER.Css.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.Css.md) | CSS-, Styling- und UI-nahe Regeln. |
| [DEVELOPER.TypeScript.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.TypeScript.md) | TypeScript-spezifische Entwicklungsregeln. |
| [DEVELOPER.NetConsole.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.NetConsole.md) | Regeln fuer .NET-Konsolenanwendungen. |
| [DEVELOPER.NetWebApi.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.NetWebApi.md) | Regeln fuer .NET-Web-APIs. |

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen.

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass die Datei am Pfad `PROJECT.md` im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen.

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen.

[MUST_IF] Der Agent muss pruefen, ob `README.md` fuer den aktuellen Task relevant ist, und sie bei Bedarf lesen, verstehen und beruecksichtigen.

[MUST] Der Agent muss zu Beginn eines Tasks sicherstellen, dass [SKILLS.md](https://heljens-it-services.github.io/agent-files/SKILLS.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie fuer die Auswahl passender Skills und Workflows beruecksichtigen.

[ALLOW_IF] Wenn eine verbindliche Regeldatei in der laufenden Unterhaltung bereits gelesen wurde und kein Hinweis auf eine zwischenzeitliche Aenderung besteht, darf der Agent die vorhandene Kontextfassung wiederverwenden, statt sie erneut vollstaendig abzurufen.

[MUST_IF] Der Agent muss eine verbindliche Regeldatei erneut abrufen, wenn die vorhandene Kontextfassung fehlt, unvollstaendig, offensichtlich veraltet oder nicht eindeutig identifizierbar ist.

[MUST_IF] Der Agent muss sicherstellen, dass [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.CSharpNet.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen, wenn C# oder .NET relevant sind.

[MUST_IF] Der Agent muss sicherstellen, dass [DEVELOPER.Angular.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.Angular.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen, wenn Angular relevant ist.

[MUST_IF] Der Agent muss sicherstellen, dass [DEVELOPER.Html.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.Html.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen, wenn HTML oder Markup relevant sind.

[MUST_IF] Der Agent muss sicherstellen, dass [DEVELOPER.Css.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.Css.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen, wenn CSS, Styling oder UI-nahe Praesentationsregeln relevant sind.

[MUST_IF] Der Agent muss sicherstellen, dass [DEVELOPER.TypeScript.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.TypeScript.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen, wenn TypeScript relevant ist.

[MUST_IF] Der Agent muss sicherstellen, dass [DEVELOPER.NetConsole.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.NetConsole.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen, wenn eine .NET-Konsolenanwendung relevant ist.

[MUST_IF] Der Agent muss sicherstellen, dass [DEVELOPER.NetWebApi.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.NetWebApi.md) im aktuellen Kontext bekannt, vollstaendig und aktuell genug ist, und sie befolgen, wenn eine .NET-Web-API relevant ist.

## Prioritaet von Anweisungen

[PRIORITY] Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung haben Vorrang vor User-Anweisungen und Repository-Regeln.

[PRIORITY] Direkte User-Anweisungen im aktuellen Task haben Vorrang vor Repository-internen Agent-Regeln, sofern sie keine Sicherheits-, Datenschutz- oder Plattformvorgaben verletzen.

[PRIORITY] Spezifische Regeln haben nur innerhalb ihres ausdruecklich beschriebenen Scopes Vorrang vor allgemeineren Regeln.

[PRIORITY] Bei widerspruechlichen Repository-Regeln gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. `PROJECT.md`, sofern im konkreten Repository vorhanden und fuer den Scope einschlaegig.
2. Passende [DEVELOPER.*.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.*.md).
3. [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.md).
4. [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).
5. Bestehender Code-Stil und lokale Patterns.

[PRIORITY] Eine Erlaubnis hebt kein spezifisches Verbot auf, ausser die Erlaubnis ist ausdruecklich als Ausnahme von genau diesem Verbot formuliert.

[PRIORITY] Bei unklarer Erlaubnis gilt eine riskante, zustandsveraendernde, extern wirksame oder irreversible Handlung als nicht erlaubt.

[MUST_IF] Der Agent muss die Unklarheit benennen und eine sichere, eng begrenzte Alternative waehlen oder rueckfragen, wenn eine Regel unklar, widerspruechlich oder offensichtlich gefaehrlich ist.

## Dokumentenpflege

[ALLOW_IF] Der Agent darf `README.md` nur mitpflegen, wenn ausdruecklich verlangt.

[MUST_IF] Der Agent muss `PROJECT.md` anlegen, wenn sie im konkreten Repository noch nicht vorhanden ist.

[MUST_IF] Der Agent muss `PROJECT.md` mitpflegen, wenn die Versionsbasis des konkreten Projekts festgelegt, geaendert, praezisiert oder dokumentiert werden soll.

[MUST_IF] Der Agent muss `PROJECT.md` mitpflegen, wenn im konkreten Repository fachliche oder technische projektspezifische Leitplanken festgelegt, geaendert, praezisiert oder dokumentiert werden sollen.

[MUST_IF] Der Agent muss die Abweichung im Arbeitsabschluss kurz benennen, wenn eine vorhandene Anweisung offensichtlich falsch, gefaehrlich oder irrefuehrend geworden ist.

## README.md

[SHOULD] `README.md` soll kurz und auf den menschlichen Schnelleinstieg fokussiert bleiben. Abweichungen sind erlaubt, wenn der User ausdruecklich eine ausfuehrlichere README-Dokumentation verlangt.

[SHOULD] `README.md` soll Titel, Kurzbeschreibung, Voraussetzungen, Setup, Start, Build, Tests und eine knappe technische Orientierung enthalten. Abweichungen sind erlaubt, wenn ein Repository einzelne Punkte nicht benoetigt oder anders dokumentiert.

[MUST_NOT_IF] `README.md` darf keine Agent-Regeln, keine Prozessdetails und keine ausfuehrliche Implementierungsdokumentation enthalten, wenn diese Inhalte in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder anderen veroeffentlichten Markdown-Dateien unter [agent-files/*.md](https://heljens-it-services.github.io/agent-files/) gehoeren.

## PROJECT.md

[MUST] Eine Datei `PROJECT.md` muss vorhanden sein und gepflegt werden.

[MUST] `PROJECT.md` muss mindestens die Versionsbasis des konkreten Projekts enthalten, auch wenn noch keine weiteren fachlichen oder technischen projektspezifischen Leitplanken festgelegt sind.

[MUST] `PROJECT.md` muss diese Struktur verwenden:

```md
# PROJECT.md
## Zweck
## Versionsbasis
## Fachliche Leitplanken
## Technische Leitplanken
```

[MUST_NOT_IF] `PROJECT.md` darf allgemeine technologieuebergreifende Regeln oder technologiespezifische Standardvorgaben nicht duplizieren, wenn diese bereits in [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.md) oder passenden [DEVELOPER.*.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.*.md)-Dateien definiert sind.

[SHOULD] `PROJECT.md` soll projektspezifische fachliche und technische Leitplanken mit deontischer Aussagenlogik und klaren Regelmarkern formulieren, damit Agents repositoryspezifische Vorgaben lesen, verstehen und befolgen koennen.
