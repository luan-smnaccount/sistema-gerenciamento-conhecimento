using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoConhecimento.Api;
using SistemaGestaoConhecimento.Dominio;
using SistemaGestaoConhecimento.Infra;

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
app.Run();
