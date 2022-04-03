using FeriaVirtual.Database.Entities;
using FeriaVirtual.Database.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Database
{
    public class FeriaVirtualContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public FeriaVirtualContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("FeriaVirtualDatabase"), b => b.MigrationsAssembly("FeriaVirtual.API"));
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
