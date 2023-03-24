import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Categoria } from '../shared/models/categoria';
import { LojaParams } from '../shared/models/lojaParams';
import { Marca } from '../shared/models/marca';
import { Produto } from '../shared/models/produto';
import { LojaService } from './loja.service';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.scss']
})
export class LojaComponent implements OnInit{
  @ViewChild('search') searchTerm?: ElementRef;
  produtos: Produto[] = [];
  marcas: Marca[] = [];
  categorias: Categoria[] = [];
  lojaParams = new LojaParams();
  sortOptions = [
    {nome: 'Alfabética', value: 'nome'},
    {nome: 'Preço: Do mais barato para o mais caro', value: 'priceAsc'},
    {nome: 'Preço: Do mais caro para o mais barato', value: 'priceDes'},
  ];
  totalCount = 0;

  constructor(private lojaService: LojaService){}

  ngOnInit(): void {
    this.getProducts(),
    this.getMarcas();
    this.getCategorias();
  }

  getProducts() {
    this.lojaService.getProducts(this.lojaParams).subscribe({
      next: response => {
        this.produtos = response.data;
        this.lojaParams.pageIndex = response.pageIndex;
        this.lojaParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    })
  }

  getMarcas() {
    this.lojaService.getMarcas().subscribe({
      next: response => this.marcas = [{id: 0, nome: 'All'}, ...response],
      error: error => console.log(error)
    })
  }

  getCategorias() {
    this.lojaService.getCategorias().subscribe({
      next: response => this.categorias = [{id: 0, nome: 'All'}, ...response],
      error: error => console.log(error)
    })
  }

  onMarcaSelected(marcaId:number) {
    this.lojaParams.marcaId = marcaId;
    this.lojaParams.pageIndex = 1;
    this.getProducts();
  }

  onCategoriaSelected(categoriaId:number) {
    this.lojaParams.categoriaId = categoriaId;
    this.lojaParams.pageIndex = 1;
    this.getProducts();
  }

  onSortSelected(event: any) {
    this.lojaParams.sort = event.target.value;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.lojaParams.pageIndex !== event) {
      this.lojaParams.pageIndex = event;
      this.getProducts();
    }
  }

  onSearch() {
    this.lojaParams.search = this.searchTerm?.nativeElement.value;
    this.lojaParams.pageIndex = 1;
    this.getProducts();
  }

  onReset() {
    if(this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.lojaParams = new LojaParams();
    this.getProducts();
  }
}
