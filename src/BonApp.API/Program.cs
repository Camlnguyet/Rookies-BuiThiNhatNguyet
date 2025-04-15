using BonApp.Application;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure;
using BonApp.Infrastructure.Data;
using BonApp.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using BonApp.Domain.Interfaces.Service;
using BonApp.Infrastructure.Data.Service;
using BonApp.Application.Interfaces;
using BonApp.Application.Services;
using BonApp.Infrastructure.Data.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddAutoMapper(typeof(OtherMapper));
builder.Services.AddAutoMapper(typeof(ProductMapper));
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // generic
builder.Services.AddScoped<IProductRepository, ProductRepository>();     // cụ thể
builder.Services.AddScoped<IProductService, ProductService>();                  // service xử lý logic
builder.Services.AddScoped<ICsvProductImporter, CsvProductImporter>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICsvCategoryImporter, CsvCategoryImporter>();

// builder.Services.AddInfrastructureServices();
// builder.Services.AddApplication

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();