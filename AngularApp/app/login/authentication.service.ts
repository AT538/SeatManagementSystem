
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { API_CONFIG } from '../api.config';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
 public isAuthenticated: boolean = false;

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
  
    return this.http.post(API_CONFIG.baseUrl + 'User', { username, password });
   
    
  }

  logout(): void {
 
    this.isAuthenticated = false;
  }

  isLoggedIn(): boolean {
    return this.isAuthenticated;
  }
}
