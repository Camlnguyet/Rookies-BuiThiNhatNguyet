using AutoMapper;
using BonApp.Domain.Entities;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using BonApp.Application.Interfaces;
using BonApp.Infrastructure.Data;
using BonApp.Domain.Interfaces;

namespace BonApp.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _mapper = mapper;
    }

    public async Task<bool> IsCategoryExistAsync(string name)
    {
        return await _categoryRepository.Categories.AnyAsync(c => c.CategoryName.ToLower().Trim() == name.ToLower().Trim());
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.Categories.ToListAsync();
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.Categories.FirstOrDefaultAsync(p => p.Id == id);

        return category == null ? null : _mapper.Map<CategoryDto>(category);
    }
    public async Task<Category?> CreateCategoryAsync(CategoryDto dto)
    {
        if (await IsCategoryExistAsync(dto.Name))
        {
            return null;
        }

        var category = new Category
        {
            CategoryName = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        await _categoryRepository.CreateAsync(category);
        await _categoryRepository.UnitOfWork.SaveChangesAsync();

        Console.WriteLine($"Category ID: {category.Id}");
        return category;
    }


}