# Workflow: Issue Umsetzung

## Ziel

Ein bestehendes Issue von der Anforderungsaufnahme bis zur versandbereiten Aenderung bearbeiten.

Das Issue kann alleine stehen oder ueber Beziehungen weitere Issues in den Arbeitsumfang ziehen, zum Beispiel durch `parent`, `child`, `blocks`, `blocked by`, `related`, Checklisten oder Kommentarverweise.

## Verwendete Skills

- `github_branch-checkout-from-default`
- `github_issue-lesen`
- `code_lesen`
- `code_analyse`
- `code_implementierungsplanung`
- `code_implementieren`
- `code_testen`
- `code_diff-review`
- `github_commit-vorbereiten`
- `github_pr-text-erstellen`

## Ablauf

1. Mit `github_branch-checkout-from-default` einen geeigneten Arbeitsbranch von der Standardbasis erstellen.
2. Ausgangs-Issue mit `github_issue-lesen` in Ziel, Scope und offene Fragen uebersetzen.
3. Relevante Issue-Beziehungen erfassen:
   - direkte Beziehungen aus GitHub-Metadaten, Issue-Body, Kommentaren und Checklisten lesen
   - `blocks` und `blocked by` als harte Reihenfolge-Abhaengigkeiten behandeln
   - `parent` und `child` als Strukturhinweise behandeln und mit fachlichen Abhaengigkeiten abgleichen
   - `related` oder reine Kommentarverweise nur aufnehmen, wenn sie fuer Scope, Reihenfolge oder Verifikation relevant sind
   - einzeln stehende Issues ohne relevante Beziehungen als eigenstaendige Arbeitseinheit behandeln
4. Arbeitsumfang festlegen:
   - Arbeits-Issues bestimmen, die im Rahmen des Ausgangs-Issues umgesetzt werden muessen
   - reine Kontext-Issues von umzusetzenden Arbeits-Issues trennen
   - Issues ausserhalb des Scopes ausdruecklich ausschliessen
   - fehlende oder falsche Issue-Metadaten nur korrigieren, wenn der Prompt dies verlangt oder die Korrektur fuer den Ablauf erforderlich ist
5. Umsetzungsreihenfolge bestimmen:
   - harte Abhaengigkeiten zuerst aufloesen
   - fachliche und technische Vorarbeiten vor darauf aufbauenden Aenderungen einordnen
   - explizite Reihenfolge aus Prompt, Issue-Body oder Kommentaren beruecksichtigen, sofern sie keine Abhaengigkeiten verletzt
   - bei Gleichstand kleine, isolierte oder niedrigere Issue-Nummern zuerst bearbeiten
6. Mit `code_lesen` relevanten Code fuer die naechste Arbeitseinheit einordnen.
7. Mit `code_analyse` Risiken, Ursachen oder Auswirkungen klaeren.
8. Mit `code_implementierungsplanung` den Umsetzungsweg fuer die naechste Arbeitseinheit festlegen.
9. Mit `code_implementieren` die Aenderung umsetzen.
10. Mit `code_testen` die Aenderung verifizieren.
11. Mit `code_diff-review` den Aenderungssatz auf Scope, Seiteneffekte, Regressionen und fehlende Tests pruefen.
12. Kritische Funde korrigieren und die passende Pruefung wiederholen.
13. Mit `github_commit-vorbereiten` den Commit fuer die abgeschlossene Arbeitseinheit vorbereiten.
14. Falls mehrere Arbeits-Issues im Scope liegen, die Schritte 6 bis 13 je Arbeitseinheit in der festgelegten Reihenfolge wiederholen.
15. Umgesetzte Arbeits-Issues knapp mit Ergebnis, Commit und Teststatus kommentieren und schliessen, wenn ihre Akzeptanzkriterien erfuellt sind.
16. Ausgangs-Issue abschliessend pruefen, bei erfuelltem Scope knapp kommentieren und schliessen.
17. Mit `github_pr-text-erstellen` den PR-Text formulieren.

## Ruecksprungregeln

- Bei unklarem Issue zurueck zu `github_issue-lesen`.
- Bei unklaren Issue-Beziehungen zurueck zu `github_issue-lesen` und GitHub-Kontext erneut lesen.
- Bei widerspruechlichen Abhaengigkeiten zurueck zur Scope- und Reihenfolgeplanung.
- Bei unerwartetem Verhalten oder Seiteneffekten zurueck zu `code_analyse`.
- Bei zu grossem Scope zurueck zu `code_implementierungsplanung`.
- Bei nicht automatisierbaren GitHub-Metadaten die Implementierung nicht blockieren, aber den fehlenden Pflege-Schritt im Issue- oder PR-Kommentar transparent nennen.

## Endergebnis

- geklaerter Issue-Scope inklusive relevanter Beziehungen
- begruendete Umsetzungsreihenfolge
- umgesetzte und verifizierte Aenderung je Arbeitseinheit
- Commit-Vorschlag oder Commit-Scope je Arbeitseinheit
- kommentierte und geschlossene Issues, soweit ihr Scope erfuellt ist
- PR-fertige Beschreibung
