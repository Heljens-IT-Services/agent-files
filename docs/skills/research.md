# Skill: Research

## Zweck

Frei recherchieren, um externen, repo-uebergreifenden oder issue-bezogenen Kontext belastbar zusammenzufassen.

## Verwenden

- Wenn aktuelle, externe oder nicht lokal vorhandene Informationen gebraucht werden.
- Wenn Web, Online-Dokumentation, Anbieterinformationen, Standards, Releases, Preise, Marktinformationen, andere GitHub-Repositories, Issues oder PRs relevant sind.
- Wenn vorhandener lokaler Kontext durch externe Quellen ergaenzt oder verifiziert werden soll.
- Nicht verwenden, wenn nur lokaler Code gelesen werden soll. Dann `code_lesen` nutzen.
- Nicht verwenden, wenn Optionen interaktiv entwickelt werden sollen. Dann `brainstorming` nutzen.
- Nicht verwenden, wenn Code oder Laufzeitverhalten bewertet werden soll. Dann `code_analyse` nutzen.

## Vorgehen

1. Recherchefrage und benoetigten Aktualitaetsgrad klaeren.
2. Relevante Quellentypen bestimmen: offizielle Dokumentation, Spezifikationen, Release Notes, GitHub-Repositories, Issues, PRs, Blogposts oder Marktquellen.
3. Primaerquellen bevorzugen, besonders bei technischen, rechtlichen, finanziellen oder sicherheitsrelevanten Themen.
4. Quellen lesen, vergleichen und Widersprueche mit beteiligten Quellen markieren.
5. Ergebnisse knapp nach Fakten, Einordnung und Unsicherheiten strukturieren.
6. Quellen standardmaessig in der Antwort nennen.

## Kommandos

```powershell
gh repo view <owner>/<repo>
gh issue view <issue-nummer> --repo <owner>/<repo> --comments
gh pr view <pr-nummer> --repo <owner>/<repo> --comments
gh search issues "<suchbegriff>" --repo <owner>/<repo>
```

Websuche oder Browser-Werkzeuge verwenden, wenn Online-Quellen benoetigt werden.

## Grenzen

- Keine Dateien aendern.
- Kein Artefakt erstellen, ausser der User fordert es explizit.
- Keine unsicheren Informationen als Fakt darstellen.
- Keine veralteten Informationen verwenden, wenn Aktualitaet fuer die Frage relevant ist.
- Bei aktuellen oder zeitkritischen Themen Online-Recherche durchfuehren.
- Keine umfangreiche Marktrecherche starten, wenn eine gezielte Quellenpruefung reicht.
- Bei widerspruechlichen Quellen keine eigene Rangentscheidung erzwingen.

## Artefakt

- Nur erstellen, wenn der User es explizit verlangt.
- Dateiname: `docs/research-<scope>.md`.
- Inhalt entspricht dem Output dieses Skills.

## Output

- Kurzantwort oder strukturierte Zusammenfassung
- relevante Fakten
- Quellen mit Links oder konkreten Referenzen
- Widersprueche oder Unsicherheiten
- offene Punkte, falls die Quellenlage nicht reicht

## Qualitaetskriterien

- Primaerquellen vor Sekundaerquellen.
- Aktualitaet explizit beachten.
- Fakten, Interpretation und Annahmen trennen.
- Keine Quellen aufblasen; nur relevante Quellen nennen.
- Quellen standardmaessig nennen.
- Widersprueche klar benennen und den jeweiligen Quellen zuordnen.
- Bei technischen Fragen offizielle Dokumentation oder Repository-Quellen bevorzugen.
