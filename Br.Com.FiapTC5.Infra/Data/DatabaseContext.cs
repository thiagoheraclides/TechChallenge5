using Br.Com.FiapTC5.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.FiapTC5.Infra.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Ativo> Ativos { get; set; }

        public DbSet<Portifolio> Portifolios { get; set; }

        public DbSet<Transacao> Transacoes { get; set; }

        public DbSet<TipoAtivo> TiposAtivo { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
