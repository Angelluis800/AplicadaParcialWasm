using AplicadaParcialWasm.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.Models;
using Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Inyectando HttpClient
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:7028/") 
});

builder.Services.AddScoped<IClienteService<Articulos>, ArticuloService>();

await builder.Build().RunAsync();
