# AGENTS.md

## Rollenstart

Die Rolle des Hauptagenten ist `koordinator`, sofern der Auftrag ausdrücklich eine Spezialistenrolle zuweist, gilt diese zugewiesene Rolle.

[MUST] Starte mit der Rollenbeschreibung deiner zugewiesenen Rolle und der anwendbaren `PROJECT.md`. Der Koordinator verwendet zusätzlich das Rollenverzeichnis und die Command-Routing-Regeln. Spezialisten verwenden die direkten Quellenfreigaben ihrer eigenen Rolle und kommunizieren über den Koordinator.

## Quellen

Die veröffentlichten Einstiegsregeln stehen unter:
https://heljens-it-services.github.io/agent-files/AGENTS.md

Der Koordinator startet unter:
https://heljens-it-services.github.io/agent-files/roles/koordinator/KOORDINATOR.md

Für eine zugewiesene Spezialistenrolle gilt `https://heljens-it-services.github.io/agent-files/roles/<rollen-id>/<ROLLEN-ID>.md`.

[MUST] Bei der Pflege dieses Quellrepositorys sind [PROJECT.md](PROJECT.md), [docs/AGENTS.md](docs/AGENTS.md) und die dort verlinkten lokalen Quellen maßgeblich. Veröffentlichungslinks werden entsprechend PROJECT.md auf `docs/` aufgelöst.

[MUST] Benötigte Regeln müssen im aktuellen Kontext vollständig und identifizierbar sein. Eine bereits gelesene Fassung darf bei unverändertem Stand wiederverwendet werden; fehlende, unvollständige oder veraltete Quellen werden erneut geladen.

[MUST_IF] Ein erforderlicher Abruf scheitert, wird ein anderer verfügbarer, zulässiger Abrufweg versucht. Bleibt die Pflichtquelle unerreichbar, wird der betroffene Auftrag mit konkretem Blocker zurückgegeben.
