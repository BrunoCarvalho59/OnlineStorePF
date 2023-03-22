import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Produto } from '../shared/models/produto';

@Injectable({
  providedIn: 'root'
})
export class LojaService {
  baseUrl = 'https://localhost:5001/api/';


  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<Pagination<Produto[]>>(this.baseUrl + 'produtos?pageSize=50');
  }
}
