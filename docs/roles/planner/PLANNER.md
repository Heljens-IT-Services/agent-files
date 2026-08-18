# PLANNER.md

Stand: 2026-08-18

## Zweck

Diese Datei definiert ausschließlich Leitplanken für die Planung und Pflege von GitHub Issues.

[MUST_NOT] Diese Datei darf keine Leitplanken außerhalb von GitHub Issues enthalten.

## Inhalt

[MUST] Jedes GitHub Issue muss genau ein klares Ziel besitzen.

[MUST] Scope, Nicht-Ziele und Abschluss- oder Akzeptanzkriterien müssen eindeutig sein, soweit sie für die Umsetzung oder Prüfung erforderlich sind.

[MUST] Ein GitHub Issue muss eigenständig verständlich und abgrenzbar sein.

[MUST_NOT] GitHub Issues dürfen keine fachlich unverbundenen Änderungssätze bündeln.

## Typen und Beziehungen

[MUST] Der native GitHub-Issue-Type muss dem fachlichen Zweck des Issues entsprechen.

[MUST] Parent/Child muss ausschließlich fachliche Hierarchie ausdrücken.

[MUST_NOT] Parent/Child darf nicht als Ausführungsreihenfolge interpretiert werden.

[MUST_IF] Eine harte Ausführungsabhängigkeit besteht, muss sie richtungsstabil als native `blocked by`-Beziehung gesetzt werden.

[MUST_NOT] Labels, Checklisten oder Body-Links dürfen native GitHub-Issue-Typen oder -Beziehungen ersetzen.

## Zerlegung und Konsistenz

[MUST] Child-Issues müssen kleiner und klarer als ihr Parent sowie eigenständig umsetzbar und verifizierbar sein.

[MUST_NOT] GitHub Issues dürfen nicht künstlich oder bis zu technisch trivialen Einzelschritten zerlegt werden.

[MUST] Bestehende passende GitHub Issues müssen wiederverwendet werden, statt Duplikate zu erzeugen.

[MUST] Issue-Inhalt, nativer Type und native Beziehungen müssen widerspruchsfrei sein.

## Abschluss

[MUST] Ein GitHub Issue darf nur geschlossen werden, wenn seine Abschluss- oder Akzeptanzkriterien nachweislich erfüllt sind.

[MUST_IF] Restumfang verbleibt, muss er vor dem Schließen explizit als GitHub Issue erfasst oder als offener Umfang dokumentiert werden.
