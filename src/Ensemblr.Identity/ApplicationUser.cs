using Ensemblr.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Ensemblr.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? DisplayName { get; set; }

    public ICollection<Membership> Memberships { get; set; } = [];
}
