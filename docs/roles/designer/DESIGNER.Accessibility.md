# DESIGNER.Accessibility.md

Stand: 2026-10-19

## Zweck

Diese Datei definiert Designer-Regeln für barrierefreie Gestaltung. Allgemeine Designer-Regeln werden über [DESIGNER.md](https://heljens-it-services.github.io/agent-files/roles/designer/DESIGNER.md) aufgelöst. Das Zielniveau steht in [DEVELOPER.Accessibility.md](https://heljens-it-services.github.io/agent-files/roles/developer/DEVELOPER.Accessibility.md).

## Gestaltung

[MUST] Designrichtungen, die in Produktivcode überführt werden sollen, müssen das Zielniveau für Kontrast, Zielgröße, Fokusdarstellung und Unabhängigkeit von Farbe bereits im Entwurf erfüllen.

[MUST] Jeder interaktive Zustand muss gestaltet sein: Standard, Hover, Fokus, aktiv, deaktiviert, Fehler und gegebenenfalls ausgewählt.

[MUST_NOT] Ein Fokuszustand darf nicht ausschließlich über eine Farbänderung mit geringem Kontrast dargestellt werden.

[MUST] Typografie und Layout müssen bei vergrößertem Text und schmalen Viewports funktionsfähig bleiben.

[MUST_IF] Wenn Bewegung oder Animation Teil des Designs ist, muss eine reduzierte Variante für `prefers-reduced-motion` festgelegt werden.

## Review und Handoff

[MUST_IF] Wenn ein Design-Review stattfindet, müssen Kontrast, Lesereihenfolge, Fokusführung und Zustände in die Bewertung einbezogen werden.

[MUST] Ein Design-Handoff muss Lesereihenfolge, Überschriftenstruktur, zugängliche Namen für reine Icon-Bedienelemente, Alternativtexte und erwartete Fokusführung enthalten, soweit sie für die Umsetzung relevant sind.

[MUST_NOT] Ein Prototyp darf nicht als barrierefrei bezeichnet werden, solange die Barrierefreiheit nicht separat geprüft wurde.
