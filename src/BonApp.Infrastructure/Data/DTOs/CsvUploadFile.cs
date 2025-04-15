namespace BonApp.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Http;

public class CsvUploadFile
{
    public IFormFile File { get; set; } = default!;
}
