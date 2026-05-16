$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$docsRoot = Join-Path $repoRoot "docs"
$referenceRoot = Join-Path $docsRoot "reference"
$sourceRoot = Join-Path $repoRoot "files"
$repoUrl = "https://github.com/Heljens-IT-Services/agent-files"
$pagesUrl = "https://heljens-it-services.github.io/agent-files/"

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
    [string] $RelativeSourcePath,
    [Parameter(Mandatory = $true)]
    [string] $ContentHtml,
    [Parameter(Mandatory = $true)]
    [string] $RelativeRoot
  )

  $sourceUrl = "$repoUrl/blob/main/$RelativeSourcePath".Replace("\", "/")

  @"
<!DOCTYPE html>
<html lang="de">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>$Title | Heljens Agent Files</title>
  <meta
    name="description"
    content="Verbindlich veroeffentlichte Agent- und Developer-Anweisungen von Heljens IT Services."
  >
  <link rel="stylesheet" href="${RelativeRoot}styles.css">
</head>
<body class="doc-page">
  <header class="doc-hero">
    <div class="doc-hero__inner">
      <p class="eyebrow">Heljens Agent Files</p>
      <h1>$Title</h1>
      <p class="lead">
        Diese Seite wird aus dem Repository generiert und spiegelt den aktuell veroeffentlichten Stand
        der verbindlichen Agent- und Developer-Anweisungen.
      </p>
      <div class="hero__actions">
        <a class="button button--primary" href="${RelativeRoot}index.html">Zur Startseite</a>
        <a class="button button--secondary" href="${RelativeRoot}reference/index.html">Alle Dateien</a>
        <a class="button button--secondary" href="$sourceUrl">Quelle auf GitHub</a>
      </div>
    </div>
  </header>

  <main class="doc-layout">
    <aside class="doc-meta card">
      <h2>Metadaten</h2>
      <p><strong>Quelle:</strong> <code>$($RelativeSourcePath.Replace("\", "/"))</code></p>
      <p><strong>Veroeffentlicht ueber:</strong> <a href="$pagesUrl">$pagesUrl</a></p>
      <p><strong>Pflege:</strong> Aenderungen erfolgen im Repository und werden danach nach <code>docs/</code> synchronisiert.</p>
    </aside>

    <article class="doc-content card markdown-body">
$ContentHtml
    </article>
  </main>
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
  $depth = ([IO.Path]::GetDirectoryName($targetRelativePath) -split "[\\/]" | Where-Object { $_ }).Count
  $relativeRoot = if ($depth -eq 0) { "../" } else { "../" + ("../" * $depth) }
  $documentHtml = New-DocumentHtml `
    -Title $sourceFile.BaseName `
    -RelativeSourcePath $relativeSourcePath `
    -ContentHtml $contentHtml `
    -RelativeRoot $relativeRoot

  Set-Content -LiteralPath $targetPath -Value $documentHtml -Encoding UTF8

  $referenceItems += [PSCustomObject]@{
    Title = $sourceFile.Name
    SourcePath = $relativeSourcePath.Replace("\", "/")
    PublishPath = ("reference/" + $targetRelativePath).Replace("\", "/")
  }
}

$referenceLinks = ($referenceItems | ForEach-Object {
  "        <li><a href=""../$($_.PublishPath)"">$($_.Title)</a><span><code>$($_.SourcePath)</code></span></li>"
}) -join [Environment]::NewLine

$referenceIndex = @"
<!DOCTYPE html>
<html lang="de">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Referenzdateien | Heljens Agent Files</title>
  <meta
    name="description"
    content="Uebersicht der veroeffentlichten Agent- und Developer-Dateien von Heljens IT Services."
  >
  <link rel="stylesheet" href="../styles.css">
</head>
<body class="doc-page">
  <header class="doc-hero">
    <div class="doc-hero__inner">
      <p class="eyebrow">Heljens Agent Files</p>
      <h1>Veroeffentlichte Referenzdateien</h1>
      <p class="lead">
        Diese Liste verweist auf die aktuell veroeffentlichten Agent- und Developer-Anweisungen,
        die aus den Quelldateien im Repository generiert wurden.
      </p>
      <div class="hero__actions">
        <a class="button button--primary" href="../index.html">Zur Startseite</a>
        <a class="button button--secondary" href="$repoUrl">Repository</a>
      </div>
    </div>
  </header>

  <main class="section">
    <div class="card reference-card">
      <h2>Dateiliste</h2>
      <ul class="reference-list">
$referenceLinks
      </ul>
    </div>
  </main>
</body>
</html>
"@

Set-Content -LiteralPath (Join-Path $referenceRoot "index.html") -Value $referenceIndex -Encoding UTF8
