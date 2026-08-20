# Kanonische Heljens-Issue-Templates

Diese Dateien werden unverändert nach `.github/ISSUE_TEMPLATE/` übernommen:

- [bug.yml](issue-templates/bug.yml)
- [config.yml](issue-templates/config.yml)
- [epic.yml](issue-templates/epic.yml)
- [refactor.yml](issue-templates/refactor.yml)
- [story.yml](issue-templates/story.yml)
- [task.yml](issue-templates/task.yml)

## Task-Issue-Vertrag

Ein Task ist terminal, wenn er als eigenständig ausführbarer technischer Plan ohne erneute grundlegende Architektur-, Scope- oder Vorgehensentscheidung umgesetzt und verifiziert werden kann. Dafür muss er enthalten:

- eindeutigen Zielzustand und erforderlichen fachlichen sowie technischen Kontext
- verbindlichen Scope und expliziten Nicht-Scope
- bekannte betroffene Bereiche, Schnittstellen und hilfreiche Referenzimplementierungen
- bereits getroffene umsetzungsrelevante Entscheidungen und Constraints
- geordnete Arbeitspakete auf direkt ausführbarer, nicht mikrogranularer Ebene
- prüfbare Akzeptanzkriterien und konkrete reproduzierbare Verifikationsschritte
- bekannte Risiken, Abhängigkeiten und Blocker

Wesentliche offene Produkt-, Architektur-, Scope- oder Vorgehensentscheidungen verhindern Terminalität. Widersprechen Task-Plan, Repository-Zustand oder geltende Regeln einander, muss die Umsetzung stoppen und gezielt in Klärung oder Planung zurückspringen.

Globale Agent-, Engineering- und Technologieregeln werden nicht in den Task kopiert. Der Task dokumentiert nur aufgabenspezifischen Kontext und Entscheidungen; der geltende Repository- und Agent-Files-Kontext bleibt separat verbindlich.
