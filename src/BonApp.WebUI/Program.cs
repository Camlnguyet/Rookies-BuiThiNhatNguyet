using BonApp.Infrastructure;
using BonApp.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<ProductService>();

builder.Services.AddHttpClient("ApiClient", client =>
{
    // Cấu hình Base Address của API của bạn
    client.BaseAddress = new Uri("https://localhost:5238/api/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    // Có thể thêm các header mặc định khác nếu cần
});

// (Nếu dùng Session) Cấu hình Session
builder.Services.AddDistributedMemoryCache(); // Lưu session trong memory (chỉ phù hợp cho dev/demo)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian session hết hạn
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();

app.UseAuthentication(); // Thêm dòng này nếu có dùng cơ chế xác thực nào đó phía MVC (ví dụ Cookie)
app.UseAuthorization();

app.MapStaticAssets();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}")
// .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}")
.WithStaticAssets();


app.Run();
