namespace BonApp.Domain.Entities;

public class Role : BaseEntity
{
    public string RoleName { get; set; } = default!;
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
