# Workflow: Commit History Summary

## Ziel

Commits und gemergte Pull Requests eines Repositorys fuer einen angegebenen Zeitraum erfassen und als tabellarisches fachliches, technisches oder detailliertes Summary ausgeben.

## Verwenden

- Wenn ein Commit- und Pull-Request-Bericht fuer ein Datum, eine Anzahl vergangener Tage oder einen Zeitraum erstellt werden soll.
- Wenn die Ausgabe fuer Kundenkommunikation, technische Dokumentation oder eine detaillierte Historienpruefung gebraucht wird.
- Nicht verwenden, wenn offene Pull Requests, geplante Aenderungen oder Issues ausgewertet werden sollen.

## Verwendete Skills

- `github_commit-history-lesen`
- `dokumentation`

## Eingaben und Defaults

| Eingabe | Pflicht | Default | Aufloesung |
|---|---|---|---|
| Repository | Nein | aktuelles Repository | Explizite User-Angabe hat Vorrang. |
| Branch | Nein | Default-Branch des Repositorys | Nur von diesem Branch erreichbare Commits und in diesen Branch gemergte Pull Requests werden ausgewertet. |
| Zeitraum | Ja | - | Einzelnes Datum, Anzahl Tage oder Start- und Enddatum. |
| Modus | Nein | `customer` | `customer`, `technical` oder `detailed`. |
| Zeitzone | Nein | Zeitzone des Users, sonst `UTC` | Gilt fuer alle Zeitraumgrenzen und angezeigten Zeitpunkte. |

## Zeitraumregeln

- Ein einzelnes Datum umfasst den betreffenden Kalendertag von `00:00` bis zum Folgetag `00:00`.
- `N Tage` umfasst den aktuellen Kalendertag und die unmittelbar vorhergehenden `N - 1` Kalendertage.
- Ein Zeitraum aus Start- und Enddatum umfasst beide genannten Kalendertage.
- Intern muss jeder Zeitraum als halboffenes Intervall `[Start, Ende)` in der aufgeloesten Zeitzone behandelt werden.
- Wenn kein Zeitraum angegeben ist oder die Angabe mehrere Auslegungen zulaesst, muss vor der Datenerhebung nachgefragt werden.

## Modi

| Modus | Zielgruppe | Inhalt | Tabellenspalten |
|---|---|---|---|
| `customer` | Kunde oder fachlicher Stakeholder | Nach fachlichem Ergebnis gebuendelte Aenderungen, Nutzen und sichtbare Wirkung; technische Interna nur, wenn sie fuer das Verstaendnis notwendig sind. | Bereich, Aenderung, Kundennutzen |
| `technical` | Entwicklung und technische Stakeholder | Gebuendelte Implementierungen, betroffene Komponenten, technische Wirkung und dokumentierte Verifikation. | Bereich, Technische Umsetzung, Betroffene Komponenten, Verifikation |
| `detailed` | Audit, Nachverfolgung oder Vollstaendigkeitspruefung | Chronologisch absteigende Einzelauflistung aller Pull Requests und Commits einschliesslich ihrer Zuordnung. | Zeitpunkt, Typ, ID, Titel, Autor, Pull Request, Link |

Modusnamen werden ohne Beachtung der Gross-/Kleinschreibung aufgeloest und kanonisch in Kleinbuchstaben ausgegeben.

## Prompt-Beispiele

```text
/summary 2026-07-23
/summary 7 Tage mode: technical
/summary 2026-07-01 bis 2026-07-15 mode: detailed
```

## Ablauf

1. Repository, Branch, Zeitraum, Modus und Zeitzone aus der User-Anweisung aufloesen.
2. Zeitraum gemaess den Zeitraumregeln in ein exaktes Intervall umrechnen und die aufgeloesten Eingaben knapp ausweisen.
3. Mit `github_commit-history-lesen` alle Commits, gemergten Pull Requests und ihre Zuordnung fuer den Branch und das Intervall laden.
4. Pull Requests als primaere Aenderungseinheiten verwenden; zugeordnete Commits nicht zusaetzlich als eigenstaendige Aenderungen zaehlen.
5. Nicht zuordenbare Commits als eigenstaendige Aenderungseinheiten aufnehmen.
6. Im Modus `customer` Aenderungen nach fachlichem Ergebnis buendeln und mit `dokumentation` in kundengerechte Sprache ueberfuehren.
7. Im Modus `technical` Aenderungen nach technischer Verantwortung oder Komponente buendeln und mit `dokumentation` praezise zusammenfassen.
8. Im Modus `detailed` Pull Requests und Commits einzeln chronologisch ausgeben; Zuordnungen sichtbar machen, ohne Datensaetze zu verbergen.
9. Anzahl der gefundenen Pull Requests, Commits und eigenstaendigen Commits sowie vorhandene Kontextluecken nennen.

## Ruecksprungregeln

- Bei fehlendem oder mehrdeutigem Zeitraum zur Eingabeaufloesung zurueckkehren und nachfragen.
- Bei unbekanntem Modus die gueltigen Modi nennen und nachfragen.
- Bei unklarem Repository oder Branch zur Eingabeaufloesung zurueckkehren.
- Bei unvollstaendiger Historie zu `github_commit-history-lesen` zurueckkehren oder mit Blocker enden.
- Wenn aus Titel, Body und Commit-Nachrichten keine belastbare fachliche oder technische Aussage ableitbar ist, keine Wirkung erfinden, sondern die Kontextluecke ausweisen.

## Endergebnis

- aufgeloester Berichtsrahmen mit Repository, Branch, Zeitraum, Zeitzone und Modus
- tabellarisches Summary im gewaehlten Modus
- Anzahl der ausgewerteten Pull Requests, Commits und eigenstaendigen Commits
- Links zu den zugrunde liegenden Pull Requests und eigenstaendigen Commits
- benannte Kontextluecken oder Blocker

## Grenzen

- Nur gemergte Pull Requests und vom ausgewaehlten Branch erreichbare Commits auswerten.
- Keine fachliche Wirkung, Kundenwirkung, Verifikation oder technische Umsetzung erfinden.
- Im Modus `customer` keine Commit-SHAs, Branch-Namen oder Implementierungsdetails in die Haupttabelle aufnehmen.
- Im Modus `technical` keine Verifikation als erfolgreich darstellen, wenn sie nicht aus den Quellen hervorgeht.
- Im Modus `detailed` keine Commits oder Pull Requests wegen vermuteter geringer Relevanz auslassen.
- Keine Dateien erzeugen, ausser der User verlangt ausdruecklich ein Artefakt.
