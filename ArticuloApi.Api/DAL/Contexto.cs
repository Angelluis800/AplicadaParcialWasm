using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;

namespace ArticuloApi.Api.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Articulos> Articulos { get; set; }
}
