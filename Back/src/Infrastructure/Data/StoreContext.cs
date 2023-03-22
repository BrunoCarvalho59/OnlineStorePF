using System.Reflection;
using Core.Models;
using Core.Models.Basket;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) //É especificado o tipo das options por haver mais do que um DbContext
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCategoria> Categorias { get; set; }
        public DbSet<ProdutoMarca> Marcas { get; set; }
        public DbSet<BasketCliente> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Este método é chamado quando o modelo é criado pela primeira vez no banco de dados, e permite personalizar como as classes e propriedades das entidades são mapeadas para as tabelas e colunas do banco de dados.
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}