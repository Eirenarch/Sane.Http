using Sane.Http.HttpResponseExceptions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseHttpResponseExceptions();

app.UseAuthorization();

app.MapControllers();

app.Run();
