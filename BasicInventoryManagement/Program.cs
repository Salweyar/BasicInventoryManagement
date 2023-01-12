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
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var constr = builder.Configuration.GetConnectionString("InventoryManagement");
//Configure EF Core for Identity
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(constr);
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IViewInventoriesByName, ViewInventoriesByName>();
builder.Services.AddTransient<IAddInventory, AddInventory>();
builder.Services.AddTransient<IEditInvetory, EditInvetory>();
builder.Services.AddTransient<IViewInventoryById, ViewInventoryById>();

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IViewProductByName, ViewProductByName>();
builder.Services.AddTransient<IAddProduct, AddProduct>();
builder.Services.AddTransient<IViewProductById, ViewProductById>();
builder.Services.AddTransient<IEditProduct, EditProduct>();

builder.Services.AddSingleton<IInventorytransationRepository, InventorytransationRepository>();
builder.Services.AddTransient<IPurchaseInventory, PurchaseInventory>();

builder.Services.AddSingleton<IProductTransactionRepository, ProductTransactionRepository>();
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
