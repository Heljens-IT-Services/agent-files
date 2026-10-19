#!/usr/bin/env python3
"""Schreibt den maschinenlesbaren Index docs/index.json neu.

Der Index wird mit den Änderungen unter docs/ committet; scripts/lint_docs.py
prüft lediglich, ob er aktuell ist.
Aufruf aus dem Repository-Root: python3 scripts/update_index.py
"""
from __future__ import annotations

import sys

sys.dont_write_bytecode = True  # kein __pycache__ im Repository erzeugen

from lint_docs import INDEX, ROOT, build_index, load_texts


def main() -> int:
    INDEX.write_text(build_index(load_texts()), encoding="utf-8", newline="\n")
    print(f"{INDEX.relative_to(ROOT).as_posix()} aktualisiert.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
