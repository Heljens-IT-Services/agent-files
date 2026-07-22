# Skill: GitHub PR Merge

## Zweck

Einen freigegebenen Pull Request mit der konfigurierten Merge-Methode zusammenfuehren und das Ergebnis pruefen.

## Verwenden

- Wenn der User den Merge ausdruecklich beauftragt hat.
- Wenn erforderliche Checks erfolgreich und Repository-Regeln erfuellt sind.
- Nicht verwenden, um Checks, Reviews, Konflikte oder Branch-Regeln zu umgehen.

## Vorgehen

1. Repository, Pull Request und ausdrueckliche Merge-Autorisierung bestimmen.
2. Pull-Request-Status, Draft-Status, Review-Entscheidung, Mergebarkeit und Head-Commit lesen.
3. Sicherstellen, dass das erfolgreiche Check-Ergebnis zum aktuellen Head-Commit gehoert.
4. Merge-Methode nach Prioritaet bestimmen: User-Vorgabe, `PROJECT.md`, eindeutige etablierte Repository-Konvention, eindeutige Repository-Konfiguration.
5. Stoppen, wenn erforderliche Reviews, Checks oder andere Branch-Regeln nicht erfuellt sind, Konflikte bestehen oder die Merge-Methode mehrdeutig bleibt.
6. Pull Request ohne administrative Umgehung und gebunden an den geprueften Head-Commit mit der bestimmten Methode mergen oder in eine erforderliche Merge Queue einreihen.
7. Wenn GitHub eine Merge Queue verlangt, deren erforderliche Checks und Pull-Request-Zustand bis zu einem terminalen Ergebnis beobachten.
8. Zustand erneut lesen und nur `MERGED` mit Merge-Zeitpunkt und Merge-Commit als Erfolg bewerten.

## Kommandos

```powershell
gh pr view <pr-nummer> --repo <org>/<repo> --json state,isDraft,reviewDecision,mergeable,mergeStateStatus,headRefOid,url
gh repo view <org>/<repo> --json mergeCommitAllowed,squashMergeAllowed,rebaseMergeAllowed
gh pr merge <pr-nummer> --repo <org>/<repo> --merge --match-head-commit <head-sha>
gh pr merge <pr-nummer> --repo <org>/<repo> --squash --match-head-commit <head-sha>
gh pr merge <pr-nummer> --repo <org>/<repo> --rebase --match-head-commit <head-sha>
gh pr checks <pr-nummer> --repo <org>/<repo> --required --watch --interval 10
gh pr view <pr-nummer> --repo <org>/<repo> --json state,mergedAt,mergeCommit,url
```

Nur genau eine zur aufgeloesten Merge-Methode passende `gh pr merge`-Variante ausfuehren.

## Grenzen

- Extern wirksam arbeiten: Der Pull Request wird tatsaechlich gemergt.
- Kein `--admin`, kein ausdrueckliches `--auto` und keine Umgehung erforderlicher Checks oder Reviews verwenden.
- Eine vom Zielbranch vorgeschriebene Merge Queue darf erst nach erfolgreichen bisherigen Pflichtchecks verwendet werden und muss bis zum terminalen Ergebnis beobachtet werden.
- Draft-Pull-Requests nicht mergen.
- Keine Merge-Methode raten, wenn mehrere Methoden erlaubt und keine Praeferenz dokumentiert ist.
- Keine Konflikte beheben und keine neuen Commits erstellen.
- Den Source-Branch nicht automatisch loeschen.
- Bei unklarem oder veraendertem Head-Commit stoppen.

## Output

- Pull Request und Merge-Commit
- verwendete Merge-Methode
- verifizierter Merge- oder terminaler Merge-Queue-Status
- nicht ausgefuehrter Merge mit Blocker, falls relevant

## Qualitaetskriterien

- Merge nur nach ausdruecklicher Autorisierung.
- Schutzregeln nicht umgehen.
- Ergebnis nach der Mutation erneut pruefen.
