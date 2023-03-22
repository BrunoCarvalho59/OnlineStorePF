import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'ITShop';

  constructor()  {}

  /* O método ngOnIt é chamado antes do Html*/
  ngOnInit(): void {
  }
}
