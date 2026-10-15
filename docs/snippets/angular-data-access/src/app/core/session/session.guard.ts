import { inject } from '@angular/core';
import { type CanActivateFn, Router } from '@angular/router';

import { SessionStore } from './session-store';

/** Lässt nur mit geladener Sitzung in geschützte Routen; sonst Umleitung zur Anmeldung mit Grund. */
export const sessionGuard: CanActivateFn = async () => {
  const sessionStore = inject(SessionStore);
  const router = inject(Router);

  const result = await sessionStore.ensureLoaded();
  switch (result) {
    case 'loaded':
      return true;
    case 'unauthenticated':
      return router.createUrlTree(['/auth'], { queryParams: { reason: 'expired' } });
    case 'unavailable':
      return router.createUrlTree(['/auth'], { queryParams: { reason: 'unavailable' } });
  }
};
