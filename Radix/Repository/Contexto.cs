using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Loja> Loja { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Adquirente> Adquirente { get; set; }
        public DbSet<LojaAdquirente> LojaAdquirente { get; set; }

        //TODO: Esse mapeamento não está funcionando devido a bug no .Net Core
        //Por conta disso carregarei os objetos manualmente
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
