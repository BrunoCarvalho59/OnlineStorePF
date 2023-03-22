import { Produto } from "./produto";

export interface Pagination<T> {
  paginaIndex: number;
  paginaSize: number;
  count: number;
  data: T;
}
