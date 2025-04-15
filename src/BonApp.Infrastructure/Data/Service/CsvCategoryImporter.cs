using System.Text;
using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;

namespace BonApp.Infrastructure.Data.Service;

public class CsvCategoryImporter : ICsvCategoryImporter
{
    public async Task<List<Category>> ParseCsvAsync(IFormFile file)
    {
        var categories = new List<Category>();
        using (var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
        {
            string? line;
            bool isFirstLine = true;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (isFirstLine)
                {
                    Console.WriteLine("Categor get go" + line);
                    isFirstLine = false;
                    continue;
                }
                string[] parts = line.Split([';']);
                if (parts.Length < 2) continue;

                categories.Add(new Category
                {
                    CategoryName = parts[0].Trim(),
                    Description = parts[1].Trim(),
                    Status = "available",
                    UpdatedAt = DateTimeOffset.UtcNow,
                    CreatedAt = DateTimeOffset.UtcNow,
                });
            }
        }
        return categories;
    }
}

