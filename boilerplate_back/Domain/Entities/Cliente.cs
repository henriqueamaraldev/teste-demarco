using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Cliente : IEntity
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime Updated { get; private set; } = DateTime.UtcNow;
        public bool IsDeleted { get; private set; } = false;

        public Cliente() { }

        public Cliente(string nome, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
        }

        public void UpdateTimestamp()
        {
            Updated = DateTime.UtcNow;
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
            UpdateTimestamp();
        }

        public void CreatedTimestamp()
        {
            Created = DateTime.UtcNow;
        }

        public void SetCreatedTimestamp(DateTime created)
        {
            Created = created;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
