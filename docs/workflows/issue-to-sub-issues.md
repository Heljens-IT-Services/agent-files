# Workflow: Issue To Sub Issues

## Ziel

Ein vorhandenes grosses GitHub-Issue in mehrere klare Sub-Issues schneiden und als Child-Issues anlegen.

## Verwenden

- Wenn ein bestehendes Issue zu gross ist und in mehrere Teilaufgaben zerlegt werden soll.
- Wenn aus einem Epic, einer Story oder einem grossen Task umsetzbare Sub-Issues entstehen sollen.
- Nicht verwenden, wenn das Ausgangs-Issue direkt umgesetzt werden soll. Dann `issue-to-pr.md` oder `issue-umsetzung.md` nutzen.

## Verwendete Skills

- `github_issue-lesen`
- `anforderungsklaerung`
- `brainstorming`
- `github_issue-erstellen`

## Ablauf

1. Mit `github_issue-lesen` das Ausgangs-Issue inklusive explizit angeforderter Parent/Child- oder Beziehungskontexte lesen.
2. Mit `anforderungsklaerung` Ziel, Scope, Nicht-Ziele und Akzeptanzkriterien des Ausgangs-Issues klaeren, falls sie nicht belastbar sind.
3. Mit `brainstorming` moegliche sinnvolle Teilaufgaben schneiden, wenn die Zerlegung nicht offensichtlich ist.
4. Sub-Issue-Schnitt festlegen: jedes Sub-Issue muss eigenstaendig verstaendlich, umsetzbar und verifizierbar sein.
5. Mit `github_issue-erstellen` die Sub-Issues erstellen.
6. Die erstellten Issues als Child-Issues des Ausgangs-Issues setzen.
7. Relationships wie Blocked-by setzen, wenn Abhaengigkeiten aus dem Schnitt hervorgehen.

## Ruecksprungregeln

- Bei unklarem Ausgangs-Issue zurueck zu `github_issue-lesen`.
- Bei unklaren Anforderungen zurueck zu `anforderungsklaerung`.
- Bei unklarem Zuschnitt zurueck zu `brainstorming`.
- Bei moeglichen Duplikaten den Duplikatregeln aus `github_issue-erstellen` folgen.

## Endergebnis

- mehrere erstellte Sub-Issues
- gesetzte Parent/Child-Beziehungen zum Ausgangs-Issue
- gesetzte Blocked-by-Beziehungen, falls vorhanden
- Liste der erstellten Issue-Links

## Grenzen

- Ausgangs-Issue nicht automatisch schliessen.
- Keine Umsetzung der Sub-Issues starten.
- Keine Sub-Issues erstellen, wenn Ziel, Scope oder Zuschnitt nicht ausreichend geklaert sind.
- Sub-Issues muessen kleiner sein als das Ausgangs-Issue und jeweils einen klaren eigenen Scope haben.
