import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BaseHttpService {
  private baseUrl: string = environment.apiUrl;

  constructor(private httpClient: HttpClient) {}

  /**
   * Function used for HTTP get
   * @param relativeUrl API endpoint
   * @param options Optional parameters
   */
  public get<T, OT = object>(relativeUrl: string, options?: OT) {
    if (options) {
      return this.httpClient.get<T>(`${this.baseUrl}${relativeUrl}`, options);
    } else {
      return this.httpClient.get<T>(`${this.baseUrl}${relativeUrl}`);
    }
  }

  /**
   * Function used for HTTP post
   * @param relativeUrl API endpoint
   * @param data Data object
   * @param options Optional parameters
   */
  public post<T, OT = object, U = object>(
    relativeUrl: string,
    data: U | T,
    options?: OT
  ) {
    if (options) {
      return this.httpClient.post<T>(
        `${this.baseUrl}${relativeUrl}`,
        data,
        options
      );
    } else {
      return this.httpClient.post<T>(`${this.baseUrl}${relativeUrl}`, data);
    }
  }

  /**
   * Function used for HTTP put
   * @param relativeUrl API endpoint
   * @param data Data object
   * @param options Optional parameters
   */
  public put<T, OT = object, U = object>(
    relativeUrl: string,
    data: T | U,
    options?: OT
  ) {
    if (options) {
      return this.httpClient.put<T>(
        `${this.baseUrl}${relativeUrl}`,
        data,
        options
      );
    } else {
      return this.httpClient.put<T>(`${this.baseUrl}${relativeUrl}`, data);
    }
  }

  /**
   * Function used for HTTP delete
   * @param relativeUrl: API endpoint
   * @param options: Optional parameters
   */
  public delete<T, OT = object | string>(relativeUrl: string, options?: OT) {
    if (options) {
      return this.httpClient.delete<T>(
        `${this.baseUrl}${relativeUrl}`,
        options
      );
    } else {
      return this.httpClient.delete<T>(`${this.baseUrl}${relativeUrl}`);
    }
  }
}
