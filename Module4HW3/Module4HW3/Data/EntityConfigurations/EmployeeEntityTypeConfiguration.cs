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

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
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
        }
    }
}