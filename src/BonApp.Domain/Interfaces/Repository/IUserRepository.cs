using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IUserRepository
{
    // Lấy entity theo 
    IQueryable<User> Users { get; }
    IUnitOfWork UnitOfWork { get; }
    void Add(User user);
    // Cập nhập entity
    void Update(User user);
    // Xóa entity
    void Delete(User user);
    Task SaveChangesAsync();
    Task<IEnumerable<User>> GetAllAsync();
    Task CreateAsync(User user);
}
