using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface ICartDetailRepository
{
    IQueryable<CartDetail> CartsDetail { get; }
    IUnitOfWork UnitOfWork { get; }
    // Thêm entity mới 
    void Add(CartDetail cartDetail);
    // Cập nhập entity
    void Update(CartDetail cartDetail);
    // Xóa entity
    void Delete(CartDetail cartDetail);
    Task SaveChangesAsync();
    Task CreateAsync(CartDetail cartDetail);
    Task<IEnumerable<CartDetail>> GetAllAsync();
}
