using ClientMongoApp.Application.Client.Handlers.CommandHandlers;
using ClientMongoApp.Core.Entities;
using ClientMongoApp.Infrastructure.Services;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var databaseConnectionString = Environment.GetEnvironmentVariable("DATABASECONNECTIONSTRING");
var mongoDatabaseName = Environment.GetEnvironmentVariable("DATABASENAME");

// Build Custom Configuration
var configuration = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>()
    {
        ["ConnectionString"] = databaseConnectionString, //http:
        ["DatabaseName"] = mongoDatabaseName // dbName:
    }).Build();

// Add services to the container.
builder.Services.Configure<AppSettings>(configuration);

// Add services Singleton
builder.Services.AddSingleton<ClientService>();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Swagger Doc
var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ClientMongoApp API",
        Description = "Servicio web encargado de manejar los clientes de BS"
    });

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

builder.Services.AddMediatR(typeof(CreateClientHandler).Assembly);

builder.Services.AddMemoryCache();

var app = builder.Build();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapGet("/", () => "ClientMongoApp.WebApi");

app.MapControllers();

app.Run();