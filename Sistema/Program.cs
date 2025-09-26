using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Sistema.Application.Interfaces;
using Sistema.Application.Services;
using Sistema.Context;
using Sistema.OperacoesConsole;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITipoPermissao, TipoPermissaoService>();
builder.Services.AddScoped<ICargo, CargoServices>();
builder.Services.AddScoped<IDepartamento, DepartamentoService>();
builder.Services.AddScoped<IStatusUsuario, StatusUsuarioService>();

builder.Services.AddScoped<OperacoesConsole>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

using (var scope = app.Services.CreateScope())
{
    var operacoesConsole = scope.ServiceProvider.GetRequiredService<OperacoesConsole>();
    operacoesConsole.Menu();
}

app.Run();
