using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services;

public interface IClienteService<T>
{
    public Task<List<T>> GetTodoAsync();
    public Task<T> GetPorIdAsync(int id);
    public Task<T> CrearAsync(T articulo);
    public Task<bool> ModificarAsync(int id, T articulo);
    public Task<bool> EliminarAsync(int id);
    public Task<bool> ExisteDescripcionAsync(int id, string descripcion);
}
