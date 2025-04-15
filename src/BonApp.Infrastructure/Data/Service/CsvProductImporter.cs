using System;
using System.Globalization;
using System.Text;
using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;

namespace BonApp.Infrastructure.Data.Service;

public class CsvProductImporter : ICsvProductImporter
{
    public async Task<List<Product>> ParseCsvAsync(IFormFile file)
    {
        var products = new List<Product>();
        using (var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
        {
            Console.WriteLine($"File length: {file.Length}");
            string? line;
            bool isFirstLine = true;

            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (isFirstLine)
                {
                    Console.WriteLine("Header: " + line); // <-- log dòng đầu tiên
                    isFirstLine = false;
                    continue;
                }
                string[] parts = line.Split([';']);

                if (parts.Length < 5) continue;

                var name = parts[0].Trim();

                var productDescription = parts[1].Trim();

                if (!decimal.TryParse(parts[2], out var price)) continue;

                DateTimeOffset createdAt = DateTimeOffset.UtcNow;
                if (parts.Length >= 3)
                {
                    DateTimeOffset.TryParseExact(
                        parts[3],
                        new[] { "d/M/yy", "dd/MM/yyyy", "yyyy-MM-dd" },
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal,
                        out createdAt
                    );
                }

                if (!int.TryParse(parts[4], out var dateUse)) continue;

                products.Add(new Product
                {
                    ProductName = name,
                    ProductDescription = productDescription,
                    CategoryId = 1,
                    Price = price,
                    DateUse = dateUse,
                    Status = "avaliable",
                    UpdatedAt = DateTimeOffset.UtcNow,
                    CreatedAt = createdAt
                });
                // Console.WriteLine(products);
            }
        }

        // query thuan cho add nhieu san pham cungf luc
        // test performance cho case 1000 product 
        // su dung benchmark
        return products;
    }

}