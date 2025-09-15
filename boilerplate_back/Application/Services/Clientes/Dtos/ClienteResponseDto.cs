namespace Application.Services.Clientes.Dtos
{
    public class ClienteResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
