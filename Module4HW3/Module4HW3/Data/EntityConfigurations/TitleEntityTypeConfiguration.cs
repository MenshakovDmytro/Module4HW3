using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.EntityConfigurations
{
    public class TitleEntityTypeConfiguration : IEntityTypeConfiguration<TitleEntity>
    {
        public void Configure(EntityTypeBuilder<TitleEntity> builder)
        {
            builder.ToTable("Title");

            builder.HasKey(t => t.TitleId);
            builder.Property(t => t.TitleId).ValueGeneratedNever();

            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);

            builder.HasData(new List<TitleEntity>()
            {
                new TitleEntity() { TitleId = 1, Name = "Title One" },
                new TitleEntity() { TitleId = 2, Name = "Title Two" },
                new TitleEntity() { TitleId = 3, Name = "Title Three" },
                new TitleEntity() { TitleId = 4, Name = "TItle Four" },
                new TitleEntity() { TitleId = 5, Name = "Title Five" },
            });
        }
    }
}