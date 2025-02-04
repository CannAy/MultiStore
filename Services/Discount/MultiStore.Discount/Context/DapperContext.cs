using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiStore.Discount.Entities;
using System.Data;

namespace MultiStore.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration; //IConfiguration appsettings.json dosyasındaki connection stringi almak için
		private readonly string _connectionString; 
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection"); //appsettings.json dosyasındaki connection stringi almak için
		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //protected override void kullanılmasının sebebi DbContext sınıfından türetilen sınıfların bu metodu ezmesi gerektiğidir. //  DapperContext sınıfının DbContext sınıfından türetilmiş bir yapılandırma metodunu özelleştirmesine olanak tanır.
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-36BDD8O\\MSSQL2022;initial Catalog=MultiStoreDiscountDb; integrated Security=true"); 
        }
        public DbSet<Coupon> Coupons { get; set; } //Coupon sınıfı ile Coupons tablosunu eşleştirir.
		public IDbConnection CreateConnection()=> new SqlConnection(_connectionString); //IDbConnection metodu oluşturuldu ve SqlConnection sınıfından bir nesne oluşturuldu.
	}
}
