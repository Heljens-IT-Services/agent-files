# Skill: GitHub Issue Lesen

## Zweck

Ein GitHub-Issue und seine Kommentare atomar lesen und den enthaltenen Kontext strukturiert wiedergeben.

## Verwenden

- Wenn Inhalt, Kommentare, Status oder Metadaten eines GitHub-Issues gelesen werden sollen.
- Vor Anforderungsklaerung, Planung oder Implementierung eines Issues.
- Nicht verwenden, um fehlende Anforderungen zu klaeren. Dann `anforderungsklaerung` nutzen.
- Nicht verwenden, um ein Issue in einen technischen Plan zu ueberfuehren. Dann `code_implementierungsplanung` nutzen.

## Vorgehen

1. Issue-Nummer, Repository und Lesefokus bestimmen.
2. Issue-Body, Kommentare und relevante GitHub-Metadaten lesen.
3. Im Default nur Ausgangs-Issue, Kommentare und direkt sichtbare Metadaten lesen.
4. Bei expliziter Anweisung wie "Graph lesen", "Parent/Children lesen" oder "blockierende Issues lesen" den angeforderten Beziehungskontext vollstaendig lesen.
5. Lange Kommentarverlaeufe zusammenfassen, statt jeden Kommentar einzeln wiederzugeben.
6. Standardmaessig still in den Agenten-Kontext laden.
7. Nur bei explizit verlangtem Output Inhalt strukturiert nach vorhandenen Informationen wiedergeben.
8. Widersprueche, fehlende Informationen oder offene Stellen markieren, ohne sie zu klaeren.

## Kommandos

```powershell
gh issue view <issue-nummer> --comments
gh issue view <issue-nummer> --json title,body,state,labels,assignees,milestone,comments,url
gh issue view <issue-nummer> --json id,number,title,body,state,comments,url
```

Fuer explizit angeforderten Beziehungskontext passende `gh api`- oder GraphQL-Leseaufrufe nutzen.

## Grenzen

- Read-only arbeiten.
- Keine GitHub-Aenderungen vornehmen.
- Keine Anforderungen erfinden oder stillschweigend erweitern.
- Keine technische Planung, Analyse oder Umsetzung durchfuehren.
- Ohne explizite Anweisung keine Issue-Beziehungen aktiv verfolgen.
- Auch im erweiterten Lesemodus Beziehungen nur wiedergeben, nicht Scope oder Reihenfolge daraus ableiten.
- PRs nur lesen, wenn der User sie explizit als Kontext nennt.
- Fehlende GitHub-Authentifizierung, fehlende Repository-Zuordnung oder nicht auffindbare Issues als Blocker melden.

## Output

- Standard: keine eigene Ausgabe, sondern Kontext laden.
- Bei explizit verlangtem Output: Kurzfassung, vorhandene Informationen aus Body und Kommentaren, relevante Metadaten, gelesene Issue-Beziehungen und sichtbare Widersprueche oder fehlende Informationen.

## Qualitaetskriterien

- Ticket nicht stillschweigend erweitern.
- Fehlende Informationen explizit benennen.
- Kommentare beruecksichtigen.
- Beobachtung und Ableitung trennen.
