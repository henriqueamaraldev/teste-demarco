export type ApiError = FluentValidatorApiErrorResponse | ServiceExceptionApiErrorResponse;

export interface FluentValidatorApiErrorResponse {
  errors: Record<string, string[]>;
}

export type ServiceExceptionApiErrorResponse = string;
