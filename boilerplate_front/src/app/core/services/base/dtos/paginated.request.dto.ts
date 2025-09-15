export class PaginatedRequestDto {
  pageNumber = 1;
  pageSize = 10;
  sortBy?: string;

  constructor(pageNumber = 1, pageSize = 10, sortBy?: string) {
    this.pageNumber = pageNumber;
    this.pageSize = pageSize;
    this.sortBy = sortBy;
  }
}

export interface ClienteFilterDto extends PaginatedRequestDto {
  nome?: string;
  email?: string;
}
