import { Injectable } from '@angular/core';
import { HttpInterceptorFn } from '@angular/common/http';

// 🔹 Función que devuelve el token almacenado
function getToken(): string | null {
  return localStorage.getItem('auth_token');
}

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = getToken();

  if (token) {
    const authReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next(authReq);
  }

  return next(req);
};
