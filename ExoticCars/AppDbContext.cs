using ExoticCars.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoticCars
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Model>(entity =>
            {
                entity
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

                entity
                .HasIndex(p => p.Name)
                .IsUnique();

                entity
                .Property(p => p.Price)
                .HasPrecision(4);

            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

                entity
                .HasIndex(p => p.Name)
                .IsUnique();

                entity
                .HasMany(p => p.Models)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Brand>  Brands { get; set; }
        public DbSet<Model>  Models { get; set; }
    }
}
