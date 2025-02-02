using MultiStore.Catalog.Dtos.CategoryDtos;

namespace MultiStore.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync(); //sen bize ResultCategoryDto tipinde bir liste dön
		Task CreateCategoryAsync(CreateCategoryDto createCategoryDto); //sen bize CreateCategoryDto tipinde bir nesne dön
		Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto); //sen bize UpdateCategoryDto tipinde bir nesne dön
		Task DeleteCategoryAsync(string id); //sen bize string tipinde bir id dön
		Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id); //sen bize GetByIdCategoryDto tipinde id ye göre bir nesne dön

	}
}
