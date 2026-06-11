# Skill: GitHub Issue Lesen

## Zweck

Uebersetze ein bestehendes Ticket in eine klare, technisch verwertbare Arbeitsgrundlage.

## Wann verwenden

- Vor der Implementierung eines Issues.
- Wenn ein Ticket unklar, breit oder unvollstaendig formuliert ist.
- Wenn Akzeptanzkriterien erst aus dem Text herausgearbeitet werden muessen.

## Input

- Issue-Text oder Ticketbeschreibung
- optional: Kommentare, Links, Screenshots oder verknuepfte Artefakte

## Vorgehen

1. Ziel und erwartetes Ergebnis des Tickets zusammenfassen.
2. Scope und Nicht-Ziele herausarbeiten.
3. Unklarheiten, Widersprueche und fehlende Informationen markieren.
4. Technische Annahmen und betroffene Bereiche ableiten.
5. Einen sinnvollen naechsten Arbeitsschritt empfehlen.

## Empfohlene Kommandos

```powershell
gh issue view <issue-nummer> --comments
gh issue view <issue-nummer> --json title,body,state,labels,assignees,comments,url
gh issue list --state open --limit 20
```

Wenn das Issue mit Pull Requests oder Branches verknuepft ist:

```powershell
gh issue view <issue-nummer> --web
gh pr list --search "<issue-nummer>"
```

`<issue-nummer>` muss aus User-Anweisung, Branch-Namen, Commit-Text oder Repository-Kontext abgeleitet werden.

## Output

- Kurzfassung
- Ziel
- Scope
- Nicht-Ziele
- Unklarheiten
- technische Annahmen
- naechster Schritt

## Qualitätskriterien

- Nicht einfach nur umformulieren, sondern verdichten.
- Fehlende Informationen explizit benennen.
- Ticketinhalt nicht stillschweigend erweitern.
