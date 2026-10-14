# AGENTS.md

## Einstiegspunkt

Nutzeraufträge beginnen beim [Koordinator](https://heljens-it-services.github.io/agent-files/roles/koordinator/KOORDINATOR.md). Er nutzt das [Rollenverzeichnis](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) und die [Command-Regeln](https://heljens-it-services.github.io/agent-files/COMMANDS.md) für direkte Zuweisungen.

[MUST] Ein ausdrücklich zugewiesener Spezialist startet mit seiner eigenen Rollen-Markdown-Datei unter `roles/<rollen-id>/<ROLLEN-ID>.md`. Er lädt ausschließlich deren direkte, auftragsrelevante Quellen und die anwendbare repository-lokale `PROJECT.md`. Die Kommunikation erfolgt über den Koordinator.

Diese Datei dient der Navigation. Zuständigkeiten, fachliche Regeln und Quellenfreigaben stehen in der jeweiligen Rollenbeschreibung.

[MUST] Im Quellrepository `agent-files` gilt zusätzlich `PROJECT.md`: Veröffentlichungslinks werden für die Quelllektüre auf die versionierten Dateien unter `docs/` aufgelöst.
