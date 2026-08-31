# Workflow: Online-Publikation prüfen

## Ziel

Die über GitHub Pages veröffentlichten Agent Files gegen den aktuellen Stand von `origin/main` auf Quelle, Erreichbarkeit, Vernetzung und Inhaltsgleichheit prüfen.

## Verwenden

- Nach einem Release nach `main`.
- Bei Zweifeln an Erreichbarkeit, Vernetzung oder Aktualität der veröffentlichten Agent Files.
- Ausschließlich lesend; für die Behebung eines Befunds den passenden Umsetzungsworkflow verwenden.

## Verwendete Skills

- `research`

## Ablauf

1. `origin/main` aktualisieren und dessen Commit-SHA erfassen.
2. Die GitHub-Pages-Konfiguration und den letzten Build über die GitHub API lesen. Quelle muss `main` mit Pfad `/docs` sein, der Build-Status `built` und dessen Commit muss `origin/main` entsprechen.
3. Den Einstiegspunkt `https://heljens-it-services.github.io/agent-files/AGENTS.md` per HTTP abrufen. Er muss HTTP-Status `200` liefern.
4. Aus den internen Markdown-Links ab `docs/AGENTS.md` einen Graphen bilden und ihn mit den versionierten Markdown-Dateien unter `docs/` vergleichen. Kein Linkziel darf fehlen und jede Markdown-Datei muss erreichbar sein.
5. Für jede versionierte Markdown-Datei sowie jede Codex-Agent-Vorlage unter `docs/codex/agents/` den zugehörigen Pages-Pfad per HTTP abrufen. Jede URL muss HTTP-Status `200` liefern.
6. Den Online-Inhalt jeder geprüften Datei nach Vereinheitlichung der Zeilenenden mit dem zugehörigen Blob aus `origin/main` vergleichen. Die veröffentlichten Codex-Agent-Vorlagen zusätzlich mit `.codex/agents/` abgleichen.
7. Referenz-SHA, Build, Datei- und Linkanzahl sowie jede Abweichung getrennt nach Quelle, Erreichbarkeit, Vernetzung und Aktualität zusammenfassen.

## Rücksprungregeln

- Wenn Pages-Quelle, Build-Status oder Build-Commit nicht dem erwarteten Stand entsprechen, keine Aktualität behaupten und nach abgeschlossenem Deployment erneut prüfen.
- Wenn ein Linkziel fehlt, eine URL keinen Status `200` liefert oder ein Inhaltsabgleich abweicht, konkrete Pfade, URLs sowie erwartete und tatsächliche Commit-SHAs nennen und zur Dokumentationspflege zurückkehren.
- Wenn Browser- oder Web-Tools eine Markdown-URL nicht abrufen können, vor einem Fehlerurteil den HTTP-Abruf per Shell versuchen.

## Endergebnis

- Quelle und Build-Commit sind eindeutig bewertet.
- Erreichbarkeit und Vernetzung aller veröffentlichten Markdown-Dateien sind nachgewiesen oder mit konkreten Befunden fehlgeschlagen.
- Die Inhaltsgleichheit zur veröffentlichten Referenz und zu den Codex-Agent-Vorlagen ist nachgewiesen oder mit konkreten Abweichungen dokumentiert.

## Grenzen

- Keine versionierten Dateien, GitHub-Pages-Konfigurationen oder anderen externen Zustände ändern.
