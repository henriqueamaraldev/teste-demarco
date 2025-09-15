import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PaginatorModule, PaginatorState } from 'primeng/paginator';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { CreateClienteComponent } from '../../components/create-cliente/create-cliente.component';
import { ClienteModel } from '../../core/models/cliente.model';
import { ClienteFilterDto } from '../../core/services/base/dtos/paginated.request.dto';
import { PaginatedResponseDto } from '../../core/services/base/dtos/paginated.response.dto';
import { ClienteService } from '../../core/services/cliente/cliente.service';

@Component({
  selector: 'app-clientes',
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
    TagModule,
    PaginatorModule
  ],
  templateUrl: './clientes.page.html',
  providers: [DialogService]
})
export class ClientesPageComponent implements OnInit {
  clientes: ClienteModel[] = [];
  loading = false;
  totalRecords = 0;
  pageSize = 10;
  currentPage = 0;
  modalRef: DynamicDialogRef | undefined;

  constructor(
    private readonly clienteService: ClienteService,
    public dialogService: DialogService
  ) { }

  ngOnInit() {
    this.carregarClientes();
  }

  async carregarClientes() {
    try {
      this.loading = true;
      const filters: ClienteFilterDto = {
        pageNumber: this.currentPage + 1,
        pageSize: this.pageSize
      };
      console.log('Carregando clientes com filtros:', filters);
      const response: PaginatedResponseDto<ClienteModel> = await this.clienteService.getClientesPaginados(filters);
      console.log('Resposta recebida:', response);
      this.clientes = response.items;
      this.totalRecords = response.totalItems;
      console.log('Clientes carregados:', this.clientes.length, 'Total:', this.totalRecords);
    } catch (error) {
      console.error('Erro ao carregar clientes:', error);
    } finally {
      this.loading = false;
    }
  }

  onPageChange(event: PaginatorState) {
    this.currentPage = event.page ?? 1;
    this.pageSize = event.rows ?? 10;
    console.log('New page:', this.currentPage, 'New pageSize:', this.pageSize);
    this.carregarClientes();
  }

  async criarNovoCliente() {
    this.modalRef = this.dialogService.open(CreateClienteComponent, {
      closable: true,
      header: "Criar Novo Cliente",
      width: '500px',
      modal: true,
      data: {}
    });

    this.modalRef.onClose.subscribe((novoCliente?: ClienteModel) => {
      if (novoCliente) {
        console.log('Cliente criado:', novoCliente);
        // Recarregar a lista de clientes
        this.carregarClientes();
      }
    });
  }

}
