using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeriaVirtual.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeriaVirtual.Database.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.ImageUrl).IsRequired(false);
            builder.Property(p => p.Timestamp).IsRowVersion();

            builder.HasData(new Product { ProductId = 1, Name = "Papas" });
            builder.HasData(new Product { ProductId = 2, Name = "Manzana" });
            builder.HasData(new Product { ProductId = 3, Name = "Zanahoria" });
            builder.HasData(new Product { ProductId = 4, Name = "Zapallo" });
            builder.HasData(new Product { ProductId = 5, Name = "Frutillas" });
            builder.HasData(new Product { ProductId = 6, Name = "Limón de pica" });


        }
    }
}
