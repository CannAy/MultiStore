using Microsoft.Extensions.Options;
using MultiStore.Catalog.Services.CategoryServices;
using MultiStore.Catalog.Services.ProductDetailDetailServices;
using MultiStore.Catalog.Services.ProductImageServices;
using MultiStore.Catalog.Services.ProductServices;
using MultiStore.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //automapper i�in

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //appsettings'ten configure i�in ald�k.
builder.Services.AddScoped<IDatabaseSettings>(sp =>
    {
        return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value; //DatabaseSettings s�n�f� i�indeki value'lara (tablo isimleri) ula�abilmek i�in.
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
