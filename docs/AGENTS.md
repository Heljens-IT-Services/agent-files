# AGENTS.md

## Einstiegspunkt

Diese Datei dient ausschließlich als Navigation. Rollenfachwissen, Zuständigkeiten und freigegebene Ressourcen stehen in der jeweiligen Rollen-Markdown-Datei unter `roles/<rollen-id>/`.

[MUST] Der zugewiesene operative Agent öffnet direkt seine Rollen-Markdown-Datei und befolgt deren Pflichtlektüren und Lookup-Freigaben. Diese Datei ist keine Rollen-Pflichtlektüre und definiert keine operativen Fachregeln.

[MUST] Der Koordinator nutzt den Rollenindex [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) zur Auswahl der zu delegierenden Rollen-ID. Die operative Rolle lädt den Index nicht; sie verwendet ausschließlich ihre eigene Rollen-Markdown-Datei und die dort freigegebenen Quellen.

[MUST] Bei Arbeit im Quellrepository `agent-files` gelten zusätzlich die repositoryweiten Vorgaben aus `PROJECT.md`. Rollenbezogene Quelldateien und Lookup-Ressourcen werden aus dem Verzeichnis `docs/` gepflegt.

[MUST] Skills, Workflows und Technologien werden nur über die Freigaben und direkten Links in der eigenen Rollen-Markdown-Datei geladen. Kataloge dienen der Navigation und geben keine zusätzlichen Fachregeln frei.
