using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using King.Environment.Shell;
using King.Hosting;

namespace King.DeferredTasks
{
    /// <summary>
    /// Executes any deferred tasks when the request is terminated.
    /// </summary>
    public class DeferredTaskMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IShellHost _KingHost;

        public DeferredTaskMiddleware(RequestDelegate next, IShellHost KingHost)
        {
            _next = next;
            _KingHost = KingHost;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next.Invoke(httpContext);

            // Register the shell settings as a custom feature.
            var shellSettings = httpContext.Features.Get<ShellSettings>();

            // We only serve the next request if the tenant has been resolved.
            if (shellSettings != null)
            {
                var shellContext = _KingHost.GetOrCreateShellContext(shellSettings);

                using (var scope = shellContext.CreateServiceScope())
                {
                    var deferredTaskEngine = scope.ServiceProvider.GetService<IDeferredTaskEngine>();

                    if (deferredTaskEngine != null && deferredTaskEngine.HasPendingTasks)
                    {
                        var context = new DeferredTaskContext(scope.ServiceProvider);
                        await deferredTaskEngine.ExecuteTasksAsync(context);
                    }
                }
            }
        }
    }
}
