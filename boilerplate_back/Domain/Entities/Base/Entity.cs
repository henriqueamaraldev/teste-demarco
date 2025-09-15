namespace Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
            IsDeleted = false;
        }

        public Guid Id { get; protected set; }
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime Updated { get; private set; } = DateTime.UtcNow;
        public bool IsDeleted { get; private set; }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }

        public void UpdateTimestamp()
        {
            Updated = DateTime.UtcNow;
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

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }

}
