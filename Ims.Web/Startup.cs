using Google.Cloud.Functions.Hosting;
using Ims.Web.Util.Settings;
using Ims.Data.Context;
using Microsoft.EntityFrameworkCore;
using Ims.Web.Service;

namespace Ims.Web;

public class Startup : FunctionsStartup
{
    private IConfiguration _configuration = null!;

    public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
    {
        _configuration = context.Configuration;

        ConfigureServices(services);
    }

    public override void Configure(WebHostBuilderContext context, IApplicationBuilder app)
    {
        Configure(app, context.HostingEnvironment);
    }

    public override void ConfigureAppConfiguration(WebHostBuilderContext context, IConfigurationBuilder configuration)
    {
        configuration
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();
    }

    /// <summary>
    /// Add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<ConnectionSettings>(_configuration.GetSection("Database"));
        services.Configure<ActiveDirectorySettings>(_configuration.GetSection("ActiveDirectory"));
        services.AddDbContext<PersistenceContext>((sp, options) =>
        {
            var database = sp
                .GetRequiredService<ConnectionSettings>()
                .Database;

            options.UseMySQL(database);
        });
        services.AddScoped<IDeviceService, DeviceService>();
        services.AddHealthChecks();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    /// <summary>
    /// Configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ActiveDirectoryMiddleware>();
        app.UseRouting();
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapControllers();
            endpoint.MapHealthChecks("health-check");
            endpoint
                .MapGet("/", () => "hello world")
                .WithOpenApi();
        });
    }
}
