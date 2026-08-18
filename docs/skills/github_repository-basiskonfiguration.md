# Skill: GitHub Repository-Basiskonfiguration

## Zweck

Die GitHub-Basiskonfiguration eines Repositorys kontrolliert gegen die zentralen Heljens-Referenzen prüfen und innerhalb eines erlaubten Repository-Pflegeauftrags gezielt ergänzen oder korrigieren.

## Verwenden

- Wenn ein Repository für GitHub-Basiskonfiguration gepflegt wird.
- Wenn `.github/ISSUE_TEMPLATE` fehlt, unvollständig ist oder gegen den kanonischen Heljens-Satz geprüft werden soll.
- Nicht verwenden, wenn nur ein einzelnes GitHub-Issue erstellt wird und keine Repository-Pflege erlaubt ist.

## Vorgehen

1. Prüfen, dass der Auftrag Änderungen an der Repository-Basiskonfiguration erlaubt.
2. Den Sollbestand aus der [kanonischen Template-Referenz](https://heljens-it-services.github.io/agent-files/github/ISSUE_TEMPLATES.md) bestimmen: `bug.yml`, `config.yml`, `epic.yml`, `refactor.yml`, `story.yml`, `task.yml`.
3. `.github/ISSUE_TEMPLATE` einschließlich aller vorhandenen Dateien inventarisieren und jeden Sollbestand inhaltlich mit der kanonischen Quelle vergleichen.
4. Fehlende Dateien unverändert aus der kanonischen Quelle ergänzen.
5. Abweichende vorhandene Dateien sichtbar machen. Sie nur ersetzen, wenn die verbindliche zentrale Leitplanke die Korrektur verlangt und der Auftrag Repository-Pflege umfasst; sonst Rückfrage halten.
6. Nach der Änderung Dateinamen, Inhalte und YAML-Syntax erneut prüfen. Zusätzliche, nicht kanonische Dateien nur dann entfernen, wenn der Auftrag dies ausdrücklich umfasst.
7. Ergebnis mit erkannten Abweichungen, ergänzten oder korrigierten Dateien sowie bewusst unveränderten Dateien kompakt dokumentieren.

## Kommandos

```powershell
Get-ChildItem .github/ISSUE_TEMPLATE -File
Get-FileHash .github/ISSUE_TEMPLATE/<template-datei> -Algorithm SHA1
Get-Content .github/ISSUE_TEMPLATE/<template-datei>
git diff --check
```

## Grenzen

- Repository-Dateien nur ändern, wenn der Auftrag die Repository-Pflege erlaubt.
- Keine abweichenden vorhandenen Templates stillschweigend überschreiben.
- Keine GitHub-Issues, Labels, nativen Issue-Types oder Relationships pflegen.
- Den Sollbestand ausschließlich aus der zentralen Referenz ableiten, nicht aus einer lokalen Variante oder einer einzelnen Fremdquelle.
- Fehlende Rechte, nicht erreichbare zentrale Referenz oder nicht prüfbare YAML-Syntax als Blocker melden.

## Output

- erkannter Soll- und Istbestand
- ergänzte oder korrigierte Dateien
- bewusst unveränderte Abweichungen mit Grund
- Ergebnis der Inhalts- und YAML-Prüfung

## Qualitätskriterien

- Der vollständige kanonische Satz wird geprüft, nicht nur die für ein aktuelles Issue gewählte Form.
- Jede Mutation wird durch einen erneuten Inhalts- und Bestandsabgleich nachgewiesen.
- Issue-Erstellung und Repository-Pflege bleiben getrennte, konsistente Aufgaben.
