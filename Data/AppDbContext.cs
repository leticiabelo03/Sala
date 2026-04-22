using Microsoft.EntityFrameworkCore;
using Sala.Model;

namespace Sala.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CategoriaChamado> CategoriaChamado { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ComentarioChamado> ComentarioChamado { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<ItemOrdemServico> ItemOrdemServico { get; set; }
        public DbSet<LogAcesso> logAcesso { get; set; }
        public DbSet<LogAuditoria> LogAuditoria { get; set; }
        public DbSet<Notificacao> Notificacao { get; set; }
        public DbSet<OrdemServico> OrdemServico { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Sla> Sla { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama o base apenas UMA vez
            base.OnModelCreating(modelBuilder);

            // USUÁRIO
            modelBuilder.Entity<Usuario>()
                .Property(u => u.PerfilUsuario)
                .HasConversion<string>();

            // FATURA
            modelBuilder.Entity<Fatura>()
                .Property(u => u.Status)
                .HasConversion<string>();

            // CHAMADO
            modelBuilder.Entity<Chamado>()
                .Property(u => u.Status)
                .HasConversion<string>();

            // 🔹 ADICIONANDO A PRIORIDADE NO CHAMADO
            // Não vai "dentro" do Status, é uma configuração separada para a nova propriedade
            modelBuilder.Entity<Chamado>()
                .Property(u => u.PrioridadeChamado)
                .HasConversion<string>();

            // PAGAMENTO
            modelBuilder.Entity<Pagamento>()
                .Property(u => u.Metodo)
                .HasConversion<string>();

            // ORDEM DE SERVIÇO
            modelBuilder.Entity<OrdemServico>()
                .Property(u => u.Status)
                .HasConversion<string>();
        }

    }
}
