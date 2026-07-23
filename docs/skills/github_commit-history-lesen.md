# Skill: GitHub Commit History Lesen

## Zweck

Commits und gemergte Pull Requests eines Repositorys fuer einen abgegrenzten Zeitraum vollstaendig und read-only erfassen.

## Verwenden

- Wenn Commits und gemergte Pull Requests eines Repositorys fuer einen Bericht oder eine Auswertung benoetigt werden.
- Wenn Zeitraum, Repository und auszuwertender Branch feststehen.
- Nicht verwenden, um Aenderungen fachlich oder technisch zusammenzufassen. Das uebernimmt ein nachgelagerter Workflow oder `dokumentation`.
- Nicht verwenden, um offene Pull Requests, Issues oder allgemeine Repository-Fragen zu recherchieren. Dann `research` nutzen.

## Vorgehen

1. Repository, Branch, Zeitzone sowie exklusiven Start- und Endzeitpunkt bestimmen.
2. Repository- und Branch-Zugriff pruefen.
3. Alle vom Branch erreichbaren Commits anhand ihres Commit-Zeitpunkts innerhalb des halboffenen Intervalls `[Start, Ende)` lesen.
4. Alle in denselben Branch gemergten Pull Requests anhand ihres Merge-Zeitpunkts innerhalb desselben Intervalls lesen.
5. Commit-Daten mindestens mit SHA, Titel, Autor, Commit-Zeitpunkt und URL erfassen.
6. Pull-Request-Daten mindestens mit Nummer, Titel, Body, Autor, Merge-Zeitpunkt, Base, Head, Merge-Commit und URL erfassen.
7. Commits ihren Pull Requests zuordnen, soweit GitHub diese Beziehung bereitstellt; nicht zuordenbare Commits als eigenstaendig kennzeichnen.
8. Paginierung und Ergebnisgrenzen pruefen und nur bei vollstaendiger Abfrage abschliessen.

## Kommandos

```powershell
gh repo view <org>/<repo> --json nameWithOwner,defaultBranchRef,url
gh api --paginate "/repos/<org>/<repo>/commits?sha=<branch>&since=<start-iso>&until=<end-iso>&per_page=100"
gh pr list --repo <org>/<repo> --state merged --base <branch> --search "merged:<von-datum>..<bis-datum>" --limit 1000 --json number,title,body,author,mergedAt,mergeCommit,url,baseRefName,headRefName
gh api --paginate "/repos/<org>/<repo>/pulls?state=closed&base=<branch>&sort=updated&direction=desc&per_page=100"
gh api "/repos/<org>/<repo>/commits/<sha>/pulls"
```

- API-Ergebnisse anhand des Commit-Zeitpunkts beziehungsweise `mergedAt` auf `[Start, Ende)` filtern.
- Wenn die Pull-Request-Suche ihr Limit erreicht, die paginierte REST-Abfrage als vollstaendige Datenquelle verwenden.

## Grenzen

- Read-only arbeiten.
- Keine Branches, Commits, Pull Requests, Issues oder Repository-Einstellungen veraendern.
- Keine Commits anderer Branches aufnehmen, die vom ausgewaehlten Branch nicht erreichbar sind.
- Pull Requests nach `mergedAt`, Commits nach Commit-Zeitpunkt filtern; Erstellungs-, Update- und Autorzeitpunkte nicht als Ersatz verwenden.
- Merge-Commits und enthaltene Einzelcommits nicht als voneinander unabhaengige Aenderungen interpretieren.
- Bei abgeschnittenen, nicht paginierten oder wegen fehlender Rechte unvollstaendigen Ergebnissen die Historie nicht als vollstaendig ausgeben.
- Fehlende Pull-Request-Bodies, unklare Commit-Zuordnungen und abweichende Zeitangaben als Kontextluecken kennzeichnen.

## Output

- Repository, Branch, Zeitzone und exaktes Zeitintervall
- vollstaendige Liste der Commits
- vollstaendige Liste der gemergten Pull Requests
- Zuordnung zwischen Commits und Pull Requests
- eigenstaendige Commits
- Kontextluecken oder Blocker

## Qualitaetskriterien

- Zeitraumgrenzen muessen eindeutig und fuer beide Datenquellen identisch sein.
- Ergebnisse muessen paginiert und auf Vollstaendigkeit geprueft sein.
- Commit- und Pull-Request-Daten duerfen nicht doppelt als unabhaengige Aenderungen gezaehlt werden.
- Beobachtete Metadaten und abgeleitete Zuordnungen muessen unterscheidbar bleiben.
