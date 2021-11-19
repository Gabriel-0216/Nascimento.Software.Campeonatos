using Campeonatos.Application.Servicos.Contratos;
using Campeonatos.Application.Servicos.Implementacoes;
using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;
using Campeonatos.Infra.Cadastros.Contratos;
using Campeonatos.Infra.Cadastros.Implementacoes;
using Campeonatos.Infra.Cadastros.Implementacoes.SubDominios;
using Campeonatos.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nascimento.Software.Campeonatos.Api.Configuration;
using System.Text;

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

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")), ServiceLifetime.Transient);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        RequireExpirationTime = false,
    };
});


builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
