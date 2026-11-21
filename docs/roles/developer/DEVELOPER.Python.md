# DEVELOPER.Python.md

Stand: 2026-10-18

## Zweck

Diese Datei gilt für Python-Code, einschließlich Hilfs- und Prüfskripten im Repository. Zugehörige allgemeine Developer-Regeln werden über [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md), weitere technologiespezifische Regeldateien über [TECHNOLOGIES.md](https://heljens-it-services.github.io/agent-files/TECHNOLOGIES.md) aufgelöst.

## Version und Umgebung

[MUST] Die unterstützte Python-Version muss aus `PROJECT.md`, `requires-python` in `pyproject.toml` oder `.python-version` übernommen werden.

[MUST_IF] Wenn das Projekt keine Python-Version vorgibt, muss Code für die aktuelle stabile, noch unterstützte Python-Version geschrieben und die gewählte Mindestversion dokumentiert werden.

[MUST] Projektabhängigkeiten müssen in einer virtuellen Umgebung wie `.venv` installiert werden.

[MUST_NOT] Pakete dürfen nicht in die systemweite Python-Installation installiert und virtuelle Umgebungen nicht versioniert werden.

## Abhängigkeiten

[SHOULD] Hilfsskripte sollen ausschließlich die Standardbibliothek verwenden. Abweichungen sind erlaubt, wenn eine Drittbibliothek einen erheblichen Teil der Logik ersetzt und gemäß [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md) freigegeben ist.

[MUST] Abhängigkeiten müssen in `pyproject.toml` deklariert und über ein Lockfile oder eine `requirements.txt` mit exakten Versionen reproduzierbar gepinnt werden.

[MUST] Laufzeit- und Entwicklungsabhängigkeiten wie `pytest` oder `ruff` müssen getrennt deklariert werden.

## Code

[MUST] Funktionssignaturen, öffentliche Attribute und Modulkonstanten mit nicht offensichtlichem Typ müssen Type Hints tragen.

[SHOULD] Moderne Typ-Syntax wie `list[str]` und `str | None` soll verwendet werden. Abweichungen sind erlaubt, wenn die unterstützte Mindestversion sie nicht kennt.

[MUST] Dateisystempfade müssen über `pathlib.Path` verarbeitet werden.

[MUST] Datei-I/O mit Text muss `encoding="utf-8"` explizit angeben, sofern kein anderes Encoding fachlich vorgegeben ist.

[MUST] Ausführbare Skripte müssen ihre Logik in `main() -> int` kapseln und über `if __name__ == "__main__": sys.exit(main())` starten.

[MUST_NOT] Module dürfen beim Import keine Seiteneffekte wie Dateizugriffe, Netzwerkaufrufe oder Ausgaben auslösen.

[MUST_IF] Wenn ein Skript Argumente entgegennimmt, muss es `argparse` oder eine im Projekt bereits verwendete CLI-Bibliothek nutzen.

## Fehler und Prozesse

[MUST_NOT] Bare `except:` und breite `except Exception:`-Blöcke ohne erneutes Auslösen oder Protokollieren mit Kontext dürfen nicht verwendet werden.

[MUST] Exceptions müssen so spezifisch wie möglich gefangen werden.

[MUST] Externe Prozesse müssen über `subprocess.run` mit Argumentliste und `check=True` oder expliziter Prüfung von `returncode` aufgerufen werden.

[MUST_NOT] `subprocess` darf nicht mit `shell=True` verwendet werden, außer ein Shell-Feature ist zwingend erforderlich und alle Eingaben sind vertrauenswürdig.

[MUST_NOT] `eval`, `exec` und `pickle` dürfen nicht auf nicht vertrauenswürdige Eingaben angewendet werden.

## Formatierung, Linting und Tests

[SHOULD] Formatierung und Linting sollen mit `ruff format` und `ruff check` erfolgen. Abweichungen sind erlaubt, wenn `PROJECT.md` oder die bestehende Projektkonfiguration ein anderes Werkzeug vorgibt; die Ersteinführung von ruff folgt der Freigaberegel für neue Abhängigkeiten aus [DEVELOPER.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.md).

[MUST_IF] Wenn ein Projekt ruff verwendet, muss dessen Konfiguration in `pyproject.toml` oder `ruff.toml` versioniert sein.

[SHOULD] Tests sollen mit `pytest` geschrieben werden. Abweichungen sind erlaubt, wenn das Projekt ein anderes Test-Framework vorgibt; die Ersteinführung von pytest folgt derselben Freigaberegel.

[SHOULD] Dateisystemzugriffe in Tests sollen über die Fixture `tmp_path` isoliert werden.
