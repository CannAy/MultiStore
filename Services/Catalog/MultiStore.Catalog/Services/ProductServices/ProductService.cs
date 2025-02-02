using AutoMapper;
using MongoDB.Driver;
using MultiStore.Catalog.Dtos.CategoryDtos;
using MultiStore.Catalog.Dtos.ProductDtos;
using MultiStore.Catalog.Entities;
using MultiStore.Catalog.Settings;

namespace MultiStore.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection; //<Product> Product entitysinin collection'ini alir
		public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings) //IDatabaseSettings _databaseSettings ile MongoDB ayarlarini alir
		{
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName); //GetCollection<Product> Product entitysinin collection'ini alir
			_mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto); //createProductDto'yu Product entitysinin map'ine cevirir
			await _productCollection.InsertOneAsync(values); //Product entitysinin collection'ina ekler (tabloya ekler)
		}
        public async Task DeleteProductAsync(string id) 
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id); //Product entitysinin collection'indan id'si eslesen veriyi siler
		}
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }
        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);

        }
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values); //Product entitysinin collection'indan id'si eslesen veriyi gunceller. values'teki veriyi gunceller.
		}
    }
}
