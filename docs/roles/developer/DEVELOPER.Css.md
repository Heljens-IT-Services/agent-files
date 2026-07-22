# DEVELOPER.Css.md

Stand: 2026-05-16

## Zweck

Diese Datei definiert CSS-, Styling- und praesentationsnahe UI-Regeln. Allgemeine Regeln stehen in [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md). Framework- oder technologiespezifische Regeln stehen in passenderen [DEVELOPER.*.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.*.md)-Dateien.

[PRIORITY] Diese Regeln gelten fuer CSS-, SCSS- und Styling-Code, sofern keine passendere technologiespezifische Regel innerhalb ihres ausdruecklichen Scopes eine engere Vorgabe macht.

## Styling, UI und Accessibility

[MUST] Bestehende UI-Konventionen des Projekts muessen vor neuen Styling-Konzepten verwendet werden.

[MUST] Component-SCSS muss lokal, begrenzt und komponentennah bleiben.

[MUST_NOT] Component-SCSS darf keine globalen Seiteneffekte erzeugen.

[MUST_NOT] Globale Styles duerfen nicht fuer lokale Component-Probleme erweitert werden.

[MUST_NOT_IF] Inline-Styles duerfen nicht verwendet werden, ausser fuer dynamische Werte, die nicht sinnvoll ueber Klassen oder CSS Custom Properties abbildbar sind.

[MUST_NOT] Styling-Aenderungen duerfen keine ungenutzten Klassen, doppelten Regeln oder widerspruechlichen Layout-Mechanismen einfuehren.

[MUST] Spacing, Typografie, Farben, Radius, Schatten und Breakpoints muessen bestehenden Projektkonventionen folgen.

[MUST_NOT_IF] Magic Numbers in CSS duerfen nicht eingefuehrt werden, wenn bestehende Tokens, Variablen oder Konventionen vorhanden sind.

[MUST_IF] Responsive Verhalten muss bei layoutrelevanten Aenderungen beruecksichtigt werden.

[MUST] Kontraste, Fokuszustand, Disabled-Zustand, Loading-Zustand und Fehlerzustand muessen visuell nachvollziehbar sein.
