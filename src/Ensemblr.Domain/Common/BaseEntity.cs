namespace Ensemblr.Domain.Common;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; protected set; } = default!;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public void SetUpdatedAt()
    {
        this.UpdatedAt = DateTime.UtcNow;
    }
}
