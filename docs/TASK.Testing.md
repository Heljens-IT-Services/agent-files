# TASK.Testing.md

Stand: 2026-07-22

## Zweck

Diese Datei definiert den Kontext fuer Aufgaben, deren primaeres Ergebnis ein belastbarer Test-, Build- oder Verifikationsstatus ist.

## Scope

| Als primaeren Task-Typ verwenden, wenn | Als sekundaeren Task-Typ verwenden, wenn |
|---|---|
| Bestehendes Verhalten ohne beabsichtigte Aenderung ausgefuehrt, getestet oder manuell verifiziert werden soll. | Ein anderer Task eine eigenstaendig angeforderte Verifikation enthaelt, die nicht bereits sein Workflow festlegt. |

## Erlaubte Aktionen

[ALLOW] Der Agent darf vorhandene Builds, Tests, Linter, Anwendungen und klar definierte manuelle Pruefschritte ausfuehren.

[ALLOW_IF] Der Agent darf fuer die Verifikation erforderliche Projekt- und Testkonfiguration lesen, wenn er sie nicht veraendert.

## Verbotene Aktionen

[MUST_NOT] Der Agent darf Produktivcode, Testcode oder Projektkonfiguration im Testing-Scope nicht aendern.

[MUST_NOT] Der Agent darf fehlgeschlagene Checks nicht relativieren, ausblenden oder eigenstaendig reparieren.

## Zusatzkontext

| Kontext | Laden, wenn |
|---|---|
| `README.md` | Test-, Build-, Start- oder Setup-Kommandos benoetigt werden. |

## Skill-Verweise

| Skill | Verwenden, wenn |
|---|---|
| [code_testen](https://heljens-it-services.github.io/agent-files/skills/code_testen.md) | Builds, Tests oder manuelle Pruefschritte ausgefuehrt und bewertet werden sollen. |
| [code_lesen](https://heljens-it-services.github.io/agent-files/skills/code_lesen.md) | Testeinstiege oder vorhandene Testabdeckung lokalisiert werden muessen. |

## Abschlussanforderungen

[MUST] Der Arbeitsabschluss muss jeden ausgefuehrten Check mit Ergebnis nennen.

[MUST] Nicht ausgefuehrte relevante Pruefungen und verbleibende Testluecken muessen sichtbar bleiben.
