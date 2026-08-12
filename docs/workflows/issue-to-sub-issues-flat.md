# Workflow: Issue To Sub Issues Flat

## Ziel

Ein einzelnes vorhandenes GitHub-Issue genau eine Hierarchieebene tief in mehrere klare Child-Issues schneiden, die Child-Issues anlegen und ihre direkten Beziehungen vollständig setzen. Dieser Workflow ist die atomare Ein-Ebenen-Operation für den rekursiven Workflow `issue-to-sub-issues.md`.

## Verwenden

- Wenn genau eine Ebene unterhalb eines Ausgangs-Issues erzeugt werden soll.
- Wenn `issue-to-sub-issues.md` im Modus `flat` läuft.
- Wenn `issue-to-sub-issues.md` im rekursiven Modus einen einzelnen noch nicht terminalen Knoten um genau eine Ebene weiter zerlegt.
- Nicht direkt als rekursiven Baum-Orchestrator verwenden.
- Nicht verwenden, wenn das Ausgangs-Issue bereits ein sauber geschnittenes terminales Leaf ist.

## Verwendete Skills

- `github_issue-lesen`
- `anforderungsklaerung`
- `brainstorming`
- `github_issue-erstellen`
- `github_type-setzen`
- `github_relationship-setzen`

## Ablauf

1. Mit `github_issue-lesen` das Ausgangs-Issue mit Body, Kommentaren, Status, Type und bereits vorhandenen direkten Child-Issues lesen.
2. Mit `anforderungsklaerung` Ziel, Scope, Nicht-Ziele und Akzeptanzkriterien des Ausgangs-Issues klären, falls sie für einen belastbaren Schnitt nicht ausreichen.
3. Bereits vorhandene Child-Issues gegen den beabsichtigten Schnitt prüfen und keine semantischen Duplikate erzeugen.
4. Mit `brainstorming` mögliche sinnvolle Teilaufgaben schneiden, wenn die Zerlegung nicht offensichtlich ist.
5. Genau eine neue Hierarchieebene planen. Jedes geplante Child-Issue muss eigenständig verständlich, klar abgegrenzt und inhaltlich kleiner als das Ausgangs-Issue sein.
6. GitHub-Issue-Type je Child-Issue kontextbasiert bestimmen.
7. Mit `github_issue-erstellen` die fehlenden Child-Issues erstellen.
8. Mit `github_type-setzen` den nativen GitHub-Issue-Type je neu erstelltem Child-Issue setzen.
9. Mit `github_relationship-setzen` die erstellten Issues als native GitHub-Child-Issues des Ausgangs-Issues setzen.
10. Harte Abhängigkeiten der direkten Child-Issues bestimmen.
11. Mit `github_relationship-setzen` native `blocked by`-Relationships setzen, wenn eine harte Abhängigkeit fachlich oder technisch erforderlich ist.
12. Die erzeugte Ebene zurücklesen und prüfen, dass geplante Child-Issues, Types, Parent/Child-Beziehungen und harte Abhängigkeiten vollständig gesetzt sind.

## Schnittkriterien

- Jedes Child-Issue verfolgt genau ein fachliches, technisches, Recherche- oder Entscheidungsziel.
- Jedes Child-Issue ist eigenständig verständlich und besitzt klaren Scope sowie klaren Nicht-Scope.
- Jedes Child-Issue besitzt belastbare Akzeptanz- oder Abschlusskriterien.
- Child-Issues müssen kleiner als das Ausgangs-Issue sein.
- Ein Schnitt in nur ein inhaltlich nahezu identisches Child-Issue ist keine sinnvolle Zerlegung.
- Harte Abhängigkeiten nur setzen, wenn sie tatsächlich erforderlich sind; Parent/Child allein ist keine Ausführungsreihenfolge.
- Abhängigkeiten möglichst auf der niedrigsten fachlich korrekten Ebene ausdrücken.
- Parent-Issue-Type gibt eine Tendenz, bestimmt den Child-Issue-Type aber nicht automatisch.
- Parent `Epic` führt häufig zu `Story`, `Task` oder `Spike`.
- Parent `Story` führt häufig zu `Task` oder `Spike`.
- Ein bereits als `Task` typisiertes Issue darf erneut in Child-Tasks zerlegt werden, wenn es die Kriterien eines terminalen Leafs noch nicht erfüllt.
- Recherche-, Entscheidungs- oder Klärungsanteile können als `Spike` geschnitten werden.
- Nicht blind alle Child-Issues mit demselben Type erstellen.

## Rücksprungregeln

- Bei unklarem Ausgangs-Issue zurück zu `github_issue-lesen`.
- Bei unklaren Anforderungen zurück zu `anforderungsklaerung`.
- Bei unklarem Zuschnitt zurück zu `brainstorming`.
- Bei möglichen Duplikaten den Duplikatregeln aus `github_issue-erstellen` folgen.
- Bei unklarem GitHub-Issue-Type oder unklarer Relationship-Richtung zurück zu `anforderungsklaerung` oder `brainstorming`.

## Endergebnis

- genau eine belastbar geschnittene Child-Ebene unterhalb des Ausgangs-Issues
- erstellte oder wiederverwendete direkte Child-Issues
- gesetzte native GitHub-Types für neu erstellte Issues
- gesetzte native GitHub-Parent/Child-Beziehungen
- gesetzte native `blocked by`-Beziehungen, falls erforderlich
- verifizierte direkte Hierarchieebene

## Grenzen

- Niemals selbstständig eine zweite Hierarchieebene erzeugen.
- Ausgangs-Issue nicht automatisch schließen oder kommentieren.
- Keine Umsetzung der erzeugten Issues starten.
- Keine Child-Issues erstellen, solange Ziel, Scope oder Schnitt nicht belastbar sind.
- Keine Bestätigungsschleife verlangen, wenn Ziel, Scope und Schnittkriterien belastbar sind.
- Keine künstliche Zerlegung allein zur Erzeugung weiterer Hierarchieebenen vornehmen.
