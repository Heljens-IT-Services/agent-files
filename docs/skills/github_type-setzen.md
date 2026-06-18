# Skill: GitHub Type Setzen

## Zweck

Den nativen GitHub-Issue-Type eines bestehenden Issues gezielt setzen oder aendern.

## Verwenden

- Wenn fuer ein bestehendes GitHub-Issue der native Issue-Type gesetzt werden soll.
- Wenn `Task`, `Story`, `Spike`, `Epic` oder ein anderer in der Organisation vorhandener Issue-Type nachtraeglich gesetzt werden muss.
- Wenn klar ist, welche Organisation, welches Repository, welche Issue-Nummer und welcher Type-Name gemeint sind.
- Nicht verwenden, um Labels zu setzen. GitHub-Issue-Type ist kein Label.
- Nicht verwenden, um Relationships zu setzen. Dann `github_relationship-setzen` nutzen.

## Vorgehen

1. Organisation, Repository, Issue-Nummer und gewuenschten Type-Namen bestimmen.
2. GitHub-Authentifizierung und Repository-Zugriff pruefen.
3. Issue-ID des Ziel-Issues lesen.
4. Verfuegbare Issue-Types der Organisation lesen.
5. Issue-Type-ID anhand des Type-Namens eindeutig bestimmen.
6. Native GitHub-Mutation `updateIssueIssueType` ausfuehren.
7. Ergebnis lesen und pruefen, ob der native Issue-Type gesetzt ist.

## Kommandos

Issue-ID lesen:

```powershell
$issueId = gh issue view <issue-nummer> --repo <org>/<repo> --json id --jq .id
```

Verfuegbare Issue-Types der Organisation lesen:

```powershell
gh api orgs/<org>/issue-types
$issueTypeId = gh api orgs/<org>/issue-types --jq '.[] | select(.name == "<issue-type>") | .node_id'
```

Native GitHub-Issue-Type-Mutation ausfuehren:

```powershell
gh api graphql `
  -f issueId="$issueId" `
  -f issueTypeId="$issueTypeId" `
  -f query='mutation($issueId:ID!, $issueTypeId:ID!) { updateIssueIssueType(input: { issueId: $issueId, issueTypeId: $issueTypeId }) { issue { number issueType { name } } } }'
```

Ergebnis pruefen:

```powershell
gh issue view <issue-nummer> --repo <org>/<repo> --json number,title,issueType,url
```

Platzhalter:

- `<org>`: GitHub-Organisation, z. B. `Heljens-IT-Services`.
- `<repo>`: Repository-Name ohne Organisation.
- `<issue-nummer>`: Nummer des bestehenden Issues.
- `<issue-type>`: exakt vorhandener nativer GitHub-Issue-Type-Name.

## Grenzen

- Extern wirksam arbeiten: Der native GitHub-Issue-Type wird tatsaechlich in GitHub gesetzt.
- GitHub-Issue-Type ist kein Label und darf nicht durch ein Label ersetzt werden.
- Keine Labels setzen oder empfehlen.
- Keine Relationships setzen oder pflegen.
- Keine Issue-Erstellung in diesen Skill ziehen.
- Keinen Type raten, wenn der Kontext unklar ist.
- Bei unklarer Organisation, unklarem Repository, unklarer Issue-Nummer oder unklarem Type-Namen nachfragen.
- Fehlende GitHub-Authentifizierung, fehlende Rechte, unbekannte Issue-Types oder fehlende Repository-Zuordnung als Blocker melden.
- Wenn der Type-Name mehrfach oder nicht eindeutig aufloesbar ist, nicht setzen und die Mehrdeutigkeit melden.

## Output

- Issue-Nummer und Issue-URL
- gesetzter nativer GitHub-Issue-Type
- nicht gesetzter Issue-Type mit Grund, falls relevant
- Blocker wie fehlende Rechte, unbekannter Issue-Type oder fehlende Authentifizierung

## Qualitaetskriterien

- Der Skill behandelt ausschliesslich native GitHub-Issue-Types.
- Der gesetzte Type wird nach der Mutation geprueft.
- Beobachtung und Aenderung werden getrennt: erst lesen, dann setzen, dann verifizieren.
- Labels, Body-Links oder Textverweise werden nicht als Ersatz fuer den nativen Issue-Type verwendet.
