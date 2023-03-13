import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'ITShop';

  constructor(private http: HttpClient)  {}

  /* O método ngOnIt é chamado antes do Html*/
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/produtos').subscribe({
      
    })
  }
}
