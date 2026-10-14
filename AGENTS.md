# AGENTS.md

## Rollenstart

Die Rolle des Hauptagenten ist `koordinator`, sofern der Auftrag ausdrücklich eine Spezialistenrolle zuweist, gilt diese zugewiesene Rolle.

[MUST] Starte mit der Rollenbeschreibung deiner zugewiesenen Rolle und den geltenden Root- und lokalen `PROJECT.md`-Dateien. Der Koordinator verwendet zusätzlich das Rollenverzeichnis und die Command-Routing-Regeln. Spezialisten verwenden die direkten Quellenfreigaben ihrer eigenen Rolle und kommunizieren über den Koordinator.

## Quellen

Die veröffentlichten Einstiegsregeln stehen unter:
https://heljens-it-services.github.io/agent-files/AGENTS.md

Der Koordinator startet unter:
https://heljens-it-services.github.io/agent-files/roles/koordinator/KOORDINATOR.md

Für eine zugewiesene Spezialistenrolle gilt `https://heljens-it-services.github.io/agent-files/roles/<rollen-id>/<ROLLEN-ID>.md`.

[MUST] Bei der Pflege dieses Quellrepositorys sind [PROJECT.md](PROJECT.md), [docs/AGENTS.md](docs/AGENTS.md) und die dort verlinkten lokalen Quellen maßgeblich. Veröffentlichungslinks werden entsprechend PROJECT.md auf `docs/` aufgelöst.

[MUST] Benötigte Regeln müssen im aktuellen Kontext vollständig und identifizierbar sein. Eine bereits gelesene Fassung darf bei unverändertem Stand wiederverwendet werden; fehlende, unvollständige oder veraltete Quellen werden erneut geladen.

[MUST_IF] Ein erforderlicher Abruf scheitert, wird ein anderer verfügbarer, zulässiger Abrufweg versucht. Bleibt die Pflichtquelle unerreichbar, wird der betroffene Auftrag mit konkretem Blocker zurückgegeben.

## Projektkontext und Vorrang

[MUST] Lade zu Beginn des Auftrags die `PROJECT.md` im Repository-Root. Bei Arbeit in einer eigenständigen Teilsolution lade zusätzlich deren lokale `PROJECT.md` im Solution-Root, bevor du dort fachliche Dateien liest, Änderungen vornimmst, Kommandos ausführst oder Prüfungen startest. Ermittle den betroffenen Teilsolution-Scope aus dem Auftrag, dem vorhandenen Projektverzeichnis und der Repository-Struktur.

[MUST] Prüfe bei einem Wechsel des Repositorys oder der Teilsolution erneut, welche Root- und lokalen PROJECT-Regeln gelten. Bereits gelesene, vollständige und identifizierbare Fassungen dürfen bei unverändertem Stand wiederverwendet werden; fehlende, unvollständige oder veraltete Fassungen werden nachgeladen. Fehlt eine erforderliche PROJECT-Quelle oder bleibt ihr Scope unklar, melde die konkrete Kontextlücke vor der betroffenen Arbeit.

[PRIORITY] Für projektspezifische fachliche und technische Regeln gilt im jeweiligen Scope: lokale `PROJECT.md` der Teilsolution vor Root-`PROJECT.md` vor allgemeinen Rollenregeln. Nicht widersprochene Root-Regeln bleiben wirksam. Projektdokumente erweitern weder den zugewiesenen Auftrag noch Rollenbefugnisse, Quellenfreigaben oder Berechtigungen; direkte Nutzeranweisungen und höherrangige Sicherheits-, Datenschutz- und Plattformvorgaben bleiben maßgeblich.
