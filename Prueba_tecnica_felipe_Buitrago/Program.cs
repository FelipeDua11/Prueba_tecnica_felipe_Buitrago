using System;
using Microsoft.EntityFrameworkCore;
using Prueba_tecnica_felipe_Buitrago.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Se cre una variable para la cadena de conexi�n
var connectionString = builder.Configuration.GetConnectionString("Connection");
//Registrar el servicio para la conexion
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
