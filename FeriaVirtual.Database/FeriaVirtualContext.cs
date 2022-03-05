using FeriaVirtual.Database.Entities;
using FeriaVirtual.Database.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Database
{
    public class FeriaVirtualContext : DbContext
    {
        public FeriaVirtualContext(DbContextOptions<FeriaVirtualContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
