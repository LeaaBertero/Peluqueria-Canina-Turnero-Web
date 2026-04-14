using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.Server.Repositorio;
using PeluCaninaWeb.Server.Util;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region codigo para ignorar ciclos
//-----------------------------------------------------------------------------
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//-----------------------------------------------------------------------------
#endregion


#region Client
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region conexion string con la base de datos
builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));
#endregion

#region AutioMapper
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
#endregion

#region Inyección de dependencias de la interfaz IRepositorio
builder.Services.AddScoped<IMascotaRepositorio, MascotaRepositorio>();
builder.Services.AddScoped<IPromocionRepositorio, PromocionRepositorio>();
builder.Services.AddScoped<IServicioRepositorio, ServicioRepositorio>();
builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Blazor
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
#endregion


app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
