#!/usr/bin/env python3
"""Konsistenzprüfung der veröffentlichten Agent Files.

Reiner Lesecheck ohne Abhängigkeiten außerhalb der Python-Standardbibliothek.
Aufruf aus dem Repository-Root: python3 scripts/lint_docs.py
"""
from __future__ import annotations

import re
import sys
from datetime import date
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
DOCS = ROOT / "docs"
BASE_URL = "https://heljens-it-services.github.io/agent-files/"
ENTRY = DOCS / "AGENTS.md"
CHANGELOG = DOCS / "CHANGELOG.md"

MARKERS = {
    "MUST", "MUST_IF", "MUST_NOT", "MUST_NOT_IF",
    "ALLOW", "ALLOW_IF", "SHOULD", "OPTIONAL", "PRIORITY",
}
CONDITIONAL_MARKERS = {"MUST_IF", "MUST_NOT_IF", "ALLOW_IF"}
# Eine bedingte Regel muss ihre Bedingung in natürlicher Sprache nennen.
CONDITION_WORDS = re.compile(
    r"\b(wenn|falls|sofern|solange|sobald|bei|ohne|nur|außer|soweit|bevor|erst)\b",
    re.IGNORECASE,
)
# Ein Verbot muss in natürlicher Sprache verneint sein.
NEGATION_WORDS = re.compile(
    r"\b(nicht|kein|keine|keinen|keinem|keiner|keines|nie|niemals|weder)\b",
    re.IGNORECASE,
)
RULE_LINE = re.compile(r"^\[([A-Z_]+)\]\s*(.*)$")
LINK = re.compile(r"\]\(([^)\s]+)\)")
ID_PATTERN = re.compile(r"^[a-z0-9]+(?:-[a-z0-9]+)*$")
CATALOG_ROW = re.compile(r"^\| `([^`]+)` \|(.*)\|\s*$")
ALIAS = re.compile(r"`(/[^`]+)`")
STAND = re.compile(r"^Stand: (\d{4}-\d{2}-\d{2})$")
CHANGELOG_ENTRY = re.compile(r"^### (\S+)\s*$")
RESERVED_ROOTS = {"help", "?", "skills", "workflows", "technologies", "roles", "actions"}

errors: list[str] = []


def fail(path: Path, line: int | None, message: str) -> None:
    location = path.relative_to(ROOT).as_posix()
    if line is not None:
        location += f":{line}"
    errors.append(f"{location}: {message}")


def markdown_files() -> list[Path]:
    return sorted(DOCS.rglob("*.md"))


def check_markers(path: Path, text: str) -> None:
    in_code_block = False
    for number, line in enumerate(text.splitlines(), start=1):
        if line.startswith("```"):
            in_code_block = not in_code_block
            continue
        if in_code_block:
            continue
        match = RULE_LINE.match(line)
        if not match:
            continue
        marker, sentence = match.groups()
        if marker not in MARKERS:
            fail(path, number, f"unbekannter Regelmarker [{marker}]")
            continue
        if marker in CONDITIONAL_MARKERS and not CONDITION_WORDS.search(sentence):
            fail(path, number, f"[{marker}] nennt keine Bedingung in natürlicher Sprache")
        if marker in {"MUST_NOT", "MUST_NOT_IF"} and not NEGATION_WORDS.search(sentence):
            fail(path, number, f"[{marker}] ist sprachlich nicht verneint")


def valid_date(value: str) -> bool:
    try:
        date.fromisoformat(value)
    except ValueError:
        return False
    return True


def check_stand(path: Path, text: str) -> None:
    if path == CHANGELOG:
        return
    lines = text.splitlines()
    following = next(((n, l) for n, l in enumerate(lines[1:], start=2) if l.strip()), None)
    if not lines or not lines[0].startswith("# ") or following is None:
        fail(path, 1, "Titelzeile mit nachfolgender `Stand: YYYY-MM-DD`-Zeile fehlt")
        return
    number, line = following
    match = STAND.match(line)
    if not match:
        fail(path, number, "erste Zeile nach dem Titel ist keine `Stand: YYYY-MM-DD`-Zeile")
    elif not valid_date(match.group(1)):
        fail(path, number, f"ungültiges Datum in `{line}`")


def check_changelog(text: str) -> None:
    previous: str | None = None
    for number, line in enumerate(text.splitlines(), start=1):
        match = CHANGELOG_ENTRY.match(line)
        if not match:
            continue
        value = match.group(1)
        if not STAND.match(f"Stand: {value}") or not valid_date(value):
            fail(CHANGELOG, number, f"Eintragsüberschrift `{value}` ist kein Datum YYYY-MM-DD")
        elif previous is not None and value >= previous:
            fail(CHANGELOG, number, f"Eintrag {value} steht nicht absteigend sortiert unter {previous}")
        else:
            previous = value


def resolve_link(source: Path, target: str) -> Path | None:
    target = target.split("#", 1)[0]
    if not target:
        return None
    if target.startswith(BASE_URL):
        return DOCS / target[len(BASE_URL):]
    if re.match(r"^[a-z][a-z0-9+.-]*:", target):
        return None
    return (source.parent / target).resolve()


def check_links(files: list[Path], texts: dict[Path, str]) -> None:
    graph: dict[Path, set[Path]] = {path: set() for path in files}
    for path in files:
        for number, line in enumerate(texts[path].splitlines(), start=1):
            for target in LINK.findall(line):
                resolved = resolve_link(path, target)
                if resolved is None:
                    continue
                if not resolved.exists():
                    fail(path, number, f"Linkziel fehlt: {target}")
                elif resolved.suffix == ".md":
                    graph[path].add(resolved)
    reachable = {ENTRY}
    stack = [ENTRY]
    while stack:
        for target in graph.get(stack.pop(), ()):
            if target not in reachable:
                reachable.add(target)
                stack.append(target)
    for path in files:
        if path not in reachable:
            fail(path, None, "ab docs/AGENTS.md nicht über Markdown-Links erreichbar")


def check_catalog(catalog: Path, folder: str, text: str, aliases: dict[str, str]) -> None:
    listed: set[str] = set()
    seen_ids: set[str] = set()
    link = re.compile(re.escape(BASE_URL + folder + "/") + r"([^)]+\.md)\)")
    for number, line in enumerate(text.splitlines(), start=1):
        row = CATALOG_ROW.match(line)
        if not row:
            continue
        entry_id, rest = row.groups()
        target = link.search(rest)
        if not target:
            continue  # Zeile einer anderen Tabelle, z. B. der Codex-Zuordnung
        if not ID_PATTERN.match(entry_id):
            fail(catalog, number, f"ID `{entry_id}` verletzt das ID-Muster")
        if entry_id in seen_ids:
            fail(catalog, number, f"ID `{entry_id}` ist doppelt vergeben")
        seen_ids.add(entry_id)
        listed.add(target.group(1))
        alias_cell = rest.split("|")[1]
        for alias in ALIAS.findall(alias_cell):
            if alias.split()[0].lstrip("/") in RESERVED_ROOTS:
                fail(catalog, number, f"Alias `{alias}` verdeckt einen Root-Command")
            owner = aliases.setdefault(alias, entry_id)
            if owner != entry_id:
                fail(catalog, number, f"Alias `{alias}` wird bereits von `{owner}` verwendet")
    present = {p.name for p in (DOCS / folder).glob("*.md")} - {catalog.name}
    for name in sorted(present - listed):
        fail(catalog, None, f"{folder}/{name} fehlt im Katalog")


def check_codex_templates() -> None:
    source = ROOT / ".codex" / "agents"
    published = DOCS / "codex" / "agents"
    names = {p.name for p in source.glob("*.toml")} | {p.name for p in published.glob("*.toml")}
    for name in sorted(names):
        left, right = source / name, published / name
        if not left.exists() or not right.exists():
            fail(published, None, f"{name} fehlt in .codex/agents oder docs/codex/agents")
        elif left.read_bytes().replace(b"\r\n", b"\n") != right.read_bytes().replace(b"\r\n", b"\n"):
            fail(right, None, "weicht von der Mustervorlage unter .codex/agents ab")


def main() -> int:
    files = markdown_files()
    texts = {path: path.read_text(encoding="utf-8") for path in files}
    for path in files:
        check_markers(path, texts[path])
        check_stand(path, texts[path])
    check_links(files, texts)
    if CHANGELOG in texts:
        check_changelog(texts[CHANGELOG])
    else:
        fail(CHANGELOG, None, "Changelog fehlt")
    aliases: dict[str, str] = {}
    for name, folder in (("SKILLS.md", "skills"), ("WORKFLOWS.md", "workflows")):
        catalog = DOCS / folder / name
        check_catalog(catalog, folder, texts[catalog], aliases)
    check_codex_templates()
    if errors:
        print("\n".join(errors))
        print(f"\n{len(errors)} Befund(e) in {len(files)} Markdown-Dateien.")
        return 1
    print(f"OK: {len(files)} Markdown-Dateien geprüft, keine Befunde.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
