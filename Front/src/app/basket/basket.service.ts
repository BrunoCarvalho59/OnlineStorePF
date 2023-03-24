import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Basket, BasketItem } from '../shared/models/basket';
import { Produto } from '../shared/models/produto';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket | null>(null);
  basketSource$ = this.basketSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get<Basket>(this.baseUrl + 'basket?id=' + id).subscribe({
      next: basket => this.basketSource.next(basket)
    })
  }

  setBasket(basket: Basket) {
    return this.http.post<Basket>(this.baseUrl + 'basket', basket).subscribe({
      next: basket => this.basketSource.next(basket)
    })
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: Produto, quantidade = 1) {
    const itemToAdd = this.mapProductItemToBasketItem(item);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantidade);
    this.setBasket(basket);
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
}
