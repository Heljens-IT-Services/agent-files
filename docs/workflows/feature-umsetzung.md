# Workflow: Feature Umsetzung

## Ziel

Ein neues Feature strukturiert von Idee oder Ticket bis zur verifizierten Implementierung bearbeiten.

## Verwenden

- Wenn ein neues Feature fachlich und technisch umgesetzt werden soll.
- Wenn Story-Issue, relevante Issue-Beziehungen, Planung, Implementierung, Verifikation, Commit/Push und Pull Request zusammenhaengend bearbeitet werden sollen.
- Nicht verwenden, wenn nur Optionen abgewogen werden sollen. Dann `brainstorming` nutzen.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `brainstorming`
- `code_lesen`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `code_diff-review`
- `github_commit-push`
- `github_pr-erstellen`

## Ablauf

1. Mit `github_issue-lesen` das Story-Issue inklusive relevanter Parent-, Child- und Blocked-by-Beziehungen lesen.
2. Issue-Graph fuer Scope, Reihenfolge und Abhaengigkeiten beruecksichtigen.
3. Alle Child-Issues des Story-Issues in den Umsetzungsumfang aufnehmen.
4. Bei blockierten Issues pruefen, ob der Blocker im Rahmen dieses Workflows selbststaendig geloest werden kann.
5. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
6. Falls die Richtung noch offen ist, mit `brainstorming` Optionen vergleichen.
7. Arbeitspakete aus Story- und Child-Issues in Umsetzungsreihenfolge festlegen.
8. Je Arbeitspaket iterieren:
   - mit `code_lesen` relevante Architektur und Code-Kontext einordnen
   - mit `code_implementierungsplanung` Zielzustand, Schritte, Abhaengigkeiten und Tests festlegen
   - mit `code_implementieren` das Arbeitspaket umsetzen
   - mit `code_testen` Funktion und angrenzende Risiken pruefen
   - mit `code_diff-review` Scope und Nebeneffekte kontrollieren
   - mit `github_commit-push` Commit und Push ausfuehren
   - umgesetztes Child-Issue minimalistisch mit Ergebnis, Commit-Kontext und Teststatus kommentieren und schliessen, falls das Arbeitspaket ein Child-Issue abschliesst
9. Mit `github_pr-erstellen` den Pull Request mit Review-Kontext und Issue-Verknuepfungen erstellen; Story-Issue so verlinken, dass GitHub es beim Merge schliessen kann.

## Ruecksprungregeln

- Bei Architekturkonflikten zurueck zu `brainstorming` oder `code_implementierungsplanung`.
- Bei unklaren Anforderungen zurueck zu `github_issue-lesen`.
- Bei unklaren Issue-Beziehungen zurueck zu `github_issue-lesen`.
- Bei widerspruechlichen Abhaengigkeiten zurueck zu `code_implementierungsplanung`.
- Bei fehlgeschlagenen Tests zurueck zu `code_implementierungsplanung`.
- Wenn ein Blocker nicht selbststaendig geloest werden kann, Workflow blockieren und Grund nennen.

## Endergebnis

- verifizierte Feature-Aenderung
- dokumentierter Teststatus
- Commit und Push
- kommentierte und geschlossene Child-Issues
- erstellter Pull Request

## Grenzen

- Story-Issue nicht manuell schliessen.
- Story-Issue ueber PR-Verlinkung schliessen lassen, wenn der PR gemergt wird.
- Wenn automatisches Schliessen nicht sicher ist, im PR-Kontext sichtbar machen.
- `code_diff-review` mit Bewertung `versandbereit mit Hinweisen` darf fortfahren.
- `code_diff-review` mit Bewertung `nicht versandbereit` blockiert Commit, Push und Pull-Request-Erstellung.
