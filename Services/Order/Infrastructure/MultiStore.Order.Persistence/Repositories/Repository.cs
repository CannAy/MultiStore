using MultiShop.Order.Application.Interfaces;
using MultiStore.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiStore.Order.Persistence.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly OrderContext _context;

		public Repository(OrderContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(T entity)
		{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
		}

		public Task<T> DeleteAsync(T Entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<T>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<T> UpdateAsync(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
