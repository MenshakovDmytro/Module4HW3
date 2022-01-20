using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.EntityConfigurations
{
    public class EmployeeProjectEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeProjectEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectEntity> builder)
        {
            builder.ToTable("EmployeeProject");

            builder.HasKey(e => e.EmployeeProjectId);

            builder.Property(e => e.Rate).IsRequired();
            builder.Property(e => e.StartedDate).IsRequired().HasMaxLength(7);
            builder.Property(e => e.EmployeeId).IsRequired();
            builder.Property(e => e.ProjectId).IsRequired();

            builder.HasOne(e => e.EmployeeEntity)
                .WithMany(ep => ep.EmployeeProjectEntities)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.ProjectEntity)
                .WithMany(ep => ep.EmployeeProjectEntities)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}