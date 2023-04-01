import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Produto } from 'src/app/shared/models/produto';
import { BreadcrumbService } from 'xng-breadcrumb';
import { LojaService } from '../loja.service';

@Component({
  selector: 'app-produto-info',
  templateUrl: './produto-info.component.html',
  styleUrls: ['./produto-info.component.scss']
})
export class ProdutoInfoComponent implements OnInit {
  produto?: Produto;
  quantity = 1;
  quatityInBasket = 0;


  constructor(private lojaService: LojaService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService) {}

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.lojaService.getProduct(+id).subscribe({
      next: produto => {
        this.produto = produto;
        this.bcService.set('@produto-info', produto.nome)
      },
      error: error => console.log(error)
    })
  }

}
