# Workflow: Issue To Sub Issues

## Ziel

Ein vorhandenes großes GitHub-Issue in mehrere klare Sub-Issues schneiden und als Child-Issues anlegen.

## Verwenden

- Wenn ein bestehendes Issue zu groß ist und in mehrere Teilaufgaben zerlegt werden soll.
- Wenn aus einem Epic, einer Story oder einem großen Task umsetzbare Sub-Issues entstehen sollen.
- Dieser Workflow muss verwendet werden, wenn ein User verlangt, ein Epic, eine Story oder ein großes GitHub-Issue in Sub-Issues, Child-Issues oder Teil-Issues zu zerlegen.
- Nicht verwenden, wenn das Ausgangs-Issue direkt umgesetzt werden soll. Dann `issue-to-pr.md` oder `issue-umsetzung.md` nutzen.

## Direkter Alias

- `/sub-issues <issue-nummer>`

`<issue-nummer>` muss als positive Ganzzahl mit optional vorangestelltem `#` angegeben werden, zum Beispiel `/sub-issues #123` oder `/sub-issues 123`.

## Verwendete Skills

- `github_issue-lesen`
- `anforderungsklaerung`
- `brainstorming`
- `github_issue-erstellen`
- `github_type-setzen`
- `github_relationship-setzen`

## Ablauf

1. Mit `github_issue-lesen` das Ausgangs-Issue inklusive explizit angeforderter Parent/Child- oder Beziehungskontexte lesen.
2. Mit `anforderungsklaerung` Ziel, Scope, Nicht-Ziele und Akzeptanzkriterien des Ausgangs-Issues klären, falls sie nicht belastbar sind.
3. Mit `brainstorming` mögliche sinnvolle Teilaufgaben schneiden, wenn die Zerlegung nicht offensichtlich ist.
4. Sub-Issue-Schnitt eigenständig festlegen: jedes Sub-Issue muss eigenständig verständlich, umsetzbar und verifizierbar sein.
5. GitHub-Issue-Type je Sub-Issue kontextbasiert bestimmen.
6. Mit `github_issue-erstellen` die Sub-Issues erstellen.
7. Mit `github_type-setzen` den nativen GitHub-Issue-Type je Sub-Issue setzen.
8. Mit `github_relationship-setzen` die erstellten Issues als native GitHub-Child-Issues des Ausgangs-Issues setzen.
9. Reihenfolge und Abhängigkeiten der Sub-Issues bestimmen.
10. Mit `github_relationship-setzen` native GitHub-Relationships wie Blocked-by setzen, wenn Abhängigkeiten aus dem Schnitt hervorgehen.

## Schnittkriterien

- Jedes Sub-Issue ist eigenständig verständlich.
- Jedes Sub-Issue ist einzeln umsetzbar.
- Jedes Sub-Issue ist einzeln verifizierbar.
- Jedes Sub-Issue hat klaren Scope und Nicht-Scope.
- Harte Abhängigkeiten zwischen Sub-Issues nur zulassen, wenn der fachliche oder technische Schnitt sie erfordert.
- Wenn Abhängigkeiten nicht vermeidbar sind, müssen sie als Reihenfolge und Relationship sichtbar werden.
- Pro Sub-Issue nur ein fachliches oder technisches Ziel verfolgen.
- Parent-Issue-Type gibt eine Default-Tendenz, bestimmt den Sub-Issue-Type aber nicht automatisch.
- Jedes Sub-Issue bekommt einen eigenen kontextbasierten GitHub-Issue-Type.
- Parent `Epic` führt häufig zu `Story` oder `Task`.
- Parent `Story` führt häufig zu `Task`.
- Recherche-, Entscheidungs- oder Klärungsanteile können `Spike` sein.
- Nicht blind alle Sub-Issues mit demselben Type erstellen.

## Rücksprungregeln

- Bei unklarem Ausgangs-Issue zurück zu `github_issue-lesen`.
- Bei unklaren Anforderungen zurück zu `anforderungsklaerung`.
- Bei unklarem Zuschnitt zurück zu `brainstorming`.
- Bei unklarem GitHub-Issue-Type oder unklarer Relationship-Richtung zurück zu `anforderungsklaerung` oder `brainstorming`.
- Bei möglichen Duplikaten den Duplikatregeln aus `github_issue-erstellen` folgen.

## Endergebnis

- mehrere erstellte Sub-Issues
- gesetzte native GitHub-Parent/Child-Beziehungen zum Ausgangs-Issue
- gesetzte native GitHub-Blocked-by-Beziehungen, falls vorhanden
- Liste der erstellten Issue-Links

## Grenzen

- Ausgangs-Issue nicht automatisch schließen.
- Ausgangs-Issue nicht automatisch kommentieren.
- Keine Umsetzung der Sub-Issues starten.
- Keine Sub-Issues erstellen, solange Ziel, Scope oder Schnittkriterien nicht erfüllt sind.
- Keine Bestätigungsschleife verlangen, wenn Ziel, Scope und Schnittkriterien erfüllt sind.
- Sub-Issues müssen kleiner sein als das Ausgangs-Issue und jeweils einen klaren eigenen Scope haben.
