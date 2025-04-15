using BonApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BonApp.Domain.Interfaces.Service;

public interface ICsvCategoryImporter
{
    Task<List<Category>> ParseCsvAsync(IFormFile file);
}
