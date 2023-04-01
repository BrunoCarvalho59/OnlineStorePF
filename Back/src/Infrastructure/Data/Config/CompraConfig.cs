using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Compras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CompraConfig : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.OwnsOne(o => o.MoradaEnvio, a => 
            {
                a.WithOwner();
            });
            builder.Navigation(a => a.MoradaEnvio).IsRequired();
            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (CompraStatus) Enum.Parse(typeof(CompraStatus), o)
                );

            builder.HasMany(o => o.CompraItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}