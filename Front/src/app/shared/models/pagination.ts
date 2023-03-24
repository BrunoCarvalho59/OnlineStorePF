import { Produto } from "./produto";

export interface Pagination<T> {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: T;
}
