import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
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
  quantityInBasket = 0;


  constructor(private lojaService: LojaService, private activatedRoute: ActivatedRoute,
      private bcService: BreadcrumbService, private basketService: BasketService) {
        this.bcService.set('@produto-info', ' ')
      }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.lojaService.getProduct(+id).subscribe({
      next: produto => {
        this.produto = produto;
        this.bcService.set('@produto-info', produto.nome);
        this.basketService.basketSource$.pipe(take(1)).subscribe({
          next: basket => {
            const item = basket?.items.find(x => x.id === +id);
            if (item) {
              this.quantity = item.quantidade;
              this.quantityInBasket = item.quantidade;
            }
          }
        })
      },
      error: error => console.log(error)
    })
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    this.quantity--;
  }

  updateBasket() {
    if (this.produto) {
      if (this.quantity > this.quantityInBasket) {
        const itemsToAdd = this.quantity - this.quantityInBasket;
        this.quantityInBasket += itemsToAdd;
        this.basketService.addItemToBasket(this.produto, itemsToAdd);
      } else {
          const itemsToRemove = this.quantityInBasket - this.quantity;
          this.quantityInBasket -= itemsToRemove;
          this.basketService.removeItemFromBasket(this.produto.id, itemsToRemove);
      }
    }
  }

  get buttonText() {
    return this.quantityInBasket == 0 ? 'Add to basket' : 'Update basket';
  }
}
