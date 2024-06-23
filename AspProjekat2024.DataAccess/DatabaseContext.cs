using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.DataAccess
{
    public class DatabaseContext: DbContext
    {
        public readonly string _connectionString;
        public DatabaseContext()
        {
            _connectionString = "Data Source=DESKTOP-PLR5Q1M\\SQLEXPRESS;Initial Catalog=laptopshop;Integrated Security=True;Trust Server Certificate=True";
        }
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                         
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelVersion> ModelVersions { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<ModelVersionSpecification> ModelVersionSpecifications { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCart> UserCarts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs{ get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }


    }
}
