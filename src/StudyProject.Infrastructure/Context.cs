﻿using Microsoft.EntityFrameworkCore;
using StudyProject.Infrastructure.Entidades;
using StudyProject.Infrastructure.Map;
using System;

namespace StudyProject.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONN"), o => o.EnableRetryOnFailure(2));
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
