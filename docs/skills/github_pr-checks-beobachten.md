# Skill: GitHub PR Checks Beobachten

## Zweck

Die erforderlichen Checks eines Pull Requests bis zu einem terminalen Zustand beobachten und ihr Ergebnis richtungsstabil bewerten.

## Verwenden

- Wenn ein Pull Request vor Review, Merge oder Abschluss auf erforderliche Checks warten muss.
- Wenn der Status bereits laufender GitHub-Actions- oder externer Checks beobachtet werden soll.
- Nicht verwenden, um fehlgeschlagene Checks zu analysieren oder zu reparieren.

## Vorgehen

1. Repository und Pull Request eindeutig bestimmen.
2. Aktuellen Head-Commit des Pull Requests lesen und fuer die Beobachtung festhalten.
3. Erforderliche Checks und ihren aktuellen Status lesen.
4. Laufende erforderliche Checks bis zu einem terminalen Zustand beobachten.
5. Vor dem Ergebnis pruefen, ob der Pull-Request-Head unveraendert ist.
6. Nur bei vollstaendig erfolgreichen erforderlichen Checks ein erfolgreiches Ergebnis ausgeben.
7. Fehlgeschlagene, abgebrochene, uebersprungene oder fehlende erforderliche Checks mit ihrem Status melden.

## Kommandos

```powershell
gh pr view <pr-nummer> --repo <org>/<repo> --json headRefOid,url
gh pr checks <pr-nummer> --repo <org>/<repo> --required --watch --interval 10
gh pr view <pr-nummer> --repo <org>/<repo> --json headRefOid,url
```

## Grenzen

- Read-only arbeiten.
- Keine Checks neu starten, abbrechen, ueberspringen oder administrativ umgehen.
- Keine CI-Fehler analysieren oder beheben.
- Ein neuer Head-Commit macht das bisherige Ergebnis ungueltig und erfordert eine neue Beobachtung.
- Fehlende erforderliche Checks nicht stillschweigend als erfolgreich behandeln, wenn Repository-Regeln Checks erwarten.
- Bei Authentifizierungs-, Berechtigungs- oder API-Fehlern stoppen und den Blocker melden.

## Output

- Pull Request und beobachteter Head-Commit
- terminaler Status der erforderlichen Checks
- erfolgreiche, fehlgeschlagene, abgebrochene, uebersprungene oder fehlende Checks
- Blocker oder erforderliche erneute Beobachtung

## Qualitaetskriterien

- Nur terminale Ergebnisse als abgeschlossen melden.
- Check-Status nicht relativieren.
- Ergebnis an den unveraenderten Pull-Request-Head binden.
