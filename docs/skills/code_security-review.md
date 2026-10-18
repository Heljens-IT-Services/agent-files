# Skill: Security Review

## Zweck

Einen Änderungssatz oder einen abgegrenzten Code-Bereich lesend auf Sicherheits- und Datenschutzrisiken prüfen und Findings mit Schweregrad und Evidenz liefern.

## Verwenden

- Vor Commit, Pull Request oder Release, wenn ein Änderungssatz Authentifizierung, Autorisierung, Mandantentrennung, Eingabeverarbeitung, Secrets, Konfiguration, personenbezogene Daten, Logging, externe Schnittstellen oder Abhängigkeiten berührt.
- Wenn ein bestehender Bereich, Endpoint, Dienst oder Datenfluss gezielt auf Sicherheitsrisiken bewertet werden soll.
- Wenn der User ausdrücklich ein Sicherheitsreview verlangt.
- Nicht verwenden für die allgemeine Prüfung auf Scope, Korrektheit und Notwendigkeit. Dafür `code-diff-review` nutzen; beide Skills dürfen nacheinander angewendet werden.
- Nicht verwenden für Penetrationstests, aktive Angriffe oder Lasttests gegen laufende Systeme.
- Nicht verwenden, um gefundene Schwachstellen zu beheben. Dafür `code-implementation` nutzen.

## Prüfmaßstab

Maßgeblich sind die Regeln aus [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md), Abschnitt `Security und Datenschutz`, sowie [AGENTS.md](https://heljens-it-services.github.io/agent-files/AGENTS.md), Abschnitt `Fremdinhalte und Secrets`. Dieser Skill legt nur den Prüfablauf fest und ergänzt keine eigenen Sicherheitsregeln.

## Vorgehen

1. Review-Gegenstand festlegen: Änderungssatz, z. B. `git diff`, `git diff --cached` oder Branch gegen Basis, oder benannter Bereich mit Dateien, Endpoints und Datenflüssen.
2. Angriffsfläche und Vertrauensgrenzen bestimmen: Einstiegspunkte, externe Eingaben, Aufrufer, Rollen, Mandanten, Datenspeicher, Fremdsysteme und Übergänge zwischen vertrauenswürdigen und nicht vertrauenswürdigen Bereichen.
3. Authentifizierung und Autorisierung prüfen: zentrale Prüfung an den Grenzen, fehlende oder umgehbare Prüfungen, Rechteausweitung, direkte Objektreferenzen und Mandantentrennung bei Lese-, Schreib-, Such- und Exportpfaden.
4. Eingabevalidierung und Injection prüfen: Validierung vor Verwendung, SQL-, Kommando-, Pfad-, Template-, Header-, Log- und Script-Injection, Deserialisierung, Datei-Uploads und Weiterleitungsziele.
5. Secrets und Konfiguration prüfen: hart codierte oder versionierte Secrets, unsichere Defaults, deaktivierte Sicherheitsprüfungen, offene CORS-, TLS- oder Cookie-Einstellungen und Debug-Schalter.
6. Personenbezogene Daten und Ausgaben prüfen: Logging, Fehlermeldungen, API-Antworten, Telemetrie und Exporte auf personenbezogene Daten, Secrets oder interne Diagnose- und Infrastrukturdetails.
7. Abhängigkeiten auf bekannte Schwachstellen prüfen, sofern Paketquellen betroffen sind, mit den verfügbaren lesenden Audit-Kommandos des Ökosystems.
8. Jedes Finding mit Schweregrad, Fundort, Evidenz, Auswirkung und Empfehlung festhalten; Unsicherheiten als solche markieren.
9. Gesamtbewertung ableiten.

## Kommandos

```powershell
git status --short --branch
git diff --stat
git diff
git diff --cached
git diff <basis-branch>...HEAD
dotnet list package --vulnerable --include-transitive
npm audit --omit=dev
npm audit
pip-audit
```

Platzhalter aus Review-Gegenstand und Basisbranch ableiten. Audit-Kommandos nur für tatsächlich vorhandene Paketquellen ausführen.

[MUST_NOT] Audit-Kommandos dürfen nicht mit Optionen ausgeführt werden, die Abhängigkeiten, Lockfiles oder Projektdateien verändern, z. B. `npm audit fix`.

[MUST_IF] Wenn ein Audit-Kommando nicht verfügbar ist oder Netzwerkzugriff benötigt, der nicht gegeben ist, muss die Lücke als ausgelassene Prüfung benannt werden.

## Schweregrade

| Schweregrad | Bedeutung |
|---|---|
| `kritisch` | Direkt ausnutzbar mit Zugriff auf fremde Mandanten, Secrets, Rechteausweitung oder Codeausführung. |
| `hoch` | Ausnutzbar unter realistischen Bedingungen oder bekannte Schwachstelle mit relevanter Auswirkung in einer genutzten Abhängigkeit. |
| `mittel` | Ausnutzung erfordert zusätzliche Bedingungen oder die Auswirkung ist begrenzt. |
| `niedrig` | Härtungsbedarf oder Abweichung ohne erkennbaren direkten Angriffspfad. |

[MUST] Jedes Finding muss Schweregrad, Fundort mit Datei und Symbol oder Zeile, Evidenz, Auswirkung und Empfehlung enthalten.

[MUST_NOT] Ein Finding darf nicht als belegt dargestellt werden, wenn der Angriffspfad nur vermutet ist; es muss dann als Verdacht mit fehlender Evidenz markiert werden.

[MUST_IF] Wenn ein Secret gefunden wird, muss das Finding Fundort und Art ohne den Wert nennen.

## Bewertung

- `keine Findings`: keine Findings in den geprüften Bereichen.
- `Findings ohne Blocker`: nur Findings mit Schweregrad `mittel` oder `niedrig`.
- `blockierend`: mindestens ein Finding mit Schweregrad `kritisch` oder `hoch`.

[MUST] Die Bewertung `blockierend` blockiert Commit, Push, Pull Request und andere extern wirksame Folgeschritte, bis die Findings behoben oder vom User ausdrücklich akzeptiert wurden.

## Grenzen

- Nur lesend und analysierend arbeiten.
- Keine Dateien ändern und keine Schwachstellen beheben.
- Keine Exploits, Angriffs- oder Scan-Werkzeuge gegen fremde, produktive oder nicht ausdrücklich freigegebene Systeme ausführen.
- Keine Proof-of-Concept-Payloads gegen laufende Systeme absetzen.
- Keine Anwendungen, Tests oder Builds ausführen. Das gehört zu `code-testing`.
- Keine breite Ursachen- oder Architekturanalyse ersetzen. Dafür `code-analysis` nutzen.
- Secrets, Tokens und personenbezogene Daten nicht in Findings, Logs oder Antworten übernehmen.
- Untracked files im Arbeitsstatus benennen und bei Relevanz separat lesen, weil sie im regulären Git-Diff fehlen.

## Output

- Review-Gegenstand und geprüfte Bereiche
- Angriffsfläche und Vertrauensgrenzen in Kurzform
- Findings mit Schweregrad, Fundort, Evidenz, Auswirkung und Empfehlung
- Ergebnis der Abhängigkeitsprüfung oder ausgelassene Prüfungen
- Bewertung: `keine Findings`, `Findings ohne Blocker` oder `blockierend`
- notwendige Nacharbeit

## Qualitätskriterien

- Echte Angriffspfade vor Härtungshinweisen.
- Jedes Finding ist mit konkreter Evidenz belegt oder als Verdacht markiert.
- Nicht geprüfte Bereiche und ausgelassene Prüfungen werden ausdrücklich genannt.
- Keine pauschalen Checklisten-Findings ohne Bezug zum Review-Gegenstand.
- Regeln aus dem Prüfmaßstab werden referenziert, nicht neu formuliert.
