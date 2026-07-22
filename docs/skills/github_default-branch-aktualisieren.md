# Skill: GitHub Default Branch Aktualisieren

## Zweck

Nach einem verifizierten Pull-Request-Merge auf den Default-Branch zurueckkehren und ihn sicher per Fast-Forward aktualisieren.

## Verwenden

- Nach einem erfolgreichen, verifizierten Merge, wenn der lokale Checkout auf die aktuelle Standardbasis wechseln soll.
- Nicht verwenden, solange der Merge nicht bestaetigt oder der Arbeitsbaum nicht sauber ist.

## Vorgehen

1. Verifizierten Merge-Kontext und Repository bestimmen.
2. Arbeitsbaum auf lokale Aenderungen pruefen und bei Aenderungen stoppen.
3. Default-Branch aus dem Remote-Repository lesen.
4. Remote-Stand holen.
5. Auf den lokalen Default-Branch wechseln.
6. Den Default-Branch ausschliesslich per Fast-Forward auf den Remote-Stand aktualisieren.
7. Aktuellen Branch und Synchronisationsstatus pruefen.

## Kommandos

```powershell
git status --short --branch
gh repo view --json defaultBranchRef --jq .defaultBranchRef.name
git fetch <remote>
git switch <default-branch>
git merge --ff-only <remote>/<default-branch>
git status --short --branch
```

## Grenzen

- Zustandsveraendernd arbeiten: Der lokale Branch wird gewechselt und aktualisiert.
- Keine lokalen Aenderungen verwerfen, stashen oder automatisch mitnehmen.
- Kein Rebase, Reset oder Merge-Commit.
- Default-Branch und Remote nicht raten.
- Arbeitsbranch weder lokal noch remote loeschen.
- Bei nicht moeglichem Fast-Forward stoppen und den Arbeitsbranch beziehungsweise vorhandene Daten unveraendert lassen.

## Output

- Default-Branch und Remote
- aktualisierter Commit-Stand
- bestaetigter sauberer Arbeitsbaum
- Blocker, falls kein sicherer Wechsel oder Fast-Forward moeglich war

## Qualitaetskriterien

- Der Abschluss muss einen sauberen Arbeitsbaum auf dem mit dem Remote synchronisierten Default-Branch nachweisen.
