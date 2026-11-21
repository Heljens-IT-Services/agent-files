# DEVELOPER.GitHubActions.md

Stand: 2026-10-18

## Zweck

Diese Datei gilt für GitHub-Actions-Workflows unter `.github/workflows/` sowie für wiederverwendbare Workflows und Composite Actions im Repository. Zugehörige allgemeine Developer-Regeln werden über [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md), weitere technologiespezifische Regeldateien über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst.

## Berechtigungen

[MUST] Jeder Workflow muss `permissions` auf oberster Ebene explizit setzen; der Default ist `contents: read`.

[MUST_IF] Wenn ein einzelner Job weitergehende Rechte benötigt, etwa `pull-requests: write` oder `id-token: write`, müssen diese nur auf Ebene dieses Jobs und nur im benötigten Umfang vergeben werden.

[MUST_NOT] `permissions: write-all` oder eine fehlende `permissions`-Angabe mit Verlass auf die Repository-Defaults dürfen nicht verwendet werden.

## Actions und Versionen

[MUST] Jede `uses`-Referenz muss mindestens auf ein Major-Tag wie `actions/checkout@v5` festgelegt sein.

[MUST_NOT] Actions dürfen nicht über Branch-Namen wie `@main` oder `@master` oder ohne Versionsangabe referenziert werden.

[SHOULD] Actions außerhalb der Organisationen `actions` und `github` sollen per vollständiger Commit-SHA mit nachgestelltem Versionskommentar gepinnt werden, zum Beispiel `uses: owner/action@<sha> # v1.2.3`. Abweichungen sind erlaubt, wenn das Projekt einen verifizierten Herausgeber ausdrücklich per Tag zulässt.

[MUST_IF] Wenn ein Repository Workflows unter `.github/workflows/` besitzt, muss das Ökosystem `github-actions` gemäß der [Dependabot-Leitplanke](https://heljens-it-services.github.io/agent-files/github/DEPENDABOT.md) in `.github/dependabot.yml` abgedeckt sein.

## Secrets und untrusted Input

[MUST] Secrets dürfen ausschließlich über den Kontext `secrets` oder über GitHub Environments mit passenden Schutzregeln in Workflows gelangen.

[MUST_NOT] Secrets dürfen nicht per `echo`, Debug-Ausgabe, Artefakt oder Cache offengelegt und nicht als Kommandozeilenargument an Tools übergeben werden, deren Aufruf protokolliert wird.

[MUST_IF] Wenn ein Wert zur Laufzeit aus einem Secret abgeleitet wird, muss er vor jeder Ausgabe mit `::add-mask::` maskiert werden.

[MUST] Untrusted Kontextwerte wie `github.event.pull_request.title`, `github.event.issue.body`, `github.head_ref` oder Kommentartexte müssen über `env` an Shell-Schritte übergeben und dort als quotierte Variable verwendet werden.

[MUST_NOT] Untrusted Kontextwerte dürfen nicht per `${{ ... }}` direkt in `run`-Skripte oder in `script`-Eingaben von `actions/github-script` interpoliert werden.

[MUST_NOT] Workflows mit `pull_request_target` oder `workflow_run` dürfen keinen Code aus einem fremden Fork oder Head-Branch auschecken, bauen oder ausführen.

[MUST_IF] Wenn ein Workflow Code aus Pull Requests prüft, muss er `pull_request` statt `pull_request_target` verwenden.

## Laufzeit und Ressourcen

[MUST] Jeder Job muss `timeout-minutes` mit einem realistischen Wert setzen.

[MUST_IF] Wenn ein Workflow durch `pull_request` oder Pushes auf Feature-Branches ausgelöst wird, muss er `concurrency` mit einer Gruppe je Workflow und Ref sowie `cancel-in-progress: true` verwenden.

[MUST_NOT_IF] `cancel-in-progress: true` darf nicht gesetzt werden, wenn ein Abbruch Deployments, Releases oder andere extern wirksame Schritte in einem inkonsistenten Zustand hinterlassen würde.

[SHOULD] Abhängigkeiten sollen über das integrierte Caching der Setup-Actions oder über `actions/cache` mit Schlüsseln aus Lockfile-Hashes zwischengespeichert werden. Abweichungen sind erlaubt, wenn Caching für den Job keinen messbaren Nutzen bringt.

[MUST_NOT] Caches dürfen keine Secrets, Zugangsdaten oder Build-Ausgaben mit Umgebungsgeheimnissen enthalten.

## Struktur und Wiederverwendung

[MUST_IF] Wenn dieselbe Job- oder Schrittfolge in mehreren Workflows benötigt wird, muss sie als wiederverwendbarer Workflow über `workflow_call` oder als Composite Action gekapselt werden.

[MUST_NOT] Workflow-Logik darf nicht per Copy-Paste zwischen Workflows dupliziert werden.

[SHOULD] Mehrzeilige oder verzweigte Shell-Logik soll in versionierte Skripte im Repository ausgelagert werden, statt umfangreich inline in `run` zu stehen.

[MUST] Workflow- und Jobnamen müssen stabil und sprechend sein, weil Jobnamen als Namen erforderlicher Status-Checks in Branch-Schutzregeln verwendet werden.

[MUST_IF] Wenn ein Job- oder Workflow-Name umbenannt wird, der als erforderlicher Status-Check konfiguriert sein kann, muss die Umbenennung im Arbeitsabschluss mit dem Hinweis auf anzupassende Branch-Schutzregeln gemeldet werden.

[SHOULD] Runner-Images sollen mit expliziter Version wie `ubuntu-24.04` gewählt werden, wenn reproduzierbares Verhalten wichtiger ist als automatische Aktualisierung.
