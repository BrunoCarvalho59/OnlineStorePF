import { Morada } from "./user"

export interface OrderToCreate {
  basketId: string;
  metodoEnvioId: number;
  moradaEnvio: Morada;
}

export interface Order {
  id: number
  clienteEmail: string
  compraData: string
  moradaEnvio: Morada
  metodoEnvio: string
  precoEnvio: number
  compraItems: CompraItem[]
  subTotal: number
  total: number
  status: string
}

export interface CompraItem {
  produtoId: number
  produtoNome: string
  fotoUrl: string
  preco: number
  quantidade: number
}
