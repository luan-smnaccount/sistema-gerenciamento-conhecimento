using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoConhecimento.Api;
using SistemaGestaoConhecimento.Api.Services;
using SistemaGestaoConhecimento.Dominio;
using SistemaGestaoConhecimento.Dominio.Interfaces;
using SistemaGestaoConhecimento.Infra;
using SistemaGestaoConhecimento.Infra.Data.EntidadesConnection;
using SistemaGestaoConhecimento.Infra.Data.InterfacesConnection;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICargo, CargoService>();
builder.Services.AddScoped<IDepartamento, DepartamentoService>();
builder.Services.AddScoped<IUsuario, UsuarioService>();
builder.Services.AddScoped<IComentario, ComentarioService>();

builder.Services.AddScoped<IConnection, SqlServerDatabaseConnection>();

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var connection = serviceProvider.GetRequiredService<IConnection>();
    var config = serviceProvider.GetRequiredService<IConfiguration>();
    connection.ConfigureConnection(options, config);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.Run();
