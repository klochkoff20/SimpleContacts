export interface ListResponse<T> {
  content: T[];
  statusCode: number;
  message: string;
}
