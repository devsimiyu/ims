using Ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Data;

public class DeviceAssignmentConfiguration : IEntityTypeConfiguration<DeviceAssignment>
{
    public void Configure(EntityTypeBuilder<DeviceAssignment> entity)
    {
        entity.ToTable("device_assignments");
        entity.HasKey(e => e.Id).HasName("id");

        entity
            .Property(e => e.DateAssigned)
            .HasColumnName("date_assigned")
            .IsRequired();

        entity
            .Property(e => e.Status)
            .HasColumnName("status")
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
            .Property(e => e.TicketId)
            .HasColumnName("ticket_id")
            .HasMaxLength(250);

        entity
            .HasOne(e => e.User)
            .WithMany(e => e.DeviceAssignments)
            .HasForeignKey(e => e.UserId)
            .HasConstraintName("device_assignments_user_id_fkey")
            .IsRequired();
        
        entity
            .HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .HasConstraintName("device_assignments_department_id_fkey")
            .IsRequired();
        
        entity
            .HasOne(e => e.Ticket)
            .WithMany()
            .HasForeignKey(e => e.TicketId)
            .HasConstraintName("device_assignments_ticket_id_fkey")
            .IsRequired();
    }
}
