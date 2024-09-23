using AutoMapper;
using MongoDB.Driver;
using MultiStore.Catalog.Dtos.CategoryDtos;
using MultiStore.Catalog.Entities;

namespace MultiStore.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection; //MongoDb => Table
        private readonly IMapper _mapper;
        public Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryDtoAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
