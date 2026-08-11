# Skill: GitHub Issue Erstellen

## Zweck

Aus vorhandenem Kontext ein strukturiertes GitHub-Issue erstellen.

## Verwenden

- Wenn ein neues GitHub-Issue aus belastbarem Kontext erstellt werden soll.
- Nicht verwenden, wenn Anforderungen oder Scope erst geklärt werden müssen. Dann `anforderungsklaerung` nutzen.
- Nicht verwenden, um den nativen Issue-Type oder Relationships zu setzen. Dafür `github_type-setzen` bzw. `github_relationship-setzen` nachlagern.

## Vorgehen

1. Repository, Ziel und zugrundeliegenden Kontext prüfen.
2. Vorhandene Templates aus `.github/ISSUE_TEMPLATE` lesen und das passende Template bestimmen.
3. Gezielte Suche nach offenen Duplikaten oder sehr ähnlichen Issues durchführen.
4. Bei einem möglichen Duplikat die Alternativen benennen und die User-Entscheidung abwarten.
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

- Extern wirksam arbeiten: Das Issue wird tatsächlich erstellt.
- Keine Anforderungen, Metadaten oder Beziehungen erfinden.
- Bei möglichem Duplikat nicht ohne User-Entscheidung erstellen.
- Bestehende Issues nur nach expliziter User-Anweisung aktualisieren oder schließen.
- Labels nur setzen, wenn der User oder das verwendete Template sie explizit vorgibt.
- Fehlende Authentifizierung, Repository-Zuordnung oder Rechte als Blocker melden.

## Output

- Issue-Titel und URL
- verwendetes Template oder Standardstruktur
- sichtbare Kontextlücken

## Qualitätskriterien

- Issue-Body entspricht dem Template oder der definierten Standardstruktur.
- Kontextlücken werden nicht erfunden oder versteckt.
- Ein mögliches Duplikat wird vor der Erstellung geklärt.
