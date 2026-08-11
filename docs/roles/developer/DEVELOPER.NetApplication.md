# DEVELOPER.NetApplication.md

Stand: 2026-08-05

## Zweck

Diese Datei gilt für geschichtete .NET-Anwendungen mit Entry-, Infrastructure- und Core-Projekten. Zugehörige allgemeine und hostspezifische Regeldateien werden über [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgelöst.

## Schichten und Referenzen

[MUST] `Core` muss fachliche Begriffe, Value Objects, Domain Services, Regeln, Fehler, Use Cases, Ports und Ergebnisobjekte enthalten.

[MUST] `Infrastructure` muss technische Adapter für Ports aus `Core` enthalten.

[MUST] Entry-Projekte müssen Composition Root für Host, Konfiguration, Logging, Dependency Injection sowie Ein- und Ausgabe sein.

[MUST] Die Referenzrichtung muss `Entry -> Infrastructure -> Core` sein.

[MUST_NOT] `Core` darf kein produktives Projekt und keine Laufzeitdetails aus Host, Transport, Konfiguration oder Dependency Injection referenzieren.

[ALLOW_IF] Weitere produktive Projekte und Testprojekte dürfen angelegt werden, wenn ihre Verantwortung begrenzt ist und sie keine Rückreferenz in `Core` erzwingen.

## Fachliche und technische Grenzen

[MUST] Use Cases und Workflows müssen fachlich benannt sein.

[MUST] Workflows in `Core` müssen Use Cases über Ports orchestrieren und explizite Ergebnis- oder Statusobjekte liefern.

[MUST_NOT] Workflows dürfen fachliche Regeln nicht in langen Ablaufblöcken verstecken.

[MUST] Lang laufende Operationen müssen `CancellationToken` akzeptieren.

## Infrastruktur und Konfiguration

[MUST] Externe Dienste, Persistenz, Caches und Dateisysteme müssen über Ports aus `Core` angesprochen werden.

[MUST] Parser und Adapter müssen Rohdaten an der Systemgrenze in interne Modelle umwandeln und relevante Quelleninformationen erhalten.

[MUST] Retry, Timeout, Backoff, technische Konfigurationsbindung und Persistenz müssen in `Infrastructure` liegen.

[MUST_IF] Bei einem zulässigen Fallback muss der technische Mechanismus in `Infrastructure` und der fachliche Ersatzvertrag in `Core` liegen.

[MUST] Runtime-Konfiguration muss im Entry-Projekt geladen, für technische Komponenten typisiert gebunden und vor dem Start validiert werden.

[MUST_NOT] `Core` darf Konfiguration nicht direkt lesen.

[MUST] Fachlich relevante Konfiguration muss nach der Validierung explizit an `Core` übergeben werden.

## Fehler und Tests

[MUST] Technische Fehler müssen in `Infrastructure` mit Diagnosekontext angereichert werden.

[MUST_IF] Ohne fachlich definierten Fallback müssen Adapter technische Fehler als portdefiniertes Fehlerergebnis oder Exception propagieren.

[MUST] Fachliche Regeln und Workflows müssen in `Core.Tests` mit Fake-Ports und kontrollierten Testdaten abgesichert werden.

[MUST] Infrastrukturtests müssen Adapter, Provider, Mapping, Serialisierung und Konfigurationsbindung ohne instabile Live-Dienste prüfen.

[MUST_IF] Infrastrukturtests müssen die Fehlerpropagierung von Adaptern nachweisen, wenn deren Fehlerpfade geändert oder neu erstellt werden.
