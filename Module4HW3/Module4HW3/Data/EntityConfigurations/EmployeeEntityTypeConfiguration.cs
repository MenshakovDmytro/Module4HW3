using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.EntityConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeId).ValueGeneratedNever();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.SecondName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.HiredDate).IsRequired().HasMaxLength(7);
            builder.Property(e => e.DateOfBirth).IsRequired(false);
            builder.Property(e => e.OfficeId).IsRequired();
            builder.Property(e => e.TitleId).IsRequired();

            builder.HasOne(o => o.OfficeEntity)
                .WithMany(e => e.EmployeeEntities)
                .HasForeignKey(o => o.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.TitleEntity)
                .WithMany(e => e.EmployeeEntities)
                .HasForeignKey(t => t.TitleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<EmployeeEntity>()
            {
                new EmployeeEntity() { EmployeeId = 1, FirstName = "Shamika", SecondName = "Johnson", DateOfBirth = new DateTimeOffset(new DateTime(1998, 09, 04)), HiredDate = new DateTimeOffset(new DateTime(2010, 09, 04)), OfficeId = 1, TitleId = 1 },
                new EmployeeEntity() { EmployeeId = 2, FirstName = "Juan", SecondName = "Hernandez", DateOfBirth = null, HiredDate = new DateTimeOffset(new DateTime(2011, 08, 03)), OfficeId = 2, TitleId = 2 },
                new EmployeeEntity() { EmployeeId = 3, FirstName = "Richard", SecondName = "Williamson", DateOfBirth = new DateTimeOffset(new DateTime(1975, 04, 04)), HiredDate = new DateTimeOffset(new DateTime(2007, 01, 12)), OfficeId = 3, TitleId = 3 },
                new EmployeeEntity() { EmployeeId = 4, FirstName = "Misty", SecondName = "Fowler", DateOfBirth = null, HiredDate = new DateTimeOffset(new DateTime(2005, 01, 14)), OfficeId = 4, TitleId = 4 },
                new EmployeeEntity() { EmployeeId = 5, FirstName = "Sean", SecondName = "Johnson", DateOfBirth = null, HiredDate = new DateTimeOffset(new DateTime(2011, 12, 05)), OfficeId = 5, TitleId = 5 }
            });
        }
    }
}