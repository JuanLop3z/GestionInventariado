import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Productos, Producto, MovimientoRequest } from '../../services/productos';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-inventario',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './inventario.html',
  styleUrls: ['./inventario.css'],
})
export class Inventario implements OnInit {
  inventario: Producto[] = [];
  movimiento: MovimientoRequest = { productoId: 0, tipo: 'entrada', cantidad: 0 ,};
  mensaje: string = '';
  mensajeTipo: string = '';

  constructor(private productosService: Productos,  private cdr: ChangeDetectorRef
) {}

  ngOnInit(): void {
    this.cargarInventario();
  }

  cargarInventario() {
  this.productosService.getInventario().subscribe({
    next: (res) => {
      if (!res.isError) {
        this.inventario = res.content;
        this.cdr.detectChanges();
      } else {
        this.mensaje = 'Error al cargar inventario: ' + res.message;
        this.cdr.detectChanges();
      }
    },
    error: (err) => {
      this.mensaje = 'Error de conexión al backend';
      this.cdr.detectChanges();
    }
  });
}


  registrarMovimiento() {
    this.productosService.registrarMovimiento(this.movimiento).subscribe({
      next: (res) => {
        if (!res.isError) {
          this.mensaje = 'Movimiento registrado correctamente';
          this.mensajeTipo = 'success';
          this.cargarInventario();
          this.movimiento = { productoId: 0, tipo: 'entrada', cantidad: 0 }; // limpiar form
        } else {
          this.mensaje = 'Error: ' + res.message;
          this.mensajeTipo = 'error';
        }
      },
      error: () => {
        this.mensaje = 'Error al registrar movimiento';
        this.mensajeTipo = 'error';
      }
    });
  }
}
