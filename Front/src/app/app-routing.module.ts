import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LojaComponent } from './loja/loja.component';
import { ProdutoInfoComponent } from './loja/produto-info/produto-info.component';
import { ProdutosComponent } from './loja/produtos/produtos.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'loja', component: LojaComponent},
  {path: 'loja/:id', component: ProdutoInfoComponent},
  {path: 'loja', loadChildren: () => import('./loja/loja.module').then(mod => mod.LojaModule)},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule)},
  {path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
