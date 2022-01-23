using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.EntityConfigurations
{
    public class ClientEntityTypeConfigurator : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(c => c.ClientId);

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(c => c.DateOfBirth).IsRequired(false).HasMaxLength(50);
            builder.Property(c => c.Gender).IsRequired().HasMaxLength(1);

            builder.HasData(new List<ClientEntity>()
            {
                new ClientEntity() { ClientId = 1, FirstName = "Shamika", LastName = "Johnson", Email = "ShamikaFJohnson@armyspy.com", PhoneNumber = "804-837-7518", DateOfBirth = new DateTimeOffset(new DateTime(1998, 09, 04)), Gender = "F" },
                new ClientEntity() { ClientId = 2, FirstName = "Juan", LastName = "Hernandez", Email = "JuanRHernandez@jourrapide.com", PhoneNumber = "916-663-8311", DateOfBirth = null, Gender = "M" },
                new ClientEntity() { ClientId = 3, FirstName = "Richard", LastName = "Williamson", Email = "RichardMWilliamson@jourrapide.com", PhoneNumber = "808-955-6175", DateOfBirth = new DateTimeOffset(new DateTime(1975, 04, 04)), Gender = "M" },
                new ClientEntity() { ClientId = 4, FirstName = "Misty", LastName = "Fowler", Email = "MistyMFowler@armyspy.com", PhoneNumber = "252-467-3244", DateOfBirth = null, Gender = "F" },
                new ClientEntity() { ClientId = 5, FirstName = "Sean", LastName = "Johnson", Email = "SeanTJohnson@rhyta.com", PhoneNumber = "540-605-5503", DateOfBirth = null, Gender = "M" }
            });
        }
    }
}