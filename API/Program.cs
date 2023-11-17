using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PostgreSQL.ChainOfResponsibility;
using PostgreSQL.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add database context to the container.
builder.Services
    .AddProjectManagementData("USER ID=postgres;" +
                              "Password=postgres;" +
                              "Server=localhost;" +
                              "Port=5432;" +
                              "Database=pms-db;" +
                              "Integrated Security=true;" +
                              "Pooling=true")
    .AddDataAccess()
    .AddCommands();

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.TagActionsBy(api =>
    {
        if (api.GroupName != null)
        {
            return new[] { api.GroupName };
        }

        if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
        {
            return new[] { controllerActionDescriptor.ControllerName };
        }

        throw new InvalidOperationException("Unable to determine tag for endpoint.");
    });

    options.DocInclusionPredicate((name, api) => true);
});

var app = builder.Build();

var logger = app.Services.GetService<PostgreSQL.ChainOfResponsibility.ILogger>();

logger?.Log("Application builded.", OutputType.Debug);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    logger?.Log("Swagger configured.", OutputType.Debug);
}

app.UseHttpsRedirection();

logger?.Log("Https redirection configured.", OutputType.Debug);

app.UseAuthorization();

logger?.Log("Authorization configured.", OutputType.Debug);

app.MapControllers();

logger?.Log("Controllers mapped.", OutputType.Debug);

app.Run();

logger?.Log("Application started.", OutputType.Info);