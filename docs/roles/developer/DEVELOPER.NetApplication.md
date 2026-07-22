# DEVELOPER.NetApplication.md

Stand: 2026-07-22

## Zweck

Diese Datei definiert gemeinsame Regeln fuer geschichtete .NET-Anwendungen mit Entry-, Infrastructure- und Core-Projekten. Allgemeine C#- und .NET-Regeln stehen in [DEVELOPER.CSharpNet.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.CSharpNet.md); hostspezifische Regeln stehen in passenderen `DEVELOPER.Net*.md`-Dateien.

## Schichten und Referenzen

[MUST] `Core` muss fachliche Begriffe, Value Objects, Domain Services, Regeln, Fehler, Use Cases, Ports und Ergebnisobjekte enthalten.

[MUST] `Infrastructure` muss technische Adapter fuer Ports aus `Core` enthalten.

[MUST] Entry-Projekte muessen Composition Root fuer Host, Konfiguration, Logging, Dependency Injection sowie Ein- und Ausgabe sein.

[MUST] Die Referenzrichtung muss `Entry -> Infrastructure -> Core` sein.

[MUST_NOT] `Core` darf kein produktives Projekt und keine Laufzeitdetails aus Host, Transport, Konfiguration oder Dependency Injection referenzieren.

[ALLOW_IF] Weitere produktive Projekte und Testprojekte duerfen angelegt werden, wenn ihre Verantwortung begrenzt ist und sie keine Rueckreferenz in `Core` erzwingen.

## Fachliche und technische Grenzen

[MUST] Use Cases und Workflows muessen fachlich benannt sein.

[MUST] Workflows in `Core` muessen Use Cases ueber Ports orchestrieren und explizite Ergebnis- oder Statusobjekte liefern.

[MUST_NOT] Workflows duerfen fachliche Regeln nicht in langen Ablaufbloecken verstecken.

[MUST] Lang laufende Operationen muessen `CancellationToken` akzeptieren.

## Infrastruktur und Konfiguration

[MUST] Externe Dienste, Persistenz, Caches und Dateisysteme muessen ueber Ports aus `Core` angesprochen werden.

[MUST] Parser und Adapter muessen Rohdaten an der Systemgrenze in interne Modelle umwandeln und relevante Quelleninformationen erhalten.

[MUST] Retry, Timeout, Backoff, Fallback, technische Konfigurationsbindung und Persistenz muessen in `Infrastructure` liegen.

[MUST] Runtime-Konfiguration muss im Entry-Projekt geladen, fuer technische Komponenten typisiert gebunden und vor dem Start validiert werden.

[MUST_NOT] `Core` darf Konfiguration nicht direkt lesen.

[MUST] Fachlich relevante Konfiguration muss nach der Validierung explizit an `Core` uebergeben werden.

## Fehler und Tests

[MUST] Technische Fehler muessen in `Infrastructure` mit Diagnosekontext angereichert werden.

[MUST] Fachliche Regeln und Workflows muessen in `Core.Tests` mit Fake-Ports und kontrollierten Testdaten abgesichert werden.

[MUST] Infrastrukturtests muessen Adapter, Provider, Mapping, Serialisierung und Konfigurationsbindung ohne instabile Live-Dienste pruefen.
