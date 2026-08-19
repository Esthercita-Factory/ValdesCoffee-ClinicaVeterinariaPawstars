using ClinicaVeterinariaPawStars.Application.Interfaces;
using ClinicaVeterinariaPawStars.Application.Services;
using ClinicaVeterinariaPawStars.Domain.Interfaces;
using ClinicaVeterinariaPawStars.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Infraestructura: implementación concreta de persistencia (en memoria por ahora).
builder.Services.AddSingleton<IPetRepository, InMemoryPetRepository>();

// Aplicación: casos de uso / lógica de negocio.
builder.Services.AddScoped<IPetService, PetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Necesario para que los controladores con enrutamiento por atributos (como PetsController) respondan.
app.MapControllers();

app.Run();