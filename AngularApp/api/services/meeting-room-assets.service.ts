/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { SeatManagementApiConfiguration as __Configuration } from '../seat-management-api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { MeetingRoomAssetsDTO } from '../models/meeting-room-assets-dto';
import { MeetingRoomAssets } from '../models/meeting-room-assets';
@Injectable({
  providedIn: 'root',
})
class MeetingRoomAssetsService extends __BaseService {
  static readonly getApiMeetingRoomAssetsPath = '/api/MeetingRoomAssets';
  static readonly postApiMeetingRoomAssetsPath = '/api/MeetingRoomAssets';
  static readonly putApiMeetingRoomAssetsPath = '/api/MeetingRoomAssets';
  static readonly deleteApiMeetingRoomAssetsIdPath = '/api/MeetingRoomAssets/{id}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param id undefined
   */
  getApiMeetingRoomAssetsResponse(id?: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    if (id != null) __params = __params.set('id', id.toString());
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/MeetingRoomAssets`,
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
  getApiMeetingRoomAssets(id?: number): __Observable<null> {
    return this.getApiMeetingRoomAssetsResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param body undefined
   */
  postApiMeetingRoomAssetsResponse(body?: MeetingRoomAssetsDTO): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/MeetingRoomAssets`,
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
  postApiMeetingRoomAssets(body?: MeetingRoomAssetsDTO): __Observable<null> {
    return this.postApiMeetingRoomAssetsResponse(body).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param body undefined
   */
  putApiMeetingRoomAssetsResponse(body?: MeetingRoomAssets): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/MeetingRoomAssets`,
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
  putApiMeetingRoomAssets(body?: MeetingRoomAssets): __Observable<null> {
    return this.putApiMeetingRoomAssetsResponse(body).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id undefined
   */
  deleteApiMeetingRoomAssetsIdResponse(id: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/MeetingRoomAssets/${encodeURIComponent(String(id))}`,
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
  deleteApiMeetingRoomAssetsId(id: number): __Observable<null> {
    return this.deleteApiMeetingRoomAssetsIdResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module MeetingRoomAssetsService {
}

export { MeetingRoomAssetsService }
