import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LojaComponent } from './loja.component';
import { ProdutoInfoComponent } from './produto-info/produto-info.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', component: LojaComponent},
  {path: ':id', component: ProdutoInfoComponent},

]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class LojaRoutingModule { }
