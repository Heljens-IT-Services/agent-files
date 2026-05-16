# DEVELOPER.Project.md

Stand: 2026-05-13

## Zweck

Diese Datei definiert projektspezifische Entwicklungsregeln fuer dieses Repository. Sie ergaenzt `DEVELOPER.md` und `DEVELOPER.Angular.md` um Entscheidungen fuer die Modernisierung der CRS-App.

[PRIORITY] Diese Regeln gelten fuer die modernisierte CRS-App und haben in diesem Scope Vorrang vor allgemeineren Regeln aus `DEVELOPER.md` und `DEVELOPER.Angular.md`.

## Technische Ausrichtung

[MUST] Die modernisierte App muss auf Angular mit Standalone-Bootstrap basieren.

[MUST] Fuer die UI muss Ignite UI for Angular von Infragistics als primaere Komponentenbibliothek verwendet werden.

[MUST] Projektweite Styles muessen unter `src/styles/styles.scss` liegen.

[MUST] Zentrale Theme-Definitionen und spaetere Design-Tokens muessen in `src/styles/theme.scss` liegen.

## UI- und Komponentenregeln

[SHOULD] Wenn Ignite UI for Angular fuer einen Use Case eine passende Komponente oder Direktive bereitstellt, soll diese verwendet werden. Abweichungen sind erlaubt, wenn Ignite UI den fachlichen Bedarf, Accessibility, Performance oder die benoetigte Interaktion nicht ausreichend abdeckt.

[ALLOW_IF] Eigene UI-Komponenten duerfen gebaut werden, wenn Ignite UI den fachlichen oder ergonomischen Bedarf nicht ausreichend abdeckt oder wenn eine gekapselte Projekterweiterung die Wartbarkeit verbessert.

[SHOULD] Eigene Komponenten sollen sich in Verhalten, Benennung und Zusammenspiel an Ignite UI orientieren. Abweichungen sind erlaubt, wenn Accessibility, Fachlogik oder bestehende Projektpatterns eine andere Loesung erfordern.

[SHOULD] Standalone-Imports von Ignite-UI-Komponenten und -Direktiven sollen verwendet werden. Abweichungen sind erlaubt, wenn eine Bibliothek oder ein konkreter Migrationsfall Legacy-`NgModule`-Imports erfordert.

[ALLOW_IF] Native HTML-Elemente ohne Ignite-UI-Huelle duerfen verwendet werden, wenn sie semantisch einfacher, technisch klarer oder fuer Accessibility robuster sind.

[MUST_NOT] Zusaetzliche UI-Bibliotheken duerfen nicht eingefuehrt werden, ohne vorher zu pruefen, ob Ignite UI plus kleine eigene Ergaenzungen den Bedarf abdecken.

## Layout, Styling und Theme

[MUST] Design-Variablen, Farben, Abstaende und Theme-Regeln muessen zentral in `src/styles/theme.scss` gepflegt werden.

[MUST] `src/styles/styles.scss` muss als globaler Einstiegspunkt fuer weitere globale Style-Dateien dienen.

[SHOULD] Feature- oder komponentenspezifische Styles sollen lokal an der Komponente bleiben. Abweichungen sind erlaubt, wenn ein Style als wiederverwendbares globales Designmuster benoetigt wird.

[SHOULD] Globale CSS-Regeln sollen auf Reset, App-Rahmen, Theme, Utility-Grundlagen und dokumentierte globale Muster beschraenkt bleiben. Abweichungen sind erlaubt, wenn eine technische Bibliothek globale Regeln verlangt.

[SHOULD] Ignite-UI-Theming, globale Stylesheets und Theme-Anpassungen sollen zentral gepflegt werden. Abweichungen sind erlaubt, wenn eine einzelne Komponente eine isolierte, nicht wiederverwendbare Anpassung braucht.

## Modernisierungskontext

[MUST] Dieses Repository muss als Modernisierung der Legacy-App `CRS.Ui.Cordova.Erfassung` behandelt werden, nicht als fachliche Neuerfindung.

[MUST] Fachliche Abweichungen vom Legacy-Verhalten muessen entschieden und dokumentiert werden, bevor sie umgesetzt werden.

[SHOULD] Analysen des Legacy-Stands sollen gegen `heljens/legacy` erfolgen. Abweichungen sind erlaubt, wenn der User einen anderen Remote, Branch oder Stand nennt.

[SHOULD] Neue Architektur- und UI-Entscheidungen sollen die fachliche Migration erleichtern und keine unnoetigen Parallelwelten erzeugen. Abweichungen sind erlaubt, wenn eine dokumentierte Migrationsgrenze getrennte Loesungen erfordert.

## Struktur und Integrationsregeln

[MUST] Neue Features muessen in die Zielstruktur der modernisierten App eingeordnet werden.

[MUST_NOT] Neue Features duerfen nicht nach Legacy-Seiten oder Cordova-Denkmustern reproduziert werden.

[ALLOW] Legacy-Begriffe duerfen fuer fachliche Wiedererkennbarkeit erhalten bleiben.

[MUST_NOT] Technische Altstrukturen wie monolithische Page-Logik, globale Mutable-Objekte oder eng gekoppelte Service-Ketten duerfen nicht uebernommen werden.

[MUST] Projektweite Konfiguration fuer Angular, Ignite UI, Styles und Build muss zentral gepflegt werden, insbesondere in `angular.json`, `src/app/app.config.ts` und `src/styles/`.

[MUST_IF] Vor der Einfuehrung neuer Abhaengigkeiten muss geprueft werden, ob sie zur Zielarchitektur und zum Ignite-UI-Ansatz des Projekts passen.

## Remote- und Branch-Kontext

[MUST] `heljens` muss als aktiver Arbeits-Remote behandelt werden.

[MUST] `christ` muss als Kunden-Remote fuer stabile bzw. auslieferbare Staende behandelt werden.

[MUST] `develop` muss als aktiver Branch fuer die modernisierte App behandelt werden.

[MUST_NOT] `main` und `legacy` duerfen nicht als Zielbasis fuer neue Modernisierungsarbeit genutzt werden.

[ALLOW_IF] `main` oder `legacy` duerfen als Zielbasis genutzt werden, wenn der User dies ausdruecklich anfordert.

## Arbeitsweise

[SHOULD] Aufgaben sollen primaer im GitHub-Repo zu `heljens` nachverfolgt werden. Abweichungen sind erlaubt, wenn der User einen anderen Arbeitskontext vorgibt.

[SHOULD] Kommentare in bestehenden Issues sollen knapp und direkt bleiben. Abweichungen sind erlaubt, wenn Review-, Sicherheits- oder Migrationskontext eine laengere Erklaerung erfordert.

[ALLOW] Neu erstellte Issues duerfen strukturierter und ausfuehrlicher sein, wenn dadurch Umsetzungs- oder Review-Kontext klarer wird.

[MUST] Nicht ausgefuehrte, ausgelassene oder fehlgeschlagene Checks muessen im Arbeitsabschluss explizit genannt werden.
