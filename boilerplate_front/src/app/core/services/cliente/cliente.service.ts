import { Injectable } from '@angular/core';
import { ClienteModel } from '../../models/cliente.model';
import { BaseService } from '../base/base.service';
import { ClienteFilterDto } from '../base/dtos/paginated.request.dto';
import { PaginatedResponseDto } from '../base/dtos/paginated.response.dto';

@Injectable({
  providedIn: 'root'
})
export class ClienteService extends BaseService {

  constructor() {
    super();
  }

  /**
   * Busca clientes com paginação e filtros
   * @param filters Filtros de paginação e busca
   * @returns Promise<PaginatedResponseDto<ClienteModel>>
   */
  async getClientesPaginados(filters: ClienteFilterDto): Promise<PaginatedResponseDto<ClienteModel>> {
    console.log('ClienteService - Enviando requisição com filtros:', filters);
    const params = {
      pageNumber: filters.pageNumber,
      pageSize: filters.pageSize,
      sortBy: filters.sortBy,
      nome: filters.nome,
      email: filters.email
    };
    console.log('ClienteService - Parâmetros da requisição:', params);
    const result = await this.callApi<PaginatedResponseDto<ClienteModel>>('GET', '/cliente', undefined, undefined, params);
    console.log('ClienteService - Resposta recebida:', result);
    return result;
  }

  /**
   * Cria um novo cliente
   * @param nome Nome do cliente
   * @param email Email do cliente
   * @returns Promise<ClienteModel>
   */
  async criarCliente(nome: string, email: string): Promise<ClienteModel> {
    console.log('ClienteService - Criando cliente:', { nome, email });
    const data = { nome, email };
    const result = await this.callApi<ClienteModel>('POST', '/cliente', data);
    console.log('ClienteService - Cliente criado:', result);
    return result;
  }
}
