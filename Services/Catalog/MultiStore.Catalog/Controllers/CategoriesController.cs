using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiStore.Catalog.Dtos.CategoryDtos;
using MultiStore.Catalog.Services.CategoryServices;

namespace MultiStore.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService; //ICategoryService tipinde bir nesne oluşturduk

		public CategoriesController(ICategoryService categoryService) //CategoryService'i enjekte ettik
		{
            _categoryService = categoryService;
        }

        [HttpGet] //HttpGet attribute'ü ile CategoryList metodu get isteğine açıldı
		public async Task<IActionResult> CategoryList() //CategoryList metodu async olarak tanımlandı
		{
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")] // {id} ile id'ye göre get isteği açıldı
		public async Task<IActionResult> GetCategoryById(string id)
        {
            var values = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(values);
        }

        [HttpPost] //HttpPost attribute'ü kullanmamızın sebebi create işlemi yapmamız
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto) //CreateCategoryDto tipinde createCategoryDto parametresini alıyoruz. IActionResult tipinde bir metot oluşturduk. bunun sebebi ise metotun sonucunda bir mesaj döndürmek istememiz.
		{
            await _categoryService.CreateCategoryAsync(createCategoryDto); //await ile asenkron bir şekilde CreateCategoryAsync metotunu çağırdık
			return Ok("Kategori başarıyla eklendi");
        }

        [HttpDelete] //HttpDelete attribute'ü ile delete işlemi yapmamızı sağladık
		public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi");
        }

        [HttpPut] //HttpPut attribute'ü kullanmamızın sebebi update işlemi yapmamız.
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi");
        }
    }
}
