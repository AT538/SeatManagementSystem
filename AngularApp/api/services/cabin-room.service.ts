/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { SeatManagementApiConfiguration as __Configuration } from '../seat-management-api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
class CabinRoomService extends __BaseService {
  static readonly getApiCabinRoomPath = '/api/CabinRoom';
  static readonly postApiCabinRoomPath = '/api/CabinRoom';
  static readonly deleteApiCabinRoomIdPath = '/api/CabinRoom/{id}';
  static readonly patchApiCabinRoomIdPath = '/api/CabinRoom/{id}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param id undefined
   */
  getApiCabinRoomResponse(id?: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (id != null) __params = __params.set('id', id.toString());
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/CabinRoom`,
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
  getApiCabinRoom(id?: number): __Observable<null> {
    return this.getApiCabinRoomResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `CabinRoomService.PostApiCabinRoomParams` containing the following parameters:
   *
   * - `totalCabins`:
   *
   * - `FacilityId`:
   */
  postApiCabinRoomResponse(params: CabinRoomService.PostApiCabinRoomParams): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (params.totalCabins != null) __params = __params.set('totalCabins', params.totalCabins.toString());
    if (params.FacilityId != null) __params = __params.set('FacilityId', params.FacilityId.toString());
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/CabinRoom`,
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
   * @param params The `CabinRoomService.PostApiCabinRoomParams` containing the following parameters:
   *
   * - `totalCabins`:
   *
   * - `FacilityId`:
   */
  postApiCabinRoom(params: CabinRoomService.PostApiCabinRoomParams): __Observable<null> {
    return this.postApiCabinRoomResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id undefined
   */
  deleteApiCabinRoomIdResponse(id: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/CabinRoom/${encodeURIComponent(String(id))}`,
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
  deleteApiCabinRoomId(id: number): __Observable<null> {
    return this.deleteApiCabinRoomIdResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `CabinRoomService.PatchApiCabinRoomIdParams` containing the following parameters:
   *
   * - `id`:
   *
   * - `EmployeeId`:
   */
  patchApiCabinRoomIdResponse(params: CabinRoomService.PatchApiCabinRoomIdParams): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    if (params.EmployeeId != null) __params = __params.set('EmployeeId', params.EmployeeId.toString());
    let req = new HttpRequest<any>(
      'PATCH',
      this.rootUrl + `/api/CabinRoom/${encodeURIComponent(String(params.id))}`,
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
   * @param params The `CabinRoomService.PatchApiCabinRoomIdParams` containing the following parameters:
   *
   * - `id`:
   *
   * - `EmployeeId`:
   */
  patchApiCabinRoomId(params: CabinRoomService.PatchApiCabinRoomIdParams): __Observable<null> {
    return this.patchApiCabinRoomIdResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module CabinRoomService {

  /**
   * Parameters for postApiCabinRoom
   */
  export interface PostApiCabinRoomParams {
    totalCabins?: number;
    FacilityId?: number;
  }

  /**
   * Parameters for patchApiCabinRoomId
   */
  export interface PatchApiCabinRoomIdParams {
    id: number;
    EmployeeId?: number;
  }
}

export { CabinRoomService }
