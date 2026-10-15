/**
 * Öffentliche Fassade der API-Schicht. Data-Access-Services importieren ausschließlich von hier, nie
 * direkt aus `./generated`. Ändert sich die erzeugte Dateistruktur, ändert sich nur diese Datei.
 */
export * from './generated';
export * from './api-error';
