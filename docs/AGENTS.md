# AGENTS.md
Stand: 2026-08-11

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
| [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Pflicht | Lookup fuer kontextabhaengige Rollenregeln. |
| [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) | Pflicht | Lookup fuer atomare Skills. |
| [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md) | Pflicht | Lookup fuer zusammengesetzte Workflows. |
| [COMMANDS.md](https://heljens-it-services.github.io/agent-files/COMMANDS.md) | Bei Slash-Commands | Grammatik, Aufloesung und Fehlerbehandlung fuer Slash-Commands. |
| [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) | Bei Technologie-Commands | IDs fuer technologiespezifische Developer-Regeln. |
| `README.md` | Bei Relevanz | Menschlicher Schnelleinstieg in Projekt, Setup und Kommandos. |

[MUST] Der Agent muss alle als Pflicht gekennzeichneten Einstiegsdateien zu Beginn eines Tasks im aktuellen Kontext vollstaendig und aktuell genug kennen und befolgen.

[MUST_IF] Wenn die in der Spalte `Geltung` genannte Bedingung eintritt, muss der Agent die betreffende Einstiegsdatei im aktuellen Kontext vollstaendig und aktuell genug kennen und befolgen.

[ALLOW_IF] Bereits gelesene verbindliche Regeldateien duerfen wiederverwendet werden, wenn kein Hinweis auf eine zwischenzeitliche Aenderung besteht.

[MUST_IF] Der Agent muss eine verbindliche Regeldatei erneut abrufen, wenn die vorhandene Kontextfassung fehlt, unvollstaendig, offensichtlich veraltet oder nicht eindeutig identifizierbar ist.

[MUST_IF] Wenn eine in den Lookup-Dateien beschriebene Situation fuer den aktuellen Task eintritt, muss der Agent die dort verlinkte Detaildatei lesen und befolgen.

Als optionale Regeldateien gelten Einstiegsdateien mit bedingter Geltung sowie ueber Lookup ausgewaehlte Detaildateien.

[MUST_IF] Wenn der Agent eine optionale Regeldatei einliest oder erneut abruft, muss er dem User unmittelbar kurz den Dokumenttitel mitteilen.

[ALLOW_IF] Mehrere gleichzeitig eingelesene optionale Regeldateien duerfen in einer Rueckmeldung zusammengefasst werden, wenn jeder Dokumenttitel genannt wird.

## Dokumentierte Kommandos

[MUST] Der Agent muss dokumentierte Kommandos vor der Ausfuehrung gegen den aktuellen Kontext pruefen und Platzhalter durch konkrete Werte ersetzen.

[MUST_NOT_IF] Dokumentierte Kommandos duerfen bei unaufgeloesten Platzhaltern, ungeprueften destruktiven Zielen oder einer Zustandsaenderung ausserhalb des autorisierten Task-Scopes nicht ausgefuehrt werden.

## Sprache

[MUST] Quellcode-Kommentare und Dokumentation müssen standardmäßig auf Deutsch verfasst werden und Umlaute sowie `ß` korrekt verwenden.

[ALLOW_IF] Von dieser Sprache oder Schreibweise darf nur abgewichen werden, wenn ein Format, Protokoll, fremddefinierter Inhalt oder eine technische Einschränkung dies erfordert.

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

[MUST_IF] Der Agent muss die Abweichung im Arbeitsabschluss kurz benennen, wenn eine vorhandene Anweisung offensichtlich falsch, gefaehrlich oder irrefuehrend geworden ist.

## README.md

[SHOULD] `README.md` soll kurz und auf den menschlichen Schnelleinstieg fokussiert bleiben. Abweichungen sind erlaubt, wenn der User ausdruecklich eine ausfuehrlichere README-Dokumentation verlangt.

[SHOULD] `README.md` soll Titel, Kurzbeschreibung, Voraussetzungen, Setup, Start, Build, Tests und eine knappe technische Orientierung enthalten, soweit diese Punkte fuer das Repository relevant sind.

[ALLOW_IF] Der Agent darf `README.md` nur mitpflegen, wenn ausdruecklich verlangt.

[MUST_NOT_IF] `README.md` darf keine Inhalte duplizieren, die in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder andere veroeffentlichte Agent Files gehoeren.

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

[MUST_NOT_IF] `PROJECT.md` darf keine bereits in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder Rollenregeldateien definierten Standardvorgaben duplizieren.

[SHOULD] `PROJECT.md` soll projektspezifische Leitplanken mit deontischer Aussagenlogik und klaren Regelmarkern formulieren.
