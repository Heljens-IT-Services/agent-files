# Snippet: .NET Build Hygiene

Stand: 2026-10-15

## Zweck

Einheitliche Build-Basis für .NET-Repositories: gemeinsame Sprach- und Analyseeinstellungen, Warnungen als Fehler, Schwachstellenprüfung der Pakete, zentrale Paketversionen und ein festgelegter SDK- und Test-Runner.

## Verwenden

- Wenn ein .NET-Repository neu angelegt wird oder seine Build-Konfiguration geändert wird.
- Wenn Pakete hinzugefügt, aktualisiert oder entfernt werden.
- Nicht verwenden für einzelne Skripte oder Werkzeuge außerhalb einer Solution.

## Dateien

| Datei | Ablage | Zweck |
|---|---|---|
| [Directory.Build.props](https://heljens-it-services.github.io/agent-files/snippets/dotnet-build-hygiene/Directory.Build.props) | Repository-Root | Sprache, Warnungen, NuGet-Audit und Analyse für alle Projekte. |
| [Directory.Packages.props](https://heljens-it-services.github.io/agent-files/snippets/dotnet-build-hygiene/Directory.Packages.props) | Repository-Root | Zentrale Paketversionen und globale Analyzer; Beispielversionen. |
| [global.json](https://heljens-it-services.github.io/agent-files/snippets/dotnet-build-hygiene/global.json) | Repository-Root | SDK-Version und Microsoft.Testing.Platform als Test-Runner. |
| [editorconfig](https://heljens-it-services.github.io/agent-files/snippets/dotnet-build-hygiene/editorconfig) | Repository-Root als `.editorconfig` | Code-Style sowie Analyzer-Ausnahmen für Tests, Migrationen, erzeugten Vertragscode und `Module.cs`. |
| [Tests.Directory.Build.props](https://heljens-it-services.github.io/agent-files/snippets/dotnet-build-hygiene/Tests.Directory.Build.props) | Testordner als `Directory.Build.props` | Gemeinsame Einstellungen und Pakete aller Testprojekte. |

## Regeln

[MUST] Jedes .NET-Repository muss `Directory.Build.props`, `Directory.Packages.props` und `global.json` im Repository-Root besitzen.

[MUST] `TargetFramework`, `Nullable`, `ImplicitUsings`, Warnungs- und Analyseeinstellungen müssen in `Directory.Build.props` stehen und dürfen in Projektdateien nicht wiederholt oder abgeschwächt werden.

[MUST] `TreatWarningsAsErrors`, `EnforceCodeStyleInBuild` und `AnalysisLevel` mindestens `latest-Recommended` müssen aktiv sein.

[MUST] NuGet-Audit muss mit `NuGetAuditMode` `all` laufen; Schwachstellen hoher und kritischer Schwere (`NU1903`, `NU1904`) müssen den Build brechen.

[MUST] Paketversionen dürfen ausschließlich in `Directory.Packages.props` stehen. `VersionOverride` ist abgeschaltet.

[MUST_IF] Wenn NuGet-Audit eine transitive Schwachstelle meldet, muss das betroffene Paket in `Directory.Packages.props` auf eine behobene Version gepinnt und der Grund in einem Kommentar genannt werden.

[MUST_NOT] Warnungen dürfen nicht über `NoWarn`, `#pragma` oder `.editorconfig` pauschal unterdrückt werden. Eine einzelne Unterdrückung muss lokal begrenzt und begründet sein; ausgenommen sind die im Snippet benannten Ausnahmen für Testprojekte, Migrationen, erzeugten Vertragscode und `Module.cs`.

[MUST] Die Versionen in `Directory.Packages.props` des Snippets sind Beispiele; beim Übernehmen müssen aktuelle, von NuGet-Audit nicht beanstandete Versionen gewählt werden.

[MUST] Testprojekte müssen unter `test/` liegen, damit die Ausnahmen aus `.editorconfig` greifen.

[MUST] Testprojekte müssen Microsoft.Testing.Platform mit `xunit.v3.mtp-v2` verwenden; gemeinsame Testeinstellungen stehen in der `Directory.Build.props` des Testordners.

[MUST_IF] Wenn die Laufzeitumgebung kein ICU bereitstellt, darf `InvariantGlobalization` nur für Testprojekte gesetzt werden, nicht für Anwendungen mit kulturabhängiger Formatierung.

## Grenzen

- Meziantou.Analyzer und SonarAnalyzer erzeugen bei Bestandscode viele Befunde; die Einführung in ein bestehendes Repository braucht einen eigenen Bereinigungsschritt.
- `ContinuousIntegrationBuild` ist nur für GitHub Actions vorkonfiguriert.
