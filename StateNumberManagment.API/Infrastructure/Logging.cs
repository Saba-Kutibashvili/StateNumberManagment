using Microsoft.VisualBasic;
using Serilog;
using Serilog.Events;

namespace StateNumberManagment.API.Infrastructure
{
    public static class Logging
    {
        public static void AddLogging(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            builder.Host.UseSerilog();
        }
    }
}
