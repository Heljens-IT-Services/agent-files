import { Injectable, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';

import { type ApiResult, TeamsService, type TeamResponse, toApiResult } from '@core/data-access/api';

import type { Team } from './team';

/**
 * Einziger Zugang zu den Team-Endpunkten. Kapselt den aus `contracts/api.yaml` erzeugten Client,
 * liefert Promises und interne Modelle und meldet fachliche Fehler als {@link ApiResult}.
 */
@Injectable({ providedIn: 'root' })
export class TeamsApiService {
  private readonly teamsService = inject(TeamsService);

  async list(page: number, pageSize: number): Promise<{ readonly items: readonly Team[]; readonly count: number }> {
    const result = await firstValueFrom(this.teamsService.listTeams({ page, pageSize }));
    return { items: result.items.map(toTeam), count: result.count };
  }

  async create(name: string): Promise<ApiResult<Team>> {
    const result = await toApiResult(() => firstValueFrom(this.teamsService.createTeam({ createTeamRequest: { name } })));
    return result.succeeded ? { succeeded: true, value: toTeam(result.value) } : result;
  }
}

function toTeam(response: TeamResponse): Team {
  return { id: response.businessId, name: response.name };
}
