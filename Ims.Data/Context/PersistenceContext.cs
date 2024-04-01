using Ims.Data.Configuration;
using Ims.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ims.Data.Context;

public class PersistenceContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<DeviceAssignment> DeviceAssignments { get; set; }
    
    public PersistenceContext(DbContextOptions<PersistenceContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new DeviceAssignmentConfiguration());
    }
}
