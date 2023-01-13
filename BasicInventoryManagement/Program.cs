using BasicInventoryManagement;
using BasicInventoryManagement.Data;
using BusinessLogicLibrary.BusinessLogic.Activities;
using BusinessLogicLibrary.BusinessLogic.Activities.Interfaces;
using BusinessLogicLibrary.BusinessLogic.Inventories;
using BusinessLogicLibrary.BusinessLogic.Inventories.Interfaces;
using BusinessLogicLibrary.BusinessLogic.Products;
using BusinessLogicLibrary.BusinessLogic.Products.Interfaces;
using BusinessLogicLibrary.BusinessLogic.Reports;
using BusinessLogicLibrary.BusinessLogic.Reports.Interfaces;
using BusinessLogicLibrary.Interfaces;
using EFCoreSqlServer;
using InMemoryPlugin;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// configure authorizations
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Department", "Administration"));
    options.AddPolicy("Inventory", policy => policy.RequireClaim("Department", "InventoryManagement", "Administration"));
    options.AddPolicy("Sales", policy => policy.RequireClaim("Department", "Sales", "Administration"));
    options.AddPolicy("Purchasers", policy => policy.RequireClaim("Department", "Purchasing", "Administration"));
    options.AddPolicy("Productions", policy => policy.RequireClaim("Department", "ProductionManagement", "Administration"));
});


var constr = builder.Configuration.GetConnectionString("InventoryManagement");

//Configure EF Core for Identity
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(constr);
});

//Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<AccountDbContext>();


//Configure EF Core for Identity
builder.Services.AddDbContextFactory<DataContext>(options =>
{
    options.UseSqlServer(constr);
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

if (builder.Environment.IsEnvironment("TESTING"))
{
    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

    builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
    builder.Services.AddSingleton<IProductRepository, ProductRepository>();
    builder.Services.AddSingleton<IInventorytransationRepository, InventorytransationRepository>();
    builder.Services.AddSingleton<IProductTransactionRepository, ProductTransactionRepository>();
}
else
{
    builder.Services.AddTransient<IInventoryRepository, InventoryEFCoreRepository>();
    builder.Services.AddTransient<IProductRepository, ProductEFCoreRepository>();
    builder.Services.AddTransient<IInventorytransationRepository, InventoryTransactionEFCoreRepository>();
    builder.Services.AddTransient<IProductTransactionRepository, ProductTransactionEFCoreRepository>();
}

builder.Services.AddTransient<IViewInventoriesByName, ViewInventoriesByName>();
builder.Services.AddTransient<IAddInventory, AddInventory>();
builder.Services.AddTransient<IEditInvetory, EditInvetory>();
builder.Services.AddTransient<IViewInventoryById, ViewInventoryById>();

builder.Services.AddTransient<IViewProductByName, ViewProductByName>();
builder.Services.AddTransient<IAddProduct, AddProduct>();
builder.Services.AddTransient<IViewProductById, ViewProductById>();
builder.Services.AddTransient<IEditProduct, EditProduct>();

builder.Services.AddTransient<IPurchaseInventory, PurchaseInventory>();

builder.Services.AddTransient<IProduceProduct, ProduceProduct>();
builder.Services.AddTransient<ISellProduct, SellProduct>();

builder.Services.AddTransient<ISearchInventoryTransactions, SearchInventoryTransactions>();
builder.Services.AddTransient<ISearchProductTransactions, SearchProductTransactions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
