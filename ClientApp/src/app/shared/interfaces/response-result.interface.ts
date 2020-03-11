export interface ResponseResult<T> {
  content: T;
  statusCode: number;
  message: string;
}
