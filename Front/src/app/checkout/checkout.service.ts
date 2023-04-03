import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MetodoEnvio } from '../shared/models/deliveryMethod';
import { Order, OrderToCreate } from '../shared/models/order';


@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  createOrder(order: OrderToCreate) {
    return this.http.post<Order>(this.baseUrl + 'compras', order);
  }

  getDeliveryMethods() {
    return this.http.get<MetodoEnvio[]>(this.baseUrl + 'compras/metodosEnvio').pipe(
      map(dm => {
        return dm.sort((a, b) => b.preco - a.preco)
      })
    )
  }
}
