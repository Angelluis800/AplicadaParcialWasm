using ArticuloApi.Api.DAL;
using ArticuloApi.Api.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectando ConnectionStrings
var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlite(ConStr));
//Inyectando Servicios
builder.Services.AddScoped<IApiService<Articulos>, ArticuloService>();
//Inyectando Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
