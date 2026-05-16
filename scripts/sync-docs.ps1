$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$docsRoot = Join-Path $repoRoot "docs"
$referenceRoot = Join-Path $docsRoot "reference"
$sourceRoot = Join-Path $repoRoot "files"
$sourceFiles = Get-ChildItem -Path $sourceRoot -Recurse -File -Filter *.md | Sort-Object FullName

if (Test-Path $referenceRoot) {
  Remove-Item -LiteralPath $referenceRoot -Recurse -Force
}

New-Item -ItemType Directory -Path $referenceRoot | Out-Null

function Convert-MarkdownToHtml {
  param(
    [Parameter(Mandatory = $true)]
    [string] $Markdown
  )

  if (Get-Command ConvertFrom-Markdown -ErrorAction SilentlyContinue) {
    return (ConvertFrom-Markdown -InputObject $Markdown).Html
  }

  $escaped = [System.Net.WebUtility]::HtmlEncode($Markdown)
  return "<pre><code>$escaped</code></pre>"
}

function Get-RelativePath {
  param(
    [Parameter(Mandatory = $true)]
    [string] $BasePath,
    [Parameter(Mandatory = $true)]
    [string] $TargetPath
  )

  $baseUri = New-Object System.Uri((Resolve-Path -LiteralPath $BasePath).Path.TrimEnd('\') + '\')
  $targetUri = New-Object System.Uri((Resolve-Path -LiteralPath $TargetPath).Path)
  $relativeUri = $baseUri.MakeRelativeUri($targetUri)
  return [System.Uri]::UnescapeDataString($relativeUri.ToString()).Replace('/', '\')
}

function New-DocumentHtml {
  param(
    [Parameter(Mandatory = $true)]
    [string] $Title,
    [Parameter(Mandatory = $true)]
    [string] $ContentHtml
  )

  @"
<!DOCTYPE html>
<html lang="de">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>$Title</title>
</head>
<body>
$ContentHtml
</body>
</html>
"@
}

$referenceItems = @()

foreach ($sourceFile in $sourceFiles) {
  $relativeSourcePath = Get-RelativePath -BasePath $repoRoot -TargetPath $sourceFile.FullName
  $relativeWithinSource = Get-RelativePath -BasePath $sourceRoot -TargetPath $sourceFile.FullName
  $targetRelativePath = [IO.Path]::ChangeExtension($relativeWithinSource, ".html")
  $targetPath = Join-Path $referenceRoot $targetRelativePath
  $targetDir = Split-Path -Parent $targetPath

  if (-not (Test-Path $targetDir)) {
    New-Item -ItemType Directory -Path $targetDir -Force | Out-Null
  }

  $markdown = Get-Content -LiteralPath $sourceFile.FullName -Raw
  $contentHtml = Convert-MarkdownToHtml -Markdown $markdown
  $documentHtml = New-DocumentHtml `
    -Title $sourceFile.BaseName `
    -ContentHtml $contentHtml

  Set-Content -LiteralPath $targetPath -Value $documentHtml -Encoding UTF8

  $referenceItems += [PSCustomObject]@{
    Title = $sourceFile.Name
    SourcePath = $relativeSourcePath.Replace("\", "/")
    PublishPath = ("reference/" + $targetRelativePath).Replace("\", "/")
  }
}

$referenceLinks = ($referenceItems | ForEach-Object {
  "    <li><a href=""$($_.PublishPath)"">$($_.Title)</a></li>"
}) -join [Environment]::NewLine

$referenceIndex = @"
<!DOCTYPE html>
<html lang="de">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Heljens Agent Files</title>
</head>
<body>
  <h1>Heljens Agent Files</h1>
  <ul>
$referenceLinks
  </ul>
</body>
</html>
"@

Set-Content -LiteralPath (Join-Path $referenceRoot "index.html") -Value $referenceIndex -Encoding UTF8
