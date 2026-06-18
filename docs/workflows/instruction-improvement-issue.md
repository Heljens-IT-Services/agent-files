# Workflow: Instruction Improvement Issue

## Ziel

Schwachstellen und Verbesserungsvorschlaege an Agent-Files, Leitplanken, Skills oder Workflows als GitHub-Issue in diesem Repository erfassen.

## Verwenden

- Wenn waehrend der Nutzung der zentralen `agent-files` ein Verbesserungsvorschlag entsteht.
- Wenn ein Agent eine Schwachstelle, Luecke, unklare Regel, widerspruechliche Leitplanke oder kontraproduktiven Workflow erkennt.
- Wenn der Vorschlag aus einem konsumierenden Repository kommt, das diese Instruktionen referenziert.
- Nicht verwenden fuer projektspezifische Agent- oder Developer-Instruktionen anderer Repositories.
- Nicht verwenden, wenn direkt an den Instruktionsdateien gearbeitet werden soll. Dann passenden Skill oder Workflow im `agent-files`-Repository verwenden.

## Verwendete Skills

- `anforderungsklaerung`
- `github_issue-erstellen`
- `github_type-setzen`
- `github_relationship-setzen`

## Ablauf

1. Verbesserungsvorschlag oder Schwachstelle, betroffene Instruktion und Ursprungskontext erfassen.
2. Aktuelle Regelbefolgung und zukuenftige Regelverbesserung trennen: Die geltende Leitplanke bleibt fuer den aktuellen Task bindend, solange keine hoeherrangige Vorgabe entgegensteht.
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

Ein Issue ist sinnvoll, wenn eine Leitplanke oder ein Workflow mindestens eines davon zeigt:

- kein klarer Zweck fuer Sicherheit, Qualitaet, Wartbarkeit, Governance oder Nutzerziel
- schlechtere Ergebnisse, hoeheres Risiko, unnoetige Reibung oder schlechtere Nachvollziehbarkeit
- Widerspruch zu gleich- oder hoeherpriorisierten Regeln
- Ziel wird nicht erreicht oder wichtige Faelle bleiben offen
- Begriffe, Ausnahmen, Prioritaeten oder Abschlussbedingungen sind nicht operationalisierbar

## Vorschlagsformat

Ein Instruction-Improvement-Issue soll mindestens enthalten:

- betroffene Datei, Regel, Skill oder Workflow
- Ursprungskontext und beobachtetes Problem
- Art des Befunds: Verbesserungsvorschlag, Schwachstelle, Widerspruch, Luecke, Risiko oder unklare Operationalisierung
- aktuelles Verhalten oder aktuelle Regelwirkung
- erwarteter Zielzustand
- vorgeschlagene Aenderungsrichtung
- Risiken, Nicht-Ziele und offene Fragen
- Hinweis, dass die geltende Regel im aktuellen Task weiterhin befolgt wurde oder warum eine hoeherrangige Vorgabe abweichendes Verhalten erzwungen hat

## Zielkanaele

- GitHub-Issue in `Heljens-IT-Services/agent-files`: Standard, weil reviewbar, versionierbar und gut nachverfolgbar.
- MCP-Tool oder Review-Backend: spaetere Option fuer strukturierte Felder, Routing und Deduplizierung.
- Zentrales Review-Postfach: Fallback fuer Umgebungen ohne GitHub-Zugriff.

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
- Keine geltende Leitplanke im aktuellen Task umgehen, nur weil ein Verbesserungsvorschlag erstellt wird.
- Keine automatische Aenderung verbindlicher Leitplanken ohne menschliches Review.
- Keine Verbesserungsvorschlaege erzeugen, die nur die eigene Bequemlichkeit optimieren und Sicherheit, Qualitaet, Nachvollziehbarkeit oder Nutzerziel verschlechtern.
- Kein Spam: aehnliche Beobachtungen buendeln oder vorhandene offene Issues weiterverwenden, wenn sie denselben Verbesserungsbedarf abdecken.
- Fehlendes konsumierendes Repository, fehlende Referenzdatei oder fehlender Nutzungskontext blockiert die Issue-Erstellung nicht.
- Labels, Body-Links oder Textverweise ersetzen weder native GitHub-Issue-Types noch native GitHub-Relationships.

## Risiken

- Regelumgehung
- Spam oder Duplikate
- falsche Optimierungsziele
- fehlende Verantwortlichkeit ohne Human-Review
- Kontextverlust durch unkonkrete Vorschlaege
