using Ensemblr.Domain.Common;

namespace Ensemblr.Domain.Entities;

public class Group : BaseEntity<Guid>, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Guid OwnerId { get; private set; }

    private Group() { }

    public Group(string name, Guid ownerId, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(null, nameof(name));
        if (ownerId == Guid.Empty) throw new ArgumentException(null, nameof(ownerId));

        this.Name = name;
        this.OwnerId = ownerId;
        this.Description = description ?? string.Empty;
    }

    public void ChangeOwner(Guid newOwnerId)
    {
        if (newOwnerId == Guid.Empty) throw new ArgumentException(null, nameof(newOwnerId));

        this.OwnerId = newOwnerId;
        this.SetUpdatedAt();
    }
}
