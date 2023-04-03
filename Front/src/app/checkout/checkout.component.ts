import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../account/account.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit{

  constructor(private fb: FormBuilder, private accountService: AccountService) {}

  ngOnInit(): void {
    this.getMoradaFormValues();
  }


  checkoutForm = this.fb.group({
    addressForm: this.fb.group({
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      rua: ['', Validators.required],
      localidade: ['', Validators.required],
      country: ['', Validators.required],
      zip: ['', Validators.required],
    }),
  deliveryForm: this.fb.group({
      deliveryMethod: ['', Validators.required]
  }),
  paymentForm: this.fb.group({
    nameOnCard: ['', Validators.required]
  })
  })

  getMoradaFormValues() {
    this.accountService.getUserMorada().subscribe({
      next: morada => {
        morada && this.checkoutForm.get('addressForm')?.patchValue(morada)
      }
    })
  }
}
