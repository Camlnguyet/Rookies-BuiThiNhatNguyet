using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces.Repository;

public interface IRoleRepository
{
    IQueryable<Role> Roles { get; }
    IUnitOfWork UnitOfWork { get; }
    void Add(Role role);
    void Update(Role role);
    void Delete(Role role);
    Task SaveChangesAsync();
    Task CreateAsync(Role role);
    Task<IEnumerable<Role>> GetAllAsync();
}
