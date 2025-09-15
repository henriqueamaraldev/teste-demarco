export interface PaginatedResponseDto<T> {
  pageSize: number;
  totalItems: number;
  pageNumber: number;
  totalPages: number;
  items: T[];
}
