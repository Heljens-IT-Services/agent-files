import { defineConfig } from 'orval';

/**
 * Erzeugt die Angular-Services aus `contracts/api.json`.
 *
 * - `target` und `schemas` müssen INNERHALB von `generated/` liegen: `clean: true` leert das
 *   Zielverzeichnis vor jedem Lauf und würde sonst handgeschriebene Nachbardateien löschen.
 * - `headers: true` ist Pflicht: ohne das Flag verwirft der Angular-Generator Header-Parameter wie
 *   `Page`/`Page-Size` ohne Fehler oder Warnung.
 * - `retrievalClient: 'httpClient'` hält den Client beim klassischen `HttpClient`, damit ein
 *   orval-Update nicht still auf `httpResource` umschaltet.
 */
export default defineConfig({
  api: {
    input: { target: '../../contracts/api.json' },
    output: {
      mode: 'tags-split',
      target: './src/app/core/data-access/api/generated/endpoints.ts',
      schemas: './src/app/core/data-access/api/generated/model',
      client: 'angular',
      clean: true,
      prettier: false,
      headers: true,
      override: {
        angular: {
          retrievalClient: 'httpClient',
        },
        mutator: {
          path: './src/app/core/data-access/api/http-client.mutator.ts',
          name: 'useCustomClient',
        },
      },
    },
  },
});
