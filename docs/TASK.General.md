# TASK.General.md

Stand: 2026-07-22

## Zweck

Diese Datei definiert den Kontext fuer allgemeine Aufgaben ohne primaeren Coding-, Testing-, GitHub- oder Issue-Schwerpunkt.

## Scope

| Als primaeren Task-Typ verwenden, wenn | Als sekundaeren Task-Typ verwenden, wenn |
|---|---|
| Erklaerung, Anforderungsklaerung, Brainstorming, Research oder Dokumentationspflege das primaere Ergebnis ist. | Ein anderer Task einen klar abgegrenzten allgemeinen Teil wie Research oder Anforderungsklaerung enthaelt. |

## Erlaubte Aktionen

[ALLOW] Der Agent darf vorhandenen autorisierten Kontext lesen, auswerten und als Antwort oder Dokumentation aufbereiten.

[ALLOW_IF] Der Agent darf Dokumentationsdateien aendern, wenn Dokumentationspflege ausdruecklich oder als notwendiges Ergebnis verlangt ist.

## Verbotene Aktionen

[MUST_NOT] Der Agent darf im General-Scope keinen Produktiv- oder Testcode aendern.

[MUST_NOT] Der Agent darf keine externe Zustandsaenderung ausfuehren, die nicht ausdruecklich verlangt und durch einen passenden Task-Typ abgedeckt ist.

## Zusatzkontext

| Kontext | Laden, wenn |
|---|---|
| `README.md` | Projektzweck, Nutzung, Setup oder menschliche Dokumentation relevant sind. |

## Skill-Verweise

| Skill | Verwenden, wenn |
|---|---|
| [anforderungsklaerung](https://heljens-it-services.github.io/agent-files/skills/anforderungsklaerung.md) | Ziel, Scope oder Akzeptanzkriterien unklar sind. |
| [brainstorming](https://heljens-it-services.github.io/agent-files/skills/brainstorming.md) | Optionen interaktiv entwickelt und abgewogen werden sollen. |
| [research](https://heljens-it-services.github.io/agent-files/skills/research.md) | Web-, Repository- oder sonstiger Quellenkontext recherchiert werden soll. |
| [dokumentation](https://heljens-it-services.github.io/agent-files/skills/dokumentation.md) | Dokumentation erstellt, aktualisiert oder umstrukturiert werden soll. |

## Abschlussanforderungen

[MUST] Der Arbeitsabschluss muss das Ergebnis, wesentliche Annahmen und offene Kontextluecken nennen, soweit sie fuer die weitere Nutzung relevant sind.

[MUST_IF] Der Agent muss Quellen oder geaenderte Dokumentationsdateien nennen, wenn sie das Ergebnis tragen.
