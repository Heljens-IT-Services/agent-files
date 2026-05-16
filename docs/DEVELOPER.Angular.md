# DEVELOPER.Angular.md

Stand: 2026-05-16

## Zweck

Diese Datei definiert Angular-spezifische Entwicklungsregeln. Allgemeine Regeln stehen in [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.md). HTML-, CSS- und TypeScript-spezifische Regeln stehen in [DEVELOPER.Html.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.Html.md), [DEVELOPER.Css.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.Css.md) und [DEVELOPER.TypeScript.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.TypeScript.md). Sie gilt fuer Angular-Anwendungen und Angular-nahe Frontend-Teile mit Routing, UI, State, Formularen, Datenzugriff und optionaler Offline-Faehigkeit.

[PRIORITY] Diese Regeln gelten in ihrem Scope vorrangig vor allgemeineren Regeln aus [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/DEVELOPER.md).

## Zielbild

Angular-Anwendungen werden als reaktive, modulare Anwendungen gebaut. Components zeigen Daten an und senden Nutzerintentionen; fachlicher Zustand, Datenzugriff, lokale Persistenz und Hintergrundarbeit liegen ausserhalb der Components.

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

## Begriffe und Grenzen

[MUST] Components und Views sind fuer Darstellung, Nutzerinteraktion und lokalen Template-Zustand verantwortlich.

[ALLOW] Components duerfen Inputs lesen, Outputs senden, lokale UI-Signals halten, View-Modelle anzeigen und Methoden einer Facade oder eines Component Service aufrufen.

[MUST_NOT] Components duerfen keine fachlichen Workflows, HTTP-Zugriffe, Persistenzzugriffe, DTO-Mappings, globale State-Aenderungen oder Worker-Aufgaben direkt ausfuehren.

[MUST] Eine Facade oder ein Component Service ist die direkte Schnittstelle zwischen View und fachlichem Ablauf eines Features.

[MUST] Bestehende Projektkonventionen muessen bestimmen, ob diese Schicht als Facade, Component Service, Feature Service oder Use Case benannt wird.

[MUST] Facades oder Component Services muessen Nutzeraktionen aus der View in klar benannte Operationen uebersetzen, z. B. `saveDraft`, `loadDetails`, `confirmSelection` oder `refresh`.

[MUST] Facades oder Component Services duerfen View-nahe Koordination enthalten, z. B. Laden, Speichern, Fehlerabbildung, Navigation nach erfolgreicher Aktion oder Zusammenbau eines View-Models.

[MUST_NOT] Facades oder Component Services duerfen technische Details wie konkrete HTTP-Endpunkte, IndexedDB-Stores oder Storage-Schluessel offenlegen.

[MUST] Ein Feature Store oder Feature State Service haelt den Zustand eines fachlichen Features.

[MUST] Feature State muss ueber readonly Signals, computed Values oder klar benannte Selector-Methoden lesbar sein.

[MUST] Feature State darf nur ueber explizite Methoden geaendert werden, z. B. `load`, `setFilter`, `markDirty`, `applyServerResult` oder `reset`.

[MUST_NOT] Feature Stores duerfen keine Template-spezifischen Layout- oder Anzeigeentscheidungen enthalten.

[MUST] Ein Global Store oder Global State Service darf nur app-weiten Zustand halten, der von mehreren Features benoetigt wird, z. B. angemeldeter Nutzer, Berechtigungen, Mandant, Sprache, Online-Status oder globale Konfiguration.

[MUST_NOT] Feature-spezifischer Zustand darf nicht in globalen State verschoben werden, nur weil mehrere Komponenten desselben Features ihn brauchen.

[MUST] Data-Access Services kapseln technische Kommunikation mit externen Systemen, z. B. HTTP APIs.

[MUST] Data-Access Services muessen DTOs, Request-Parameter, technische Fehler und Transportdetails an der Systemgrenze behandeln.

[MUST_NOT] Data-Access Services duerfen keine UI-Zustaende wie `selected`, `expanded`, `editing` oder `visible` modellieren.

[MUST] Repository- oder Adapter-Services kapseln lokale Persistenz wie IndexedDB, LocalStorage oder Cache-Schichten.

[MUST] Repository- oder Adapter-Services duerfen Speicherformat, Keys, Versionierung und Migration kennen.

[MUST_NOT] Repository- oder Adapter-Services duerfen nicht entscheiden, welche Nutzeraktion fachlich erlaubt ist.

[MUST] Worker-Services kapseln Hintergrundarbeit und stellen eine abbrechbare, klar benannte API bereit.

[MUST_NOT] Worker-Aufrufe duerfen nicht direkt aus Components gestartet werden, wenn sie fachlichen Zustand, Persistenz oder API-Kommunikation beeinflussen.

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
    store/
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

## Templates und Component-Markup

[MUST] Komplexe Angular-Template-Ausdruecke muessen in `computed`, readonly Properties oder View-Modelle ausgelagert werden.

[MUST_NOT] Methodenaufrufe im Template duerfen Seiteneffekte, Datenzugriffe, Mutationen, teure Berechnungen oder asynchrone Operationen ausloesen.

[SHOULD] Mehrfach verschachtelte `@if`, `@for` oder `ng-template`-Strukturen sollen durch kleinere Presentational Components, benannte computed Values oder View-Modelle vereinfacht werden.

[MUST] Listen muessen stabile fachliche `track`-Ausdruecke verwenden.

[MUST_NOT] Array-Index darf nicht als `track` verwendet werden, wenn fachliche IDs oder stabile Schluessel verfuegbar sind.

## UI-Aenderungen durch Agents

[MUST] Vor neuen Komponenten, Klassen oder Utilities muss geprueft werden, ob im Projekt bereits ein passendes Pattern existiert.

[MUST_IF] Wenn ein UI-Problem durch ein gemeinsames Pattern verursacht wird oder mehrfach vorkommt, muss die gemeinsame Stelle angepasst oder die lokale Ausnahme im Arbeitsabschluss begruendet werden.

[MUST_IF] Screenshots, Storybook, Playwright oder vergleichbare visuelle Checks muessen genutzt werden, wenn Angular-UI-Aenderungen Layout, Responsiveness, Accessibility oder sichtbare Nutzerflows betreffen und diese Werkzeuge im Projekt verfuegbar sind.

## State-Regeln

[SHOULD] Signals sollen fuer synchronen UI-State verwendet werden. Abweichungen sind erlaubt, wenn Angular APIs oder externe Bibliotheken Observables vorgeben oder erwarten.

[MUST] Abgeleiteter Signal-State muss berechnet werden und darf nicht redundant gespeichert werden.

[MUST_NOT] RxJS darf nicht als Anwendungs-State- oder Datenfluss-Primitive verwendet werden.

[ALLOW_IF] Angular-/RxJS-Interop darf genutzt werden, wenn Angular APIs oder externe Bibliotheken Observables vorgeben oder erwarten.

## Lokale Daten und Offline-Faehigkeit

[MUST] IndexedDB und LocalStorage muessen ueber Adapter oder Repository-Services gekapselt werden.

[MUST] Offline- und Sync-Zustaende muessen explizit modelliert werden, z. B. `idle`, `loading`, `synced`, `dirty`, `conflict`, `failed`.

[MUST_IF] Cache-Invalidierung, TTL, Konfliktloesung und manuelles Refresh-Verhalten muessen fachlich geregelt und getestet werden, wenn lokale Daten oder Offline-Faehigkeit Teil des Tasks sind.

## Web API und Worker

[MUST] HTTP-Zugriff muss in `core/data-access/` liegen.

[MUST] Fuer HTTP Requests muss `Promise<T>` oder `Promise` verwendet werden.

[MUST] DTOs muessen an der Grenze in fachliche View- oder Domain-Modelle gemappt werden.

[MUST_IF] Interceptors muessen Auth, Correlation IDs, Retry fuer idempotente Requests und technische Fehlerklassen behandeln, wenn diese Querschnittsthemen im Projekt benoetigt werden.

[MUST] Cancellation muss fuer Requests, Worker-Jobs und laengere Streams vorgesehen werden.

## Forms und Validierung

[SHOULD] Signal Forms sollen verwendet werden, wenn die verwendete Angular-Version und das Projektsetup sie ohne experimentelle Flags, bekannte Blocker oder inkompatible Bibliotheken unterstuetzen.

[MUST] Geteilte fachliche Formularvalidierung muss wiederverwendbar ausserhalb der Component liegen, z. B. in `shared/util`.

[MUST] Formularzustaende wie `dirty`, `pending`, `invalid`, `saving` und `saved` muessen explizit behandelt werden.

## Unit Tests und E2E

[MUST_IF] Unit Tests muessen Stores, Services, Guards, Resolver, Pipes und fachliche Hilfsfunktionen absichern, wenn diese im Task geaendert oder neu erstellt werden.

[SHOULD] E2E-Tests sollen mit Playwright kritische Nutzerfluesse abdecken. Abweichungen sind erlaubt, wenn das Projekt einen anderen E2E-Runner vorgibt oder der Task keinen sichtbaren Nutzerflow betrifft.

[SHOULD] Playwright-Tests sollen nutzerorientierte Selektoren wie `getByRole`, `getByLabel` und `getByText` verwenden.

[ALLOW_IF] `data-testid` darf eingesetzt werden, wenn semantische Selektoren nicht robust genug sind.

[MUST_NOT] Feste Wartezeiten wie `waitForTimeout` duerfen nicht verwendet werden.

## Qualitaet und Code

[MUST_NOT] Zirkulaere Feature-Abhaengigkeiten duerfen nicht eingefuehrt werden.
