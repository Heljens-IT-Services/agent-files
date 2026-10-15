import { type ApplicationConfig } from '@angular/core';
import { provideHttpClient, withFetch, withInterceptors, withXsrfConfiguration } from '@angular/common/http';
import { provideRouter } from '@angular/router';

import { provideApi } from '@core/data-access/api';
import { sessionExpiredInterceptor } from '@core/http/session-expired.interceptor';

import { routes } from './app.routes';

/**
 * Ausschnitt: HTTP-Client mit Interceptors und XSRF-Schutz für Cookie-basierte Sitzungen.
 * `provideApi('')` lässt den erzeugten Client relativ zur eigenen Origin aufrufen; ohne diese Angabe
 * verwendet er `http://localhost`.
 */
export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideApi(''),
    provideHttpClient(
      withFetch(),
      withInterceptors([sessionExpiredInterceptor]),
      withXsrfConfiguration({ cookieName: 'XSRF-TOKEN', headerName: 'X-XSRF-TOKEN' }),
    ),
  ],
};
