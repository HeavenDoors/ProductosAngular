import { HttpClientModule } from '@angular/common/http';
import { LOCALE_ID ,NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ɵBrowserAnimationBuilder } from '@angular/animations';
import { AppComponent } from './app.component';
import { ProductosListComponent } from './componentes/producto/productos-list/productos-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductosListComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'es-MX' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
