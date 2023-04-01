using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Compras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DeliveryMethodConiguration : IEntityTypeConfiguration<MetodoEnvio>
    {
        public void Configure(EntityTypeBuilder<MetodoEnvio> builder)
        {
            builder.Property(d => d.Preco)
                .HasColumnType("decimal(18,2)");
        }
    }
}