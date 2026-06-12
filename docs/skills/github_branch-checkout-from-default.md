# Skill: GitHub Branch Checkout From Default

## Zweck

Einen aufgabenbezogenen Arbeitsbranch von einer aktuellen Standardbasis erstellen oder bestaetigen, dass bereits ein passender Branch aktiv ist.

## Verwenden

- Vor Beginn einer neuen Aufgabe.
- Wenn Arbeit von `develop`, `main` oder einer expliziten Basis starten soll.
- Nicht verwenden, wenn bewusst auf dem aktuellen Branch weitergearbeitet werden soll.

## Vorgehen

1. Aktuellen Branch und Arbeitsstatus pruefen, z. B. `git status --short --branch`.
2. Bestimmen, ob bereits ein passender Arbeitsbranch aktiv ist.
3. Wenn ein passender Arbeitsbranch aktiv ist, keinen neuen Branch erstellen und Status melden.
4. Basisbranch nach Prioritaet bestimmen: explizite User-Vorgabe, Workflow-/Issue-Vorgabe, Remote-Default, `develop`, `main`, `master`.
5. Remote-Stand holen, z. B. `git fetch origin`.
6. Vor dem Checkout pruefen, ob die lokale Basis mit dem Remote-Branch aktuell ist.
7. Basis per Fast-Forward aktualisieren, falls Remote voraus ist.
8. Gewuenschten Branch-Namen gegen lokale und Remote-Branches pruefen.
9. Bei lokalen uncommitted Aenderungen nachfragen, bevor sie auf einen neuen Branch mitgenommen werden.
10. Aufgabenbezogenen Branch nach Konvention erstellen.
11. Branch und mitgenommene lokale Aenderungen melden.

## Kommandos

```powershell
git status --short --branch
git fetch origin
git branch --list
git branch --remotes
git switch <basis-branch>
git merge --ff-only origin/<basis-branch>
git switch -c <neuer-branch> <basis-branch>
git status --short --branch
```

Platzhalter aus Aufgabe, Basisbranch und Branch-Namenskonvention ableiten.

## Grenzen

- Extern wirksam arbeiten: Branch kann tatsaechlich gewechselt oder erstellt werden.
- Keine lokalen Aenderungen verwerfen.
- Lokale uncommitted Aenderungen nicht automatisch mitnehmen.
- Keine Rebase-, Reset- oder Merge-Commits erzeugen.
- Basisbranch nicht raten, wenn er unklar ist.
- Wenn nach Prioritaetenliste keine Basis klar ist, stoppen und nachfragen.
- Nur Fast-Forward-Aktualisierung der Basis verwenden.
- Wenn die Basis nicht per Fast-Forward aktualisiert werden kann, stoppen und Blocker melden.
- Nicht von veralteter lokaler Basis branchen.
- Branch-Namen nicht doppelt lokal oder remote verwenden.
- Branch-Namenskonvention: `feature/<kurzer-scope>`, `bugfix/<kurzer-scope>`, `refactor/<kurzer-scope>` oder `chore/<kurzer-scope>`.
- Bei Issue-Bezug: `<typ>/<issue-number>-<kurzer-scope>`.

## Output

- Basisbranch
- neuer Branch
- Hinweis, wenn kein Checkout noetig war
- Hinweis auf lokale Aenderungen

## Qualitaetskriterien

- Basis nicht raten, wenn sie unklar ist.
- Keine lokalen Aenderungen verwerfen.
- Branch-Name muss Aufgabe und Scope erkennen lassen.
