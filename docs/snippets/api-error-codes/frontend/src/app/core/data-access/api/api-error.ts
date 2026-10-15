import { HttpErrorResponse } from '@angular/common/http';

/** Ersatzcode, wenn eine Fehlerantwort keinen lesbaren `errorCode` trägt. */
export const UNKNOWN_ERROR_CODE = 'unknown';

/** Ergebnis eines Data-Access-Aufrufs: Erfolg mit Wert oder fachlicher Fehlercode. */
export type ApiResult<T> =
  | { readonly succeeded: true; readonly value: T }
  | { readonly succeeded: false; readonly errorCode: string };

/**
 * Liest `errorCode` aus einer ProblemDetails-Antwort. Liefert {@link UNKNOWN_ERROR_CODE}, wenn der
 * Fehler keine HTTP-Antwort ist oder keinen Code trägt, damit Aufrufer immer eine Meldung zeigen können.
 */
export function readProblemErrorCode(error: unknown): string {
  if (!(error instanceof HttpErrorResponse)) {
    return UNKNOWN_ERROR_CODE;
  }
  const body: unknown = error.error;
  if (typeof body !== 'object' || body === null || !('errorCode' in body)) {
    return UNKNOWN_ERROR_CODE;
  }
  const candidate = (body as { errorCode: unknown }).errorCode;
  return typeof candidate === 'string' && candidate.length > 0 ? candidate : UNKNOWN_ERROR_CODE;
}

/** Führt einen API-Aufruf aus und überführt fachliche Fehler (4xx) in ein {@link ApiResult}. */
export async function toApiResult<T>(call: () => Promise<T>): Promise<ApiResult<T>> {
  try {
    return { succeeded: true, value: await call() };
  } catch (error: unknown) {
    if (error instanceof HttpErrorResponse && error.status >= 400 && error.status < 500) {
      return { succeeded: false, errorCode: readProblemErrorCode(error) };
    }
    throw error;
  }
}
