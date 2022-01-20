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

            builder.Property(o => o.Title).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Location).IsRequired().HasMaxLength(100);
        }
    }
}