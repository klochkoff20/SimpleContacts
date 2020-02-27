export interface PagedListContent<T> {
  pageNumber: number;
  pageSize: number;
  totalItems: number;
  items: T[];
}
