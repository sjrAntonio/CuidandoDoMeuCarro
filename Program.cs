using CuidandoDoMeuCarro.BusinessRules;
using CuidandoDoMeuCarro.Data;
using CuidandoDoMeuCarro.Data.IRepository;
using CuidandoDoMeuCarro.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    context => context.UseSqlite(connectionString)
);

/**************************
* Injecao de dependencias *
**************************/
builder.Services.AddScoped<IMotoristaRepository, MotoristaRepository>();

builder.Services.AddScoped<MotoristaRules>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
