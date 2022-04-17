using FeriaVirtual.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Database.EntitiesConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.RoleId);
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Description).IsRequired(false);
            builder.Property(r => r.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);

            builder.HasData(new Role{ RoleId = -1, Name = "Admin", Description = "Administrator of the system"} );
            builder.HasData(new Role { RoleId = -2, Name = "Client", Description = "Client" });
            builder.HasData(new Role { RoleId = -3, Name = "Executive" });
        }
    }
}
