using Microsoft.EntityFrameworkCore;
using StoreManager.BLL;
using StoreManager.DAL.Contracts;
using StoreManager.DAL.Infrastructure;
using StoreManager.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//todo: можно попробовать сделать класс конфигурации и разнести
if (builder.Configuration["Storage"] == "db")
{
    builder.Services.AddDbContext<StoreDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<IStoreRepository, DbStoreRepository>();
    builder.Services.AddScoped<IStockRepository, DbStockRepository>();
    builder.Services.AddScoped<IProductRepository, DbProductRepository>();
}
else
{
    builder.Services.AddScoped<IStoreRepository>(_ => new FileStoreRepository("DAL/Data/store.json"));
    builder.Services.AddScoped<IStockRepository>(_ => new FileStockRepository("DAL/Data/stock.json"));
    builder.Services.AddScoped<IProductRepository>(_ => new FileProductRepository("DAL/Data/product.json"));
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
