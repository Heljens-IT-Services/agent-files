# DEVELOPER.Docker.md

Stand: 2026-10-18

## Zweck

Diese Datei gilt für Dockerfiles, Compose-Dateien und Container-Images. Zugehörige allgemeine Developer-Regeln werden über [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md), weitere technologiespezifische Regeldateien über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst.

## Basis-Images

[MUST] Basis-Images müssen aus offiziellen oder verifizierten Quellen stammen und schlanke Varianten wie `-slim`, `-alpine`, `chiseled` oder `distroless` bevorzugen, sofern die Anwendung damit lauffähig ist.

[MUST] Jedes Basis-Image muss mit fester Version referenziert werden, mindestens mit Major- und Minor-Version wie `node:22.11-slim` oder `mcr.microsoft.com/dotnet/aspnet:9.0`.

[MUST_NOT] Basis-Images dürfen nicht über `latest` oder ohne Tag referenziert werden.

[SHOULD] Produktive Images sollen ihr Basis-Image zusätzlich per Digest (`@sha256:...`) pinnen. Abweichungen sind erlaubt, wenn Dependabot oder ein vergleichbarer Prozess Tag-Aktualisierungen nachvollziehbar steuert.

[MUST_IF] Wenn ein Repository Dockerfiles oder Compose-Dateien enthält, müssen die Ökosysteme `docker` beziehungsweise `docker-compose` gemäß der [Dependabot-Leitplanke](https://heljens-it-services.github.io/agent-files/github/DEPENDABOT.md) abgedeckt sein.

## Aufbau des Dockerfiles

[MUST] Images mit Build-Schritt müssen Multi-Stage-Builds verwenden; das finale Image enthält nur Laufzeit, Anwendung und zwingend benötigte Dateien.

[MUST_NOT] SDKs, Compiler, Paketmanager-Caches, Testdaten und Quellcode dürfen nicht im finalen Image verbleiben, außer die Laufzeit benötigt sie zwingend.

[MUST] Schichten müssen für den Build-Cache geordnet sein: zuerst Abhängigkeitsdefinitionen wie `package.json`, Lockfiles, `*.csproj` oder `Directory.Packages.props` kopieren und wiederherstellen, erst danach den übrigen Quellcode kopieren.

[MUST] Jedes Build-Kontext-Verzeichnis muss eine `.dockerignore` besitzen, die mindestens `.git`, Build-Ausgaben, lokale Abhängigkeitsordner, `.env`-Dateien und IDE-Artefakte ausschließt.

[MUST] Builds müssen reproduzierbar sein: Abhängigkeiten werden aus Lockfiles mit festen Versionen installiert, etwa über `npm ci` oder `dotnet restore --locked-mode`.

[MUST_NOT] Paketinstallationen im Dockerfile dürfen nicht ungepinnt auf beliebige aktuelle Versionen auflösen, sofern das Ökosystem Lockfiles oder feste Versionen unterstützt.

[SHOULD] Zusammengehörige `RUN`-Befehle sollen so zusammengefasst werden, dass Paketlisten und temporäre Dateien in derselben Schicht entfernt werden.

## Laufzeit

[MUST] Das finale Image muss die Anwendung als Non-Root-User über `USER` ausführen.

[MUST] Ein Container muss genau einen Hauptprozess ausführen; zusätzliche Dienste wie Datenbanken oder Proxys laufen in eigenen Containern.

[MUST] `ENTRYPOINT` beziehungsweise `CMD` müssen in der Exec-Form (JSON-Array) angegeben werden, damit Signale den Hauptprozess erreichen.

[MUST] Laufzeitkonfiguration muss über Umgebungsvariablen oder eingebundene Konfigurationsdateien erfolgen, nicht durch umgebungsspezifische Images.

[MUST_IF] Wenn ein Container einen Dienst bereitstellt, muss ein `HEALTHCHECK` im Image oder ein `healthcheck` in Compose den tatsächlichen Betriebszustand prüfen.

[MUST_NOT_IF] Ein Healthcheck darf keine im finalen Image fehlenden Tools wie `curl` voraussetzen, wenn das Image diese nicht ausdrücklich bereitstellt.

## Secrets

[MUST_NOT] Secrets, Tokens und Zugangsdaten dürfen nicht über `ENV`, `ARG`, `COPY` oder Image-Labels in ein Image gelangen.

[MUST_IF] Wenn der Build Zugangsdaten benötigt, etwa für private Paketquellen, müssen BuildKit-Secrets über `RUN --mount=type=secret` verwendet werden.

## Compose

[SHOULD] Lokale Abhängigkeiten wie PostgreSQL, Redis oder Message Broker sollen über Compose bereitgestellt werden.

[MUST] Persistente Daten lokaler Dienste müssen in benannten Volumes liegen.

[MUST_IF] Wenn ein Dienst von einem anderen abhängt, muss `depends_on` mit `condition: service_healthy` verwendet werden, sofern der Zieldienst einen Healthcheck besitzt.

[MUST_NOT] Compose-Dateien dürfen keine produktiven Credentials, Hostnamen oder Verbindungszeichenfolgen enthalten.

[ALLOW_IF] Lokale Entwicklungszugangsdaten dürfen in Compose-Dateien stehen, wenn sie ausschließlich für lokale, nicht erreichbare Container gelten und als solche erkennbar sind; sonst sind sie über eine nicht versionierte `.env`-Datei einzubinden.

[MUST_IF] Wenn eine `.env`-Datei für Compose benötigt wird, muss eine versionierte Vorlage wie `.env.example` ohne echte Werte bereitstehen und die `.env`-Datei in `.gitignore` ausgeschlossen sein.

[SHOULD] Ports lokaler Abhängigkeiten sollen nur an `127.0.0.1` gebunden werden. Abweichungen sind erlaubt, wenn der Task einen Zugriff aus dem lokalen Netz ausdrücklich verlangt.
