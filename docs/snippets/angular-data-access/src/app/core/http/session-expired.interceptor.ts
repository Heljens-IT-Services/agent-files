import { HttpErrorResponse, type HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

import { SessionStore } from '@core/session/session-store';

/**
 * Reagiert zentral auf eine abgelaufene Sitzung: verwirft den Sitzungszustand und führt zur
 * Anmeldung, statt jede Ansicht eine eigene Fehlermeldung zeigen zu lassen. Verändert keine Anfrage
 * und reicht den Fehler weiter, damit Aufrufer ihren Ladezustand beenden.
 */
export const sessionExpiredInterceptor: HttpInterceptorFn = (request, next) => {
  const router = inject(Router);
  const sessionStore = inject(SessionStore);

  return next(request).pipe(
    catchError((error: unknown) => {
      const isUnauthorized = error instanceof HttpErrorResponse && error.status === 401;
      if (isUnauthorized && !router.url.startsWith('/auth')) {
        sessionStore.reset();
        void router.navigate(['/auth'], { queryParams: { reason: 'expired' } });
      }
      return throwError(() => error);
    }),
  );
};
