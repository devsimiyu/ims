using System.DirectoryServices;
using System.Runtime.Versioning;
using Ims.Web.Util.Settings;
using Microsoft.AspNetCore.Mvc;

namespace Ims.Web;

public record JwtPayload(string Email);

public class ActiveDirectoryMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ActiveDirectorySettings _configuration;

    public ActiveDirectoryMiddleware(RequestDelegate next, ActiveDirectorySettings configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    [SupportedOSPlatform("Windows")]
    public async Task InvokeAsync(HttpContext context)
    {
        // read email from jwt payload
        var email = "jdoe@example.org";
        var activeDirectory = new DirectoryEntry
        {
            Path = _configuration.DomainPath,
            Username = _configuration.Username,
            Password = _configuration.Password,
            AuthenticationType = AuthenticationTypes.Secure,
        };
        var search = new DirectorySearcher(activeDirectory)
        {
            Filter = $"(&(objectCategory=person)(objectClass=user)(mail={email}))",
            Tombstone = false,
        };
        var result = search.FindAll();

        if (result.Count == 1)
        {
            await _next(context);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            var error = new ProblemDetails
            {
                Title = "Unauthorized",
                Detail = $"User with email {email} does not exist",
                Status = context.Response.StatusCode
            };

            await context.Response.WriteAsJsonAsync(error);
        }
    }
}
