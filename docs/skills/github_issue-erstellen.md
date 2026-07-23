# Skill: GitHub Issue Erstellen

## Zweck

Aus vorhandenem Kontext ein strukturiertes GitHub-Issue erstellen.

## Verwenden

- Wenn ein neues GitHub-Issue aus belastbarem Kontext erstellt werden soll.
- Nicht verwenden, wenn Anforderungen oder Scope erst geklaert werden muessen. Dann `anforderungsklaerung` nutzen.
- Nicht verwenden, um den nativen Issue-Type oder Relationships zu setzen. Dafuer `github_type-setzen` bzw. `github_relationship-setzen` nachlagern.

## Vorgehen

1. Repository, Ziel und zugrundeliegenden Kontext pruefen.
2. Vorhandene Templates aus `.github/ISSUE_TEMPLATE` lesen und das passende Template bestimmen.
3. Gezielte Suche nach offenen Duplikaten oder sehr aehnlichen Issues durchfuehren.
4. Bei einem moeglichen Duplikat die Alternativen benennen und die User-Entscheidung abwarten.
5. Titel und Body aus dem vorhandenen Kontext formulieren; bei fehlendem Template mindestens Problem, Ziel, Scope, Nicht-Ziele und Akzeptanzkriterien abbilden.
6. Issue erstellen und Ergebnis lesen.

## Kommandos

```powershell
Get-ChildItem .github/ISSUE_TEMPLATE -File
Get-Content .github/ISSUE_TEMPLATE/<template-datei>
gh issue list --search "<suchbegriff>" --state open
gh issue create --title "<titel>" --body-file <body-datei>
gh issue view <issue-nummer> --json id,number,title,url
```

## Grenzen

- Extern wirksam arbeiten: Das Issue wird tatsaechlich erstellt.
- Keine Anforderungen, Metadaten oder Beziehungen erfinden.
- Bei moeglichem Duplikat nicht ohne User-Entscheidung erstellen.
- Bestehende Issues nur nach expliziter User-Anweisung aktualisieren oder schliessen.
- Labels nur setzen, wenn der User oder das verwendete Template sie explizit vorgibt.
- Fehlende Authentifizierung, Repository-Zuordnung oder Rechte als Blocker melden.

## Output

- Issue-Titel und URL
- verwendetes Template oder Standardstruktur
- sichtbare Kontextluecken

## Qualitaetskriterien

- Issue-Body entspricht dem Template oder der definierten Standardstruktur.
- Kontextluecken werden nicht erfunden oder versteckt.
- Ein moegliches Duplikat wird vor der Erstellung geklaert.
