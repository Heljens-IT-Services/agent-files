# Skill: GitHub Branch Checkout From Default

## Zweck

Erstelle und wechsle auf einen geeigneten Arbeitsbranch, ausgehend von der Default-Branch des Repositories.

## Wann verwenden

- Vor Beginn einer neuen Aufgabe oder Aenderung.
- Wenn sichergestellt werden soll, dass die Arbeit von `develop`, `main` oder einer anderen definierten Standardbasis startet.
- Wenn ein passender Branch-Name fuer einen neuen Arbeitskontext benoetigt wird.

## Input

- Aufgabenkontext oder Ziel der Aenderung
- optional: gewuenschter Branch-Name
- optional: gewuenschte Basis-Branch

## Vorgehen

1. Default- oder Ziel-Basis-Branch bestimmen.
2. Pruefen, ob die Basis-Branch lokal und remote aktuell ist.
3. Lokalen Arbeitsstatus auf uncommitted Aenderungen pruefen.
4. Einen passenden Branch-Namen aus Aufgabenkontext oder Vorgabe ableiten.
5. Den neuen Branch von der Basis erstellen und auschecken.
6. Ergebnis verifizieren und die verwendete Basis festhalten.

## Output

- verwendete Basis-Branch
- neuer Branch-Name
- Hinweis auf uebernommene lokale Aenderungen, falls vorhanden

## Qualitätskriterien

- Keine stillschweigende Wahl einer falschen Basis.
- Keine riskante Branch-Operation bei unklarem Arbeitsstatus.
- Branch-Name soll Aufgabe und Scope knapp widerspiegeln.
