using BonApp.Domain.Entities;


namespace BonApp.Domain.Interfaces.Service;

public interface IProductService
{
    // Truy vấn linh hoạt từ controller hoặc các service khác
    IQueryable<Product> Query();

    // Lấy danh sách sản phẩm đang còn bán
    Task<IEnumerable<Product>> GetAllActiveAsync();

    // Lấy chi tiết sản phẩm
    Task<Product> GetByIdAsync(int id);

    // Tạo mới sản phẩm
    Task CreateAsync(Product product);

    // Cập nhật sản phẩm
    Task UpdateAsync(Product product);

    // Xóa mềm sản phẩm (IsDeleted = true)
    Task SoftDeleteAsync(int id);
}
