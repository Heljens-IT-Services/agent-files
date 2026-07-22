# Workflow: Issue To Sub Issues

## Ziel

Ein vorhandenes grosses GitHub-Issue in mehrere klare Sub-Issues schneiden und als Child-Issues anlegen.

## Verwenden

- Wenn ein bestehendes Issue zu gross ist und in mehrere Teilaufgaben zerlegt werden soll.
- Wenn aus einem Epic, einer Story oder einem grossen Task umsetzbare Sub-Issues entstehen sollen.
- Dieser Workflow muss verwendet werden, wenn ein User verlangt, ein Epic, eine Story oder ein grosses GitHub-Issue in Sub-Issues, Child-Issues oder Teil-Issues zu zerlegen.
- Nicht verwenden, wenn das Ausgangs-Issue direkt umgesetzt werden soll. Dann `issue-to-pr.md` oder `issue-umsetzung.md` nutzen.

## Verwendete Skills

- `github_issue-lesen`
- `anforderungsklaerung`
- `brainstorming`
- `github_issue-erstellen`
- `github_type-setzen`
- `github_relationship-setzen`

## Ablauf

1. Mit `github_issue-lesen` das Ausgangs-Issue inklusive explizit angeforderter Parent/Child- oder Beziehungskontexte lesen.
2. Mit `anforderungsklaerung` Ziel, Scope, Nicht-Ziele und Akzeptanzkriterien des Ausgangs-Issues klaeren, falls sie nicht belastbar sind.
3. Mit `brainstorming` moegliche sinnvolle Teilaufgaben schneiden, wenn die Zerlegung nicht offensichtlich ist.
4. Sub-Issue-Schnitt eigenstaendig festlegen: jedes Sub-Issue muss eigenstaendig verstaendlich, umsetzbar und verifizierbar sein.
5. GitHub-Issue-Type je Sub-Issue kontextbasiert bestimmen.
6. Mit `github_issue-erstellen` die Sub-Issues erstellen.
7. Mit `github_type-setzen` den nativen GitHub-Issue-Type je Sub-Issue setzen.
8. Mit `github_relationship-setzen` die erstellten Issues als native GitHub-Child-Issues des Ausgangs-Issues setzen.
9. Reihenfolge und Abhaengigkeiten der Sub-Issues bestimmen.
10. Mit `github_relationship-setzen` native GitHub-Relationships wie Blocked-by setzen, wenn Abhaengigkeiten aus dem Schnitt hervorgehen.

## Schnittkriterien

- Jedes Sub-Issue ist eigenstaendig verstaendlich.
- Jedes Sub-Issue ist einzeln umsetzbar.
- Jedes Sub-Issue ist einzeln verifizierbar.
- Jedes Sub-Issue hat klaren Scope und Nicht-Scope.
- Harte Abhaengigkeiten zwischen Sub-Issues moeglichst vermeiden.
- Wenn Abhaengigkeiten nicht vermeidbar sind, muessen sie als Reihenfolge und Relationship sichtbar werden.
- Pro Sub-Issue nur ein fachliches oder technisches Ziel verfolgen.
- Sub-Issues sollen klein genug sein, dass sie sinnvoll in einem Pull Request bearbeitet werden koennen.
- Parent-Issue-Type gibt eine Default-Tendenz, bestimmt den Sub-Issue-Type aber nicht automatisch.
- Jedes Sub-Issue bekommt einen eigenen kontextbasierten GitHub-Issue-Type.
- Parent `Epic` fuehrt haeufig zu `Story` oder `Task`.
- Parent `Story` fuehrt haeufig zu `Task`.
- Recherche-, Entscheidungs- oder Klaerungsanteile koennen `Spike` sein.
- Nicht blind alle Sub-Issues mit demselben Type erstellen.

## Ruecksprungregeln

- Bei unklarem Ausgangs-Issue zurueck zu `github_issue-lesen`.
- Bei unklaren Anforderungen zurueck zu `anforderungsklaerung`.
- Bei unklarem Zuschnitt zurueck zu `brainstorming`.
- Bei unklarem GitHub-Issue-Type oder unklarer Relationship-Richtung zurueck zu `anforderungsklaerung` oder `brainstorming`.
- Bei moeglichen Duplikaten den Duplikatregeln aus `github_issue-erstellen` folgen.

## Endergebnis

- mehrere erstellte Sub-Issues
- gesetzte native GitHub-Parent/Child-Beziehungen zum Ausgangs-Issue
- gesetzte native GitHub-Blocked-by-Beziehungen, falls vorhanden
- Liste der erstellten Issue-Links

## Grenzen

- Ausgangs-Issue nicht automatisch schliessen.
- Ausgangs-Issue nicht automatisch kommentieren.
- Keine Umsetzung der Sub-Issues starten.
- Keine Sub-Issues erstellen, wenn Ziel, Scope oder Zuschnitt nicht ausreichend geklaert sind.
- Keine Bestaetigungsschleife vor Erstellung, wenn der Zuschnitt plausibel und ausreichend geklaert ist.
- Sub-Issues muessen kleiner sein als das Ausgangs-Issue und jeweils einen klaren eigenen Scope haben.
