using AutoMapper;
using MongoDB.Driver;
using MultiStore.Catalog.Dtos.CategoryDtos;
using MultiStore.Catalog.Entities;
using MultiStore.Catalog.Settings;
using System.Collections.Generic;

namespace MultiStore.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection; //MongoDb için _categoryCollection => Category tablosu(field)
		private readonly IMapper _mapper; //AutoMapper için _mapper => AutoMapper kütüphanesi

		public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings) //CategoryService sınıfı için Constructor oluşturduk. IDatabaseSettings aracılığıyla ConnStr'ye erişim sağladık.
		{
            var client = new MongoClient(_databaseSettings.ConnectionString); //IDatabase aracılığıyla ConnStr'ye erişim sağladık.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); //GetDatabase ile DatabaseName'e eriştik. 
			_categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName); //_categoryCollection'a Category tablosunu atadık.
			_mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto); //AutoMapper ile createCategoryDto'yu Category'e dönüştürdük.
			await _categoryCollection.InsertOneAsync(value); //InsertOneAsync MongoDB'ye veri eklemek için kullanılır. InsertOneAsync ile MongoDB'ye veri ekledik.
		} 

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync(); //.
            return _mapper.Map<List<ResultCategoryDto>>(values); //AutoMapper ile values'yi ResultCategoryDto'ya dönüştürdük.
		}

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto); //AutoMapper ile updateCategoryDto'yu Category'e dönüştürdük.
			await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values); //FindOneAndReplaceAsync ile MongoDB'de veri güncelledik. o idye sahip olanı bul ve values'teki veri ile değiştir.
		}
    }
}
