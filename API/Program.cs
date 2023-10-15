using PostgreSQL.Data;
using PostgreSQL.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add database context to the container.
builder.Services.
    AddProjectManagementData("USER ID=postgres;" +
                             "Password=postgres;" +
                             "Server=localhost;" +
                             "Port=5432;" +
                             "Database=pms-db;" +
                             "Integrated Security=true;" +
                             "Pooling=true");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
