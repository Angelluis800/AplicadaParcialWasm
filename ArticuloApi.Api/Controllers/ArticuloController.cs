﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticuloApi.Api.DAL;
using Shared.Models;
using ArticuloApi.Api.Services;

namespace ArticuloApi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticulosController(ArticuloService articuloService) : ControllerBase
{
    // GET: api/Articulos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Articulos>>> GetArticulos()
    {
        var articulo = await articuloService.Listar(a => true);

        if (articulo is null)
            return NotFound("No se encontraron artículos.");

        return Ok(articulo);
    }

    // GET: api/Articulos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Articulos>> GetArticulos(int id)
    {
        var articulos = await articuloService.Buscar(id);

        if (articulos is null)
            return NotFound($"No se encontró el artículo con ID {id}.");

        return articulos;
    }

    //GET
    [HttpGet("existe-descripcion")]
    public async Task<ActionResult<bool>> ExisteDescripcion(int id, string descripcion)
    {
        var existe = await articuloService.ExisteDescripcion(id, descripcion);
        return Ok(existe);
    }

    // POST: api/Articulos
    [HttpPost]
    public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos)
    {

        var guardado = await articuloService.Guardar(articulos);

        if (guardado != null)
            return Ok(guardado);

        return NotFound("No se pudo guardar el artículo.");
    }

    // PUT: api/Articulos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArticulos(int id, Articulos articulos)
    {
        if (id != articulos.ArticuloId)
            return BadRequest("El ID del artículo no coincide con el ID de la URL.");

        var modificado = await articuloService.Guardar(articulos);
        if (!modificado)
            return NotFound($"No se pudo actualizar el artículo con ID {id}. Puede que el artículo no exista.");

        return NoContent();
    }

    // DELETE: api/Articulos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticulos(int id)
    {
        var articulos = await articuloService.Eliminar(id);

        if (articulos == null)
            return NotFound($"No se pudo eliminar el artículo con ID {id}. Puede que el artículo no exista.");

        return NoContent();
    }
}
