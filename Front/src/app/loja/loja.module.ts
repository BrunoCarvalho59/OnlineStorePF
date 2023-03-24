import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoInfoComponent } from './produto-info/produto-info.component';
import { LojaComponent } from './loja.component';
import { ProdutosComponent } from './produtos/produtos.component';
import { SharedModule } from '../shared/shared.module';
import { PagingHeaderComponent } from '../shared/paging-header/paging-header.component';
import { RouterModule } from '@angular/router';
import { LojaRoutingModule } from './loja-routing.module';



@NgModule({
  declarations: [
    ProdutosComponent,
    ProdutoInfoComponent,
    LojaComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    LojaRoutingModule
  ],
  exports: [
    ProdutosComponent
  ]
})
export class LojaModule { }
