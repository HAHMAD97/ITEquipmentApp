using Microsoft.EntityFrameworkCore;
using ITEquipmentBorrowApp.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FastEquipmentContext>(opts =>
{
    opts.UseSqlite(
    builder.Configuration["ConnectionStrings:FastEquipmentDb"]);
});
builder.Services.AddScoped<IEquipmentRepository, EFEquipmentRepository>();
builder.Services.AddScoped<IRequestRepository, EFRequestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


SeedData.EnsurePopulated(app);
app.Run();
