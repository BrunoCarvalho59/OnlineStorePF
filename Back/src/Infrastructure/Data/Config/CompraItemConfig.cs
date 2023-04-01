using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Compras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{ 
    public class CompraItemConfig : IEntityTypeConfiguration<CompraItem>
    {
        public void Configure(EntityTypeBuilder<CompraItem> builder)
        {
            builder.OwnsOne(i => i.ItemPedido, io => {io.WithOwner();});

            builder.Property(i => i.Preco)
                .HasColumnType("decimal(18,2)");
        }
    }
}