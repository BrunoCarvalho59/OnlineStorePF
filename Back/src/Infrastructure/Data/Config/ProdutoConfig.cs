using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Preco).HasColumnType("decimal(18,2)");
            builder.Property(p => p.FotoUrl).IsRequired();
            builder.HasOne(m => m.ProdutoMarca).WithMany().HasForeignKey(p => p.ProdutoMarcaId); //WithMany - Cada marca pode estar associada a vários produtos
            builder.HasOne(c => c.ProdutoCategoria).WithMany().HasForeignKey(p => p.ProdutoCategoriaId);
        }
    }
}


// Este código é um exemplo de Fluent API, uma técnica usada no Entity Framework Core para configurar as propriedades de um modelo de uma entidade.