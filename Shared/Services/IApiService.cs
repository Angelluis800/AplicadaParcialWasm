using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
	public interface IApiService<T>
	{
		public Task<List<T>> GetAllAsync();
		public Task<T> GetByIdAsync(int id);
		public Task<T> CreateAsync(T articulo);
		public Task<bool> UpdateAsync(T articulo);
		public Task<bool> DeleteAsync(int id);
	}
}
