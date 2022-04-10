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
    internal class PolicyRoleConfiguration : IEntityTypeConfiguration<PolicyRole>
    {
        public void Configure(EntityTypeBuilder<PolicyRole> builder)
        {
            builder.HasKey(pr => new {pr.PolicyId, pr.RoleId});
            builder.HasOne(pr => pr.Role).WithMany(r => r.PolicyRoles).HasForeignKey(pr => pr.RoleId);
            builder.HasOne(pr => pr.Policy).WithMany(p => p.PolicyRoles).HasForeignKey(pr => pr.PolicyId);
            builder.Property(pr => pr.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
        }
    }
}
