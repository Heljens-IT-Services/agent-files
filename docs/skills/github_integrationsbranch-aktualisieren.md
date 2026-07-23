# Skill: GitHub Integrationsbranch Aktualisieren

## Zweck

Nach einem verifizierten Pull-Request-Merge nach `develop` auf den Integrationsbranch wechseln und ihn sicher per Fast-Forward aktualisieren.

## Verwenden

- Nach einem erfolgreichen, verifizierten Feature- oder Task-Merge nach `develop`.
- Nicht verwenden, solange der Merge nicht bestaetigt oder der Arbeitsbaum nicht sauber ist.
- Nicht fuer die Aktualisierung des Default-Branches verwenden; dafuer `github_default-branch-aktualisieren` nutzen.

## Vorgehen

1. Verifizierten Merge-Kontext, Repository und Remote bestimmen.
2. Bestaetigen, dass der Pull Request nach `develop` gemergt wurde.
3. Arbeitsbaum auf lokale Aenderungen pruefen und bei Aenderungen stoppen.
4. Remote-Stand holen und die Existenz von `<remote>/develop` bestaetigen.
5. Auf den lokalen Branch `develop` wechseln.
6. `develop` ausschliesslich per Fast-Forward auf `<remote>/develop` aktualisieren.
7. Aktuellen Branch und Synchronisationsstatus pruefen.

## Kommandos

```powershell
git status --short --branch
git fetch <remote>
git rev-parse --verify <remote>/develop
git switch develop
git merge --ff-only <remote>/develop
git status --short --branch
```

## Grenzen

- Zustandsveraendernd arbeiten: Der lokale Branch wird gewechselt und aktualisiert.
- Keine lokalen Aenderungen verwerfen, stashen oder automatisch mitnehmen.
- Kein Rebase, Reset oder Merge-Commit.
- Remote nicht raten.
- Arbeitsbranch weder lokal noch remote loeschen.
- Bei nicht moeglichem Fast-Forward stoppen und vorhandene Daten unveraendert lassen.

## Output

- Integrationsbranch und Remote
- aktualisierter Commit-Stand
- bestaetigter sauberer Arbeitsbaum
- Blocker, falls kein sicherer Wechsel oder Fast-Forward moeglich war

## Qualitaetskriterien

- Der Abschluss muss einen sauberen Arbeitsbaum auf dem mit dem Remote synchronisierten Branch `develop` nachweisen.
