using AutoMapper;
using MongoDB.Driver;
using MultiStore.Catalog.Dtos.ProductDetailDtos;
using MultiStore.Catalog.Entities;
using MultiStore.Catalog.Settings;

namespace MultiStore.Catalog.Services.ProductDetailDetailServices
{
    public class ProductDetailService  : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _ProductDetailionCollection;
        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings) //ctor
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductDetailionCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName); //bize tablo olarak verecek (GetCollection)
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _ProductDetailionCollection.InsertOneAsync(values);
        }
        public async Task DeleteProductDetailAsync(string id)
        {
            await _ProductDetailionCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }
        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _ProductDetailionCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }
        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _ProductDetailionCollection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);

        }
        public async Task UpdateProductDetailDtoAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _ProductDetailionCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
        }
    }
}
