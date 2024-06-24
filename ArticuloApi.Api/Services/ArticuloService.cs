using ArticuloApi.Api.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Linq.Expressions;

namespace ArticuloApi.Api.Services;

public class ArticuloService(Contexto _contexto)
{
    public async Task<bool> Guardar(Articulos articulo)
    {
        if (!await Existe(articulo.ArticuloId))
            return await Insertar(articulo);
        else
            return await Modificar(articulo);
    }

    private async Task<bool> Existe(int articuloId)
    {
        return await _contexto.Articulos
            .AnyAsync(a => a.ArticuloId == articuloId);
    }

    public async Task<bool> ExisteDescripcion(int id, string descripcion)
    {
        return await _contexto.Articulos.AnyAsync(a => a.ArticuloId == id
        && a.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }

    private async Task<bool> Insertar(Articulos articulo)
    {
        _contexto.Articulos.Add(articulo);
        if (articulo != null)
            articulo.Precio = articulo.Costo + (articulo.Costo * (articulo.Ganancia / 100));

        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Articulos articulo)
    {
        _contexto.Articulos.Update(articulo);
        if (articulo != null)
            articulo.Precio = articulo.Costo + (articulo.Costo * (articulo.Ganancia / 100));

        var modificado = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(articulo).State = EntityState.Detached;
        return modificado;
    }

    public async Task<bool?> Eliminar(int id)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .Where(a => a.ArticuloId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Articulos?> Buscar(int id)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArticuloId == id);
    }

    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
