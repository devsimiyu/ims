using Ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ims.Data.Configuration;

public class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> entity)
    {
        entity.ToTable("devices");
        entity.HasKey(e => e.Id).HasName("id");
        
        entity
            .Property(e => e.CpuSerial)
            .HasColumnName("cpu_serial")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.CpuTag)
            .HasColumnName("cpu_tag")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.MonitorSerial)
            .HasColumnName("monitor_serial")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.MonitorTag)
            .HasColumnName("monitor_tag")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.OperatingSystem)
            .HasColumnName("operating_system")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.Model)
            .HasColumnName("model")
            .IsRequired()
            .HasMaxLength(250);
        
        entity
            .Property(e => e.Status)
            .HasColumnName("status")
            .IsRequired();
        
        entity
            .Property(e => e.Type)
            .HasColumnName("type")
            .IsRequired();
        
        entity
            .Property(e => e.PurchaseDate)
            .HasColumnName("purchase_date")
            .IsRequired();
        
        entity.HasIndex(e => e.CpuSerial).IsUnique();
        entity.HasIndex(e => e.CpuTag).IsUnique();
        entity.HasIndex(e => e.MonitorSerial).IsUnique();
        entity.HasIndex(e => e.MonitorTag).IsUnique();
    }
}
