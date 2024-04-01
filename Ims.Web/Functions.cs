using Google.Cloud.Functions.Framework;
using Google.Cloud.Functions.Hosting;

namespace Ims.Web;

[FunctionsStartup(typeof(Startup))]
public class Function : IHttpFunction
{
    public async Task HandleAsync(HttpContext context)
    {
        await context.Response.CompleteAsync();
    }
}
