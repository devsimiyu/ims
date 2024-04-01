using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ims.Data.Context;

public class PersistenceContextDesignTimeFactory : IDesignTimeDbContextFactory<PersistenceContext>
{
    public PersistenceContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        var options = new DbContextOptionsBuilder<PersistenceContext>()
            .UseMySQL(configuration.GetConnectionString("Database"))
            .Options;
        
        return new PersistenceContext(options);
    }
}
