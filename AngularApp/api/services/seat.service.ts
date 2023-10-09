/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { SeatManagementApiConfiguration as __Configuration } from '../seat-management-api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Seat } from '../models/seat';
@Injectable({
  providedIn: 'root',
})
class SeatService extends __BaseService {
  static readonly putApiSeatPath = '/api/Seat';
  static readonly patchApiSeatPath = '/api/Seat';
  static readonly postApiSeatPath = '/api/Seat';
  static readonly getApiSeatPath = '/api/Seat';
  static readonly deleteApiSeatIdPath = '/api/Seat/{id}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param body undefined
   */
  putApiSeatResponse(body?: Seat): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Seat`,
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
  putApiSeat(body?: Seat): __Observable<null> {
    return this.putApiSeatResponse(body).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `SeatService.PatchApiSeatParams` containing the following parameters:
   *
   * - `id`:
   *
   * - `EmployeeId`:
   */
  patchApiSeatResponse(params: SeatService.PatchApiSeatParams): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (params.id != null) __params = __params.set('id', params.id.toString());
    if (params.EmployeeId != null) __params = __params.set('EmployeeId', params.EmployeeId.toString());
    let req = new HttpRequest<any>(
      'PATCH',
      this.rootUrl + `/api/Seat`,
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
   * @param params The `SeatService.PatchApiSeatParams` containing the following parameters:
   *
   * - `id`:
   *
   * - `EmployeeId`:
   */
  patchApiSeat(params: SeatService.PatchApiSeatParams): __Observable<null> {
    return this.patchApiSeatResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `SeatService.PostApiSeatParams` containing the following parameters:
   *
   * - `totalSeats`:
   *
   * - `FacilityId`:
   */
  postApiSeatResponse(params: SeatService.PostApiSeatParams): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (params.totalSeats != null) __params = __params.set('totalSeats', params.totalSeats.toString());
    if (params.FacilityId != null) __params = __params.set('FacilityId', params.FacilityId.toString());
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Seat`,
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
   * @param params The `SeatService.PostApiSeatParams` containing the following parameters:
   *
   * - `totalSeats`:
   *
   * - `FacilityId`:
   */
  postApiSeat(params: SeatService.PostApiSeatParams): __Observable<null> {
    return this.postApiSeatResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `SeatService.GetApiSeatParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `page`:
   *
   * - `id`:
   *
   * - `facilityid`:
   *
   * - `cityid`:
   *
   * - `buildingid`:
   *
   * - `Floor`:
   */
  getApiSeatResponse(params: SeatService.GetApiSeatParams): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (params.pageSize != null) __params = __params.set('pageSize', params.pageSize.toString());
    if (params.page != null) __params = __params.set('page', params.page.toString());
    if (params.id != null) __params = __params.set('id', params.id.toString());
    (params.facilityid || []).forEach(val => {if (val != null) __params = __params.append('facilityid', val.toString())});
    (params.cityid || []).forEach(val => {if (val != null) __params = __params.append('cityid', val.toString())});
    (params.buildingid || []).forEach(val => {if (val != null) __params = __params.append('buildingid', val.toString())});
    (params.Floor || []).forEach(val => {if (val != null) __params = __params.append('Floor', val.toString())});
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Seat`,
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
   * @param params The `SeatService.GetApiSeatParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `page`:
   *
   * - `id`:
   *
   * - `facilityid`:
   *
   * - `cityid`:
   *
   * - `buildingid`:
   *
   * - `Floor`:
   */
  getApiSeat(params: SeatService.GetApiSeatParams): __Observable<null> {
    return this.getApiSeatResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id undefined
   */
  deleteApiSeatIdResponse(id: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Seat/${encodeURIComponent(String(id))}`,
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
  deleteApiSeatId(id: number): __Observable<null> {
    return this.deleteApiSeatIdResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module SeatService {

  /**
   * Parameters for patchApiSeat
   */
  export interface PatchApiSeatParams {
    id?: number;
    EmployeeId?: number;
  }

  /**
   * Parameters for postApiSeat
   */
  export interface PostApiSeatParams {
    totalSeats?: number;
    FacilityId?: number;
  }

  /**
   * Parameters for getApiSeat
   */
  export interface GetApiSeatParams {
    pageSize?: number;
    page?: number;
    id?: number;
    facilityid?: Array<number>;
    cityid?: Array<number>;
    buildingid?: Array<number>;
    Floor?: Array<number>;
  }
}

export { SeatService }
