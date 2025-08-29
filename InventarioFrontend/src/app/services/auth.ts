import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

interface LoginResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class Auth {
  
  private apiUrl = 'https://localhost:7050/api/JWTAuthentication';
  private tokenKey = 'auth_token';

  constructor(private http: HttpClient) {}

  // 🔹 Login y guardado del token
  login(user: string, password: string): Observable<LoginResponse> {
    const body = { user, password };
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, body)
      .pipe(
        tap((response: LoginResponse) => {
          localStorage.setItem(this.tokenKey, response.token);
        })
      );
  }

  // 🔹 Obtener token guardado
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  // 🔹 Eliminar token (logout)
  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  // 🔹 Saber si está logueado
  isAuthenticated(): boolean {
    return !!this.getToken();
  }
}
