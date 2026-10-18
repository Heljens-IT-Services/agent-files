# DEVELOPER.ShellScripts.md

Stand: 2026-10-18

## Zweck

Diese Datei gilt für versionierte PowerShell- und Bash-Skripte im Repository. Zugehörige allgemeine Developer-Regeln werden über [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md), weitere technologiespezifische Regeldateien über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst. Die Ausführung dokumentierter Kommandos in einer anderen Shell regelt [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md).

## Shell-Auswahl

[SHOULD] Neue Skripte sollen plattformübergreifend in PowerShell 7 (`pwsh`) geschrieben werden. Abweichungen sind erlaubt, wenn `PROJECT.md`, die Zielumgebung oder bestehende Skripte des Projekts eine andere Shell vorgeben.

[ALLOW_IF] Bash darf verwendet werden, wenn das Skript ausschließlich in Linux- oder Container-Umgebungen läuft oder das Projekt Bash vorgibt.

[MUST_NOT] Skripte dürfen nicht auf Windows PowerShell 5.1 oder `cmd` aufbauen, außer `PROJECT.md` oder die Zielumgebung verlangt dies ausdrücklich.

## PowerShell

[MUST] PowerShell-Skripte müssen mit `#Requires -Version 7` beginnen und vor der ersten Anweisung `Set-StrictMode -Version Latest` sowie `$ErrorActionPreference = 'Stop'` setzen.

[MUST] Eingaben müssen über einen `param()`-Block mit Typen, `[Parameter(Mandatory)]` für Pflichtwerte und Validierungsattributen wie `[ValidateSet()]` oder `[ValidateScript()]` entgegengenommen werden.

[MUST_IF] Wenn ein PowerShell-Skript Dateien, Ressourcen oder externen Zustand verändert oder löscht, muss es `[CmdletBinding(SupportsShouldProcess)]` deklarieren und die Änderung über `$PSCmdlet.ShouldProcess()` absichern, damit `-WhatIf` und `-Confirm` wirken.

[MUST_IF] Wenn ein externes Programm aufgerufen wird, muss `$LASTEXITCODE` danach geprüft werden, sofern nicht `$PSNativeCommandUseErrorActionPreference = $true` gesetzt ist.

[MUST_NOT] Aliase wie `ls`, `cat`, `%` oder `?` dürfen in versionierten Skripten nicht verwendet werden; vollständige Cmdlet-Namen sind Pflicht.

## Bash

[MUST] Bash-Skripte müssen mit dem Shebang `#!/usr/bin/env bash` beginnen und direkt danach `set -euo pipefail` setzen.

[MUST] Bash-Skripte müssen ohne Befunde von `shellcheck` geprüft werden können.

[MUST_IF] Wenn eine `shellcheck`-Warnung bewusst unterdrückt wird, muss dies lokal per `# shellcheck disable=SCxxxx` mit kurzer Begründung erfolgen.

[MUST] Variablen- und Parameterexpansionen müssen in doppelte Anführungszeichen gesetzt werden, zum Beispiel `"$file"` und `"$@"`.

[MUST_IF] Wenn ein Bash-Skript temporäre Dateien oder Prozesse erzeugt, muss es diese über `trap ... EXIT` aufräumen.

[MUST_NOT] `eval` und ungeprüfte Kommandosubstitution aus Eingaben dürfen nicht verwendet werden.

## Gemeinsame Regeln

[MUST] Pfade, Ziele, Umgebungen und andere variable Werte müssen als Parameter mit sinnvollen Defaults übergeben werden statt hart kodiert.

[MUST] Relative Pfade müssen über das Skriptverzeichnis aufgelöst werden, in PowerShell über `$PSScriptRoot`, in Bash über `"$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"`.

[MUST_NOT] Skripte dürfen sich nicht auf das aktuelle Arbeitsverzeichnis des Aufrufers verlassen.

[MUST] Skripte müssen idempotent sein: ein wiederholter Lauf mit denselben Parametern darf keinen Fehler und keinen abweichenden Endzustand erzeugen.

[MUST_IF] Wenn ein Skript destruktive Aktionen wie Löschen, Überschreiben oder Zurücksetzen ausführt, muss es eine Vorschau über `-WhatIf` beziehungsweise `--dry-run` und eine Bestätigung oder ein ausdrückliches Force-Flag anbieten.

[MUST_NOT] Secrets, Tokens und Zugangsdaten dürfen nicht im Skript stehen oder als Kommandozeilenargument erwartet werden; sie werden über Umgebungsvariablen oder einen Secret-Store gelesen.

[MUST] Skripte müssen bei Erfolg mit Exitcode `0` und bei Fehlern mit einem Exitcode ungleich `0` enden; Fehlermeldungen gehen auf stderr.

[MUST_IF] Wenn ein Skript unterscheidbare Fehlerarten an Aufrufer meldet, müssen die verwendeten Exitcodes im Skriptkopf dokumentiert sein.

[MUST] Skriptdateien müssen UTF-8 ohne BOM gespeichert werden; Bash-Skripte zusätzlich mit LF-Zeilenenden.

[MUST_IF] Wenn ein Repository Bash-Skripte enthält, muss `.gitattributes` für `*.sh` die Zeilenenden über `eol=lf` festlegen.

[MUST] Jedes Skript muss am Anfang Zweck, Parameter und ein Aufrufbeispiel dokumentieren, in PowerShell als Comment-Based Help, in Bash als Kopfkommentar oder `--help`-Ausgabe.
