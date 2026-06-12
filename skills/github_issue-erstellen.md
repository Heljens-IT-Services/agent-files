# Skill: GitHub Issue Erstellen

## Zweck

Aus vorhandenem Kontext ein strukturiertes GitHub-Issue erstellen und nachgelagerte GitHub-Metadaten setzen.

## Verwenden

- Wenn aus Kontext ein neues GitHub-Issue entstehen soll.
- Wenn `Task`, `Story`, `Spike` oder `Epic` samt GitHub-Metadaten gesetzt werden muessen.
- Wenn vorhandene Parent/Child-, Blocked-by- oder andere relevante Issue-Beziehungen gesetzt werden muessen.
- Nicht verwenden, wenn Anforderungen oder Scope erst geklaert werden muessen. Dann `anforderungsklaerung` nutzen.

## Vorgehen

1. Zugrundeliegenden Kontext, Repository und Ziel des neuen Issues pruefen.
2. Vorhandene GitHub-Issue-Templates aus `.github/ISSUE_TEMPLATE` verpflichtend lesen.
3. Passendes GitHub-Issue-Template ermitteln und dessen Struktur fuer den Body verwenden; falls kein Template vorhanden ist, ein strukturiertes Standard-Issue erstellen.
4. Duplikate oder sehr aehnliche offene Issues mit gezielter Suche pruefen.
5. Bei moeglichem Duplikat Optionen vorschlagen und User-Entscheidung abwarten.
6. Titel, Problem, Ziel, Scope, Nicht-Ziele und Akzeptanzkriterien aus dem vorhandenen Kontext formulieren.
7. GitHub-Issue-Type festlegen: `Task`, `Story`, `Spike` oder `Epic`.
8. Relevante Beziehungen aus vorhandenem Kontext bestimmen.
9. Issue erstellen.
10. Nachgelagert den korrekten GitHub-Issue-Type setzen.
11. Nachgelagert vorhandene Relationships setzen, z. B. Parent/Child oder Blocked-by.

## Grenzen

- Extern wirksam arbeiten: Issue wird tatsaechlich in GitHub erstellt.
- Keine Anforderungen oder Beziehungen erfinden.
- Keine fehlenden Anforderungen klaeren. Dann `anforderungsklaerung` nutzen.
- Keine technische Planung ersetzen. Dann `code_implementierungsplanung` nutzen.
- Issue-Templates aus `.github/ISSUE_TEMPLATE` verpflichtend lesen und beruecksichtigen.
- Wenn kein Issue-Template vorhanden ist, kein Blocker; stattdessen Standardstruktur verwenden.
- Vor Erstellung gezielte Duplikatpruefung durchfuehren.
- Bei moeglichem Duplikat nicht automatisch erstellen.
- Bei moeglichem Duplikat Optionen vorschlagen: vorhandenes Issue verfeinern, neues Issue verlinkt erstellen, neues Issue als Beziehung erstellen, gefundenes Duplikat schliessen und neues Issue erstellen, oder Erstellung abbrechen.
- Bestehende Issues nur nach expliziter User-Entscheidung aktualisieren oder schliessen.
- GitHub-Issue-Type immer explizit setzen; damit ist nicht ein Label gemeint.
- Bei unklarem GitHub-Issue-Type nachfragen, nicht raten.
- Labels sind nicht praeferiert und ersetzen keine Issue-Type- oder Relationship-Pflege.
- Labels nur setzen, wenn der User oder das Issue-Template sie explizit vorgibt.
- Relationships nur setzen, wenn sie aus vorhandenem Kontext hervorgehen.
- Fehlende GitHub-Authentifizierung, fehlende Repository-Zuordnung oder fehlende Rechte als Blocker melden.
- Geeignete GitHub-Kommandos oder API-Aufrufe verwenden, z. B. `gh issue create`, `gh api` oder GraphQL fuer Issue-Type und Relationships.

## Output

- Titel
- GitHub-Issue-Type
- Body
- Parent/Child-Beziehungen
- Blocked-by-Beziehungen
- Issue-URL oder Issue-Nummer
- gesetzte Metadaten
- nicht gesetzte Metadaten mit Grund, falls relevant

## Qualitaetskriterien

- GitHub-Issue-Type immer explizit setzen; Label ersetzen den Issue-Type nicht.
- Beziehungen setzen, wenn sie aus dem Kontext hervorgehen.
- Issue-Body muss zur Template-Struktur passen.
- Fehlende Kontextteile nicht auffuellen oder verstecken.
