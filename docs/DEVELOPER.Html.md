# DEVELOPER.Html.md

Stand: 2026-05-16

## Zweck

Diese Datei definiert HTML- und Markup-Regeln. Allgemeine Regeln stehen in [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.md). Framework- oder technologiespezifische Regeln stehen in passenderen [DEVELOPER.*.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.*.md)-Dateien.

[PRIORITY] Diese Regeln gelten fuer HTML-, Template- und Markup-Code, sofern keine passendere technologiespezifische Regel innerhalb ihres ausdruecklichen Scopes eine engere Vorgabe macht.

## HTML und Markup

[MUST] Markup muss schlank, lesbar und semantisch passend bleiben.

[MUST] Markup darf sichtbare Zustaende, Nutzeraktionen und einfache UI-Verzweigungen abbilden.

[MUST_NOT] Markup darf keine fachliche Orchestrierung, komplexe Berechnungen, Datenmapping, Filterlogik oder technische Ablaufsteuerung enthalten.

[MUST] Komplexe Darstellungslogik muss aus dem Markup in klar benannte View-Modelle, Properties oder Hilfsstrukturen ausgelagert werden.

[MUST] Kontrollfluss im Markup muss nachvollziehbar bleiben.

[MUST] Jede neue DOM-Ebene muss einen klaren Zweck haben: Semantik, Layout, Zustand, Wiederverwendung oder Accessibility.

[MUST_NOT] Neue Wrapper-Elemente duerfen nicht eingefuehrt werden, wenn sie keinen klaren Zweck erfuellen.

[MUST] Interaktive Elemente muessen als passende semantische Elemente umgesetzt werden, z. B. `button` fuer Aktionen und `a` fuer Navigation.

[MUST_NOT] Klickbare `div`- oder `span`-Elemente duerfen nicht eingefuehrt werden, wenn ein semantisches Element verwendet werden kann.

[MUST] Formularfelder muessen programmatisch erkennbare Labels, Fehlermeldungen und Hilfetexte haben.

[MUST] Bedingte Darstellung muss alle relevanten Nutzerzustaende abdecken, sofern diese im Flow auftreten koennen: Laden, leerer Zustand, Fehler, nicht erlaubt, nicht verfuegbar und regulaerer Inhalt.
