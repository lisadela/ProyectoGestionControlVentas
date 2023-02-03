using Microsoft.EntityFrameworkCore;
using ProyectoGestionControlVentas.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<VentasAsesoresContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddCors(options =>{
    options.AddPolicy("NuevaPolitica",app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
//app.UseStaticFiles();

//app.UseRouting();
app.UseCors("NuevaPolitica");
app.UseAuthorization();

app.MapControllers();
//app.MapRazorPages();

app.Run();
