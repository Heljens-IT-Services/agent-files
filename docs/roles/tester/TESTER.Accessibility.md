# TESTER.Accessibility.md

Stand: 2026-10-19

## Zweck

Diese Datei definiert Testregeln für die Barrierefreiheit von Benutzeroberflächen. Allgemeine Tester-Regeln und technologiespezifische Testregeln wie Playwright werden über [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md) und [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst. Das Zielniveau steht in [DEVELOPER.Accessibility.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Accessibility.md).

## Automatisierte Prüfungen

[MUST_IF] Wenn das Projekt eine E2E- oder Komponenten-Testumgebung besitzt, müssen die zentralen Seiten und Zustände zusätzlich mit einer automatisierten Accessibility-Prüfung auf Basis einer etablierten Regel-Engine wie axe-core geprüft werden.

[MUST_IF] Wenn die benötigte Prüfbibliothek im Projekt fehlt, muss ihre Einführung als neue Abhängigkeit gemäß den Developer-Regeln freigegeben werden; bis dahin bleibt die Prüfung als ausgelassen zu benennen.

[MUST] Automatisierte Prüfungen müssen mindestens die Regelgruppen für WCAG 2.0, 2.1 und 2.2 auf den Stufen A und AA abdecken.

[MUST] Automatisierte Prüfungen müssen relevante Zustände wie geöffnete Dialoge, Fehlermeldungen, leere Zustände und Ladezustände einschließen, nicht nur den Initialzustand einer Seite.

[MUST_NOT] Befunde dürfen nicht pauschal über ganze Regelgruppen, Seiten oder Komponenten ausgeschlossen werden.

[ALLOW_IF] Ein einzelner Befund darf nur ausgeschlossen werden, wenn Regel, Element und fachlicher Grund im Test dokumentiert sind und der Ausschluss im Arbeitsabschluss genannt wird.

## Manuelle Prüfungen

[MUST_IF] Wenn neue oder geänderte Interaktionen Teil des Tasks sind, muss der Tester sie per Tastatur prüfen: Erreichbarkeit, Fokusreihenfolge, sichtbarer Fokus, Fokusführung bei Dialogen und Navigation sowie Ausbleiben von Tastaturfallen.

[MUST_IF] Wenn Layout, Typografie oder Farben geändert werden, müssen Kontrast, 200 % Zoom und eine Viewport-Breite von 320 CSS-Pixeln geprüft werden.

[SHOULD] Kritische Nutzerflows sollen stichprobenartig mit einem Screenreader geprüft werden. Abweichungen sind erlaubt, wenn in der Arbeitsumgebung kein Screenreader verfügbar ist; die Prüfung muss dann als ausgelassen benannt werden.

## Nachweis

[MUST] Im Arbeitsabschluss müssen automatisierte und manuelle Accessibility-Prüfungen getrennt nach ausgeführt, ausgelassen und fehlgeschlagen benannt werden.

[MUST_NOT] Eine bestandene automatisierte Prüfung darf nicht als vollständige WCAG-Konformität berichtet werden.
