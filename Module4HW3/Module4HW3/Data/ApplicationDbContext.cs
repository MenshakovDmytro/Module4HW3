using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Module4HW3.Data.Entities;
using Module4HW3.Data.EntityConfigurations;

namespace Module4HW3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<EmployeeEntity> EmployeeEntities { get; set; }
        public DbSet<EmployeeProjectEntity> EmployeeProjectEntities { get; set; }
        public DbSet<OfficeEntity> OfficeEntities { get; set; }
        public DbSet<ProjectEntity> ProjectEntities { get; set; }
        public DbSet<TitleEntity> TitleEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TitleEntityTypeConfiguration());
        }
    }
}