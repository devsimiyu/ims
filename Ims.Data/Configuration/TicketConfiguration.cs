using Ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Data.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> entity)
    {
        entity.ToTable("tickets");
        entity.HasKey(e => e.Id).HasName("id");
        
        entity
            .Property(e => e.Status)
            .HasColumnName("status")
            .IsRequired();

        entity
            .Property(e => e.Type)
            .HasColumnName("type")
            .IsRequired();
        
        entity
            .Property(e => e.Note)
            .HasColumnName("note");

        entity
            .Property(e => e.UserId)
            .HasColumnName("user_id")
            .HasMaxLength(250);
        
        entity
            .Property(e => e.DepartmentId)
            .HasColumnName("department_id")
            .HasMaxLength(250);

        entity
            .HasOne(e => e.User)
            .WithMany(e => e.Tickets)
            .HasForeignKey(e => e.UserId)
            .HasConstraintName("tickets_user_id_fkey")
            .IsRequired();
        
        entity
            .HasOne(e => e.Department)
            .WithMany(e => e.Tickets)
            .HasForeignKey(e => e.UserId)
            .HasConstraintName("tickets_department_id_fkey")
            .IsRequired();
    }
}
