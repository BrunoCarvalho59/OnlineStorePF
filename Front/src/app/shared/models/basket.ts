import * as cuid from "cuid";

export interface BasketItem {
    id: number;
    produtoNome: string;
    preco: number;
    quantidade: number;
    pictureUrl: string;
    marca: string;
    categoria: string;
}

 export interface Basket {
    id: string;
    items: BasketItem[];
}

export class Basket implements Basket {
    id = cuid();
    items: BasketItem[] = [];
}

export interface BasketTotals {
    shipping: number;
    subtotal: number;
    total: number;
}
