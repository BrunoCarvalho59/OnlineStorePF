import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { Produto } from 'src/app/shared/models/produto';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.scss']
})
export class ProdutosComponent{
  @Input() produto?: Produto;

  constructor(private basketService: BasketService) {}

  addItemToBasket() {
    this.produto && this.basketService.addItemToBasket(this.produto);
  }


}
