using Ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Data.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> entity)
    {
        entity.ToTable("departments");
        entity.HasKey(e => e.Id).HasName("id");
        
        entity
            .Property(e => e.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(250);

        entity.HasIndex(e => e.Name).IsUnique();
    }
}
