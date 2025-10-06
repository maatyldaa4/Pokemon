using Pokemon.Api.Configuration;
using Pokemon.Application.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerDocumentation()
    .AddCorsConfiguration()
    .AddSerilog()
    .AddIntegrations(builder.Configuration)
    .AddApplicationServices();

var app = builder.Build();

app.UseHttpsRedirection()
    .UseSwaggerDocumentation(app.Environment)
    .UseCorsConfiguration(app.Environment)
    .EnrichSerilogProperties();

app.AddEndpoints();

app.Run();
