using Pokemon.Api.Configuration;
using Pokemon.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerDocumentation()
    .AddCorsConfiguration()
    .AddIntegrations(builder.Configuration)
    .AddApplicationServices();

var app = builder.Build();

app.UseHttpsRedirection()
    .UseSwaggerDocumentation(app.Environment)
    .UseCorsConfiguration(app.Environment);

app.AddEndpoints();

app.Run();
