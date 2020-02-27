import { PagedListContent } from './paged-list-content.interface';

export interface PagedListResponse<T> {
  content: PagedListContent<T>;
  statusCode: number;
  message: string;
}
