import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BasketService } from 'src/app/basket/basket.service';
import { Basket } from 'src/app/shared/models/basket';
import { Morada } from 'src/app/shared/models/user';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent {
  @Input() checkoutForm?: FormGroup;

  constructor(private basketService: BasketService, private checkoutService: CheckoutService,
      private toastr: ToastrService, private router: Router) {}

  submitOrder() {
    const basket = this.basketService.getCurrentBasketValue();
    if (!basket) return;
    const OrderToCreate = this.getOrderToCreate(basket);
    if(!OrderToCreate) return;
    this.checkoutService.createOrder(OrderToCreate).subscribe({
      next: order => {
        this.toastr.success('Compra feita com Sucesso');
        this.basketService.deleteLocalBasket();
        const navigationsExtras: NavigationExtras = {state: order};
        this.router.navigate(['checkout/success'], navigationsExtras);
      }
    });
  }
  getOrderToCreate(basket: Basket) {
    const metodoEnvioId = this.checkoutForm?.get('deliveryForm')?.get('deliveryMethod')?.value;
    const moradaEnvio = this.checkoutForm?.get('addressForm')?.value as Morada;
    if(!metodoEnvioId || !moradaEnvio) return;
    return {
      basketId: basket.id,
      metodoEnvioId: metodoEnvioId,
      moradaEnvio: moradaEnvio
    }
  }
}
