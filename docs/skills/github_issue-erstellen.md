# Skill: GitHub Issue Erstellen

## Zweck

Aus vorhandenem Kontext ein strukturiertes GitHub-Issue erstellen und nachgelagerte GitHub-Metadaten setzen.

## Verwenden

- Wenn aus Kontext ein neues GitHub-Issue entstehen soll.
- Wenn `Task`, `Story`, `Spike` oder `Epic` samt GitHub-Metadaten gesetzt werden muessen.
- Wenn vorhandene Parent/Child-, Blocked-by- oder andere relevante Issue-Beziehungen gesetzt werden muessen.
- Nicht verwenden, wenn Anforderungen oder Scope erst geklaert werden muessen. Dann `anforderungsklaerung` nutzen.

## Vorgehen

1. Zugrundeliegenden Kontext, Repository und Ziel des neuen Issues pruefen.
2. Vorhandene GitHub-Issue-Templates aus `.github/ISSUE_TEMPLATE` verpflichtend lesen.
3. Passendes GitHub-Issue-Template ermitteln und dessen Struktur fuer den Body verwenden; falls kein Template vorhanden ist, ein strukturiertes Standard-Issue erstellen.
4. Duplikate oder sehr aehnliche offene Issues mit gezielter Suche pruefen.
5. Bei moeglichem Duplikat Optionen vorschlagen und User-Entscheidung abwarten.
6. Titel, Problem, Ziel, Scope, Nicht-Ziele und Akzeptanzkriterien aus dem vorhandenen Kontext formulieren.
7. GitHub-Issue-Type festlegen: `Task`, `Story`, `Spike` oder `Epic`.
8. Relevante Beziehungen aus vorhandenem Kontext bestimmen.
9. Issue erstellen.
10. Unmittelbar nachgelagert den korrekten nativen GitHub-Issue-Type mit `github_type-setzen` setzen.
11. Nachgelagert vorhandene native GitHub-Relationships mit `github_relationship-setzen` setzen, z. B. Parent/Child oder Blocked-by. Es koennen auch beide Arten der Relationships existieren.

## Nachgelagerte Metadaten

[MUST] Jedes neu erstellte GitHub-Issue muss unmittelbar nach der Erstellung mit `github_type-setzen` einen nativen GitHub-Issue-Type erhalten.

[MUST_NOT] Labels, Body-Text, Links oder Namenskonventionen duerfen nicht als Ersatz fuer den nativen GitHub-Issue-Type verwendet werden.

## Kommandos

```powershell
Get-ChildItem .github/ISSUE_TEMPLATE -File
Get-Content .github/ISSUE_TEMPLATE/<template-datei>
gh issue list --search "<suchbegriff>" --state open
gh issue create --title "<titel>" --body-file <body-datei>
gh issue view <issue-nummer> --json id,number,title,url
```

GitHub-Issue-Type nachtraeglich mit `github_type-setzen` setzen:

```powershell
$issueId = gh issue view <issue-nummer> --json id --jq .id
$issueTypeId = gh api orgs/<org>/issue-types --jq '.[] | select(.name == "<issue-type>") | .node_id'
gh api graphql -f issueId="$issueId" -f issueTypeId="$issueTypeId" -f query='mutation($issueId:ID!, $issueTypeId:ID!) { updateIssueIssueType(input: { issueId: $issueId, issueTypeId: $issueTypeId }) { issue { number issueType { name } } } }'
```

Parent/Child mit `github_relationship-setzen` setzen:

```powershell
$parentIssueId = gh issue view <parent-issue-nummer> --json id --jq .id
$childIssueId = gh issue view <child-issue-nummer> --json id --jq .id
gh api graphql -f parentIssueId="$parentIssueId" -f childIssueId="$childIssueId" -f query='mutation($parentIssueId:ID!, $childIssueId:ID!) { addSubIssue(input: { issueId: $parentIssueId, subIssueId: $childIssueId, replaceParent: false }) { issue { number } subIssue { number } } }'
```

Blocked-by mit `github_relationship-setzen` setzen:

```powershell
$blockedIssueId = gh issue view <blocked-issue-nummer> --json id --jq .id
$blockingIssueId = gh issue view <blocking-issue-nummer> --json id --jq .id
gh api graphql -f blockedIssueId="$blockedIssueId" -f blockingIssueId="$blockingIssueId" -f query='mutation($blockedIssueId:ID!, $blockingIssueId:ID!) { addBlockedBy(input: { issueId: $blockedIssueId, blockingIssueId: $blockingIssueId }) { issue { number } blockingIssue { number } } }'
```

Platzhalter aus Repository, Organisation, Issue-Type und Beziehungen ableiten und an die atomaren Skills uebergeben.

## Grenzen

- Extern wirksam arbeiten: Issue wird tatsaechlich in GitHub erstellt.
- Keine Anforderungen oder Beziehungen erfinden.
- Keine fehlenden Anforderungen klaeren. Dann `anforderungsklaerung` nutzen.
- Keine technische Planung ersetzen. Dann `code_implementierungsplanung` nutzen.
- Issue-Templates aus `.github/ISSUE_TEMPLATE` verpflichtend lesen und beruecksichtigen.
- Wenn kein Issue-Template vorhanden ist, kein Blocker; stattdessen Standardstruktur verwenden.
- Vor Erstellung gezielte Duplikatpruefung durchfuehren.
- Bei moeglichem Duplikat nicht automatisch erstellen.
- Bei moeglichem Duplikat Optionen vorschlagen: vorhandenes Issue verfeinern, neues Issue verlinkt erstellen, neues Issue als Beziehung erstellen, gefundenes Duplikat schliessen und neues Issue erstellen, oder Erstellung abbrechen.
- Bestehende Issues nur nach expliziter User-Entscheidung aktualisieren oder schliessen.
- GitHub-Issue-Type immer explizit setzen; damit ist nicht ein Label gemeint.
- Bei unklarem GitHub-Issue-Type nachfragen, nicht raten.
- Labels sind nicht praeferiert und ersetzen keine Issue-Type- oder Relationship-Pflege.
- Body-Links oder Textverweise ersetzen keine native GitHub-Relationship-Pflege.
- Labels nur setzen, wenn der User oder das Issue-Template sie explizit vorgibt.
- Native GitHub-Relationships nur setzen, wenn sie aus vorhandenem Kontext hervorgehen.
- Fehlende GitHub-Authentifizierung, fehlende Repository-Zuordnung oder fehlende Rechte als Blocker melden.

## Output

- Titel
- GitHub-Issue-Type
- Body
- Parent/Child-Beziehungen
- Blocked-by-Beziehungen
- Issue-URL oder Issue-Nummer
- gesetzte Metadaten
- nicht gesetzte Metadaten mit Grund, falls relevant

## Qualitaetskriterien

- GitHub-Issue-Type immer explizit setzen; Label ersetzen den Issue-Type nicht.
- Native GitHub-Relationships setzen, wenn sie aus dem Kontext hervorgehen; Labels, Body-Links oder Textverweise ersetzen sie nicht.
- Issue-Body muss zur Template-Struktur passen.
- Fehlende Kontextteile nicht auffuellen oder verstecken.
