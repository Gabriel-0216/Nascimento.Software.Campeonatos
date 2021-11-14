using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Application.Servicos.Implementacoes;
using Campeonatos.Dominio.Clubes;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Cadastros.Implementacoes;
using Campeonatos.Infra.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Campeonatos.Infra.Cadastros.Implementacoes.SubDominios;
using Campeonatos.Dominio.Tabela;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICommomDAO<Jogador>, JogadorDAO>();
builder.Services.AddScoped<ICommomDAO<Clube>, ClubeDAO>();

builder.Services.AddScoped<ICommomService<Jogador>, JogadorService>();
builder.Services.AddScoped<ICommomService<Clube>, ClubeService>();

builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<IPartidasDAO, PartidasDAO>();

builder.Services.AddScoped<IFinalizacaoPartidaService, FinalizacaoPartidaService>();
builder.Services.AddScoped<IFinalizacaoPartidaDAO, PartidasFinalDAO>();

builder.Services.AddScoped<ICommomDAO<Amarelos>, AmarelosDAO>();
builder.Services.AddScoped<ICommomDAO<Assistencias>, AssistenciasDAO>();
builder.Services.AddScoped<ICommomDAO<Artilharia>, ArtilhariaDAO>();
builder.Services.AddScoped<ICommomDAO<Vermelhos>, VermelhosDAO>();


builder.Services.AddScoped<ITabelasService, TabelasService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")), ServiceLifetime.Transient);

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
