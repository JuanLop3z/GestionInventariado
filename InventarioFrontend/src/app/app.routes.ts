import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login';
import { Inventario } from './components/inventario/inventario';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'inventario', component: Inventario },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];
