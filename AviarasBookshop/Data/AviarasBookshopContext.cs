using AviarasBookshop.Models;
using Microsoft.EntityFrameworkCore;

namespace AviarasBookshop.Data
{
    public class AviarasBookshopContext : DbContext
    {
        public AviarasBookshopContext(DbContextOptions<AviarasBookshopContext> options) : base(options)
        {
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração para relacionamento N:M entre Autor e Livro
            modelBuilder.Entity<Autor>()
                .HasMany(l => l.Livros)
                .WithMany(a => a.Autores)
                .UsingEntity(ntable => ntable.ToTable("AutorLivro"));

            // Configuração para relacionamento N:M entre Cliente e Livro
            modelBuilder.Entity<Cliente>()
                .HasMany(l => l.Livros)
                .WithMany(c => c.Clientes)
                .UsingEntity(ntable => ntable.ToTable("ClienteLivro"));

            // Configuração para relacionamento N:M entre Cliente e Livro
            modelBuilder.Entity<Pedido>()
            .HasMany(l => l.Livros)
            .WithMany(p => p.Pedidos)
            .UsingEntity(ntable => ntable.ToTable("PedidoLivro"));

            // Configuração para relacionamento 1:N entre Cliente e Pedido
            modelBuilder.Entity<Pedido>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(r => r.ClienteId);
        }
    }
}
