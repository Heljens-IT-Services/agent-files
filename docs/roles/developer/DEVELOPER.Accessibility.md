# DEVELOPER.Accessibility.md

Stand: 2026-10-19

## Zweck

Diese Datei gilt für die barrierefreie Umsetzung von Benutzeroberflächen. Zugehörige allgemeine Developer-Regeln werden über [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md), weitere technologiespezifische Regeldateien wie HTML, CSS oder Angular über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst.

## Zielniveau

[MUST] Neue und geänderte Oberflächen müssen die Erfolgskriterien der WCAG 2.2 auf Konformitätsstufe AA erfüllen, sofern `PROJECT.md` kein anderes Zielniveau festlegt.

[MUST_NOT] Bestehende Barrierefreiheit darf durch eine Änderung nicht verschlechtert werden, auch wenn der betroffene Bereich das Zielniveau noch nicht vollständig erreicht.

[MUST_IF] Wenn ein Erfolgskriterium im Rahmen des Tasks nicht erfüllt werden kann, muss der Agent Kriterium, betroffene Stelle und Grund im Arbeitsabschluss nennen.

## Semantik und ARIA

[MUST] Native HTML-Elemente und -Attribute müssen ARIA vorgezogen werden, wenn sie die benötigte Rolle, den Zustand oder die Eigenschaft bereits abbilden.

[MUST_IF] Wenn ARIA eingesetzt wird, müssen Rolle, Zustände und Eigenschaften vollständig, gültig und mit dem sichtbaren Verhalten synchron gehalten werden.

[MUST_NOT] ARIA darf nicht verwendet werden, um fehlende Tastaturbedienung oder falsche Semantik nur gegenüber Hilfstechnologien zu verdecken.

[MUST] Seiten müssen eine sinnvolle Überschriftenhierarchie, Landmarks für Hauptbereiche, eine gesetzte Dokumentsprache und einen aussagekräftigen Seitentitel besitzen.

[MUST] Jedes interaktive Element muss einen zugänglichen Namen besitzen, der den sichtbaren Beschriftungstext enthält.

[MUST] Bilder, Icons und Grafiken müssen einen passenden Alternativtext besitzen oder ausdrücklich als dekorativ ausgezeichnet sein.

## Tastatur und Fokus

[MUST] Alle Funktionen müssen ohne Maus vollständig per Tastatur erreichbar und bedienbar sein.

[MUST] Die Fokusreihenfolge muss der visuellen und inhaltlichen Reihenfolge folgen.

[MUST_NOT] Positive `tabindex`-Werte und Tastaturfallen dürfen nicht eingeführt werden.

[MUST] Der Tastaturfokus muss jederzeit sichtbar sein und darf nicht vollständig von anderen Inhalten verdeckt werden.

[MUST_IF] Wenn Dialoge, Overlays oder Menüs geöffnet werden, muss der Fokus in sie hinein und nach dem Schließen auf den auslösenden oder einen fachlich passenden Punkt zurückgeführt werden.

[MUST_IF] Wenn eine Single-Page-Anwendung ohne vollständigen Seitenwechsel navigiert, müssen Seitentitel und Fokus an den neuen Inhalt angepasst werden.

## Darstellung und Bewegung

[MUST] Text und für die Bedienung notwendige Grafiken müssen die Kontrastanforderungen der WCAG 2.2 AA erfüllen.

[MUST_NOT] Informationen dürfen nicht ausschließlich über Farbe, Position, Form oder Ton vermittelt werden.

[MUST] Inhalte müssen bei 200 % Zoom und bei einer Viewport-Breite von 320 CSS-Pixeln ohne Informations- oder Funktionsverlust nutzbar bleiben.

[MUST] Bedienelemente müssen die Mindestzielgröße der WCAG 2.2 AA erfüllen oder ausreichend Abstand zu benachbarten Zielen haben.

[MUST_IF] Wenn Animationen oder Bewegungseffekte eingesetzt werden, muss die Einstellung `prefers-reduced-motion` respektiert werden.

[MUST_NOT] Inhalte dürfen nicht automatisch blinken, scrollen oder sich bewegen, ohne dass Nutzer dies pausieren oder beenden können.

## Formulare, Fehler und Statusmeldungen

[MUST] Pflichtfelder, Eingabeformate und Validierungsfehler müssen sichtbar und programmatisch erkennbar sein.

[MUST] Fehlermeldungen müssen das betroffene Feld benennen und, soweit möglich, einen Weg zur Korrektur beschreiben.

[MUST_IF] Wenn sich Statusmeldungen, Ladezustände oder Ergebnisse ohne Fokuswechsel ändern, müssen sie über eine passende Live-Region für Hilfstechnologien angekündigt werden.

[MUST_NOT] Zeitlimits dürfen nicht eingeführt werden, ohne dass Nutzer sie verlängern, anpassen oder abschalten können, außer das Zeitlimit ist fachlich zwingend.

## Prüfung durch den Developer

[MUST] Vor dem Abschluss einer UI-Änderung muss der Developer die geänderten Bereiche mindestens per Tastatur bedienen und vorhandene automatisierte Accessibility-Prüfungen des Projekts ausführen.

[MUST_NOT] Ein fehlerfreier automatisierter Accessibility-Check darf nicht als Nachweis vollständiger WCAG-Konformität dargestellt werden.

[MUST_NOT] Die eigene Prüfung des Developers darf nicht als Nachweis der Barrierefreiheit berichtet werden. Der Nachweis erfolgt durch Tests gemäß [TESTER.Accessibility.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.Accessibility.md).
