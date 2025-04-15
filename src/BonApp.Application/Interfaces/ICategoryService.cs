using BonApp.Domain.Entities;
using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Application.Interfaces;

public interface ICategoryService
{
    Task<bool> IsCategoryExistAsync(string name);
    Task<Category> CreateCategoryAsync(CategoryDto categoryDto);
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
}

