using MultiStore.Catalog.Dtos.ProductImageDtos;

namespace MultiStore.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
		//IProductImageService'i ilk interface olarak oluşturduk. Sonrasında bu interface'i implemente eden ProductImageService'i oluşturuyoruz.
		Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
