using Ensemblr.Domain.Common;

namespace Ensemblr.Domain.Entities;

public class Membership : BaseEntity<Guid>
{
    public Guid UserId { get; private set; }
    public Guid GroupId { get; private set; }
    public DateTime JoinedAt { get; private set; }
    public bool IsAdmin { get; private set; }

    private Membership() { }

    public Membership(Guid userId, Guid groupId, bool isAdmin)
    {
        if (userId == Guid.Empty) throw new ArgumentException(null, nameof(userId));
        if (groupId == Guid.Empty) throw new ArgumentException(null, nameof(groupId));

        this.UserId = userId;
        this.GroupId = groupId;
        this.JoinedAt = DateTime.UtcNow;
        this.IsAdmin = isAdmin;
    }

    public void PromoteToAdmin()
    {
        this.IsAdmin = true;
    }
}
