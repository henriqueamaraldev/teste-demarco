import { inject } from '@angular/core';
import axios, { AxiosError, AxiosHeaders, AxiosInstance, AxiosRequestConfig } from 'axios';
import { MessageService } from 'primeng/api';
import qs from 'qs';
import { environment } from '../../../../environments/environment';
import { AlertMessage, getServerity, getSummary, isUpgradeRequired } from '../../helpers/alert.helper';
import { ApiError } from './dtos/base-error.response.dto';

export class BaseService {
  private readonly baseUrl: string;
  private readonly httpClient: AxiosInstance;
  private readonly messagesService = inject(MessageService);

  constructor() {
    this.baseUrl = environment.apiUrl;

    this.httpClient = axios.create({
      baseURL: this.baseUrl,
      headers: {
        'Content-Type': 'application/json',
      },
    });


    // Intercepta as respostas das requisições para tratar erros
    this.httpClient.interceptors.response.use(
      response => {
        return response
      },
      (error: AxiosError<ApiError>) => {
        this.handleError(error);
      }
    );
  }

  protected async callApi<T>(method: string, url: string, data?: unknown, headers?: unknown, params?: unknown): Promise<T> {
    const config: AxiosRequestConfig = {
      url, method, headers: headers as AxiosHeaders, data, params, paramsSerializer: params => qs.stringify(params, { arrayFormat: 'repeat' })
    };
    console.log('BaseService - Fazendo requisição:', config);
    const response = await this.httpClient.request<T>(config);
    console.log('BaseService - Resposta HTTP:', response.status, response.data);
    return response.data;
  }

  private handleError(error: AxiosError<ApiError>): void {
    const statusCode = error?.response?.status ?? 500;

    if (typeof error?.response?.data === "string") {
      const message: AlertMessage = {
        severity: getServerity(statusCode),
        summary: getSummary(statusCode),
        detail: error?.response?.data,
        life: 5000,
        key: isUpgradeRequired(statusCode)
      }

      this.messagesService.add(message);
    } else if (Array.isArray(error?.response?.data) && error.response.data.every(item => typeof item === 'string')) {
      const message: AlertMessage = {
        severity: getServerity(statusCode),
        summary: getSummary(statusCode),
        detail: error?.response?.data[0],
        life: 5000,
        key: isUpgradeRequired(statusCode)
      };

      this.messagesService.add(message);
    }
    else {
      const apiFluentValidationMessages = error?.response?.data.errors;

      if (apiFluentValidationMessages) {
        const errorValidations = Object.keys(apiFluentValidationMessages).map(key => apiFluentValidationMessages[key]);
        errorValidations.forEach(errorValidation => {
          errorValidation.forEach(validation => {

            const message: AlertMessage = {
              severity: getServerity(statusCode),
              summary: getSummary(statusCode),
              detail: validation,
              life: 5000,
              key: isUpgradeRequired(statusCode)
            }

            this.messagesService.add(message);
          });
        });
      }
    }
  }

  public getBaseUrl() {
    return this.baseUrl;
  }
}
