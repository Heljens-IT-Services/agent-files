# AGENTS.md
Stand: 2026-05-07

## Zweck

Diese Datei definiert die verbindlichen Arbeitsregeln fuer AI-/Code-Agents in diesem Repository.

## Pflichtlektuere

Agents lesen zu Beginn eines Tasks diese Dateien:

| Pfad | Zweck |
|---|---|
| `README.md` | Menschlicher Schnelleinstieg in Projekt, Setup und Kommandos. |
| `agents/PROJECT.md` | Projektspezifischer Arbeitskontext, fachliche Leitplanken und Begriffe. |
| `agents/DEVELOPER.md` | Technologieuebergreifende Entwicklungsregeln. |
| `agents/DEVELOPER.*.md` | Passende technologie- oder kontextspezifische Entwicklerregeln. |

Dateien unter `docs/` sind optional. Sie duerfen nur gelesen werden, wenn sie noch existieren und fuer einen konkreten Task wirklich gebraucht werden.

## Prioritaet von Anweisungen

Bei widerspruechlichen Vorgaben gilt die Reihenfolge:

1. Direkte User-Anweisung im aktuellen Task.
2. Sicherheits-, Datenschutz- und Plattformvorgaben der Arbeitsumgebung.
3. Passende `agents/DEVELOPER.*.md`.
4. `agents/DEVELOPER.md`.
5. `AGENTS.md`.
6. `agents/PROJECT.md`.
7. Bestehender Code-Stil und lokale Patterns.

## Dokumentenpflege

Dokumentation wird nicht automatisch mitgepflegt.

- `README.md`, `agents/PROJECT.md`, `agents/DEVELOPER.md` und `agents/DEVELOPER.*.md` werden nur angepasst, wenn der User es ausdruecklich anordnet.
- Ausnahme: Wenn eine vorhandene Anweisung offensichtlich falsch, gefaehrlich oder irrefuehrend geworden ist, soll der Agent die Abweichung kurz benennen.
- Dateien unter `docs/` sind keine Pflichtdokumentation und werden nicht automatisch gepflegt.

## README.md

`README.md` ist fuer Menschen und den schnellen Einstieg gedacht. Sie bleibt kurz und fokussiert auf:

- Titel und Kurzbeschreibung
- Voraussetzungen
- Setup
- Start, Build und Tests
- knappe technische Orientierung

Keine Agent-Regeln, keine Prozessdetails und keine ausfuehrliche Implementierungsdoku.

## PROJECT.md

`agents/PROJECT.md` ist fuer den projektspezifischen Arbeitskontext gedacht. Sie enthaelt:

- fachliche Leitplanken
- stabile Begriffe und Abgrenzungen
- projektspezifische Architekturgrenzen
- Branching- und Arbeitskontext

Keine README-Dopplung, keine allgemeine Technikdoku, keine Issue-Informationen und keine ausufernden Strukturindizes.
