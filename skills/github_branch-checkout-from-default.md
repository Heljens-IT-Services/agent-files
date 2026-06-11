# Skill: GitHub Branch Checkout From Default

## Zweck

Einen Arbeitsbranch von der aktuellen Standardbasis erstellen.

## Verwenden

- Vor Beginn einer neuen Aufgabe.
- Wenn Arbeit von `develop`, `main` oder einer expliziten Basis starten soll.

## Vorgehen

1. Basisbranch bestimmen.
2. Remote-Stand holen.
3. Arbeitsstatus pruefen.
4. Basis per Fast-Forward aktualisieren.
5. Aufgabenbezogenen Branch erstellen.
6. Branch und mitgenommene lokale Aenderungen melden.

## Empfohlene Kommandos

```powershell
git status --short --branch
git fetch origin
git switch <basis-branch>
git merge --ff-only origin/<basis-branch>
git switch -c <neuer-branch> <basis-branch>
git status --short --branch
```

## Output

- Basisbranch
- neuer Branch
- Hinweis auf lokale Aenderungen

## Qualitaetskriterien

- Basis nicht raten, wenn sie unklar ist.
- Keine lokalen Aenderungen verwerfen.
- Branch-Name muss Aufgabe und Scope erkennen lassen.
