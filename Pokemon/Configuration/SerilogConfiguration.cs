using Serilog;

namespace Pokemon.Api.Configuration
{
    public static class SerilogConfiguration
    {
        public static IServiceCollection AddSerilog(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            services.AddSingleton<Serilog.ILogger>(logger);
            return services;
        }

        public static IApplicationBuilder EnrichSerilogProperties(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                var traceId = context.TraceIdentifier;
                using (Serilog.Context.LogContext.PushProperty("TraceId", traceId))
                {
                    await next.Invoke();
                }
            });
        }
    }
}
