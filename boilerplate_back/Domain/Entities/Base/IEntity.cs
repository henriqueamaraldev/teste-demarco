namespace Domain.Entities.Base
{
    public interface IEntity
    {
        public Guid Id { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public bool IsDeleted { get; }

        public void MarkAsDeleted();
        public void UpdateTimestamp();
        public void CreatedTimestamp();
        public void SetCreatedTimestamp(DateTime created);
        public void SetId(Guid id);
    }
}
