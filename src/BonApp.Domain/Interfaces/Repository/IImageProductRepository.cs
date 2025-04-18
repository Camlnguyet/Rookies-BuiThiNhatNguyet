using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces.Repository;

public interface IImageProductRepository
{
    IQueryable<ImageProduct> ImageProducts { get; }
    IUnitOfWork UnitOfWork { get; }
    void Add(ImageProduct imageProduct);
    void Update(ImageProduct imageProduct);
    void Delete(ImageProduct imageProduct);
    Task SaveChangesAsync();
    Task CreateAsync(ImageProduct imageProduct);
    Task<IEnumerable<ImageProduct>> GetAllAsync();
}
