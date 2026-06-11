# Skill: Code Refactoring

## Zweck

Verbessere Struktur, Lesbarkeit oder Wartbarkeit von Code, ohne das beabsichtigte Verhalten zu aendern.

## Wann verwenden

- Wenn technische Schulden reduziert werden sollen.
- Wenn bestehender Code schwer wartbar, unklar oder unnötig komplex ist.
- Wenn vor oder nach einer Implementierung Strukturverbesserungen noetig sind.

## Input

- betroffener Codebereich
- Refactoring-Ziel
- optional: zu schützende Verhaltensannahmen oder vorhandene Tests
- optional: betroffener Sprachtyp, zum Beispiel Backend-Code oder HTML/CSS

## Vorgehen

1. Ziel des Refactorings und erwartetes unveraendertes Verhalten benennen.
2. Den kleinsten sinnvollen Strukturumbau waehlen.
3. Die Refactoring-Strategie am betroffenen Sprachtyp ausrichten.
4. Verhaltenserhaltende Aenderungen schrittweise umsetzen.
5. Relevante Regressionen oder Unsicherheiten pruefen.
6. Ergebnis mit Fokus auf Lesbarkeit und Stabilitaet bewerten.

## Sprachtyp-Leitlinien

### Backend-Sprachen

- Refactoring darf Verantwortlichkeiten staerker auseinanderziehen, wenn dadurch Logik klarer, testbarer oder austauschbarer wird.
- Extraktion in eigene Funktionen, Klassen oder Module ist sinnvoll, wenn sie echte Zustaendigkeiten trennt.
- Abhaengigkeiten und Schnittstellen nach dem Refactoring klarer sein als vorher.

### HTML und CSS

- Refactoring soll Markup und Styling in der Regel vereinfachen statt weiter aufspalten.
- Tiefe Verschachtelung, ueberfluessige Container und unnötig komplexe Selektoren gezielt reduzieren.
- Wiederverwendung nur dort einfuehren, wo sie den Code real vereinfacht und nicht bloss abstrakter macht.

## Output

- refaktorierter Code
- Beschreibung der Strukturverbesserung
- Verhaltensannahmen
- Test- oder Verifikationsstatus
- Restrisiken

## Qualitätskriterien

- Verhaltensaenderungen muessen explizit benannt werden.
- Refactoring darf nicht als Vorwand fuer Scope-Ausweitung dienen.
- Vorher-Nachher-Unterschied strukturell erklaerbar machen.
- Backend-Refactorings duerfen mehr Struktur einziehen; HTML/CSS-Refactorings sollen meist Struktur abbauen oder vereinfachen.
