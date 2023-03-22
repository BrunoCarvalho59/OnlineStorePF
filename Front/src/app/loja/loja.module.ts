import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoInfoComponent } from './produto-info/produto-info.component';
import { LojaComponent } from './loja.component';
import { ProdutosComponent } from './produtos/produtos.component';



@NgModule({
  declarations: [
    ProdutosComponent,
    ProdutoInfoComponent,
    LojaComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LojaComponent
  ]
})
export class LojaModule { }
