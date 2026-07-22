# Workflow: Finish

## Ziel

Einen bereits umgesetzten und vom User freigegebenen Arbeitsbranch mit `/finish` sicher committen, veroeffentlichen, pruefen, mergen und auf die aktualisierte Standardbasis zurueckfuehren.

## Verwenden

- Wenn der User `/finish` oder gleichbedeutend den vollstaendigen Branch-Abschluss beauftragt.
- Wenn Implementierung und taskbezogene lokale Verifikation bereits abgeschlossen sind oder im Workflow abgeschlossen werden koennen.
- Nicht verwenden, um Implementierung, Fehlerbehebung oder fachliche Freigabe zu ersetzen.

## Reifekriterien

- Ein aufgabenbezogener Arbeitsbranch ist aktiv.
- Task-Scope und taskbezogene Aenderungen sind eindeutig.
- Der User hat den vollstaendigen Abschluss einschliesslich Commit, Push, Pull Request, Check-Beobachtung und Merge ausdruecklich beauftragt.
- Repository, Remote, Default-Branch und Basis des Pull Requests sind aufloesbar.

## Verwendete Skills

- `code_testen`
- `code_diff-review`
- `github_commit-push`
- `github_pr-erstellen`
- `github_pr-checks-beobachten`
- `github_pr-merge`
- `github_default-branch-aktualisieren`

## Ablauf

1. `PROJECT.md`, Repository-Kontext, aktuellen Branch, Working Tree, Remote, Default-Branch und taskbezogenen Scope bestimmen.
2. Stoppen, wenn ein Integrationsbranch aktiv ist, der Task-Scope unklar ist oder fremde Aenderungen nicht sicher vom Task getrennt werden koennen.
3. Mit `code_testen` die fuer die Aenderung relevanten lokalen Pruefungen ausfuehren oder einen bereits belastbaren Teststatus bestaetigen.
4. Mit `code_diff-review` den gesamten taskbezogenen Aenderungssatz pruefen und nur bei `versandbereit` oder `versandbereit mit Hinweisen` fortfahren.
5. Mit `github_commit-push` ausschliesslich taskbezogene Aenderungen committen und zum konfigurierten Remote pushen.
6. Mit `github_pr-erstellen` einen vorhandenen Pull Request fuer den Branch wiederverwenden oder gegen die aufgeloeste Basis erstellen. `/finish` gilt fuer diesen Workflow als ausdrueckliche Anweisung, den Pull Request als Ready for Review bereitzustellen.
7. Mit `github_pr-checks-beobachten` die erforderlichen Checks fuer den unveraenderten Pull-Request-Head bis zu einem terminalen Zustand beobachten.
8. Nur bei vollstaendig erfolgreichen erforderlichen Checks und erfuellten Repository-Regeln mit `github_pr-merge` und der aufgeloesten Merge-Methode mergen; eine erforderliche Merge Queue bis zum terminalen Ergebnis beobachten.
9. Nach verifiziertem Merge mit `github_default-branch-aktualisieren` auf den Default-Branch wechseln und ihn per Fast-Forward aktualisieren.
10. Commit, Pull Request, Check-Ergebnis, Merge und lokalen Abschlusszustand zusammenfassen.

## Ruecksprungregeln

- Bei fehlgeschlagenen lokalen Pruefungen zur passenden Implementierung oder Fehlerbehebung zurueckkehren; keine beliebigen Fehler ausserhalb des Task-Scopes beheben.
- Bei `code_diff-review` mit Bewertung `nicht versandbereit` zur passenden Umsetzung zurueckkehren.
- Bei einem nach der Check-Beobachtung veraenderten Pull-Request-Head die Checks erneut beobachten.
- Bei fehlgeschlagenen oder abgebrochenen Checks, Konflikten, fehlenden Reviews, unklarer Merge-Methode oder fehlenden Rechten stoppen und den Arbeitsbranch aktiv lassen.
- Wenn der Merge nicht verifiziert werden kann, nicht auf den Default-Branch wechseln.

## Endergebnis

- taskbezogene Aenderungen sind bewusst committed und gepusht
- ein vorhandener Pull Request wurde wiederverwendet oder ein passender Pull Request erstellt
- erforderliche Checks sind fuer den gemergten Head-Commit erfolgreich
- der Pull Request ist regelkonform gemergt
- der lokale Checkout steht auf dem per Fast-Forward aktualisierten Default-Branch

## Grenzen

- `/finish` umgeht keine Sicherheits-, Review-, Berechtigungs-, Branch- oder Check-Regeln.
- Keine fremden oder nicht taskbezogenen Aenderungen committen.
- Kein Force-Push, kein `--admin`, kein ausdrueckliches Auto-Merge und keine Umgehung erforderlicher Checks.
- Keine festen Annahmen zu Remote, Default-Branch, PR-Basis oder Merge-Methode treffen.
- Keine beliebigen CI-Fehler ausserhalb des Task-Scopes reparieren.
- Bei jedem Fehler oder Blocker bleibt der Arbeitsbranch erhalten; lokale oder entfernte Branches werden nicht automatisch geloescht.
