# Skill: Code Refactoring

## Zweck

Code strukturieren, ohne beabsichtigtes Verhalten zu aendern.

## Verwenden

- Wenn Lesbarkeit, Wartbarkeit oder Verantwortungsgrenzen verbessert werden sollen.
- Nicht verwenden, wenn fachliches Verhalten geaendert werden soll. Dann Implementierung planen.

## Vorgehen

1. Verhalten benennen, das erhalten bleiben muss.
2. Kleinsten sinnvollen Strukturumbau waehlen.
3. Refactoring am Sprachtyp ausrichten.
4. Schrittweise aendern und Regressionen pruefen.
5. Strukturgewinn und Restrisiko benennen.

## Sprachtyp-Regel

- Backend: Verantwortlichkeiten duerfen staerker getrennt werden, wenn Logik testbarer und Abhaengigkeiten klarer werden.
- HTML/CSS: Struktur eher reduzieren als abstrahieren; Verschachtelung, Container und komplexe Selektoren abbauen.

## Output

- refaktorierter Code
- erhaltendes Verhalten
- Strukturgewinn
- Verifikationsstatus
- Restrisiken

## Qualitaetskriterien

- Jede Verhaltensaenderung explizit markieren.
- Kein Refactoring als verdeckte Feature-Arbeit.
- Vorher-Nachher-Unterschied strukturell erklaeren.
