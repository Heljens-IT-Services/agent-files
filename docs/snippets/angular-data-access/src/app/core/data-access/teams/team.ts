/** Internes Modell eines Teams. Feature-Code arbeitet nur hiermit, nie mit dem API-DTO. */
export interface Team {
  readonly id: string;
  readonly name: string;
}
