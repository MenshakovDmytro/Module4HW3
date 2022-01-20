using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.EntityConfigurations
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.ToTable("Project");

            builder.HasKey(p => p.ProjectId);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnType("money");
            builder.Property(o => o.StartedDate).IsRequired().HasMaxLength(7);
        }
    }
}