using AplicadaParcialWasm.Client.Pages;
using AplicadaParcialWasm.Client.Services;
using AplicadaParcialWasm.Components;
using Shared.Models;
using Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(a => new HttpClient
{
    BaseAddress = new Uri((builder.Configuration.GetSection("Url")!.Value)!)
});

builder.Services.AddScoped<IClienteService<Articulos>, ArticuloService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AplicadaParcialWasm.Client._Imports).Assembly);

app.Run();
