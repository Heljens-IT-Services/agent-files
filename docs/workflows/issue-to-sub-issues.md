# Workflow: Issue To Sub Issues

## Ziel

Ein Issue als Baum bis zu sauber geschnittenen, eigenständig ausführbaren Leaf-Issues zerlegen. Ohne Zusatz rekursiv, mit `flat` genau eine Ebene.

## Verwenden

- Für Epics, Stories oder zu große Tasks, die weiter zerlegt werden sollen.
- Nicht für direkte Umsetzung; dafür `issue-graph-umsetzung.md`, `issue-to-pr.md` oder `issue-umsetzung.md` nutzen.

## Direkter Alias

- `/sub-issues <issue-nummer>`
- `/sub-issues <issue-nummer> flat`

`<issue-nummer>` ist eine positive Ganzzahl mit optionalem `#`. `flat` ist das einzige optionale Positionsargument.

## Verwendete Skills

- `github_issue-lesen`
- `anforderungsklaerung`
- `brainstorming`

## Verwendete Workflows

- `issue-to-sub-issues-flat.md`

## Modi

### Rekursiv

Standard ohne Zusatz.

1. Ausgangs-Issue und vorhandene Child-Struktur lesen.
2. Geschlossene Knoten nicht erneut zerlegen.
3. Offene Leaf-Issues auf Terminalität prüfen.
4. Jeden nicht terminalen Leaf mit `issue-to-sub-issues-flat.md` genau eine Ebene weiter zerlegen.
5. Neue Child-Issues erneut prüfen.
6. Wiederholen, bis jeder offene Ast in terminalen Leaves endet.
7. Bestehende Issues wiederverwenden und Duplikate vermeiden.
8. Bereits besuchte Issues nicht erneut traversieren; Zyklen als Blocker melden.

### Flat

Bei `/sub-issues <issue-nummer> flat` `issue-to-sub-issues-flat.md` genau einmal für das Ausgangs-Issue ausführen. Danach nicht weiter zerlegen.

## Terminalitätskriterien

Ein Leaf ist terminal, wenn es:

- genau ein klares Ziel hat,
- eigenständig verständlich ist,
- klaren Scope und Nicht-Scope besitzt,
- belastbare Abschluss- oder Akzeptanzkriterien besitzt,
- eigenständig umsetzbar und verifizierbar ist,
- einen klar abgrenzbaren Änderungssatz erlaubt.

Zusätzlich:

- `Epic` und `Story` sind im rekursiven Modus nicht terminal, solange eine sinnvolle weitere Zerlegung möglich ist.
- `Task` ist nur terminal, wenn die Kriterien erfüllt sind; der Type allein beendet die Rekursion nicht.
- Ein `Spike` darf terminal sein, wenn sein Ergebnis bewusst Recherche, Analyse, Entscheidung oder Klärung ist.
- Keine künstliche Mindest- oder Zieltiefe erzeugen. Unterschiedliche Äste dürfen unterschiedlich tief sein.
- Nicht bis zu technisch trivialen Kleinstschritten zerlegen.

## Baumregeln

- Parent/Child beschreibt Hierarchie, nicht automatisch Ausführungsreihenfolge.
- Harte Abhängigkeiten nur als `blocked by` setzen, wenn sie tatsächlich erforderlich sind.
- Abhängigkeiten möglichst auf der niedrigsten fachlich korrekten Ebene ausdrücken.
- Jeder erzeugte Knoten muss kleiner und klarer als sein Parent sein.
- Bestehende passende Child-Issues verwenden statt Duplikate zu erzeugen.

## Rücksprungregeln

- Bei unklarem Inhalt zu `github_issue-lesen`.
- Bei unklarem Ziel oder Scope zu `anforderungsklaerung`.
- Bei unklarem Schnitt zu `brainstorming`.
- Bei Zyklus, widersprüchlicher Hierarchie oder nicht belastbarer Zerlegung stoppen und den Blocker nennen.

## Endergebnis

### Rekursiv

- vollständiger relevanter Issue-Baum
- terminale offene Leaf-Tasks oder bewusst terminale Spikes
- gesetzte Parent/Child- und erforderliche `blocked by`-Beziehungen

### Flat

- genau eine erzeugte oder vervollständigte Child-Ebene

## Grenzen

- Keine Umsetzung starten.
- Ausgangs-Issue nicht schließen.
- Keine künstliche Zerlegung nur zur Erzeugung weiterer Ebenen.
- Keine Duplikate erzeugen.
