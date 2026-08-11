# AGENTS.md
Stand: 2026-08-11

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
| `PROJECT.md` | Pflicht | Projektspezifische Versionsbasis und Leitplanken. |
| [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) | Pflicht | Lookup für kontextabhängige Rollenregeln. |
| [SKILLS.md](https://heljens-it-services.github.io/agent-files/skills/SKILLS.md) | Pflicht | Lookup für atomare Skills. |
| [WORKFLOWS.md](https://heljens-it-services.github.io/agent-files/workflows/WORKFLOWS.md) | Pflicht | Lookup für zusammengesetzte Workflows. |
| [COMMANDS.md](https://heljens-it-services.github.io/agent-files/COMMANDS.md) | Bei Slash-Commands | Grammatik, Auflösung und Fehlerbehandlung für Slash-Commands. |
| [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) | Bei Technologie-Commands | IDs für technologiespezifische Developer-Regeln. |
| `README.md` | Bei Relevanz | Menschlicher Schnelleinstieg in Projekt, Setup und Kommandos. |

[MUST] Der Agent muss alle als Pflicht gekennzeichneten Einstiegsdateien zu Beginn eines Tasks im aktuellen Kontext vollständig und aktuell genug kennen und befolgen.

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

1. `PROJECT.md`, sofern sie für den konkreten Scope einschlägig ist.
2. Passende rollenbasierte Regeldateien gemäß der Prioritätsreihenfolge ihrer Rolle.
3. [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).
4. Bestehender Code-Stil und lokale Patterns.

[PRIORITY] Eine Erlaubnis hebt kein spezifisches Verbot auf, außer die Erlaubnis ist ausdrücklich als Ausnahme von genau diesem Verbot formuliert.

[PRIORITY] Bei unklarer Erlaubnis gilt eine riskante, zustandsverändernde, extern wirksame oder irreversible Handlung als nicht erlaubt.

[MUST_IF] Der Agent muss die Unklarheit benennen und eine sichere, eng begrenzte Alternative wählen oder rückfragen, wenn eine Regel unklar, widersprüchlich oder offensichtlich gefährlich ist.

[MUST_IF] Der Agent muss die Abweichung im Arbeitsabschluss kurz benennen, wenn eine vorhandene Anweisung offensichtlich falsch, gefährlich oder irreführend geworden ist.

## README.md

[SHOULD] `README.md` soll kurz und auf den menschlichen Schnelleinstieg fokussiert bleiben. Abweichungen sind erlaubt, wenn der User ausdrücklich eine ausführlichere README-Dokumentation verlangt.

[SHOULD] `README.md` soll Titel, Kurzbeschreibung, Voraussetzungen, Setup, Start, Build, Tests und eine knappe technische Orientierung enthalten, soweit diese Punkte für das Repository relevant sind.

[ALLOW_IF] Der Agent darf `README.md` nur mitpflegen, wenn ausdrücklich verlangt.

[MUST_NOT_IF] `README.md` darf keine Inhalte duplizieren, die in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder andere veröffentlichte Agent Files gehören.

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

[MUST_IF] `PROJECT.md` muss mitgepflegt werden, wenn die Versionsbasis oder fachliche bzw. technische projektspezifische Leitplanken festgelegt, geändert, präzisiert oder dokumentiert werden.

[MUST_NOT_IF] `PROJECT.md` darf keine bereits in [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md) oder Rollenregeldateien definierten Standardvorgaben duplizieren.

[SHOULD] `PROJECT.md` soll projektspezifische Leitplanken mit deontischer Aussagenlogik und klaren Regelmarkern formulieren.
