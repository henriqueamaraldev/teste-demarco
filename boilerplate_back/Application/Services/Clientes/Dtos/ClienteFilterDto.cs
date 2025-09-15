using Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Application.Services.Clientes.Dtos
{
    public class ClienteFilterDto : PaginatedQueryDto
    {
        [StringLength(100)]
        public string? Nome { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; } = string.Empty;
    }
}
