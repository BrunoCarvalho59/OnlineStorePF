import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Produto } from 'src/app/shared/models/produto';
import { LojaService } from '../loja.service';

@Component({
  selector: 'app-produto-info',
  templateUrl: './produto-info.component.html',
  styleUrls: ['./produto-info.component.scss']
})
export class ProdutoInfoComponent implements OnInit {
  produto?: Produto;


  constructor(private lojaService: LojaService, private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.lojaService.getProduct(+id).subscribe({
      next: produto => this.produto = produto,
      error: error => console.log(error)
    })
  }

}
