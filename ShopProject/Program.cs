using Microsoft.EntityFrameworkCore;
using ShopProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//This will invoke the "GetCart()" passing the service provider "sp" 
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShopProjectDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ShopProjectDbContextConnection"]);
});

var app = builder.Build();


app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    //This will throw an exception when an error occurs during development and development only, its useful to expose this for the developer
    app.UseDeveloperExceptionPage();
}

//This is a middleware that routes to the pages/views we are going to have
app.MapDefaultControllerRoute(); //"{controller=Home}/{action=Index}/{id?}"

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

DbInitializer.Seed(app);
app.Run();
