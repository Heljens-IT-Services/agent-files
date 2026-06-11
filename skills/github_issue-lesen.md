# Skill: GitHub Issue Lesen

## Zweck

Ein GitHub-Issue in umsetzbare Anforderungen uebersetzen.

## Verwenden

- Vor Planung oder Implementierung eines Issues.
- Wenn Ziel, Scope, Nicht-Ziele oder offene Fragen aus dem Ticket geklaert werden muessen.

## Vorgehen

1. Issue und relevante Kommentare lesen.
2. Ziel, Scope und Nicht-Ziele extrahieren.
3. Akzeptanzkriterien und technische Annahmen ableiten.
4. Unklarheiten oder Widersprueche markieren.
5. Naechsten sinnvollen Schritt benennen.

## Empfohlene Kommandos

```powershell
gh issue view <issue-nummer> --comments
gh issue view <issue-nummer> --json title,body,state,labels,assignees,comments,url
gh pr list --search "<issue-nummer>"
```

## Output

- Kurzfassung
- Ziel
- Scope und Nicht-Ziele
- Akzeptanzkriterien
- Unklarheiten
- naechster Schritt

## Qualitaetskriterien

- Ticket nicht stillschweigend erweitern.
- Fehlende Informationen explizit benennen.
- Kommentare beruecksichtigen, wenn sie fachlich relevant sind.
