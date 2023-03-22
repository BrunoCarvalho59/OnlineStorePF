import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { RegistoComponent } from './registo/registo.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'registo', component: RegistoComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
