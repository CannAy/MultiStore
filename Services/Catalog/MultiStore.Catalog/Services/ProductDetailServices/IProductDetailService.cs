using MultiStore.Catalog.Dtos.ProductDetailDtos;

namespace MultiStore.Catalog.Services.ProductDetailDetailServices
{
    public interface IProductDetailService
    {
		//önce bu interface'i oluşturduk. sonrasında bu interface'i implemente eden ProductDetailService'i oluşturduk.
		Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
