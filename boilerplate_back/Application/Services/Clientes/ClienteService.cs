using Application.Services.Clientes.Dtos;
using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Database.Pagination;
using MongoDB.Driver;

namespace Application.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly MongoDbContext _context;

        public ClienteService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CriarClienteAsync(string nome, string email)
        {
            // Verificar se o email já existe
            if (await EmailExisteAsync(email))
            {
                throw new InvalidOperationException("Email já está em uso.");
            }

            var cliente = new Cliente(nome, email);
            await _context.Clientes.InsertOneAsync(cliente);

            // Registrar log
            var log = new Log("Cliente cadastrado", cliente.Id);
            await _context.Logs.InsertOneAsync(log);

            return cliente;
        }

        public async Task<List<Cliente>> ListarClientesAsync()
        {
            return await _context.Clientes.Find(_ => true).ToListAsync();
        }

        public async Task<PaginatedQueryResult<Cliente>> ListarClientesPaginadosAsync(ClienteFilterDto filters)
        {
            var filterBuilder = Builders<Cliente>.Filter;
            var filtersList = new List<FilterDefinition<Cliente>>();

            // Aplicar filtros se fornecidos
            if (!string.IsNullOrEmpty(filters.Nome))
            {
                filtersList.Add(filterBuilder.Regex(c => c.Nome, new MongoDB.Bson.BsonRegularExpression(filters.Nome, "i")));
            }

            if (!string.IsNullOrEmpty(filters.Email))
            {
                filtersList.Add(filterBuilder.Regex(c => c.Email, new MongoDB.Bson.BsonRegularExpression(filters.Email, "i")));
            }

            // Combinar filtros
            var combinedFilter = filtersList.Count > 0
                ? filterBuilder.And(filtersList)
                : filterBuilder.Empty;

            var query = _context.Clientes.Find(combinedFilter);
            var totalCount = await query.CountDocumentsAsync();

            var clientes = await query
                .Skip((filters.PageNumber - 1) * filters.PageSize)
                .Limit(filters.PageSize)
                .ToListAsync();

            return new PaginatedQueryResult<Cliente>(clientes, (int)totalCount, filters.PageNumber, filters.PageSize);
        }

        public async Task<bool> EmailExisteAsync(string email)
        {
            var cliente = await _context.Clientes.Find(c => c.Email == email).FirstOrDefaultAsync();
            return cliente != null;
        }
    }
}
