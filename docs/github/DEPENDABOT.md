# Dependabot-Leitplanke

## Zweck

Diese Leitplanke definiert, wann und wie eine repository-spezifische `.github/dependabot.yml` aus dem tatsächlichen technischen Bestand abgeleitet wird.

## Geltung

[MUST_IF] Ein Repository npm-, NuGet-, Docker-, Docker-Compose- oder GitHub-Actions-Abhängigkeiten verwendet, muss der Agent prüfen, ob eine passende `.github/dependabot.yml` vorhanden ist.

[MUST] Der Agent muss Paketmanager, Manifest- und Projektverzeichnisse, `Dockerfile`-/Compose-Dateien sowie GitHub-Actions-Workflows vor der Konfiguration aus dem Repository inventarisieren. Er darf keine universelle `updates`-Liste raten oder kopieren.

[MUST] Für tatsächlich vorhandene Ökosysteme müssen passende `package-ecosystem`-Einträge abgeleitet werden. Mindestens folgende Zuordnung ist zu berücksichtigen:

| Fund im Repository | Dependabot-Ökosystem |
|---|---|
| `package.json` oder Lockfile | `npm` |
| `.csproj`, `.fsproj` oder `packages.props` mit Paketabhängigkeiten | `nuget` |
| `Dockerfile` | `docker` |
| `docker-compose.yml`, `compose.yml` oder Varianten | `docker-compose` |
| Workflows unter `.github/workflows` | `github-actions` |

## Verzeichnisse und bestehende Profile

[MUST] Jeder `directory`- oder `directories`-Wert muss gegen den Repository-Bestand verifiziert werden. Root-, Multi-Directory-, Monorepo- und Multi-Solution-Strukturen müssen alle tatsächlich relevanten Manifest- oder Projektverzeichnisse abdecken.

[MUST] Eine vorhandene spezifischere Dependabot-Konfiguration muss zuerst geprüft werden. Sie darf nur bei nachgewiesenen Lücken oder Inkonsistenzen ergänzt oder korrigiert und nicht auf ein kleineres Standardprofil zurückgesetzt werden.

[MUST_NOT] Nicht vorhandene Ökosysteme oder Verzeichnisse dürfen nicht vorsorglich konfiguriert werden.

## Update-Profile

[MUST] Jeder `updates`-Eintrag muss einen expliziten sinnvollen Zeitplan, die Zeitzone `Europe/Berlin` und ein bewusst gewähltes `open-pull-requests-limit` erhalten.

[MUST] Der Agent muss verfügbare Gruppen, Cooldowns oder gleichwertige Mechanismen zur Noise-Reduktion bewerten. Minor-/Patch-Updates und zusammengehörige Framework-Pakete sollen gruppiert werden, wenn dies Review-Aufwand senkt und keine fachliche Trennung erfordert.

[MUST] Major-Updates müssen bewusst als eigene Risikoklasse behandelt werden; ihre gemeinsame oder getrennte Gruppierung ist nachvollziehbar aus Projektbedarf und Kompatibilität abzuleiten.

[ALLOW] Zeitpläne, Limits, Labels und Commit-Präfixe dürfen je Ökosystem und Repository unterschiedlich sein, wenn sie begründet zum Bestand passen.

## Verifikation

[MUST] Nach Erstellung oder Änderung muss die YAML syntaktisch geprüft werden.

[MUST] Der Agent muss jeden konfigurierten Ökosystem-/Verzeichniseintrag erneut gegen den Repository-Bestand prüfen und das Ergebnis mit abgedeckten sowie bewusst nicht konfigurierten Bereichen kompakt dokumentieren.
