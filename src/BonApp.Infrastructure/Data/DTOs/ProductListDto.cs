namespace BonApp.Infrastructure.Data.DTOs;

// Hiển thị sản phẩm theo danh mục
// Lọc sản phẩm theo tên, loại
// Tìm kiếm, lọc
public class ProductListDto
{
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = default!;
}
