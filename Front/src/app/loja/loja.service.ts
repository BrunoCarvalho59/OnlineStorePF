import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categoria } from '../shared/models/categoria';
import { LojaParams } from '../shared/models/lojaParams';
import { Marca } from '../shared/models/marca';
import { Pagination } from '../shared/models/pagination';
import { Produto } from '../shared/models/produto';

@Injectable({
  providedIn: 'root'
})
export class LojaService {
  baseUrl = 'https://localhost:5001/api/';


  constructor(private http: HttpClient) { }

  getProducts(lojaParams: LojaParams) {
    let params = new HttpParams();

    if (lojaParams.marcaId > 0) params = params.append('marcaId', lojaParams.marcaId);
    if (lojaParams.categoriaId) params = params.append('categoriaId', lojaParams.categoriaId);
    params = params.append('sort', lojaParams.sort);
    params = params.append('pageIndex', lojaParams.pageIndex);
    params = params.append('pageSize', lojaParams.pageSize);
    if (lojaParams.search) params = params.append('search', lojaParams.search);

    return this.http.get<Pagination<Produto[]>>(this.baseUrl + 'produtos', {params});
  }

  getProduct(id: number) {
    return this.http.get<Produto>(this.baseUrl + 'produtos/' + id)
  }

  getMarcas() {
    return this.http.get<Marca[]>(this.baseUrl + 'produtos/marcas');
  }

  getCategorias() {
    return this.http.get<Categoria[]>(this.baseUrl + 'produtos/categorias');
  }
}
