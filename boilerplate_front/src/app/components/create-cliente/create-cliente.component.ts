import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { InputTextModule } from 'primeng/inputtext';
import { MessageModule } from 'primeng/message';
import { ClienteModel } from '../../core/models/cliente.model';
import { ClienteService } from '../../core/services/cliente/cliente.service';

@Component({
  selector: 'app-create-cliente',
  templateUrl: './create-cliente.component.html',
  imports: [
    CommonModule,
    FormsModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    MessageModule
  ]
})
export class CreateClienteComponent {

  nome = '';
  email = '';
  loading = false;
  errorMessage = '';

  constructor(
    private readonly clienteService: ClienteService,
    public dialogRef: DynamicDialogRef,
    private readonly config: DynamicDialogConfig
  ) { }

  async criarCliente() {
    if (!this.nome.trim() || !this.email.trim()) {
      this.errorMessage = 'Nome e email são obrigatórios';
      return;
    }

    if (!this.isValidEmail(this.email)) {
      this.errorMessage = 'Email deve ter um formato válido';
      return;
    }

    try {
      this.loading = true;
      this.errorMessage = '';

      const novoCliente = await this.clienteService.criarCliente(this.nome.trim(), this.email.trim());

      this.close(novoCliente);
    } catch (error) {
      console.error('Erro ao criar cliente:', error);
      this.errorMessage = 'Erro ao criar cliente. Tente novamente.';
    } finally {
      this.loading = false;
    }
  }

  private isValidEmail(email: string): boolean {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }

  close(cliente?: ClienteModel) {
    this.dialogRef.close(cliente);
  }

  cancelar() {
    this.close();
  }
}
