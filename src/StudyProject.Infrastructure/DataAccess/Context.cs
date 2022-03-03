using Microsoft.EntityFrameworkCore;
using StudyProject.Infrastructure.DataAccess.Entidades;
using StudyProject.Infrastructure.DataAccess.Map;
using System;
using System.Collections.Generic;

namespace StudyProject.Infrastructure.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "public");
                });
            }
            else
                optionsBuilder.UseInMemoryDatabase("CustomerInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
