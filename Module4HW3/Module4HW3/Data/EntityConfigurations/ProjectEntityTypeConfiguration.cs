using System;
using System.Collections.Generic;
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

            builder.HasData(new List<ProjectEntity>()
            {
                new ProjectEntity() { ProjectId = 1, ClientId = 1, Name = "ProjectOne", Budget = 5000, StartedDate = new DateTime(2015, 09, 04) },
                new ProjectEntity() { ProjectId = 2, ClientId = 2, Name = "ProjectTwo", Budget = 15000, StartedDate = new DateTime(2013, 10, 01) },
                new ProjectEntity() { ProjectId = 3, ClientId = 3, Name = "ProjectThree", Budget = 7500, StartedDate = new DateTime(2019, 01, 15) },
                new ProjectEntity() { ProjectId = 4, ClientId = 4, Name = "ProjectFour", Budget = 6000, StartedDate = new DateTime(2019, 05, 23) },
                new ProjectEntity() { ProjectId = 5, ClientId = 5, Name = "ProjectFive", Budget = 50000, StartedDate = new DateTime(2010, 06, 01) }
            });

            builder.HasOne(c => c.ClientEntity)
                .WithMany(p => p.ProjectEntities)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}