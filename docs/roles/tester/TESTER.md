# TESTER.md

Stand: 2026-08-18

## Zweck

Diese Datei definiert technologieübergreifende Tester-Regeln. Technologiespezifische Regeldateien werden über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst.

## Codex-Ausführung

[MUST_IF] Wenn ein `tester`-SubAgent verfügbar ist, muss Tester-Verantwortung an ihn delegiert werden. Die fachlichen und technologiespezifischen Regeln bleiben dabei maßgeblich.

## Priorität innerhalb der Tester-Rolle

[PRIORITY] Bei widersprüchlichen Regeldateien innerhalb der Tester-Rolle gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. Passende technologiespezifische Regeldatei aus [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md).
2. [TESTER.md](https://heljens-it-services.github.io/agent-files/roles/tester/TESTER.md).

[PRIORITY] Bei mehreren passenden `TESTER.*.md`-Dateien hat die spezifischere Regel nur innerhalb ihres ausdrücklich beschriebenen Scopes Vorrang vor einer allgemeineren Regel.

## Tests

[MUST] Reine Fachlogik muss mit Unit Tests abgesichert werden.

[MUST] Workflows müssen Tests für Happy Path, Fehlerpfade und fachlich kritische Abzweigungen erhalten.

[MUST_IF] Fehlerpfade müssen getestet werden, wenn sie fachlich relevant, sicherheitsrelevant oder für Nutzer bzw. Clients sichtbar sind.

[SHOULD] Infrastruktur-, Adapter- und Integrationslogik soll mit kontrollierten Testdaten und ohne instabile Live-Dienste getestet werden. Abweichungen sind erlaubt, wenn ein Task ausdrücklich Live-Integrationstests verlangt und die benötigten Zugangsdaten sowie Umgebung freigegeben sind.

[MUST_IF] Einstiegspunkte wie UI, CLI oder HTTP-API müssen getestet werden, wenn Routing, Eingabevalidierung, Ausgabeformat, Auth, Fehlerabbildung oder DI-Verkabelung projektrelevant sind.

[MUST] Tests müssen deterministisch, isoliert und lesbar sein.

[MUST] Zufall, Uhrzeit, Netzwerk und Dateisystem müssen in Tests kontrolliert werden.

[MUST] Tests müssen sichtbares Verhalten und fachliche Zustände prüfen.

[MUST] UI-Tests müssen sichtbares Verhalten, Nutzerzustände, Rollen, Labels, Navigation oder stabile fachliche Ergebnisse prüfen.

[MUST_NOT] Tests dürfen private Implementierungsdetails nicht als primären Vertrag prüfen.

[MUST_NOT] UI-Tests dürfen nicht primär DOM-Struktur, CSS-Klassen oder private Implementierungsdetails prüfen.

[SHOULD] Agents sollen den kleinsten sinnvollen Checkumfang ausführen. Abweichungen sind erlaubt, wenn die Änderung gemeinsame Vertrage, Startup, Routing, Persistenz, Security oder breite Nutzerflows betrifft.

[ALLOW_IF] Reine Dokumentations- und Content-Änderungen dürfen ohne Tests abgeschlossen werden, wenn sie Rendering, Routing, Metadaten und Linksyntax nicht betreffen.

[SHOULD] Unit-Tests sollen für isolierte Logik eingesetzt werden; E2E-Tests sollen für sichtbare Nutzerflows, Navigation, Persistenz, Startup und domainübergreifende Integration eingesetzt werden.

[MUST] Im Arbeitsabschluss müssen ausgeführte, ausgelassene oder fehlgeschlagene Checks samt Begründung genannt werden.

## Graphweite Acceptance

[MUST] Bei einer graphweiten Acceptance-Prüfung muss der Tester Root und jedes rekursiv erreichbare Child gegen den aktuellen integrierten Stand prüfen und pro Akzeptanzkriterium Status sowie Evidenz dokumentieren.

[MUST_NOT] Ein Issue-, Commit-, PR- oder früherer Teststatus darf allein keinen Acceptance-Nachweis ersetzen.

[ALLOW_IF] Wenn keine erforderlichen CI-Checks konfiguriert sind und keine Checks berichtet werden, darf der Zustand als `no-checks-required` dokumentiert werden. Er ist kein Fehler und ersetzt nicht die fachliche Kriterienprüfung.
