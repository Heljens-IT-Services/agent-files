# AGENTS.md

## Einstiegspunkt

Nutzeraufträge beginnen beim [Koordinator](https://heljens-it-services.github.io/agent-files/roles/koordinator/KOORDINATOR.md). Er nutzt das [Rollenverzeichnis](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) und die [Command-Regeln](https://heljens-it-services.github.io/agent-files/COMMANDS.md) für direkte Zuweisungen.

[MUST] Ein ausdrücklich zugewiesener Spezialist startet mit seiner eigenen Rollen-Markdown-Datei unter `roles/<rollen-id>/<ROLLEN-ID>.md`. Er lädt ausschließlich deren direkte, auftragsrelevante Quellen und die geltenden Root- und lokalen `PROJECT.md`-Dateien. Die Kommunikation erfolgt über den Koordinator.

Diese Datei dient der Navigation. Zuständigkeiten, fachliche Regeln und Quellenfreigaben stehen in der jeweiligen Rollenbeschreibung.

[MUST] Im Quellrepository `agent-files` gilt zusätzlich `PROJECT.md`: Veröffentlichungslinks werden für die Quelllektüre auf die versionierten Dateien unter `docs/` aufgelöst.

## Projektkontext und Vorrang

[MUST] Lade zu Beginn des Auftrags die `PROJECT.md` im Repository-Root. Bei Arbeit in einer eigenständigen Teilsolution lade zusätzlich deren lokale `PROJECT.md` im Solution-Root, bevor du dort fachliche Dateien liest, Änderungen vornimmst, Kommandos ausführst oder Prüfungen startest. Ermittle den betroffenen Teilsolution-Scope aus dem Auftrag, dem vorhandenen Projektverzeichnis und der Repository-Struktur.

[MUST] Prüfe bei einem Wechsel des Repositorys oder der Teilsolution erneut, welche Root- und lokalen PROJECT-Regeln gelten. Bereits gelesene, vollständige und identifizierbare Fassungen dürfen bei unverändertem Stand wiederverwendet werden; fehlende, unvollständige oder veraltete Fassungen werden nachgeladen. Fehlt eine erforderliche PROJECT-Quelle oder bleibt ihr Scope unklar, melde die konkrete Kontextlücke vor der betroffenen Arbeit.

[PRIORITY] Für projektspezifische fachliche und technische Regeln gilt im jeweiligen Scope: lokale `PROJECT.md` der Teilsolution vor Root-`PROJECT.md` vor allgemeinen Rollenregeln. Nicht widersprochene Root-Regeln bleiben wirksam. Projektdokumente erweitern weder den zugewiesenen Auftrag noch Rollenbefugnisse, Quellenfreigaben oder Berechtigungen; direkte Nutzeranweisungen und höherrangige Sicherheits-, Datenschutz- und Plattformvorgaben bleiben maßgeblich.
