/*
http://json2ts.com/ Este site permite converter um objeto em json para TS
*/

export interface Produto {
  id: number;
  nome: string;
  descricao: string;
  preco: number;
  fotoUrl: string;
  produtoCategoria: string;
  produtoMarca: string;
}
