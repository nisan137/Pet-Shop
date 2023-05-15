using Microsoft.EntityFrameworkCore;
using PetShopApp.Data;
using PetShopApp.Models;
using PetShopApp.Repositories;
using PetShopApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PetShopContext>(options =>
    options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("Defaulte")));
builder.Services.AddScoped<IRepository<Animal>, AnimalRepository>();
builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IPictureReader, PictureReader>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();

if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/Index");
}

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
