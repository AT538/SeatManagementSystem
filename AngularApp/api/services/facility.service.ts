/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { SeatManagementApiConfiguration as __Configuration } from '../seat-management-api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { FacilityDTO } from '../models/facility-dto';
import { Facility } from '../models/facility';
@Injectable({
  providedIn: 'root',
})
class FacilityService extends __BaseService {
  static readonly getApiFacilityPath = '/api/Facility';
  static readonly postApiFacilityPath = '/api/Facility';
  static readonly putApiFacilityPath = '/api/Facility';
  static readonly deleteApiFacilityIdPath = '/api/Facility/{id}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param id undefined
   */
  getApiFacilityResponse(id?: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (id != null) __params = __params.set('id', id.toString());
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Facility`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param id undefined
   */
  getApiFacility(id?: number): __Observable<null> {
    return this.getApiFacilityResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param body undefined
   */
  postApiFacilityResponse(body?: FacilityDTO): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Facility`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param body undefined
   */
  postApiFacility(body?: FacilityDTO): __Observable<null> {
    return this.postApiFacilityResponse(body).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param body undefined
   */
  putApiFacilityResponse(body?: Facility): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Facility`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param body undefined
   */
  putApiFacility(body?: Facility): __Observable<null> {
    return this.putApiFacilityResponse(body).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id undefined
   */
  deleteApiFacilityIdResponse(id: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Facility/${encodeURIComponent(String(id))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param id undefined
   */
  deleteApiFacilityId(id: number): __Observable<null> {
    return this.deleteApiFacilityIdResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module FacilityService {
}

export { FacilityService }
