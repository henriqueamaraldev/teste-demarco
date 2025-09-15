using Application.Services.Clientes.Dtos;
using Domain.Entities;
using Infrastructure.Database.Pagination;

namespace Application.Services.Clientes
{
    public interface IClienteService
    {
        Task<Cliente> CriarClienteAsync(string nome, string email);
        Task<List<Cliente>> ListarClientesAsync();
        Task<PaginatedQueryResult<Cliente>> ListarClientesPaginadosAsync(ClienteFilterDto filters);
        Task<bool> EmailExisteAsync(string email);
    }
}
