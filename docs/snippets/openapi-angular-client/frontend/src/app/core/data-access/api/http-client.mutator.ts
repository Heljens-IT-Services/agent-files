import type { HttpClient } from '@angular/common/http';
import type { Observable } from 'rxjs';

/**
 * Mutator für den orval-erzeugten Angular-Client. Reicht jede Anfrage unverändert an den injizierten
 * `HttpClient` durch; Authentifizierung, XSRF und Fehlerbehandlung gehören in Interceptors, nicht
 * hierher. `headers` muss weitergereicht werden, sonst gehen Header-Parameter verloren.
 */
export type HttpClientRequestConfig = {
  readonly url: string;
  readonly method: string;
  readonly params?: unknown;
  readonly data?: unknown;
  readonly headers?: unknown;
  readonly responseType?: 'arraybuffer' | 'blob' | 'json' | 'text';
};

export const useCustomClient = <Result>(
  { url, method, params, data, headers, responseType }: HttpClientRequestConfig,
  http: HttpClient,
): Observable<Result> =>
  http.request<Result>(method, url, {
    params: params as Record<string, string> | undefined,
    headers: headers as Record<string, string> | undefined,
    body: data,
    responseType: (responseType ?? 'json') as 'json',
  });

export default useCustomClient;
