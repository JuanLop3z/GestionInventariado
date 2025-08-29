import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// 🔹 Interfaces para tipado
export interface Producto {
  id: number;
  nombre: string;
  cantidad: number;
}

export interface ApiResponse<T> {
  codigo: number;
  isError: boolean;
  message: string;
  content: T;
}

export interface MovimientoRequest {
  productoId: number;
  tipo: 'entrada' | 'salida'; // puedes ajustarlo según backend
  cantidad: number;
}

@Injectable({
  providedIn: 'root'
})
export class Productos {

  private apiUrl = 'https://localhost:7050/productos';

  constructor(private http: HttpClient) { }

  // 🔹 GET /productos/inventario
  getInventario(): Observable<ApiResponse<Producto[]>> {
    return this.http.get<ApiResponse<Producto[]>>(`${this.apiUrl}/inventario`);
  }

  // 🔹 POST /productos/movimiento
  registrarMovimiento(data: MovimientoRequest): Observable<ApiResponse<Producto>> {
    return this.http.post<ApiResponse<Producto>>(`${this.apiUrl}/movimiento`, data);
  }
}
