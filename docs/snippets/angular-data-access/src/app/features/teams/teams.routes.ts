import type { Routes } from '@angular/router';

import { sessionGuard } from '@core/session/session.guard';

import { TeamsStore } from './teams.store';

/** Feature-Routen: der Store lebt im Injector der Route und endet mit dem Feature. */
export const teamsRoutes: Routes = [
  {
    path: '',
    canActivate: [sessionGuard],
    providers: [TeamsStore],
    loadComponent: () => import('./page/teams-page.component').then((module) => module.TeamsPageComponent),
  },
];
