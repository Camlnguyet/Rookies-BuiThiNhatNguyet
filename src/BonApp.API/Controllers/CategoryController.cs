using BonApp.Application.Interfaces;
using BonApp.Domain.Interfaces;
using BonApp.Domain.Interfaces.Service;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository categoryRepository;
    private readonly ICategoryService categoryService;
    private readonly ICsvCategoryImporter csvCategoryImporter;

    public CategoryController(ICategoryService _categoryService, ICategoryRepository _categoryRepository, ICsvCategoryImporter _csvCategoryImporter)
    {
        categoryRepository = _categoryRepository;
        csvCategoryImporter = _csvCategoryImporter;
        categoryService = _categoryService;
    }

    // GET: api/categories
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories = await categoryService.GetAllCategoriesAsync();

        return Ok(categories);
    }

    // POST: api/categories
    [HttpPost]
    public async Task<IActionResult> AddCategories([FromBody] CategoryDto dto)
    {
        var category = await categoryService.CreateCategoryAsync(dto);
        if (category == null)
        {
            return BadRequest("Category name already exists.");
        }
        // await categoryRepository.CreateAsync(categories);
        // await categoryRepository.SaveChangesAsync();
        return Ok(category);
    }

    // GET: api/category/:id
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryByIdAsync(int id)
    {
        var category = await categoryService.GetCategoryByIdAsync(id);
        return Ok(category);
    }

    // POST: api/category/upload-csv
    [HttpPost("upload-csv")]
    public async Task<IActionResult> UploadCsvAsync([FromForm] CsvUploadFile dto)
    {
        if (dto.File == null || dto.File.Length == 0)
            return BadRequest("File is required");

        var categories = await csvCategoryImporter.ParseCsvAsync(dto.File);
        if (categories == null || categories.Count == 0)
            return BadRequest("CSV file is empty or invalid");

        foreach (var category in categories)
        {
            if (await categoryService.IsCategoryExistAsync(category.CategoryName))
            {
                continue;
            }
            Console.WriteLine($"Thêm sản phẩm: {category.CategoryName}");
            await categoryRepository.CreateAsync(category);
        }

        await categoryRepository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategories), new { }, new { Count = categories.Count, Message = "Categories imported successfully" });
    }

    // Hard delete
    // DELETE: api/category/:id
    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoryDto>> DeleteIdCategory(int id)
    {
        var category = await categoryRepository.Categories.FirstOrDefaultAsync(p => p.Id == id);
        if (category == null)
        {
            return BadRequest("Not found");
        }
        categoryRepository.Delete(category);
        await categoryRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategories), new { }, new { category, Message = "Category deleted successfully" });
    }

    // Soft change
    // PATCH: api/category/soft-change/:id
    [HttpPatch("/soft-change/{id}")]
    public async Task<ActionResult<CategoryDto>> UpdateCategory(int id, [FromBody] CategoryDto dto)
    {
        var category = await categoryRepository.Categories.FirstOrDefaultAsync(p => p.Id == id);
        if (category == null)
        {
            return BadRequest("Not found");
        }
        if (await categoryService.IsCategoryExistAsync(dto.Name) && dto.Name != category.CategoryName) return BadRequest("Name after update is existed");
        category.CategoryName = dto.Name;
        category.Description = dto.Description;
        category.UpdatedAt = DateTimeOffset.UtcNow;

        await categoryRepository.SaveChangesAsync();
        // phải tạo dtounable phù hợp -> chỉ cần 1 giá trị biến
        return CreatedAtAction(nameof(GetCategories), new { }, new { category, Message = "Category update successfully" });
    }

    // soft-delete
    // PATCH: api/category/soft-del/:id
    [HttpPatch("/soft-del/{id}")]
    public async Task<ActionResult<CategoryDto>> UnableCategory(int id, [FromBody] StatusCategoryDto dto)
    {
        var category = await categoryRepository.Categories.FirstOrDefaultAsync(p => p.Id == id);
        if (category == null)
        {
            return BadRequest("Not found");
        }
        category.UpdatedAt = DateTimeOffset.UtcNow;
        category.Status = dto.Status;

        await categoryRepository.SaveChangesAsync();
        // phải tạo dtounable phù hợp -> chỉ cần 1 giá trị biến
        return CreatedAtAction(nameof(GetCategories), new { }, new { category, Message = "Category unable successfully" });
    }
    // Tôi suy nghĩ phương pháp xóa category bằng tên không an toàn trong nhiều trường hợp
    // tên t.việt, tên ngôn ngữ khác => quy về xóa id để đảm bảo sự an toàn
    // => Bắt buộc tên category phải unique trong mọi trường hợp

    // Thay đổi toàn bộ thông tin entity 
    // PUT: api/category/:id
    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDto>> UpdateFullCategory(int id, [FromBody] CategoryDto categoryDto)
    {
        if (await categoryService.IsCategoryExistAsync(categoryDto.Name))
        {
            return BadRequest("Name after update is existed.");
        }
        var category = await categoryRepository.Categories.FirstOrDefaultAsync(p => p.Id == id);
        if (category == null)
        {
            return BadRequest("Not found");
        }
        // chưa có giữ nguyên createdat 
        category.CategoryName = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedAt = DateTimeOffset.UtcNow;

        await categoryRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategories), new { }, new { category, Message = "Category updated successfully" });
    }
}
