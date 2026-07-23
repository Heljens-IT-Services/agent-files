# DEVELOPER.Html.md

Stand: 2026-07-22

## Zweck

Diese Datei gilt fuer HTML und Markup. Zugehoerige allgemeine und technologiespezifische Regeldateien werden ueber [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgeloest.

## HTML und Markup

[MUST] Markup muss schlank, lesbar und semantisch passend bleiben.

[ALLOW] Markup darf sichtbare Zustaende, Nutzeraktionen und einfache UI-Verzweigungen abbilden.

[MUST_NOT] Markup darf keine fachliche Orchestrierung, komplexe Berechnungen, Datenmapping, Filterlogik oder technische Ablaufsteuerung enthalten.

[MUST] Komplexe Darstellungslogik muss aus dem Markup in klar benannte View-Modelle, Properties oder Hilfsstrukturen ausgelagert werden.

[MUST] Kontrollfluss im Markup muss nachvollziehbar bleiben.

[MUST] Jede neue DOM-Ebene muss einen klaren Zweck haben: Semantik, Layout, Zustand, Wiederverwendung oder Accessibility.

[MUST_NOT_IF] Neue Wrapper-Elemente duerfen nicht eingefuehrt werden, wenn sie keinen klaren Zweck erfuellen.

[MUST] Interaktive Elemente muessen als passende semantische Elemente umgesetzt werden, z. B. `button` fuer Aktionen und `a` fuer Navigation.

[MUST_NOT_IF] Klickbare `div`- oder `span`-Elemente duerfen nicht eingefuehrt werden, wenn ein semantisches Element verwendet werden kann.

[MUST] Formularfelder muessen programmatisch erkennbare Labels, Fehlermeldungen und Hilfetexte haben.

[MUST_IF] Bedingte Darstellung muss alle relevanten Nutzerzustaende abdecken, sofern diese im Flow auftreten koennen: Laden, leerer Zustand, Fehler, nicht erlaubt, nicht verfuegbar und regulaerer Inhalt.
