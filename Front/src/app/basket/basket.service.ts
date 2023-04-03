import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Basket, BasketItem, BasketTotals } from '../shared/models/basket';
import { MetodoEnvio } from '../shared/models/deliveryMethod';
import { Produto } from '../shared/models/produto';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket | null> (null);
  basketSource$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<BasketTotals | null> (null);
  basketTotalSource$ = this.basketTotalSource.asObservable();
  shipping = 0;

  constructor(private http: HttpClient) {}

  setShippingPrice(deliveryMethod: MetodoEnvio) {
    this.shipping = deliveryMethod.preco;
    this.calculateTotals();
  }

  getBasket(id: string) {
    return this.http.get<Basket>(this.baseUrl + 'basket?id=' + id).subscribe({
      next: basket => {
        this.basketSource.next(basket);
        this.calculateTotals();
      }
    })
  }

  setBasket(basket: Basket) {
    return this.http.post<Basket>(this.baseUrl + 'basket', basket).subscribe({
      next: basket => {
        this.basketSource.next(basket);
        this.calculateTotals();
      }
    })
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: Produto | BasketItem, quantidade = 1) {
    if (this.isProduto(item)) item = this.mapProductItemToBasketItem(item);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, item, quantidade);
    this.setBasket(basket);
  }

  removeItemFromBasket(id: number, quantidade = 1) {
    const basket = this.getCurrentBasketValue();
    if (!basket) return;
    const item = basket.items.find(x => x.id == id);
    if (item) {
      item.quantidade -= quantidade;
      if (item.quantidade === 0) {
        basket.items = basket.items.filter(x => x.id !== id);
      }
      if (basket.items.length > 0) this.setBasket(basket);
      else this.deleteBasket(basket);
    }
  }

  deleteBasket(basket: Basket) {
    return this.http.delete(this.baseUrl + 'basket?id='+ basket.id).subscribe({
      next: () => {
          this.deleteLocalBasket();
      }
    });
  }

  deleteLocalBasket() {
    this.basketSource.next(null);
    this.basketTotalSource.next(null);
    localStorage.removeItem('basket_id');
  }

  private addOrUpdateItem(items: BasketItem[], itemToAdd: BasketItem, quantidade: number): BasketItem[] {
    const item = items.find(x => x.id === itemToAdd.id);
    if (item) item.quantidade += quantidade;
    else {
      itemToAdd.quantidade = quantidade;
      items.push(itemToAdd);
    }
    return items;
  }

  private createBasket(): Basket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private mapProductItemToBasketItem(item: Produto): BasketItem {
    return {
      id: item.id,
      produtoNome: item.nome,
      preco: item.preco,
      quantidade: 0,
      pictureUrl: item.fotoUrl,
      marca: item.produtoMarca,
      categoria: item.produtoCategoria
    }
  }

  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    if (!basket) return;
    const subtotal = basket.items.reduce((a, b) => (b.preco * b.quantidade) + a, 0)
    const total = subtotal + this.shipping;
    this.basketTotalSource.next({shipping: this.shipping, total, subtotal});
  }

  private isProduto(item: Produto | BasketItem): item is Produto {
    return(item as Produto).produtoMarca !== undefined;
  }
}
