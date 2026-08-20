# Workflow: Issue Graph Sanitization

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
4. Für jeden relevanten Knoten prüfen, ob ein sinnvoller nativer Type gesetzt ist und zum fachlichen Zweck passt.
5. Für jede eindeutig erkennbare fachliche Hierarchie prüfen, ob die passende Parent/Child-Relationship besteht.
6. Für jede eindeutig dokumentierte harte Abhängigkeit prüfen, ob die richtungsstabile Blocked-by-Relationship besteht.
7. Fehlende oder eindeutig falsche Types über `type-setting` korrigieren.
8. Fehlende eindeutig ableitbare Relationships über `relationship-setting` korrigieren. Einen vorhandenen anderen Parent nicht stillschweigend ersetzen.
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
- Keine Issue-Abschlüsse oder Implementierungen ausführen.

## Endergebnis

- geprüfter und zyklussicher erfasster relevanter Issue-Graph
- verifizierte native Types und Relationships für eindeutig ableitbare Fälle
- unveränderte korrekte Metadaten
- sichtbare Unklarheiten und Konflikte
