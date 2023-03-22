import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Produto } from '../shared/models/produto';
import { LojaService } from './loja.service';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.scss']
})
export class LojaComponent implements OnInit{
  produtos: Produto[] = [];

  constructor(private lojaService: LojaService){}

  ngOnInit(): void {
    this.lojaService.getProducts().subscribe({
      next: response => this.produtos = response.data,
      error: error => console.log(error)
    })
  }

}
