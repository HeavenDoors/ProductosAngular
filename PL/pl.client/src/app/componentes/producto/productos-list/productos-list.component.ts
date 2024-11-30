import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router'
import { environment } from '../../../../environments/environment.development';
import { Categoria } from '../../../modelos/Categoria';
import { SubCategoria } from '../../../modelos/SubCategoria';


@Component({
  selector: 'app-productos-list',
  standalone: false,
  
  templateUrl: './productos-list.component.html',
  styleUrl: './productos-list.component.css'
})
export class ProductosListComponent implements OnInit {
  CategoriaGet: any = [];
  SubCategoriaGet: any = [];
  Productos: any = [];
  API_URL = environment.apiUrl;

  categoria: Categoria = {
    IdCategoria: 0,
    Nombre: ''
  }

  subCategoria: SubCategoria = {
    IdSubCategoria: 0,
    Nombre: '',
    Categoria: {
      IdCategoria: 0,
      Nombre: ''
    }
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetAllCategoria()
  }

  GetAllCategoria() {
    this.http.get(this.API_URL + '/Categoria/GetAllCategoria').subscribe(
      (res) => {
        this.CategoriaGet = res;
      },
      (err) => console.error(err)
    );
  }

  GetAllSubCategoria(IdSubCategoria: string) {
    this.http.get(this.API_URL + '/SubCategoria/GetAllSubCategoria/' + IdSubCategoria).subscribe(
      (res) => {
        this.SubCategoriaGet = res;
      },
      (err) => console.error(err))
  }
}

