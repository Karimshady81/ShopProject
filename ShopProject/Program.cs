using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopProject.App;
using ShopProject.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString
    ("ShopProjectDbContextConnection") ?? throw new InvalidOperationException
    ("Connection string 'ShopProjectDbContextConnection' not found.");

builder.Services.AddDbContext<ShopProjectDbContext>(options =>
    options.UseSqlServer(connectionString)); ;

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ShopProjectDbContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//This will invoke the "GetCart()" passing the service provider "sp" 
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllersWithViews()
                .AddJsonOptions(options => //this tell ASP.NET when serializing to ignore cycles 
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
          .AddInteractiveServerComponents();

builder.Services.AddDbContext<ShopProjectDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ShopProjectDbContextConnection"]);
});

var app = builder.Build();


app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();


if (app.Environment.IsDevelopment())
{
    //This will throw an exception when an error occurs during development and development only, its useful to expose this for the developer
    app.UseDeveloperExceptionPage();
}

//This is a middleware that routes to the pages/views we are going to have
//app.MapDefaultControllerRoute(); //"{controller=Home}/{action=Index}/{id?}"


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAntiforgery();

app.MapRazorPages();

app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

DbInitializer.Seed(app);
app.Run();
