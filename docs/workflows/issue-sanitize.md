# Workflow: Issue Graph Sanitization

## Owner

`product_owner` führt Type- und Relationship-Korrekturen an User Stories/User Epics im beauftragten Scope aus. Technische Issue-Types, technische Hierarchie und technische Abhängigkeiten weist der Koordinator an Architektur zu. Keine Rolle delegiert oder vergibt selbst Aufträge.

## Zweck

Einen relevanten GitHub-Issue-Graphen lesen, fehlende oder fachlich unpassende native Issue-Types und Relationships erkennen und eindeutig ableitbare Metadaten idempotent korrigieren. Labels und Body-Links sind dabei nur Kontext und kein Ersatz für native GitHub-Metadaten.

## Verwenden

- Wenn ein Ausgangs-Issue und sein relevanter Issue-Graph auf native Types und Relationships geprüft werden sollen.
- Wenn fehlende Parent/Child- oder Blocked-by-Beziehungen aus eindeutigem Issue-Kontext nachgezogen werden sollen.
- Nicht verwenden, wenn eine Relationship-Art oder -Richtung unklar ist. Dann die Unklarheit sichtbar machen und keine Mutation raten.

## Direkter Alias

- `/sanitize <issue-number>`

Der kanonische Aufruf lautet `/workflows run issue-sanitize <issue-number>`.

## Verwendete Skills

- `issue-reading`
- `type-setting`
- `relationship-setting`

## Ablauf

1. Das Ausgangs-Issue mit Body, Kommentaren, Status, Type und direkt relevanten Parent-, Child- und Blocked-by-Kanten lesen.
2. Den relevanten Graphen zyklussicher traversieren und bereits besuchte Issues nicht erneut expandieren.
3. Body-Referenzen als Relationship-Kandidaten erfassen, aber nicht automatisch als bestehende native Relationships interpretieren.
4. Product Owner prüft bei User-Issues den nativen Type anhand des fachlichen Zwecks. Technische Issues gehen mit Kontext an den Koordinator zur separaten Zuweisung an Architektur.
5. Product Owner prüft eindeutige fachliche Hierarchie; technische Issue-Beziehungen bearbeitet Architektur nur nach eigener Zuweisung.
6. Product Owner prüft fachlich eindeutige harte Abhängigkeiten; technische Abhängigkeiten bearbeitet Architektur nur nach eigener Zuweisung.
7. Fehlende oder eindeutig falsche fachliche Types über `type-setting` korrigieren.
8. Fehlende eindeutig ableitbare fachliche Relationships über `relationship-setting` korrigieren. Einen vorhandenen anderen Parent nicht stillschweigend ersetzen.
9. Nach jeder Mutation den tatsächlichen GitHub-Zustand erneut lesen und verifizieren.
10. Bereits korrekte Metadaten unverändert lassen.

## Ableitungsregeln

- Ein Issue-Type ist kein Label.
- Eine Relationship ist kein Body-Link.
- Nicht jede verlinkte Issue-Nummer ist ein Child; Überschrift, Listenstruktur, Beschreibung und fachlicher Kontext müssen die Richtung tragen.
- Parent/Child beschreibt fachliche Hierarchie, nicht automatisch Ausführungsreihenfolge.
- `blocked by` beschreibt eine harte Ausführungsabhängigkeit und muss richtungsstabil gesetzt werden.
- Bei unklarer Type-Zuordnung, Relationship-Art, Richtung oder bestehendem Parent keine Mutation durchführen.
- Ein erneuter Lauf darf keine unnötigen Änderungen erzeugen.

## Verifikation

- Nach jeder Mutation den betroffenen Type beziehungsweise die betroffene Relationship per GraphQL zurücklesen.
- Abschließend alle traversierten Knoten mit Type, Parent, Children, Blocked-by und Blocking zurücklesen.
- Unklare oder konfliktbehaftete Fälle mit Issue-Nummer und konkretem Grund ausgeben.

## Grenzen

- Keine Labels oder Body-Links als Ersatz für native Metadaten pflegen.
- Keine Issues, Labels oder Relationships bei unklarem Kontext erstellen oder raten.
- Keine bestehenden Parents mit `replaceParent: true` ersetzen.
- Keine fachlich nicht relevanten Geschwister- oder Teilbäume automatisch in den Scope aufnehmen.
- Keine technischen Issues oder technischen Beziehungen ohne explizite Zuweisung an Architektur verändern.
- Keine Issue-Abschlüsse oder Implementierungen ausführen.

## Endergebnis

- geprüfter und zyklussicher erfasster relevanter Issue-Graph
- verifizierte native Types und Relationships für eindeutig ableitbare Fälle
- unveränderte korrekte Metadaten
- sichtbare Unklarheiten und Konflikte
