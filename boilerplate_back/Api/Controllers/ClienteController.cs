using Api.Controllers.Base;
using Application.Dtos;
using Application.Services.Clientes;
using Application.Services.Clientes.Dtos;
using Infrastructure.Database.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="dto">Dados do cliente</param>
        /// <returns>Cliente criado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponseDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<ClienteResponseDto>> CriarCliente([FromBody] CriarClienteDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cliente = await _clienteService.CriarClienteAsync(dto.Nome, dto.Email);

                var response = new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Created = cliente.Created,
                    Updated = cliente.Updated
                };

                return CreatedAtAction(nameof(ObterCliente), new { id = cliente.Id }, response);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Lista todos os clientes (sem paginação)
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet("all")]
        [ProducesResponseType(typeof(List<ClienteResponseDto>), 200)]
        public async Task<ActionResult<List<ClienteResponseDto>>> ListarClientes()
        {
            var clientes = await _clienteService.ListarClientesAsync();

            var response = clientes.Select(c => new ClienteResponseDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Created = c.Created,
                Updated = c.Updated
            }).ToList();

            return Ok(response);
        }

        /// <summary>
        /// Lista clientes com paginação
        /// </summary>
        /// <param name="filters">Filtros de paginação e busca</param>
        /// <returns>Lista paginada de clientes</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedQueryResult<ClienteResponseDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PaginatedQueryResult<ClienteResponseDto>>> ListarClientesPaginados([FromQuery] ClienteFilterDto filters)
        {
            var result = await _clienteService.ListarClientesPaginadosAsync(filters);

            var response = new PaginatedQueryResult<ClienteResponseDto>(
                result.Items.Select(c => new ClienteResponseDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email,
                    Created = c.Created,
                    Updated = c.Updated
                }).ToList(),
                result.TotalItems,
                result.PageNumber,
                result.PageSize
            );

            return Ok(response);
        }

        /// <summary>
        /// Obtém um cliente por ID
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>Cliente encontrado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ClienteResponseDto>> ObterCliente(Guid id)
        {
            var clientes = await _clienteService.ListarClientesAsync();
            var cliente = clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            var response = new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Created = cliente.Created,
                Updated = cliente.Updated
            };

            return Ok(response);
        }
    }
}
