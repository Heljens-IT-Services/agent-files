# Skill: GitHub Issue Erstellen

## Zweck

Formuliere aus Anforderungen, Analyse oder Ideen ein klar umrissenes GitHub-Issue und setze die zugehoerigen GitHub-Metadaten.

## Wann verwenden

- Wenn aus Gespraechen, Notizen oder Analyseergebnissen ein GitHub-Issue werden soll.
- Wenn Arbeit in nachvollziehbare Aufgaben zerlegt werden soll.
- Wenn Issue-Typ, Parent/Child-Beziehung oder Blocked-by-Beziehung gesetzt werden muss.

## Input

- Problem, Idee oder Analyseergebnis
- Issue-Typ: `Task`, `Story`, `Spike` oder `Epic`
- optional: gewuenschter Scope, Prioritaet, Labels oder Kontext
- optional: Parent-Issue oder Child-Issues
- optional: Blocked-by-Beziehungen

## Vorgehen

1. Problem oder Bedarf knapp beschreiben.
2. Korrekte Issue-Type-Kategorie bestimmen: `Task`, `Story`, `Spike` oder `Epic`.
3. Ziel und Nutzen des Issues formulieren.
4. Scope und Nicht-Ziele trennen.
5. Akzeptanzkriterien definieren.
6. Parent/Child-Beziehungen bestimmen, wenn sie aus dem Kontext hervorgehen.
7. Blocked-by-Beziehungen bestimmen, wenn sie aus dem Kontext hervorgehen.
8. Relevante technische Hinweise oder Risiken angeben.
9. Issue erstellen und Type sowie Beziehungen setzen.

## Empfohlene Kommandos

```powershell
gh issue create --title "<titel>" --body "<body>"
gh issue create --title "<titel>" --body "<body>" --label "<label>"
gh label list
```

Wenn der Issue-Typ direkt beim Erstellen gesetzt werden soll, kann die GitHub REST API ueber `gh api` verwendet werden:

```powershell
gh repo view --json nameWithOwner,defaultBranchRef
gh api repos/<owner>/<repo>/issues -f title="<titel>" -f body="<body>" -f type="<issue-type>"
```

Wenn das Issue bereits existiert oder `gh issue create` verwendet wurde, kann der Issue-Typ per GraphQL gesetzt werden:

```powershell
$issueId = gh issue view <issue-nummer> --json id --jq .id
$issueTypeId = gh api orgs/<org>/issue-types --jq '.[] | select(.name == "<issue-type>") | .node_id'
gh api graphql -f issueId="$issueId" -f issueTypeId="$issueTypeId" -f query='mutation($issueId:ID!, $issueTypeId:ID!) { updateIssueIssueType(input: { issueId: $issueId, issueTypeId: $issueTypeId }) { issue { number issueType { name } } } }'
```

Wenn eine Parent/Child-Beziehung gesetzt werden soll:

```powershell
$parentIssueId = gh issue view <parent-issue-nummer> --json id --jq .id
$childIssueId = gh issue view <child-issue-nummer> --json id --jq .id
gh api graphql -f parentIssueId="$parentIssueId" -f childIssueId="$childIssueId" -f query='mutation($parentIssueId:ID!, $childIssueId:ID!) { addSubIssue(input: { issueId: $parentIssueId, subIssueId: $childIssueId, replaceParent: false }) { issue { number } subIssue { number } } }'
```

Wenn eine Blocked-by-Beziehung gesetzt werden soll:

```powershell
$blockedIssueId = gh issue view <blocked-issue-nummer> --json id --jq .id
$blockingIssueId = gh issue view <blocking-issue-nummer> --json id --jq .id
gh api graphql -f blockedIssueId="$blockedIssueId" -f blockingIssueId="$blockingIssueId" -f query='mutation($blockedIssueId:ID!, $blockingIssueId:ID!) { addBlockedBy(input: { issueId: $blockedIssueId, blockingIssueId: $blockingIssueId }) { issue { number } blockingIssue { number } } }'
```

Wenn das Issue vor dem Erstellen geprueft werden soll:

```powershell
gh issue list --search "<suchbegriff>" --state open
gh repo view --json nameWithOwner,defaultBranchRef
```

`<issue-type>` muss einer der Werte `Task`, `Story`, `Spike` oder `Epic` sein. `<owner>`, `<repo>`, `<org>`, Issue-Nummern und Beziehungstypen muessen aus dem aktuellen Repository- und Issue-Kontext abgeleitet werden. Der Agent soll den finalen Issue-Inhalt vor einer extern wirksamen Erstellung kennen.

## Output

- Titel
- Issue-Typ
- Kontext
- Problem
- Ziel
- Scope
- Nicht-Ziele
- Akzeptanzkriterien
- Parent/Child-Beziehungen, falls vorhanden
- Blocked-by-Beziehungen, falls vorhanden
- technische Hinweise
- Risiken oder offene Fragen

## Qualitaetskriterien

- Ticket muss fuer eine spaetere Umsetzung ausreichend klar sein.
- Akzeptanzkriterien sollen pruefbar formuliert sein.
- Scope soll bewusst begrenzt werden.
- Issue-Typ muss immer explizit als `Task`, `Story`, `Spike` oder `Epic` gesetzt werden.
- Parent/Child- und Blocked-by-Beziehungen muessen als GitHub-Relationen gesetzt werden, wenn sie aus dem Kontext hervorgehen.
