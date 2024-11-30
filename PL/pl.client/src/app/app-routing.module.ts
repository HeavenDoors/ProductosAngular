import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { ProductosListComponent } from './componentes/producto/productos-list/productos-list.component';

const routes: Routes = [

  {
    path: '',
    redirectTo: '/producto',
    pathMatch: 'full'
  },

  {
    path: 'producto',
    component: ProductosListComponent
  },


  {
    path: '**',
    redirectTo: '/producto',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
