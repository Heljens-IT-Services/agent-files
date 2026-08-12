# DEVELOPER.Angular.md

Stand: 2026-08-12

## Zweck

Diese Datei gilt für Angular-Anwendungen und Angular-nahe Frontend-Teile. Zugehörige allgemeine, HTML-, CSS- und TypeScript-Regeln werden über [ROLES.md](https://heljens-it-services.github.io/agent-files/roles/ROLES.md) aufgelöst.

## Zielbild

Angular-Anwendungen werden als reaktive, modulare Anwendungen gebaut. Components zeigen Daten an und senden Nutzerintentionen; fachlicher Zustand, Datenzugriff, lokale Persistenz und Hintergrundarbeit liegen außerhalb der Components.

```mermaid
flowchart TD
    Component[Component / View] --> ComponentService[Component Service / Facade]
    ComponentService --> FStore[Feature Store / Feature State Service]
    FStore --> ComponentService
    FStore --> GStore[Global Store / Global State Service]
    GStore --> FStore
    FStore --> DataAccess[core/data-access]
    GStore --> DataAccess
    DataAccess --> LocalData[IndexedDB / Local Cache]
    LocalData --> DataAccess
    DataAccess --> WebApi[Web API]
    WebApi --> DataAccess
```

## Begriffe und Grenzen

[MUST] Components und Views sind für Darstellung, Nutzerinteraktion und lokalen Template-Zustand verantwortlich.

[ALLOW] Components dürfen Inputs lesen, Outputs senden, lokale UI-Signals halten, View-Modelle anzeigen und Methoden einer Facade oder eines Component Service aufrufen.

[MUST_NOT] Components dürfen keine fachlichen Workflows, HTTP-Zugriffe, Persistenzzugriffe, DTO-Mappings, globale State-Änderungen oder Worker-Aufgaben direkt ausführen.

[MUST] Eine Facade oder ein Component Service ist die direkte Schnittstelle zwischen View und fachlichem Ablauf eines Features.

[MUST] Bestehende Projektkonventionen müssen bestimmen, ob diese Schicht als Facade, Component Service, Feature Service oder Use Case benannt wird.

[MUST] Facades oder Component Services müssen Nutzeraktionen aus der View in klar benannte Operationen übersetzen, z. B. `saveDraft`, `loadDetails`, `confirmSelection` oder `refresh`.

[ALLOW] Facades oder Component Services dürfen View-nahe Koordination enthalten, z. B. Laden, Speichern, Fehlerabbildung, Navigation nach erfolgreicher Aktion oder Zusammenbau eines View-Models.

[MUST_NOT] Facades oder Component Services dürfen technische Details wie konkrete HTTP-Endpunkte, IndexedDB-Stores oder Storage-Schlüssel nicht offenlegen.

[MUST] Ein Feature Store oder Feature State Service hält den Zustand eines fachlichen Features.

[MUST] Feature State muss über readonly Signals, computed Values oder klar benannte Selector-Methoden lesbar sein.

[MUST] Feature State darf nur über explizite Methoden geändert werden, z. B. `load`, `setFilter`, `markDirty`, `applyServerResult` oder `reset`.

[MUST_NOT] Feature Stores dürfen keine Template-spezifischen Layout- oder Anzeigeentscheidungen enthalten.

[MUST] Ein Global Store oder Global State Service muss auf app-weiten Zustand beschränkt bleiben, der von mehreren Features benötigt wird, z. B. angemeldeter Nutzer, Berechtigungen, Mandant, Sprache, Online-Status oder globale Konfiguration.

[MUST_NOT] Feature-spezifischer Zustand darf nicht in globalen State verschoben werden, nur weil mehrere Komponenten desselben Features ihn brauchen.

[MUST] Data-Access Services kapseln technische Kommunikation mit externen Systemen, z. B. HTTP APIs.

[MUST] Data-Access Services müssen DTOs, Request-Parameter, technische Fehler und Transportdetails an der Systemgrenze behandeln.

[MUST_NOT] Data-Access Services dürfen keine UI-Zustände wie `selected`, `expanded`, `editing` oder `visible` modellieren.

[MUST] Repository- oder Adapter-Services kapseln lokale Persistenz wie IndexedDB, LocalStorage oder Cache-Schichten.

[ALLOW] Repository- oder Adapter-Services dürfen Speicherformat, Keys, Versionierung und Migration kennen.

[MUST_NOT] Repository- oder Adapter-Services dürfen nicht entscheiden, welche Nutzeraktion fachlich erlaubt ist.

[MUST] Worker-Services kapseln Hintergrundarbeit und stellen eine abbrechbare, klar benannte API bereit.

[MUST_NOT_IF] Worker-Aufrufe dürfen nicht direkt aus Components gestartet werden, wenn sie fachlichen Zustand, Persistenz oder API-Kommunikation beeinflussen.

## Standardstruktur

[SHOULD] Angular-Projekte sollen der folgenden Struktur folgen. Abweichungen sind erlaubt, wenn ein bestehendes Projekt eine andere stabile Struktur vorgibt und die konkrete Aufgabe keine Strukturmigration ist.

```text
src/
  app/
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
    features/
      <feature>/
        page/
        components/
          <component-name>/
        models/
        services/
        store/
        util/
    shared/
      ui/
      util/
      pipes/
    spec/
      features/
        <feature>/
          page/
          components/
            <component-name>/
          services/
            <service-name>/
          store/
          util/
      core/
      shared/
    app.routes.ts
    app.config.ts
  environments/
  styles/
```

[MUST] `src/app/core/` muss Singleton-nahe Infrastruktur wie Auth, Konfiguration, globale Services, State und Layout enthalten.

[MUST] `src/app/shared/` muss wiederverwendbare, fachlich neutrale UI-Bausteine und Hilfen enthalten.

[MUST] `src/app/features/` muss fachliche Features enthalten.

[MUST] `src/app/spec/` muss Unit-Specs und ausschließlich für Tests benötigte Hilfsartefakte enthalten und als Geschwisterordner von `core/`, `features/` und `shared/` direkt unter `src/app/` liegen.

[MUST] Feature-Ordner müssen UI, Logik und lokale Modelle eines Features kapseln.

[MUST] Jedes Feature muss genau eine fachliche Hauptkomponente unter `<feature>/page/` enthalten. Diese Komponente repräsentiert den primären Einstiegspunkt des Features.

[SHOULD] Die Hauptkomponente des Features soll bevorzugt per Route angesteuert werden.

[MUST] Hilfskomponenten, Teilansichten und Subkomponenten eines Features müssen unter `<feature>/components/` liegen.

[MUST] Feature-Komponenten unter `<feature>/components/` müssen jeweils in einem eigenen Ordner nach dem Schema `<feature>/components/<component-name>/` organisiert werden.

[MUST] `src/app/app.routes.ts` muss die Routen der Anwendung definieren.

[MUST] `src/app/app.config.ts` muss Bootstrap und globale Provider definieren.

[SHOULD] Standalone Components, `app.config.ts` und funktionale Provider sollen verwendet werden. Abweichungen sind erlaubt, wenn Legacy-Integration oder Bibliotheken `NgModule` erfordern.

## TypeScript-Pfad-Aliase

[MUST] Angular-Projekte müssen TypeScript-Pfad-Aliase über `compilerOptions.paths` verwenden, damit Architekturgrenzen in Imports sichtbar bleiben und tiefe relative Imports vermieden werden.

[MUST] Mindestens `src/app/core/`, `src/app/shared/` und `src/app/spec/` müssen jeweils einen eigenen Alias mit `@`-Präfix besitzen, standardmäßig `@core`, `@shared` und `@spec`, jeweils einschließlich Wildcard-Variante wie `@core/*`.

[MUST] Jeder direkte Feature-Ordner unter `src/app/features/<feature>/` muss einen eigenen fachlich benannten `@`-Alias besitzen, z. B. `@login`, `@settings` oder `@order-management`, jeweils einschließlich Wildcard-Variante.

[MUST] Imports zwischen Core, Shared, Spec und Features müssen die konfigurierten Pfad-Aliase verwenden, sobald der Import die Grenze des lokalen Teilbaums überschreitet.

[MUST_NOT] Tiefe relative Imports wie `../../../core/...`, `../../shared/...` oder vergleichbare Imports über Architekturgrenzen hinweg dürfen verwendet werden, wenn dafür ein definierter Pfad-Alias existiert.

[MUST_IF] Wird ein neuer Feature-Ordner angelegt oder umbenannt, muss der zugehörige TypeScript-Pfad-Alias im selben Task angelegt oder angepasst werden.

[SHOULD] Aliase sollen auf Architektur- oder Feature-Grenzen beschränkt bleiben; für interne Dateien innerhalb desselben kleinen Teilbaums dürfen kurze relative Imports verwendet werden.

```json
{
  "compilerOptions": {
    "paths": {
      "@core": ["./src/app/core"],
      "@core/*": ["./src/app/core/*"],
      "@shared": ["./src/app/shared"],
      "@shared/*": ["./src/app/shared/*"],
      "@spec": ["./src/app/spec"],
      "@spec/*": ["./src/app/spec/*"],
      "@<feature>": ["./src/app/features/<feature>"],
      "@<feature>/*": ["./src/app/features/<feature>/*"]
    }
  }
}
```

## Templates und Component-Markup

[MUST] Komplexe Angular-Template-Ausdrücke müssen in `computed`, readonly Properties oder View-Modelle ausgelagert werden.

[MUST_NOT] Methodenaufrufe im Template dürfen keine Seiteneffekte, Datenzugriffe, Mutationen, teuren Berechnungen oder asynchronen Operationen auslösen.

[SHOULD] Mehrfach verschachtelte `@if`, `@for` oder `ng-template`-Strukturen sollen durch kleinere Presentational Components, benannte computed Values oder View-Modelle vereinfacht werden.

[MUST] Listen müssen stabile fachliche `track`-Ausdrücke verwenden.

[MUST_NOT_IF] Array-Index darf nicht als `track` verwendet werden, wenn fachliche IDs oder stabile Schlüssel verfügbar sind.

## UI-Änderungen durch Agents

[MUST] Vor neuen Komponenten, Klassen oder Utilities muss geprüft werden, ob im Projekt bereits ein passendes Pattern existiert.

[MUST_IF] Wenn ein UI-Problem durch ein gemeinsames Pattern verursacht wird oder mehrfach vorkommt, muss die gemeinsame Stelle angepasst oder die lokale Ausnahme im Arbeitsabschluss begründet werden.

[MUST_IF] Screenshots, Storybook, Playwright oder vergleichbare visuelle Checks müssen genutzt werden, wenn Angular-UI-Änderungen Layout, Responsiveness, Accessibility oder sichtbare Nutzerflows betreffen und diese Werkzeuge im Projekt verfügbar sind.

## State-Regeln

[SHOULD] Signals sollen für synchronen UI-State verwendet werden. Abweichungen sind erlaubt, wenn Angular APIs oder externe Bibliotheken Observables vorgeben oder erwarten.

[MUST] Abgeleiteter Signal-State muss berechnet werden und darf nicht redundant gespeichert werden.

[MUST_NOT] RxJS darf nicht als Anwendungs-State- oder Datenfluss-Primitive verwendet werden.

[ALLOW_IF] Angular-/RxJS-Interop darf genutzt werden, wenn Angular APIs oder externe Bibliotheken Observables vorgeben oder erwarten.

## Lokale Daten und Offline-Fähigkeit

[MUST] Offline- und Sync-Zustände müssen explizit modelliert werden, z. B. `idle`, `loading`, `synced`, `dirty`, `conflict`, `failed`.

[MUST_IF] Nach einem Datenquellenausfall angezeigte Cache- oder zuletzt bekannte Daten müssen für Nutzer als offline oder veraltet gekennzeichnet sein.

[MUST_IF] Cache-Invalidierung, TTL, Konfliktlösung und manuelles Refresh-Verhalten müssen fachlich geregelt und getestet werden, wenn lokale Daten oder Offline-Fähigkeit Teil des Tasks sind.

## Web API und Worker

[MUST] HTTP-Zugriff muss in `core/data-access/` liegen.

[SHOULD] Für einmalige HTTP Requests soll `Promise<T>` oder `Promise` verwendet werden.

[ALLOW_IF] `Observable` darf für HTTP Requests verwendet werden, wenn Angular APIs, Interceptors, Cancellation, Progress Events, Streams oder externe Bibliotheken dies vorgeben oder fachlich sinnvoll machen.

[MUST] DTOs müssen an der Grenze in fachliche View- oder Domain-Modelle gemappt werden.

[MUST_IF] Wenn der Ausfall eines notwendigen HTTP-Requests einen Nutzerablauf betrifft, muss der Feature State einen expliziten Fehlerzustand abbilden und die UI ihn verständlich darstellen.

[MUST_IF] Interceptors müssen Auth, Correlation IDs, Retry für idempotente Requests und technische Fehlerklassen behandeln, wenn diese Querschnittsthemen im Projekt benötigt werden.

[MUST] Cancellation muss für Requests, Worker-Jobs und längere Streams vorgesehen werden.

## Forms und Validierung

[SHOULD] Signal Forms sollen verwendet werden, wenn die verwendete Angular-Version und das Projektsetup sie ohne experimentelle Flags, bekannte Blocker oder inkompatible Bibliotheken unterstützen.

[MUST] Geteilte fachliche Formularvalidierung muss wiederverwendbar außerhalb der Component liegen, z. B. in `shared/util`.

[MUST] Formularzustände wie `dirty`, `pending`, `invalid`, `saving` und `saved` müssen explizit behandelt werden.

## Unit Tests und E2E

[MUST_IF] Unit Tests müssen Stores, Services, Guards, Resolver, Pipes und fachliche Hilfsfunktionen absichern, wenn diese im Task geändert oder neu erstellt werden.

[MUST] Unit-Spec-Dateien müssen unter dem zentralen Test-Root `src/app/spec/` liegen und dürfen nicht neben dem Produktivcode in `src/app/core/`, `src/app/features/` oder `src/app/shared/` abgelegt werden.

[MUST] Die Struktur unter `src/app/spec/` muss die fachliche Zuordnung des Produktivcodes nachvollziehbar spiegeln, z. B. `src/app/spec/features/<feature>/components/<component-name>/` oder `src/app/spec/features/<feature>/services/<service-name>/`.

[MUST] Alle ausschließlich für einen Testgegenstand benötigten Test-Helper, Fixtures, Builder, Mocks, Fakes, Stubs und Testdaten müssen im Ordner dieses Testgegenstands unter `src/app/spec/` liegen.

[SHOULD] Test-Utilities, die von mehreren Testgegenständen desselben Features verwendet werden, sollen auf der kleinsten gemeinsamen Ebene innerhalb von `src/app/spec/features/<feature>/` liegen.

[SHOULD] Nur projektweit wiederverwendbare Test-Infrastruktur soll unter einer gemeinsamen Struktur wie `src/app/spec/shared/` oder `src/app/spec/core/` liegen.

[MUST_NOT] Test-only Helper, Fixtures, Builder, Mocks, Fakes oder Stubs dürfen nicht in produktive `src/app/**/util`, `services` oder `shared`-Ordner verschoben werden, nur um sie für Specs erreichbar zu machen.

[MUST_NOT] Produktivcode unter `src/app/core/`, `src/app/features/` oder `src/app/shared/` darf aus `src/app/spec/` oder über `@spec` importieren.

[MUST_IF] Test-Runner-, TypeScript- oder Coverage-Konfigurationen müssen angepasst werden, wenn sie durch die zentrale `src/app/spec/`-Struktur Specs nicht automatisch finden, kompilieren oder korrekt auflösen.

[MUST_IF] Tests geänderter oder neuer Datenladevorgänge müssen nachweisen, dass Request-Fehler den vorgesehenen Fehlerzustand statt eines erfolgreichen leeren Zustands auslösen.

[SHOULD] E2E-Tests sollen mit Playwright kritische Nutzerflüsse abdecken. Abweichungen sind erlaubt, wenn das Projekt einen anderen E2E-Runner vorgibt oder der Task keinen sichtbaren Nutzerflow betrifft.

[SHOULD] Playwright-Tests sollen nutzerorientierte Selektoren wie `getByRole`, `getByLabel` und `getByText` verwenden.

[ALLOW_IF] `data-testid` darf eingesetzt werden, wenn semantische Selektoren nicht robust genug sind.

[MUST_NOT] Feste Wartezeiten wie `waitForTimeout` dürfen nicht verwendet werden.

## Qualität und Code

[MUST_NOT] Zirkuläre Feature-Abhängigkeiten dürfen nicht eingeführt werden.
