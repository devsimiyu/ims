using Ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("users");
        entity.HasKey(e => e.Id).HasName("id");
        
        entity
            .Property(e => e.FirstName)
            .HasColumnName("first_name")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.LastName)
            .HasColumnName("last_name")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.Password)
            .HasColumnName("password")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.Role)
            .HasColumnName("user_role")
            .IsRequired();
        
        entity
            .Property(e => e.DepartmentId)
            .HasColumnName("department_id")
            .HasMaxLength(250);

        entity
            .HasOne(e => e.Department)
            .WithMany(e => e.Users)
            .HasForeignKey(e => e.DepartmentId)
            .HasConstraintName("users_department_id_fkey")
            .IsRequired();

        entity
            .HasIndex(e => e.Username)
            .HasDatabaseName("users_username_idx")
            .IsUnique();
    }
}
