using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Campeonatos.Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Clube> Clubes { get; set; }
        public DbSet<Partidas> Partidas { get; set; }
        public DbSet<PartidaFinalizacao> PartidaFinalizacao { get; set; }
        public DbSet<Amarelos> Amarelos { get; set; }
        public DbSet<Vermelhos> Vermelhos { get; set; }
        public DbSet<Artilharia> Artilharia { get; set; }
        public DbSet<Assistencias> Assistencias { get; set; }

    }
}
