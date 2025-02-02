using Microsoft.Extensions.Options;
using MultiStore.Catalog.Services.CategoryServices;
using MultiStore.Catalog.Services.ProductDetailDetailServices;
using MultiStore.Catalog.Services.ProductImageServices;
using MultiStore.Catalog.Services.ProductServices;
using MultiStore.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>(); //ICategoryService'yi gördüðümüzde CategoryService'yi çaðýr.
		//Scoped, Singleton ve Transient arasýndaki farklar:
		//Scoped, bir istemciye özgü bir hizmet oluþturur ve istemci isteði sona erdiðinde hizmeti yok eder.
		//Singleton, uygulama boyunca bir hizmet oluþturur ve uygulama sona erdiðinde hizmeti yok eder.
		//Transient, her istemci isteðinde yeni bir hizmet oluþturur ve istemci isteði sona erdiðinde hizmeti yok eder.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapper'ý kullanabilmek için. Assembly.GetExecutingAssembly() ile mevcut assembly'i alýyoruz.

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //appsettings'ten configure için aldýk. GetSection ile DatabaseSettings'i alýyoruz.
builder.Services.AddScoped<IDatabaseSettings>(sp =>
    {
        return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value; //DatabaseSettings sýnýfý içindeki value'lara (tablo isimleri) ulaþabilmek için.
    }); //burada sp dediðimiz service provider, IOptions ile appsettings'ten aldýðýmýz DatabaseSettings'i alýyoruz. Value ile de içindeki tablo isimlerine ulaþýyoruz.

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
