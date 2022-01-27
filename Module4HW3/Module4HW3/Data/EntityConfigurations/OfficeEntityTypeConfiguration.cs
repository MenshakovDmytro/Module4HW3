using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.EntityConfigurations
{
    public class OfficeEntityTypeConfiguration : IEntityTypeConfiguration<OfficeEntity>
    {
        public void Configure(EntityTypeBuilder<OfficeEntity> builder)
        {
            builder.ToTable("Office");

            builder.HasKey(o => o.OfficeId);

            builder.Property(o => o.OfficeId).ValueGeneratedNever();
            builder.Property(o => o.Title).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Location).IsRequired().HasMaxLength(100);

            builder.HasData(new List<OfficeEntity>()
            {
                new OfficeEntity() { OfficeId = 1, Location = "Jaipur", Title = "OfficeI" },
                new OfficeEntity() { OfficeId = 2, Location = "Yokohama", Title = "OfficeJ" },
                new OfficeEntity() { OfficeId = 3, Location = "Colombo", Title = "OfficeSL" },
                new OfficeEntity() { OfficeId = 4, Location = "Valletta", Title = "OfficeM" },
                new OfficeEntity() { OfficeId = 5, Location = "Prague", Title = "OfficeCR" },
            });
        }
    }
}