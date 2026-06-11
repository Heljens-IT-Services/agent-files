# SKILLS.md

## Zweck

Diese Datei ist der zentrale Einstiegspunkt fuer wiederkehrende Agenten-Skills und Workflows.

Skills sind atomare, wiederverwendbare Faehigkeiten. Workflows kombinieren mehrere Skills zu einem zusammenhaengenden Ablauf.

## Verwendung

[MUST_IF] Der Agent muss diese Datei lesen, wenn ein Task einer wiederkehrenden Aufgabe entspricht, fuer die unter `../skills/` oder `../workflows/` eine passende Beschreibung existiert.

[MUST_IF] Der Agent muss einen passenden Workflow unter `../workflows/` verwenden, wenn der Task mehrere zusammenhaengende Skills benoetigt.

[MUST_IF] Der Agent muss die in einem verwendeten Workflow referenzierten Skill-Dateien unter `../skills/` lesen und befolgen.

[MUST_IF] Der Agent muss einen passenden Skill direkt verwenden, wenn kein Workflow erforderlich ist oder der User explizit einen einzelnen Arbeitsschritt verlangt.

[SHOULD] Der Agent soll die kleinste passende Einheit verwenden: Skill fuer einzelne Arbeitsschritte, Workflow fuer zusammenhaengende End-to-End-Aufgaben.

[MUST_IF] Der Agent muss Abweichungen von einem passenden Skill oder Workflow kurz begruenden, wenn der aktuelle Task einen konkreten fachlichen, technischen oder sicherheitsrelevanten Grund dafuer liefert.


## Skills

| Skill | Pfad | Zweck |
|---|---|---|
| Code Analyse | `../skills/code_analyse.md` | Problem, Ursache, Auswirkungen und Risiken untersuchen. |
| Code Brainstorming | `../skills/code_brainstorming.md` | Loesungsoptionen erzeugen und vergleichen. |
| Code Diff Review | `../skills/code_diff-review.md` | Aenderungssatz auf Scope, Risiken und Nebeneffekte pruefen. |
| Code Implementieren | `../skills/code_implementieren.md` | Geplante Codeaenderung umsetzen. |
| Code Implementierungsplanung | `../skills/code_implementierungsplanung.md` | Technischen Umsetzungsplan erstellen. |
| Code Refactoring | `../skills/code_refactoring.md` | Struktur verbessern, ohne Verhalten unbeabsichtigt zu aendern. |
| Code Testen | `../skills/code_testen.md` | Aenderung technisch und funktional pruefen. |
| Code Verstehen | `../skills/code_verstehen.md` | Bestehenden Code, Struktur und Datenfluss erklaeren. |
| GitHub Branch Checkout From Default | `../skills/github_branch-checkout-from-default.md` | Arbeitsbranch von der Standardbasis erstellen und auschecken. |
| GitHub Commit Vorbereiten | `../skills/github_commit-vorbereiten.md` | Commit logisch schneiden und Commit-Message vorbereiten. |
| GitHub Issue Erstellen | `../skills/github_issue-erstellen.md` | Aus Kontext ein umsetzbares GitHub-Issue formulieren. |
| GitHub Issue Lesen | `../skills/github_issue-lesen.md` | GitHub-Issue in Ziel, Scope und offene Fragen uebersetzen. |
| GitHub PR Text Erstellen | `../skills/github_pr-text-erstellen.md` | Pull-Request-Titel und Beschreibung vorbereiten. |

## Workflows

| Workflow | Pfad | Zweck |
|---|---|---|
| Analyse To Issue | `../workflows/analyse-to-issue.md` | Aus Idee, Beobachtung oder Analyse ein Issue erzeugen. |
| Bugfix | `../workflows/bugfix.md` | Fehler analysieren, beheben und absichern. |
| Feature Umsetzung | `../workflows/feature-umsetzung.md` | Feature von Anforderung bis verifizierter Implementierung bearbeiten. |
| Issue To PR | `../workflows/issue-to-pr.md` | Ticket bis zur Pull-Request-Vorbereitung ueberfuehren. |
| Issue Umsetzung | `../workflows/issue-umsetzung.md` | Issue End-to-End bearbeiten. |
| Refactoring Mit Absicherung | `../workflows/refactoring-mit-absicherung.md` | Code strukturieren und Verhalten absichern. |
