# TESTER.Angular.Playwright.md

Stand: 2026-10-13

## Zweck

Diese Datei definiert Playwright-Regeln für Angular-Anwendungen. Allgemeine Tester- und Angular-Regeln werden über [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md) und [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst.

## Funktionale Tests

[MUST_IF] Wenn ein Task fachliche Nutzerflows neu einführt oder verändert, müssen diese über ihre wesentlichen sichtbaren Ergebnisse mit Playwright-E2E-Tests abgesichert werden. Konkrete angrenzende Regressionsrisiken sind einzubeziehen.

[MUST_IF] Wenn eine interaktive Nutzeraktion neu eingeführt oder in ihrem Verhalten verändert wird, muss ihr beobachtbarer Effekt mindestens einmal getestet werden; vorhandene belastbare Tests können den Nachweis liefern.

[MUST_IF] Wenn Navigation, Sichtbarkeits- und Zustandsänderungen, Eingaben und Validierung, Tastaturbedienung, unterstützte Gesten, persistierende Aktionen sowie Fehler-, Loading- oder Disabled-Zustände im Änderungsscope liegen oder konkret regressionsgefährdet sind, müssen die relevanten Zustände und Effekte getestet werden.

[MUST_IF] Wenn sich ein geänderter Nutzerflow zwischen Themes oder Viewports unterschiedlich verhält, müssen die betroffenen funktionalen Tests diese Varianten abdecken.

[MUST] Tests müssen das Nutzerergebnis statt interner Implementierungsdetails prüfen.

[SHOULD] Nutzerorientierte Selektoren wie `getByRole`, `getByLabel` und `getByText` sollen bevorzugt werden.

[ALLOW_IF] `data-testid` darf verwendet werden, wenn kein robuster semantischer Selektor verfügbar ist.

[MUST_NOT] Feste Wartezeiten wie `waitForTimeout` dürfen nicht verwendet werden.

## Visuelle Tests

[MUST] Das Projekt muss seine unterstützten Themes und relevanten Viewports definieren.

[MUST_IF] Wenn eine visuell relevante Component neu eingeführt oder verändert wird, müssen die tatsächlich betroffenen Viewport-Theme-Kombinationen mit Playwright-Referenzbildern abgesichert werden. Weitere Kombinationen sind nur bei konkretem Darstellungsrisiko einzubeziehen.

[MUST] Visuelle Tests müssen das tatsächlich im Browser gerenderte Ergebnis einschließlich Styles von Frameworks und UI-Bibliotheken prüfen.

[ALLOW_IF] Bei einer beabsichtigten Designänderung dürfen betroffene Referenzbilder nach Prüfung des gerenderten Ergebnisses aktualisiert werden.

[MUST_NOT] Fehlgeschlagene visuelle Vergleiche dürfen nicht ungeprüft durch neue Referenzbilder ersetzt werden.
