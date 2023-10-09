// city.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CityDTO } from 'src/api/models';
import { API_CONFIG } from '../api.config';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  constructor(private http: HttpClient) {}

  getCities(): Observable<CityDTO[]> {
    return this.http.get<CityDTO[]>(API_CONFIG.baseUrl + 'City');
  }
}
