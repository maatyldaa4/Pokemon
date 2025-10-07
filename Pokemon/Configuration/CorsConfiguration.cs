namespace Pokemon.Api.Configuration
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });

                options.AddPolicy("FrontendOnly", policy =>
                {
                    policy
                        .WithOrigins("https://finalfrontendwebsite.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app, IHostEnvironment environment)
        {

            if (environment.IsDevelopment()) 
            {
                app.UseCors("Development");
            }
            else 
            {
                app.UseCors("AllowAll");
            }
                
            return app;
        }
    }
}
