import { Injectable, computed, inject, signal } from '@angular/core';

import { type Team, TeamsApiService } from '@core/data-access/teams';

/** Sichtbarer Ladezustand der Teamliste. */
export type TeamsLoadState = 'idle' | 'loading' | 'loaded' | 'error';

/**
 * Feature-Store der Teamverwaltung. Hält den Zustand als private Signals und gibt ihn nur lesend
 * heraus; Komponenten lösen Änderungen ausschließlich über die öffentlichen Methoden aus. Wird in
 * der Feature-Route bereitgestellt, nicht in `root`, damit der Zustand mit dem Feature endet.
 */
@Injectable()
export class TeamsStore {
  private readonly teamsApi = inject(TeamsApiService);

  private readonly _teams = signal<readonly Team[]>([]);
  private readonly _state = signal<TeamsLoadState>('idle');
  private readonly _errorCode = signal<string | null>(null);
  private loading: Promise<void> | null = null;

  readonly teams = this._teams.asReadonly();
  readonly state = this._state.asReadonly();
  readonly errorCode = this._errorCode.asReadonly();
  readonly isEmpty = computed(() => this._state() === 'loaded' && this._teams().length === 0);

  /** Lädt die Teams; parallele Aufrufe teilen sich denselben laufenden Abruf. */
  load(): Promise<void> {
    this.loading ??= this.fetchTeams().finally(() => {
      this.loading = null;
    });
    return this.loading;
  }

  /** Legt ein Team an und liefert bei fachlichem Fehler den Fehlercode für die Meldung. */
  async create(name: string): Promise<string | null> {
    const result = await this.teamsApi.create(name);
    if (!result.succeeded) {
      this._errorCode.set(result.errorCode);
      return result.errorCode;
    }
    this._errorCode.set(null);
    this._teams.update((teams) => [...teams, result.value]);
    return null;
  }

  private async fetchTeams(): Promise<void> {
    this._state.set('loading');
    try {
      const page = await this.teamsApi.list(1, 100);
      this._teams.set(page.items);
      this._state.set('loaded');
    } catch {
      this._state.set('error');
    }
  }
}
