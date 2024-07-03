using ArticuloApi.Api.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Services;
using System.Linq.Expressions;

namespace ArticuloApi.Api.Services;

public class ArticuloService(Contexto contexto) : IApiService<Articulos>
{
	public async Task<List<Articulos>> GetAllAsync()
	{
		return await contexto.Articulos.ToListAsync();
	}

	public async Task<Articulos> GetByIdAsync(int id)
	{
		return (await contexto.Articulos.FindAsync(id))!;
	}

	public async Task<Articulos> CreateAsync(Articulos articulo)
	{
		contexto.Articulos.Add(articulo);

		if (articulo != null)
			articulo.Precio = articulo.Costo + (articulo.Costo * (articulo.Ganancia / 100));

		await contexto.SaveChangesAsync();
		return articulo!;
	}

	public async Task<bool> UpdateAsync(Articulos articulo)
	{
		contexto.Entry(articulo).State = EntityState.Modified;

		if (articulo != null)
			articulo.Precio = articulo.Costo + (articulo.Costo * (articulo.Ganancia / 100));

		return await contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var articulo = await contexto.Articulos.FindAsync(id);
		if (articulo == null)
			return false;

		contexto.Articulos.Remove(articulo);
		return await contexto.SaveChangesAsync() > 0;
	}
}
