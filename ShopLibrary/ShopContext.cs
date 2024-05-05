using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class ShopContext:DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build(); optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                        .HasOne(i => i.Category)
                        .WithMany(c => c.Items)
                        .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Supplier)
                .WithMany(s => s.Items)
                .HasForeignKey(i => i.SupplierId);
        }

    }
}
