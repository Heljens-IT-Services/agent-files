# AGENTS.md

## Verbindliche Arbeitsregeln

Die verbindlichen Arbeitsregeln finden sich global unter:
https://heljens-it-services.github.io/agent-files/AGENTS.md

## Umgang mit den Arbeitsregeln

[MUST] Zu Beginn jedes Tasks muss der Agent die globale `AGENTS.md` lesen und
befolgen.

[MUST_IF] Wenn ein Web-/Browser-Tool die Datei nicht abrufen kann, muss der
Agent vor einem Abbruch einen Shell-Fallback versuchen, z. B.:

```powershell
curl.exe -L "https://heljens-it-services.github.io/agent-files/AGENTS.md"
Invoke-WebRequest -Uri "https://heljens-it-services.github.io/agent-files/AGENTS.md" -UseBasicParsing
```

[MUST_IF] Wenn kein verfuegbarer Abrufweg funktioniert, muss der Agent dies
melden und die Arbeit einstellen.
