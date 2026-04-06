using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.Server.Repositorio;
using PeluCaninaWeb.Server.Util;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<ITurnoServicioRepositorio, TurnoServicioRepositorio>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
