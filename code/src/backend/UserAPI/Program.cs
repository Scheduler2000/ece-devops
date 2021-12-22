using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using UsersAPI.Database;
using UsersAPI.Database.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
{
    Uri elasticsearchUri = new(context.Configuration["Elasticsearch:Uri"]);
    ElasticsearchSinkOptions options = new(elasticsearchUri)
    {
        IndexFormat =
            $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
        AutoRegisterTemplate = true,
        NumberOfShards = 2,
        NumberOfReplicas = 1
    };

    configuration.Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(options)
        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
        .ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
{
    Description = "User web api implementation made with Asp.Net 6.0",
    Title = "User Api",
    Version = "v1",
    Contact = new OpenApiContact
    {
        Name = "Tasnim Bennacer",
        Url = new Uri("https://github.com/scheduler2000/")
    }
}));

builder.Services
    .AddSingleton<DapperFactory>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddHealthChecks();

WebApplication app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

/* here the logic related to the verification of all components used/linked to this microservice.
 * here we return true every time but in real case you should not do that. 
 */
app.UseHealthChecks("/health", new HealthCheckOptions {Predicate = registration => true});

app.MapControllers();


app.Run();