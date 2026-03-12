using LunchLine.API.Middlewares;
using LunchLine.Application;
using LunchLine.Infrastructure;
using LunchLine.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddPersistenceServices(builder.Configuration);


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();