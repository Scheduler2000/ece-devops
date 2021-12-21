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

builder.Services.AddSingleton<DapperFactory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

WebApplication app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();


app.Run();