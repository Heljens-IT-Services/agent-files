# Skill: GitHub Issue Erstellen

## Zweck

Ein GitHub-Issue mit Typ und relevanten Beziehungen erstellen.

## Verwenden

- Wenn aus Kontext ein neues GitHub-Issue entstehen soll.
- Wenn `Task`, `Story`, `Spike` oder `Epic` samt GitHub-Metadaten gesetzt werden muessen.

## Vorgehen

1. Titel, Problem, Ziel, Scope und Akzeptanzkriterien formulieren.
2. Issue-Typ festlegen: `Task`, `Story`, `Spike` oder `Epic`.
3. Parent/Child- und Blocked-by-Beziehungen aus dem Kontext bestimmen.
4. Duplikate oder bestehende verwandte Issues pruefen.
5. Issue erstellen.
6. Typ und Beziehungen als GitHub-Relationen setzen.

## Empfohlene Kommandos

```powershell
gh issue list --search "<suchbegriff>" --state open
gh api repos/<owner>/<repo>/issues -f title="<titel>" -f body="<body>" -f type="<issue-type>"
```

Typ nachtraeglich setzen:

```powershell
$issueId = gh issue view <issue-nummer> --json id --jq .id
$issueTypeId = gh api orgs/<org>/issue-types --jq '.[] | select(.name == "<issue-type>") | .node_id'
gh api graphql -f issueId="$issueId" -f issueTypeId="$issueTypeId" -f query='mutation($issueId:ID!, $issueTypeId:ID!) { updateIssueIssueType(input: { issueId: $issueId, issueTypeId: $issueTypeId }) { issue { number issueType { name } } } }'
```

Parent/Child setzen:

```powershell
$parentIssueId = gh issue view <parent-issue-nummer> --json id --jq .id
$childIssueId = gh issue view <child-issue-nummer> --json id --jq .id
gh api graphql -f parentIssueId="$parentIssueId" -f childIssueId="$childIssueId" -f query='mutation($parentIssueId:ID!, $childIssueId:ID!) { addSubIssue(input: { issueId: $parentIssueId, subIssueId: $childIssueId, replaceParent: false }) { issue { number } subIssue { number } } }'
```

Blocked-by setzen:

```powershell
$blockedIssueId = gh issue view <blocked-issue-nummer> --json id --jq .id
$blockingIssueId = gh issue view <blocking-issue-nummer> --json id --jq .id
gh api graphql -f blockedIssueId="$blockedIssueId" -f blockingIssueId="$blockingIssueId" -f query='mutation($blockedIssueId:ID!, $blockingIssueId:ID!) { addBlockedBy(input: { issueId: $blockedIssueId, blockingIssueId: $blockingIssueId }) { issue { number } blockingIssue { number } } }'
```

## Output

- Titel
- Issue-Typ
- Body
- Parent/Child-Beziehungen
- Blocked-by-Beziehungen
- offene Fragen

## Qualitaetskriterien

- Issue-Typ immer explizit setzen.
- Beziehungen setzen, wenn sie aus dem Kontext hervorgehen.
- Extern wirksame Erstellung nur mit finalem Titel und Body.
