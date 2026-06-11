# Skill: Code Implementierungsplanung

## Zweck

Ueberfuehre Anforderungen oder Analyseergebnisse in einen konkreten technischen Umsetzungsplan.

## Wann verwenden

- Vor nicht-trivialen Codeaenderungen.
- Wenn mehrere Dateien, Schichten oder Systeme betroffen sind.
- Wenn Tests, Rollout oder Risiken vorab strukturiert werden sollen.

## Input

- Zielbild, Issue oder Analyseergebnis
- optional: bekannte Einschraenkungen oder Architekturvorgaben
- optional: betroffener Sprachtyp, zum Beispiel Backend-Code oder HTML/CSS

## Vorgehen

1. Zielzustand und Definition of Done festhalten.
2. Betroffene Dateien, Module oder Schichten identifizieren.
3. Den Sprachtyp beruecksichtigen und die Zielstruktur daran ausrichten.
4. Aenderungsschritte in sinnvoller Reihenfolge formulieren.
5. Test- und Verifikationsstrategie festlegen.
6. Risiken, Abhaengigkeiten und Rueckfalloptionen benennen.

## Sprachtyp-Leitlinien

### Backend-Sprachen

- Verantwortlichkeiten frueh trennen, wenn Logik sonst unklar oder zu eng gekoppelt wuerde.
- Abhaengigkeiten und Schnittstellen bewusst planen.
- Verschachtelung oder zusätzliche Abstraktion ist akzeptabel, wenn sie Verantwortungen sauber trennt.
- Auf Wartbarkeit, Testbarkeit und Erweiterbarkeit optimieren.

### HTML und CSS

- Struktur moeglichst flach und direkt halten.
- Zusätzliche Wrapper, Hilfskonstrukte oder Selektor-Komplexitaet nur einfuehren, wenn sie einen klaren Nutzen haben.
- Auf geringe Verschachtelung, niedrigen Overhead und klare Lesbarkeit im Markup oder Styling optimieren.
- Verantwortlichkeiten eher ueber semantische Struktur und einfache Klassenzustaendigkeiten trennen als ueber tiefe Schachtelung.

## Output

- Zielzustand
- betroffene Bereiche
- Umsetzungsschritte
- Testplan
- Risiken und offene Punkte

## Qualitätskriterien

- Schritte muessen konkret genug fuer die Umsetzung sein.
- Plan soll auf den kleinsten sinnvollen Scope optimieren.
- Tests und Verifikation nicht auslassen.
- Strukturentscheidungen sollen zum betroffenen Sprachtyp passen und nicht pauschal aus einem anderen Bereich uebernommen werden.
