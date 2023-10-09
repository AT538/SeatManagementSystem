/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { SeatManagementApiConfiguration as __Configuration } from '../seat-management-api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { MeetingRoom } from '../models/meeting-room';
@Injectable({
  providedIn: 'root',
})
class MeetingRoomService extends __BaseService {
  static readonly getApiMeetingRoomPath = '/api/MeetingRoom';
  static readonly putApiMeetingRoomPath = '/api/MeetingRoom';
  static readonly postApiMeetingRoomPath = '/api/MeetingRoom';
  static readonly deleteApiMeetingRoomIdPath = '/api/MeetingRoom/{id}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param id undefined
   */
  getApiMeetingRoomResponse(id?: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (id != null) __params = __params.set('id', id.toString());
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/MeetingRoom`,
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
  getApiMeetingRoom(id?: number): __Observable<null> {
    return this.getApiMeetingRoomResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param body undefined
   */
  putApiMeetingRoomResponse(body?: MeetingRoom): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/MeetingRoom`,
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
  putApiMeetingRoom(body?: MeetingRoom): __Observable<null> {
    return this.putApiMeetingRoomResponse(body).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `MeetingRoomService.PostApiMeetingRoomParams` containing the following parameters:
   *
   * - `totalRooms`:
   *
   * - `FacilityId`:
   */
  postApiMeetingRoomResponse(params: MeetingRoomService.PostApiMeetingRoomParams): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (params.totalRooms != null) __params = __params.set('totalRooms', params.totalRooms.toString());
    if (params.FacilityId != null) __params = __params.set('FacilityId', params.FacilityId.toString());
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/MeetingRoom`,
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
   * @param params The `MeetingRoomService.PostApiMeetingRoomParams` containing the following parameters:
   *
   * - `totalRooms`:
   *
   * - `FacilityId`:
   */
  postApiMeetingRoom(params: MeetingRoomService.PostApiMeetingRoomParams): __Observable<null> {
    return this.postApiMeetingRoomResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id undefined
   */
  deleteApiMeetingRoomIdResponse(id: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/MeetingRoom/${encodeURIComponent(String(id))}`,
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
  deleteApiMeetingRoomId(id: number): __Observable<null> {
    return this.deleteApiMeetingRoomIdResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module MeetingRoomService {

  /**
   * Parameters for postApiMeetingRoom
   */
  export interface PostApiMeetingRoomParams {
    totalRooms?: number;
    FacilityId?: number;
  }
}

export { MeetingRoomService }
