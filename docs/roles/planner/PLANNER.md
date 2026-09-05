# PLANNER.md

Stand: 2026-08-18

## Zweck

Diese Datei definiert Leitplanken für die Planung und Pflege von GitHub Issues sowie für projektweite, Human-geführte Implementierungspläne.

[MUST_NOT] Diese Datei darf keine Leitplanken für die technische Umsetzung oder technische Task-Planung enthalten.

## Codex-Ausführung

[MUST_IF] Wenn ein `planner`-SubAgent verfügbar ist, muss Planner-Verantwortung an ihn delegiert werden. Die fachlichen Regeln dieser Datei bleiben dabei maßgeblich.

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

## Projektweite Implementierungsplanung

[MUST] Ein projektweiter Implementierungsplan darf erst nach ausreichend geklärtem Zielbild, Scope, Nicht-Zielen, Prioritäten und wesentlichen Produkt-/Architekturentscheidungen als belastbar gelten.

[MUST] Vor der finalen Phasenbildung muss eine ausdrückliche Human-Freigabe für Zielbild, Grenzen und die Verwendung als Grundlage für Epic-Issues vorliegen.

[MUST] Ein freigegebener projektweiter Implementierungsplan muss aus großen, fachlichen Implementierungsphasen oberhalb der Epic-Ebene bestehen.

[MUST] Jede Phase muss mindestens Ziel, Scope, Nicht-Ziele, wesentliche Abhängigkeiten oder Constraints sowie Exit-/Akzeptanzkriterien enthalten.

[MUST] Der Plan muss seinen Status (`DRAFT`, `READY` oder `BLOCKED`), offene Punkte, die Freigabeentscheidung und den Freigabekontext ausweisen.

[MUST_NOT] Ein projektweiter Implementierungsplan darf keine unnötige technische Mikroplanung für Stories, Tasks, Dateien oder Symbole enthalten.

[MUST_NOT] `code-implementation-planning` darf nicht durch den projektweiten Phasenplan ersetzt oder in dessen Vertrag dupliziert werden; technische Detailplanung bleibt auf der Ebene des konkreten Issues oder Tasks.

[ALLOW_IF] Ein freigegebener Plan darf als langlebiges Repository-Artefakt dokumentiert werden, wenn der User dies verlangt oder der konkrete Projektworkflow es vorsieht.

## Abschluss

[MUST] Ein GitHub Issue darf nur geschlossen werden, wenn seine Abschluss- oder Akzeptanzkriterien nachweislich erfüllt sind.

[MUST_IF] Restumfang verbleibt, muss er vor dem Schließen explizit als GitHub Issue erfasst oder als offener Umfang dokumentiert werden.
