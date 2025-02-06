using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class // T class özelliklerini taşıyan bir nesne olmalıdır.
	{
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id); //id'ye göre bir entity dönecek.
		Task<T> CreateAsync(T entity); //T türünde bir entity alacak ve bu entityi dönecek.
		Task<T> UpdateAsync(T entity); 
        Task<T> DeleteAsync(T Entity); 
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter); //Lambda ifadesi, giriş değeri T ve çıkış değeri bool olan bir fonksiyon alır.
	}
}
