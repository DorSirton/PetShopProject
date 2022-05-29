using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Context;
using PetShop.Data.Repositories.Classes;
using PetShop.Data.Repositories.Interfaces;
using PetShop.Service.Classes;
using PetShop.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PetShopDataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("PetShopDataConnectionString")));
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddDbContext<AutenticationContext>(options => options.UseSqlite("Data Source=c:\\temp\\user.db"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AutenticationContext>();

builder.Services.AddControllersWithViews();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
