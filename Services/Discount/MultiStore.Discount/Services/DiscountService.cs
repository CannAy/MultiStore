using Dapper;
using MultiStore.Discount.Context;
using MultiStore.Discount.Dtos;

namespace MultiStore.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context; //DapperContext sınıfından _context adında bir nesne oluşturuldu.

		public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto) //Dapper üzerinden
        {
            string query = "insert into Coupons(Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)"; //satırın açıklaması, insert into'nun anlamı Coupons tablosuna veri eklemek. values ile de hangi kolonlara veri ekleneceği belirtilir. bu satırda query ile Coupons tablosuna Code, Rate, IsActive, ValidDate kolonlarına veri eklenmesi sağlanır.
			var parameters = new DynamicParameters(); //DynamicParameters anlamı , parametrelerin dinamik olarak oluşturulmasını sağlar.
			parameters.Add("@code", createCouponDto.Code); //parameters.Add ile parametreler eklenir.
			parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection()) //using kullanmamızın sebebi connection'ı kullanıp işimiz bittiğinde bellekten silinmesini sağlamak.
			{
                await connection.ExecuteAsync(query, parameters); //query'yi parametreleriyle beraber çalıştıracak. ExecuteAsync metodunun anlamı ise query'yi çalıştırırken asenkron bir şekilde çalıştırılmasını sağlar.
			}
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId"; // "" içindeki ifade Coupons tablosundan CouponId'si belirtilen id'ye eşit olan satırı siler.
			var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query); //QueryAsync metodu ile query çalıştırılır ve geriye dönüş değeri olarak ResultDiscountCouponDto tipinde bir liste döner.
				return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters); //QueryFirstOrDefaultAsync metodunun anlamı ise query'yi çalıştırırken asenkron bir şekilde çalıştırılmasını sağlar ve geriye dönüş değeri olarak GetByIdDiscountCouponDto tipinde bir nesne döner. FirstOrDefault metodu ile de sadece bir tane nesne döner.
				return values;
            }

        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code = @code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); //query'yi parametreleriyle beraber çalıştıracak.
            }
        }
    }
}
