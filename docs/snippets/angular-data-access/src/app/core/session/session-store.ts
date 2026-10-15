import { Injectable, inject, signal } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { type CurrentUser, UsersApiService } from '@core/data-access/users';

/** Ergebnis von {@link SessionStore.ensureLoaded}. */
export type SessionLoadResult = 'loaded' | 'unauthenticated' | 'unavailable';

/**
 * Globaler Sitzungszustand: app-weit benötigt von Guard, Kopfzeile und Menüs. Lädt den aktuellen
 * Benutzer höchstens einmal je Sitzung; {@link reset} verwirft ihn beim Abmelden oder nach Ablauf.
 */
@Injectable({ providedIn: 'root' })
export class SessionStore {
  private readonly usersApi = inject(UsersApiService);

  private readonly _user = signal<CurrentUser | null>(null);
  private loading: Promise<SessionLoadResult> | null = null;

  readonly user = this._user.asReadonly();

  /** Idempotent: liegt bereits ein Benutzer vor, wird nicht erneut geladen. */
  ensureLoaded(): Promise<SessionLoadResult> {
    if (this._user() !== null) {
      return Promise.resolve('loaded');
    }
    this.loading ??= this.loadUser().finally(() => {
      this.loading = null;
    });
    return this.loading;
  }

  reset(): void {
    this._user.set(null);
  }

  private async loadUser(): Promise<SessionLoadResult> {
    try {
      this._user.set(await this.usersApi.getCurrent());
      return 'loaded';
    } catch (error: unknown) {
      return isApiOutage(error) ? 'unavailable' : 'unauthenticated';
    }
  }
}

/** Status 0 und 5xx heißen, dass die API nicht antwortet; die Sitzung ist damit nicht widerlegt. */
function isApiOutage(error: unknown): boolean {
  return error instanceof HttpErrorResponse && (error.status === 0 || error.status >= 500);
}
