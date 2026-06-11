# Skills

Diese Dateien beschreiben atomare, wiederverwendbare Agentenfaehigkeiten.

Jeder Skill soll:
- einen klaren Zweck haben,
- in mehreren Kontexten einsetzbar sein,
- einen definierten Input und Output haben,
- moeglichst wenig Orchestrierung enthalten.

Namenskonvention:
- Programmiernahe Skills verwenden den Prefix `code_`, zum Beispiel `code_analyse.md`.
- GitHub-spezifische Skills verwenden den Prefix `github_`, zum Beispiel `github_issue-lesen.md`.
- Git-nahe Skills koennen den Prefix `git_` verwenden, wenn ihr Scope primär Branches, Commits oder Push/Pull betrifft.
- Der Dateiname soll den fachlichen Scope sichtbar machen, nicht nur die Aktivitaet.

In diesem Repository werden Branch-Checkout von der Standardbasis und Commit-Vorbereitung als GitHub-nahe Skills modelliert und daher mit `github_` benannt.

Empfohlene Nutzung:
- Einen Skill direkt verwenden, wenn nur ein einzelner Arbeitsschritt benoetigt wird.
- Mehrere Skills ueber Dateien in `workflows/` kombinieren, wenn ein groesserer Ablauf ausgefuehrt werden soll.
