using BonApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BonApp.Domain.Interfaces.Service;

public interface ICsvProductImporter
{
    Task<List<Product>> ParseCsvAsync(IFormFile file);
}
