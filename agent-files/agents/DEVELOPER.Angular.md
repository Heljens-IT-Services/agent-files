# DEVELOPER.Angular.md

Stand: 2026-05-13

## Zweck

Diese Datei definiert Angular-spezifische Entwicklungsregeln dieses Repositories. Allgemeine Regeln stehen in `DEVELOPER.md`. Sie gilt fuer Angular-Anwendungen und Angular-nahe Frontend-Teile mit Routing, UI, State, Formularen, Datenzugriff und optionaler Offline-Faehigkeit.

[PRIORITY] Diese Regeln gelten in ihrem Scope vorrangig vor allgemeineren Regeln aus `DEVELOPER.md`.

## Versionsbasis

[MUST] Angular-Implementierungen muessen zu den im Projekt wirklich eingesetzten Versionen passen.

Aktuell verwendet das Repository:

- Angular `21.2.0` fuer `@angular/common`, `@angular/compiler`, `@angular/core`, `@angular/forms`, `@angular/platform-browser`, `@angular/router`
- Angular CLI und Build `21.2.10`
- TypeScript `5.9.2`
- RxJS `7.8.0`
- Standalone-Bootstrap mit `app.config.ts` und `app.routes.ts`
- SCSS als Standard fuer Component-Styling

[MUST] Abweichungen oder Upgrades muessen als eigenes technisches Thema behandelt werden.

[MUST_NOT] Abweichungen oder Upgrades duerfen nicht implizit innerhalb fachlicher Aenderungen mitgezogen werden.

## Zielbild

[MUST] Angular-Anwendungen muessen als reaktive, modulare Anwendungen gebaut werden.

[MUST] Komponenten muessen Daten anzeigen und Nutzerintentionen senden.

[MUST] Feature-State, Datenzugriff, lokale Persistenz und Hintergrundarbeit muessen ausserhalb der Komponenten liegen.

```mermaid
flowchart TD
    Component[Component / View] --> ComponentService[Component Service / Facade]
    ComponentService --> FStore[Feature Store / Feature State Service]
    FStore --> ComponentService
    FStore --> GStore[Global Store / Global State Service]
    GStore --> FStore
    GStore --> LocalData[IndexedDB / Local Cache]
    LocalData --> GStore
    GStore --> WebApi[Web API]
    WebApi --> GStore
```

## Standardstruktur

[SHOULD] Angular-Projekte sollen der folgenden Struktur folgen. Abweichungen sind erlaubt, wenn ein bestehendes Projekt eine andere stabile Struktur vorgibt und die konkrete Aufgabe keine Strukturmigration ist.

```text
src/app/
  core/
    auth/
    config/
    data-access/
    enums/
    guards/
    interfaces/
    layout/
    models/
    resolvers/
    services/
    state/
    util/
  shared/
    ui/
    util/
    pipes/
  features/
    <feature>/
      pages/
      components/
      models/
      services/
      store/
      util/
  app.routes.ts
  app.config.ts
```

[MUST] `src/app/core/` muss Singleton-nahe Infrastruktur wie Auth, Konfiguration, globale Services, State und Layout enthalten.

[MUST] `src/app/shared/` muss wiederverwendbare, fachlich neutrale UI-Bausteine und Hilfen enthalten.

[MUST] `src/app/features/` muss fachliche Features enthalten.

[MUST] Feature-Ordner muessen UI, Logik und lokale Modelle eines Features kapseln.

[MUST] `src/app/app.routes.ts` muss die Routen der Anwendung definieren.

[MUST] `src/app/app.config.ts` muss Bootstrap und globale Provider definieren.

[SHOULD] Standalone Components, `app.config.ts` und funktionale Provider sollen verwendet werden. Abweichungen sind erlaubt, wenn Legacy-Integration oder Bibliotheken `NgModule` erfordern.

## View-Regeln

[MUST] Components und Views muessen duenn bleiben.

[ALLOW] Komponenten duerfen Template-Zustand, Eingabe-/Ausgabe-Bindings und kleine UI-Entscheidungen enthalten.

[MUST] Komponenten muessen fachliche Aktionen an Facades, Component Services oder Use Cases delegieren.

[MUST_NOT] Komponenten duerfen Web APIs, IndexedDB, LocalStorage, Worker oder globale Stores nicht direkt aufrufen.

[MUST] Smart Components muessen mit einer Feature-Facade oder einem Component Service sprechen.

[SHOULD] Presentational Components sollen frei von fachlicher Orchestrierung bleiben. Abweichungen sind erlaubt, wenn eine sehr kleine Komponente eine lokale, rein visuelle Entscheidung kapselt.

## State-Regeln

[SHOULD] Signals sollen fuer synchronen UI-State verwendet werden. Abweichungen sind erlaubt, wenn Angular APIs oder externe Bibliotheken Observables vorgeben oder erwarten.

[MUST] Oeffentliche State-Reads muessen readonly oder ueber klar benannte Selector-Methoden angeboten werden.

[ALLOW_IF] State darf geaendert werden, wenn die Aenderung ueber explizite Methoden erfolgt.

[MUST] Abgeleiteter State muss berechnet werden.

[MUST_NOT] Abgeleiteter State darf nicht redundant gespeichert werden.

[MUST_NOT] RxJS darf nicht als Anwendungs-State- oder Datenfluss-Primitive verwendet werden.

[ALLOW_IF] Angular-/RxJS-Interop darf genutzt werden, wenn Angular APIs oder externe Bibliotheken Observables vorgeben oder erwarten.

## Datenfluss

[MUST] Nutzeraktionen in der View muessen Methoden der Facade oder des Component Service aufrufen.

[MUST] Facade, Store oder Application Service muessen Validierung, Datenzugriff, lokale Persistenz und Worker-Aufgaben koordinieren.

[ALLOW_IF] Die View darf Aenderungen erhalten, wenn sie ueber Signals, Computed Values oder klar benannte Read-APIs bereitgestellt werden.

[MUST_NOT] Direkte Kurzschluesse wie Component -> Web API, Component -> Local Storage oder Component -> globaler App-State duerfen nicht eingefuehrt werden.

## Lokale Daten und Offline-Faehigkeit

[MUST] IndexedDB und LocalStorage muessen ueber Adapter oder Repository-Services gekapselt werden.

[MUST] Offline- und Sync-Zustaende muessen explizit modelliert werden, z. B. `idle`, `loading`, `synced`, `dirty`, `conflict`, `failed`.

[MUST] Cache-Invalidierung, TTL, Konfliktloesung und manuelles Refresh-Verhalten muessen fachlich geregelt und getestet werden, wenn lokale Daten oder Offline-Faehigkeit Teil des Tasks sind.

## Web API und Worker

[MUST] HTTP-Zugriff muss in `core/data-access/` liegen.

[MUST_NOT] Komponenten duerfen HTTP-Zugriff nicht direkt enthalten.

[MUST] Fuer HTTP Requests muss `Promise<T>` oder `Promise` verwendet werden.

[MUST] DTOs muessen an der Grenze in fachliche View- oder Domain-Modelle gemappt werden.

[MUST] Interceptors muessen Auth, Correlation IDs, Retry fuer idempotente Requests und technische Fehlerklassen behandeln, wenn diese Querschnittsthemen im Projekt benoetigt werden.

[MUST] Cancellation muss fuer Requests, Worker-Jobs und laengere Streams vorgesehen werden.

## Forms und Validierung

[SHOULD] Signal Forms sollen verwendet werden, wenn die verwendete Angular-Version und das Projektsetup sie ohne experimentelle Flags, bekannte Blocker oder inkompatible Bibliotheken unterstuetzen.

[MUST] Fachliche Validierung muss wiederverwendbar sein.

[MUST] Geteilte fachliche Validierung muss in `shared/util` liegen.

[MUST] Formularzustaende wie `dirty`, `pending`, `invalid`, `saving` und `saved` muessen explizit behandelt werden.

## Styling, UI und Accessibility

[MUST_NOT] Designsysteme und Komponentenbibliotheken duerfen nicht ohne ausdrueckliche User-Anweisung installiert werden.

[MUST] Accessibility ist Teil der Definition of Done: Labels, Tastaturbedienung, Fokusfuehrung, Kontraste und semantische Elemente muessen beruecksichtigt werden.

[MUST] UI-Texte muessen fachlich praezise sein.

[MUST_NOT] Technische Erklaertexte und Metadaten duerfen nicht als sichtbare UI-Texte erscheinen.

## Unit Tests und E2E

[MUST] Unit Tests muessen Stores, Services, Guards, Resolver, Pipes und fachliche Hilfsfunktionen absichern, wenn diese im Task geaendert oder neu erstellt werden.

[SHOULD] E2E-Tests sollen mit Playwright kritische Nutzerfluesse abdecken. Abweichungen sind erlaubt, wenn das Projekt einen anderen E2E-Runner vorgibt oder der Task keinen sichtbaren Nutzerflow betrifft.

[MUST] Tests muessen sichtbares Verhalten und fachliche Zustaende pruefen.

[MUST_NOT] Tests duerfen private Implementierungsdetails nicht als primaeren Vertrag pruefen.

[SHOULD] Playwright-Tests sollen nutzerorientierte Selektoren wie `getByRole`, `getByLabel` und `getByText` verwenden. Abweichungen sind erlaubt, wenn Framework-Markup keine robuste semantische Auswahl ermoeglicht.

[ALLOW_IF] `data-testid` darf eingesetzt werden, wenn semantische Selektoren durch Framework-Markup nicht robust genug sind.

[MUST_NOT] Feste Wartezeiten wie `waitForTimeout` duerfen nicht verwendet werden.

[MUST] Tests muessen auf sichtbare Nutzerzustaende, URLs oder Rollen warten.

[MUST] E2E-Testfaelle muessen klein und klar benannt bleiben.

[MUST_NOT] Grosse Sammeltests duerfen nicht eingefuehrt werden.

## Qualitaet und Code

[MUST] TypeScript `strict` muss aktiviert bleiben.

[ALLOW_IF] `any` darf nur an technischen Grenzen mit begruendeter Kapselung verwendet werden.

[MUST] TypeScript-Modelle, DTOs und Objektvertraege muessen standardmaessig als `type` definiert werden.

[MUST_NOT] TypeScript-Modelle, DTOs und Objektvertraege duerfen nicht ohne technischen Grund als `interface` definiert werden.

[MUST] Die `type`-Konvention muss ueber `@typescript-eslint/consistent-type-definitions` erzwungen werden.

[ALLOW_IF] Abweichungen von der `type`-Konvention sind erlaubt, wenn ein technischer Grund vorliegt und das aktive Lint-Regelwerk die Abweichung erlaubt.

[MUST_NOT] Zirkulaere Feature-Abhaengigkeiten duerfen nicht eingefuehrt werden.

[MUST] Environment-spezifische Werte muessen ueber Konfiguration bereitgestellt werden.

[MUST_NOT] Environment-spezifische Werte duerfen nicht hart codiert werden.
