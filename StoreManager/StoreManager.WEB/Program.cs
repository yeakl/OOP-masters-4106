using Microsoft.EntityFrameworkCore;
using StoreManager.BLL.Contracts;
using StoreManager.BLL.Service;
using StoreManager.DAL.Contracts;
using StoreManager.DAL.Infrastructure;
using StoreManager.DAL.Repositories;
using StoreManager.DAL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

if (builder.Configuration["Storage"] == "db")
{
    builder.Services.AddDbContext<StoreDbContext>(options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            sqliteOptions => sqliteOptions.MigrationsAssembly("StoreManager.DAL")));
    builder.Services.AddScoped<IStoreRepository, DbStoreRepository>();
    builder.Services.AddScoped<IStockRepository, DbStockRepository>();
    builder.Services.AddScoped<IProductRepository, DbProductRepository>();
}
else
{
    builder.Services.AddScoped<IFileHandler, JsonFileHandler>();
    builder.Services.AddScoped<IStoreRepository>(_ =>
        new FileStoreRepository("data/store.json", _.GetRequiredService<IFileHandler>()));
    builder.Services.AddScoped<IStockRepository>(_ =>
        new FileStockRepository("data/stock.json", _.GetRequiredService<IFileHandler>()));
    builder.Services.AddScoped<IProductRepository>(_ =>
        new FileProductRepository("data/product.json", _.GetRequiredService<IFileHandler>()));
}

builder.Services.AddScoped<StoreService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<StockService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();