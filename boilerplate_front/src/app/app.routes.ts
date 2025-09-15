import { Routes } from '@angular/router';
import { ClientesPageComponent } from './pages/clientes/clientes.page';

export const routes: Routes = [
  { path: 'clientes', component: ClientesPageComponent },
  { path: '', redirectTo: '/clientes', pathMatch: 'full' },
  { path: '**', redirectTo: '/clientes' }
];
