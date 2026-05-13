# DEVELOPER.Project.md

Stand: 2026-05-12

## Zweck

Diese Datei definiert projektspezifische Entwicklungsregeln fuer dieses Repository. Sie ergaenzt `DEVELOPER.md` und `DEVELOPER.Angular.md` um verbindliche Entscheidungen fuer die Modernisierung der CRS-App.

## Technische Ausrichtung

- Die modernisierte App basiert auf Angular mit Standalone-Bootstrap.
- Fuer die UI wird Ignite UI for Angular von Infragistics als primaere Komponentenbibliothek verwendet.
- Projektweite Styles liegen unter  `src/styles/styles.scss`.
- Zentrale Theme-Definitionen und spaetere Design-Tokens liegen in `src/styles/theme.scss`.

## UI- und Komponentenregeln

- Wenn Ignite UI for Angular fuer einen Use Case eine passende Komponente oder Direktive bereitstellt, wird sie bevorzugt verwendet.
- Eigene UI-Komponenten werden nur gebaut, wenn Ignite UI den fachlichen oder ergonomischen Bedarf nicht ausreichend abdeckt oder wenn eine gekapselte Projekterweiterung sinnvoller ist.
- Eigene Komponenten orientieren sich in Verhalten, Benennung und Zusammenspiel moeglichst eng an Ignite UI, damit die UI konsistent bleibt.
- Standalone-Imports von Ignite-UI-Komponenten und -Direktiven sind der Standard. Legacy-`NgModule`-Imports werden nur genutzt, wenn eine Bibliothek oder ein Migrationsfall sie wirklich erfordert.
- Native HTML-Elemente ohne Ignite-UI-Huelle sind zulaessig, wenn sie semantisch einfacher, technisch klarer oder fuer Accessibility robuster sind.
- Zusaetzliche UI-Bibliotheken werden nicht leichtfertig eingefuehrt. Vor einer weiteren Komponentenbibliothek ist zu pruefen, ob Ignite UI plus eigene kleine Ergaenzungen ausreichen.

## Layout, Styling und Theme

- Design-Variablen, Farben, Abstaende und Theme-Regeln werden zentral in `src/styles/theme.scss` gepflegt.
- `src/styles/styles.scss` dient als globaler Einstiegspunkt und referenziert weitere globale Style-Dateien.
- Feature- oder komponentenspezifische Styles bleiben lokal an der Komponente, solange sie nicht als globales Designmuster wiederverwendet werden.
- Globale CSS-Regeln bleiben sparsam. Sie sind fuer Reset, App-Rahmen, Theme, Utility-Grundlagen und bewusst globale Muster gedacht, nicht fuer fachliche Einzelansichten.
- Ignite-UI-Theming, globale Stylesheets und spaetere Theme-Anpassungen werden bevorzugt zentral statt ad hoc pro Komponente gepflegt.

## Modernisierungskontext

- Dieses Repository ist eine Modernisierung der Legacy-App `CRS.Ui.Cordova.Erfassung`, nicht eine fachliche Neuerfindung.
- Fachliche Abweichungen vom Legacy-Verhalten werden bewusst entschieden und dokumentiert, nicht versehentlich beim UI-Neubau eingefuehrt.
- Analysen des Legacy-Stands erfolgen bevorzugt gegen `heljens/legacy`, sofern nichts anderes vorgegeben ist.
- Neue Architektur- und UI-Entscheidungen sollen die fachliche Migration erleichtern und keine unnoetigen Parallelwelten erzeugen.

## Struktur und Integrationsregeln

- Neue Features werden in die Zielstruktur der modernisierten App eingeordnet und nicht nach Legacy-Seiten oder Cordova-Denkmustern reproduziert.
- Legacy-Begriffe duerfen fuer fachliche Wiedererkennbarkeit erhalten bleiben, aber technische Altstrukturen wie monolithische Page-Logik, globale Mutable-Objekte oder eng gekoppelte Service-Ketten werden nicht uebernommen.
- Projektweite Konfiguration fuer Angular, Ignite UI, Styles und Build wird zentral gepflegt, insbesondere in `angular.json`, `src/app/app.config.ts` und `src/styles/`.
- Wenn neue Abhaengigkeiten eingefuehrt werden, ist zu pruefen, ob sie zur Zielarchitektur und zum Ignite-UI-Ansatz des Projekts passen.

## Remote- und Branch-Kontext

- `heljens` ist der aktive Arbeits-Remote.
- `christ` ist der Kunden-Remote fuer stabile bzw. auslieferbare Staende.
- `develop` ist der aktive Branch fuer die modernisierte App.
- `main` und `legacy` sind Referenzstaende und keine Zielbasis fuer neue Modernisierungsarbeit, sofern nichts anderes angefordert ist.

## Arbeitsweise

- Aufgaben werden primaer im GitHub-Repo zu `heljens` nachverfolgt.
- Kommentare in bestehenden Issues bleiben knapp und direkt.
- Neu erstellte Issues duerfen strukturierter und ausfuehrlicher sein, wenn dadurch Umsetzungs- oder Review-Kontext klarer wird.
- Nicht ausgefuehrte, ausgelassene oder fehlgeschlagene Checks sind im Arbeitsabschluss explizit zu nennen.
