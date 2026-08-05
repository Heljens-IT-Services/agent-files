# DEVELOPER.md

Stand: 2026-08-05

## Zweck

Diese Datei definiert technologieuebergreifende Developer-Regeln. Technologiespezifische Regeldateien werden ueber [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgeloest.

## Prioritaet innerhalb der Developer-Rolle

[PRIORITY] Bei widerspruechlichen Regeldateien innerhalb der Developer-Rolle gilt innerhalb ihres jeweiligen Scopes diese Reihenfolge:

1. Passende spezialisierte Regeldatei aus [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md).
2. [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md).

[PRIORITY] Bei mehreren passenden `DEVELOPER.*.md`-Dateien hat die spezifischere Regel nur innerhalb ihres ausdruecklich beschriebenen Scopes Vorrang vor einer allgemeineren Regel.

## Architekturprinzipien

[MUST] Fachlogik muss von technischen Randthemen getrennt werden.

[MUST] Fachliche Regeln, Use Cases, Workflows, fachliche Fehler und fachliche Modelle muessen in der fachlichen Mitte des Systems liegen.

[MUST] Technische Details wie UI, HTTP, CLI, Persistenz, Dateisystem, externe APIs, Worker, Frameworks, Logging, Konfiguration und Dependency Injection muessen an den Systemraendern bleiben.

[MUST_NOT] Technische Einstiegspunkte wie Controllers, Endpoints, `Program.cs`, Worker-Handler oder CLI-Kommandos duerfen keine Fachlogik enthalten.

[MUST] Einstiegspunkte muessen Eingaben validieren, Use Cases oder Services aufrufen und Ergebnisse in die passende Ausgabeform mappen.

[MUST] Abhaengigkeiten muessen nach innen zeigen: fachliche Schichten definieren Ports und Vertraege, technische Schichten implementieren diese Ports.

[MUST_NOT] Externe DTOs, API-Contracts, Formularmodelle, Dateiformate und Persistenzmodelle duerfen nicht ungeprueft als interne Fachmodelle verwendet werden.

## Struktur und Verantwortlichkeiten

[SHOULD] Projektstrukturen sollen fachliche und technische Verantwortlichkeiten sichtbar machen. Abweichungen sind erlaubt, wenn ein bestehendes Projekt eine andere stabile Struktur vorgibt und die konkrete Aenderung keine Strukturmigration ist.

[MUST] Wiederverwendbare, fachlich neutrale Bausteine muessen getrennt von fachlich spezifischen Features oder Use Cases liegen.

[MUST] Infrastrukturcode muss gekapselt werden.

[MUST_NOT] Views, Endpoints, CLI-Kommandos und fachliche Logik duerfen Infrastrukturcode nicht direkt ansprechen.

[MUST] Mapping an Systemgrenzen muss explizit sein, damit externe Vertraege, technische Transportmodelle und interne Modelle entkoppelt bleiben.

[MUST] Konfiguration muss an der technischen Grenze geladen, typisiert gebunden und validiert werden.

[MUST_NOT] Fachliche Logik darf globale Konfiguration nicht direkt lesen.

[MUST] Fehlende Pflichtkonfiguration muss frueh mit klarer Fehlermeldung scheitern.

[MUST] Oeffentliche oder teamuebergreifend genutzte Schnittstellen muessen stabile Contracts und dokumentierte Fehlerformen erhalten.

## Clean Code

[MUST] Namen muessen fachlich, praezise und konsistent sein.

[SHOULD] Ein Name soll erklaeren, warum ein Konzept existiert. Abweichungen sind erlaubt, wenn ein etabliertes Framework, Protokoll oder Fremdsystem einen anderen Namen vorgibt.

[MUST] Eine Funktion oder Methode muss eine klar erkennbare Aufgabe auf einer Abstraktionsebene erfuellen.

[SHOULD] Funktionen und Methoden sollen in der Regel nicht mehr als ca. 15 Zeilen fachlich relevanten Code enthalten; bei Ueberschreitung soll eine Trennung von Verantwortlichkeiten oder Extraktion von Hilfsmethoden geprueft werden.

[MUST] Klassen, Komponenten und Services muessen hohe Kohaesion und niedrige Kopplung haben.

[MUST] Oeffentliche Typen, zentrale Einstiegspunkte, Klassen, Komponenten und Services muessen eine klar benennbare und begrenzte Hauptverantwortung haben.

[MUST_NOT] Klassen, Komponenten und Services duerfen nicht allein zur Einhaltung numerischer Groessenrichtwerte so aufgeteilt werden, dass fachliche Zusammenhaenge, Lesefluss oder Wartbarkeit schlechter werden.

[SHOULD] Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code sollen geloescht werden, wenn sie im Scope der Aufgabe liegen.

[MUST_IF] Dead Code, ungenutzte Feature-Flags, veraltete TODOs und auskommentierter Code muessen im Arbeitsabschluss gemeldet werden, wenn sie auffallen und nicht im Scope der Aufgabe geloescht werden.

## Dokumentation

[MUST_IF] Allgemeine Einstiegspunkte, komplexe Strukturen, Infrastruktur-Objekte, oeffentliche Vertraege und fachliche Regeln muessen im Quellcode dokumentiert werden, wenn ihr fuer Wartung, Nutzung oder Review notwendiger Zweck nicht aus Code und Namen hervorgeht.

[MUST] Kommentare muessen Domaenenwissen, fachspezifisches Know-how, Absicht, Trade-offs oder nicht offensichtliche Constraints erklaeren.

[MUST_NOT] Kommentare duerfen den Code nicht lediglich wiederholen.

[ALLOW] README-Dateien, Architektur-Notizen, API-Beschreibungen, Beispielaufrufe oder externe Dokumentation duerfen Quellcode-Kommentare ergaenzen.

[MUST_NOT_IF] Externe Dokumentation darf notwendiges Verstaendnis nicht ersetzen, wenn dieses Verstaendnis direkt am Code gebraucht wird.

## Design Patterns und Prinzipien

[ALLOW_IF] Design-Patterns und Code-Patterns duerfen eingesetzt werden, wenn sie Abhaengigkeiten verringern, Redundanz vermeiden, Wartbarkeit verbessern, Skalierbarkeit ermoeglichen, Fehleranfaelligkeit verringern oder Testbarkeit verbessern.

[ALLOW_IF] Vererbung darf genutzt werden, wenn echte Substituierbarkeit vorliegt.

[MUST_IF] Mapper muessen externe DTOs von internen Modellen trennen, wenn Daten aus APIs, Dateien, Datenbanken oder UI-Formularen kommen.

[SHOULD] Facades, Application Services, Use Cases oder Component Services sollen Ablaeufe koordinieren, wenn Views, Endpoints oder CLI-Einstiege sonst Wissen ueber Datenzugriff, Validierung, Status oder technische Ablaeufe enthalten wuerden.

## UI- und Praesentationsregeln

[MUST] UI-Code muss Nutzerintentionen, sichtbare Zustaende und fachliche Ablaeufe klar trennen.

[MUST] Views, Pages und Components duerfen keine Fachlogik, Datenzugriffslogik, Persistenzlogik oder technische Orchestrierung enthalten.

[MUST_IF] Sichtbare Zustaende wie `loading`, `empty`, `error`, `disabled`, `readonly`, `dirty`, `saving` und `success` muessen explizit modelliert werden, wenn sie fuer den Nutzer relevant sind.

[MUST_NOT] UI-Code darf technische Fehler, interne IDs, Debug-Daten oder Infrastrukturdetails nicht ungefiltert sichtbar machen.

[MUST_NOT] Designsysteme und Komponentenbibliotheken duerfen nicht ohne ausdrueckliche User-Anweisung installiert werden.

[MUST] Layout- und Styling-Aenderungen muessen bestehende Design-, Abstands-, Typografie- und Komponenten-Konventionen respektieren.

[MUST_NOT] UI-Aenderungen duerfen keine unnoetigen Wrapper, neuen Styling-Konzepte oder redundanten Komponentenvarianten einfuehren.

[MUST] Interaktive UI muss semantische Elemente, Tastaturbedienung, Fokusfuehrung, Labels und verstaendliche Fehlermeldungen beruecksichtigen.

[MUST] UI-Tests muessen sichtbares Verhalten, Nutzerzustaende, Rollen, Labels, Navigation oder stabile fachliche Ergebnisse pruefen.

[MUST_NOT] UI-Tests duerfen nicht primaer DOM-Struktur, CSS-Klassen oder private Implementierungsdetails pruefen.

## Fehlerbehandlung

[PRIORITY] Fachliche Korrektheit und Fehlertransparenz haben Vorrang vor einem scheinbar erfolgreichen Anwendungslauf.

[SHOULD] Erwartbare fachliche Fehler sollen als explizite Ergebnis-, Status- oder Fehlerobjekte modelliert werden. Abweichungen sind erlaubt, wenn eine vorhandene API, Sprache oder Bibliothek einen anderen fachlich stabilen Fehlervertrag vorgibt.

[MUST] Erwartbare fachliche Fehler muessen Teil des normalen fachlichen Kontrollflusses bleiben.

[ALLOW_IF] Exceptions duerfen verwendet werden, wenn technische Fehler unerwartet sind, Invarianten verletzt wurden oder eine lokale Behandlung nicht sinnvoll ist.

[MUST] Validierungsfehler muessen nahe an der Eingabe erkannt und in eine stabile, fachlich verstaendliche Fehlerform uebersetzt werden.

[MUST] Technische Fehler aus Infrastruktur, Netzwerk, Dateisystem, Persistenz oder externen APIs muessen an der technischen Grenze mit Kontext angereichert werden.

[MUST_IF] Wenn technische Fehler in fachliche oder schnittstellenspezifische Ergebnisse uebersetzt werden, muss die Uebersetzung die Fehlersemantik bewahren und darf keinen Erfolg vortaeuschen.

[MUST_NOT] Ausfaelle notwendiger Datenquellen duerfen nicht durch leere Ergebnisse, `null`, Defaultobjekte oder erfundene, hardcodierte, Mock-, Fake-, Sample- bzw. Demo-Daten als Erfolg dargestellt werden.

[ALLOW_IF] Ein Fallback darf verwendet werden, wenn ein fachlicher Vertrag Ersatzpfad und Semantik definiert, seine Aktivierung beobachtbar ist und Tests Aktivierung sowie Grenzen nachweisen.

[MUST_IF] Wenn ein Ablauf ohne erforderliche Daten nicht fachlich korrekt fortgesetzt werden kann, muss der betroffene Ablauf mit einem diagnostizierbaren Fehlerzustand kontrolliert abgebrochen werden.

[MUST] Fehlerantworten an UI, CLI, HTTP-Clients oder andere Konsumenten muessen konsistent, maschinenlesbar und stabil sein.

[MUST_NOT] Fehlerantworten duerfen keine unbeabsichtigten internen Details enthalten.

[MUST] Logs muessen technische Ursachen und Diagnosekontext erklaeren.

[MUST_NOT] Logs duerfen fachliche Status-, Ergebnis- oder Fehlerobjekte nicht ersetzen.

[MUST_IF] Fehlerpfade muessen getestet werden, wenn sie fachlich relevant, sicherheitsrelevant oder fuer Nutzer bzw. Clients sichtbar sind.

## Security und Datenschutz

[MUST_NOT] Secrets, Tokens, personenbezogene Daten und interne Infrastrukturdetails duerfen nicht geloggt, hart codiert oder versioniert werden.

[MUST] Authentifizierung, Autorisierung und Mandantentrennung muessen an zentralen Grenzen geprueft werden.

[MUST] Eingaben aus UI, CLI, Dateien, Datenbanken und APIs muessen als unsicher behandelt werden, bis sie validiert wurden.

[MUST_NOT] Ausgaben duerfen keine unbeabsichtigten internen Diagnose-, Infrastruktur- oder Sicherheitsdetails enthalten.

[MUST] Abhaengigkeiten muessen nach den Kriterien Wartbarkeit, Sicherheit, Lizenz, Kompatibilitaet und Projektbedarf ausgewaehlt und aktualisiert werden.

[PRIORITY] Sicherheitsupdates haben Vorrang vor kosmetischen Refactorings.

## Tests

[MUST] Reine Fachlogik muss mit Unit Tests abgesichert werden.

[MUST] Workflows muessen Tests fuer Happy Path, Fehlerpfade und fachlich kritische Abzweigungen erhalten.

[SHOULD] Infrastruktur-, Adapter- und Integrationslogik soll mit kontrollierten Testdaten und ohne instabile Live-Dienste getestet werden. Abweichungen sind erlaubt, wenn ein Task ausdruecklich Live-Integrationstests verlangt und die benoetigten Zugangsdaten sowie Umgebung freigegeben sind.

[MUST_IF] Einstiegspunkte wie UI, CLI oder HTTP-API muessen getestet werden, wenn Routing, Eingabevalidierung, Ausgabeformat, Auth, Fehlerabbildung oder DI-Verkabelung projektrelevant sind.

[MUST] Tests muessen deterministisch, isoliert und lesbar sein.

[MUST] Zufall, Uhrzeit, Netzwerk und Dateisystem muessen in Tests kontrolliert werden.

[MUST] Tests muessen sichtbares Verhalten und fachliche Zustaende pruefen.

[MUST_NOT] Tests duerfen private Implementierungsdetails nicht als primaeren Vertrag pruefen.

[SHOULD] Agents sollen den kleinsten sinnvollen Checkumfang ausfuehren. Abweichungen sind erlaubt, wenn die Aenderung gemeinsame Vertrage, Startup, Routing, Persistenz, Security oder breite Nutzerflows betrifft.

[ALLOW_IF] Reine Dokumentations- und Content-Aenderungen duerfen ohne Tests abgeschlossen werden, wenn sie Rendering, Routing, Metadaten und Linksyntax nicht betreffen.

[SHOULD] Unit-Tests sollen fuer isolierte Logik eingesetzt werden; E2E-Tests sollen fuer sichtbare Nutzerflows, Navigation, Persistenz, Startup und domainuebergreifende Integration eingesetzt werden.

[MUST] Im Arbeitsabschluss muessen ausgefuehrte, ausgelassene oder fehlgeschlagene Checks samt Begruendung genannt werden.
