# Workflow: Instruction Improvement Issue

## Ziel

Einen Verbesserungsvorschlag fuer Agent Instructions, Skills oder Workflows aus einem konsumierenden Repository als GitHub-Issue in diesem Repository erfassen.

## Verwenden

- Wenn waehrend der Nutzung der zentralen `agent-files` Agent Instructions, Skills oder Workflows ein Verbesserungsvorschlag entsteht.
- Wenn der Vorschlag aus einem anderen Repository kommt, das diese Instruktionen referenziert.
- Wenn ein Agent eine Leitplanke als potenziell unsinnig, kontraproduktiv, widerspruechlich oder zielverfehlend erkennt.
- Nicht verwenden fuer projektspezifische Agent- oder Developer-Instruktionen anderer Repositories.
- Nicht verwenden, wenn direkt an den Instruktionsdateien gearbeitet werden soll. Dann passenden Skill oder Workflow im `agent-files`-Repository verwenden.

## Verwendete Skills

- `anforderungsklaerung`
- `github_issue-erstellen`
- `github_type-setzen`
- `github_relationship-setzen`

## Ablauf

1. Verbesserungsvorschlag, betroffene Instruktion und Ursprungskontext knapp erfassen.
2. Aktuelle Regelbefolgung und zukuenftigen Verbesserungsvorschlag trennen: Die geltende Leitplanke bleibt fuer den aktuellen Task bindend, solange keine hoeherrangige Sicherheits-, Datenschutz- oder Plattformvorgabe entgegensteht.
3. Reflexionskriterium bestimmen: unsinnig, kontraproduktiv, widerspruechlich, zielverfehlend oder nicht ausreichend operationalisierbar.
4. Bei unscharfem Vorschlag mit `anforderungsklaerung` interaktiv nachfragen, bis Ziel, Scope, betroffene Instruktion und gewuenschter Zielzustand ausreichend klar sind.
5. Ziel-Repository explizit auf `Heljens-IT-Services/agent-files` setzen.
6. Im Issue das konsumierende Repository, die betroffene referenzierte Datei oder URL und den konkreten Nutzungskontext verlinken oder beschreiben, wenn bekannt.
7. GitHub-Issue-Type passend zum Kontext bestimmen: `Task`, `Story`, `Spike` oder `Epic`.
8. Relationships bestimmen, wenn aus dem Kontext ein Parent, Child oder Blocker hervorgeht.
9. Mit `github_issue-erstellen` eigenstaendig ein strukturiertes Issue in `Heljens-IT-Services/agent-files` erstellen.
10. Mit `github_type-setzen` den nativen GitHub-Issue-Type setzen.
11. Mit `github_relationship-setzen` native Relationships setzen, wenn sie aus dem Kontext hervorgehen.

## Reflexionskriterien

- Eine Leitplanke ist potenziell unsinnig, wenn sie keinen erkennbaren Zweck fuer Sicherheit, Qualitaet, Wartbarkeit, Governance oder Nutzerziel erfuellt.
- Eine Leitplanke ist potenziell kontraproduktiv, wenn ihre Befolgung regelmaessig zu schlechteren Ergebnissen, hoeherem Risiko, unnoetiger Reibung oder schlechterer Nachvollziehbarkeit fuehrt.
- Eine Leitplanke ist potenziell widerspruechlich, wenn sie mit einer gleich- oder hoeherpriorisierten Regel, einem projektspezifischen Constraint oder dem dokumentierten Workflow nicht konsistent vereinbar ist.
- Eine Leitplanke ist potenziell zielverfehlend, wenn sie das beschriebene Ziel nicht erreicht oder wichtige Faelle systematisch offenlaesst.
- Eine Leitplanke ist potenziell nicht ausreichend operationalisierbar, wenn ein Agent sie nicht verlaesslich anwenden kann, weil Begriffe, Ausnahmen, Prioritaeten oder Abschlussbedingungen fehlen.

## Vorschlagsformat

Ein Instruction-Improvement-Issue soll mindestens enthalten:

- betroffene Datei, Regel, Skill oder Workflow
- Ursprungskontext und beobachtetes Problem
- aktuelles Verhalten oder aktuelle Regelwirkung
- erwarteter Zielzustand
- vorgeschlagene Aenderungsrichtung
- Risiken, Nicht-Ziele und offene Fragen
- Hinweis, dass die geltende Regel im aktuellen Task weiterhin befolgt wurde oder warum eine hoeherrangige Vorgabe abweichendes Verhalten erzwungen hat

## Zielkanaele

GitHub-Issue im Repository `Heljens-IT-Services/agent-files`:

- Vorteil: versionierbar, reviewbar, nachvollziehbar, mit nativen Issue-Types und Relationships integrierbar.
- Nachteil: benoetigt GitHub-Zugriff und kann bei sehr kleinen Beobachtungen mehr Prozessgewicht haben.
- Bewertung: empfohlener erster Mechanismus.

MCP-Tool oder spezialisiertes Review-Backend:

- Vorteil: kann strukturierte Felder, Deduplizierung, Routing und Governance-Automatisierung erzwingen.
- Nachteil: benoetigt zusaetzliche Infrastruktur, Rechteverwaltung und Betriebsverantwortung.
- Bewertung: spaetere Ausbaustufe, wenn GitHub-Issues zu wenig Struktur liefern.

Zentrales Review-Postfach:

- Vorteil: niedrigschwelliger Eingangskanal fuer Umgebungen ohne GitHub-Zugriff.
- Nachteil: schlechtere Nachverfolgbarkeit, Deduplizierung, Statuspflege und Relationship-Pflege.
- Bewertung: Fallback fuer eingeschraenkte Umgebungen, nicht bevorzugter Standard.

## Minimalprozess

1. Agent erkennt einen plausiblen Verbesserungsbedarf anhand der Reflexionskriterien.
2. Agent befolgt die geltenden Regeln im aktuellen Task weiter.
3. Agent erstellt ohne vorherige Human-Bestaetigung ein GitHub-Issue in `Heljens-IT-Services/agent-files`, sofern der Vorschlag ausreichend klar und GitHub-Zugriff vorhanden ist.
4. Agent setzt den passenden nativen GitHub-Issue-Type und relevante native Relationships.
5. Ein Human reviewed, priorisiert, entscheidet und merged eine spaetere Aenderung an den Instruktionsdateien.

## Ruecksprungregeln

- Bei unklarem Verbesserungsvorschlag zurueck zu `anforderungsklaerung`.
- Wenn Ziel, Scope, betroffene Instruktion oder Zielzustand nicht klaerbar sind, Workflow blockieren.
- Bei fehlenden GitHub-Rechten oder unklarer Repository-Zuordnung stoppen und Blocker melden.
- Bei moeglichem Duplikat den Duplikatregeln aus `github_issue-erstellen` folgen.
- Bei unklarem GitHub-Issue-Type oder unklarer Relationship-Richtung zurueck zu `anforderungsklaerung`.

## Endergebnis

- GitHub-Issue im Repository `Heljens-IT-Services/agent-files`
- Issue-Link
- gesetzter GitHub-Issue-Type
- gesetzte Relationships, falls vorhanden
- dokumentierter Reflexionsgrund, Vorschlagsformat und Review-Bedarf

## Grenzen

- Das Issue immer in `Heljens-IT-Services/agent-files` erstellen, nicht im konsumierenden Repository.
- Ausschliesslich fuer zentrale `agent-files`-Instruktionen verwenden.
- Keine Aenderungen an Instruktionsdateien vornehmen.
- Keine Umsetzung planen, wenn nur ein Verbesserungsvorschlag erfasst werden soll.
- Kein Issue aus einem unscharfen Verbesserungsvorschlag erstellen.
- Keine geltende Leitplanke im aktuellen Task eigenmaechtig umgehen, nur weil ein Verbesserungsvorschlag erstellt wird.
- Keine automatische Aenderung verbindlicher Leitplanken ohne menschliches Review.
- Keine Verbesserungsvorschlaege erzeugen, die nur die eigene Bequemlichkeit optimieren und Sicherheit, Qualitaet, Nachvollziehbarkeit oder Nutzerziel verschlechtern.
- Kein Spam: aehnliche Beobachtungen buendeln oder vorhandene offene Issues weiterverwenden, wenn sie denselben Verbesserungsbedarf abdecken.
- Fehlendes konsumierendes Repository, fehlende Referenzdatei oder fehlender Nutzungskontext blockiert die Issue-Erstellung nicht.
- Labels, Body-Links oder Textverweise ersetzen weder native GitHub-Issue-Types noch native GitHub-Relationships.

## Risiken

- Regelumgehung: Agenten koennten eine Verbesserungsidee als Begruendung missbrauchen, um aktuelle Regeln nicht zu befolgen.
- Spam: zu viele kleinteilige oder doppelte Vorschlaege koennen Review-Kapazitaet binden.
- Falsche Optimierungsziele: Vorschlaege koennen auf Geschwindigkeit oder Bequemlichkeit optimieren und dabei Qualitaet, Sicherheit oder Governance schwaechen.
- Fehlende Verantwortlichkeit: Ohne Human-Review waere unklar, wer Regelwirkungen bewertet und freigibt.
- Kontextverlust: Vorschlaege ohne konkrete Ausgangssituation sind schwer pruefbar.
