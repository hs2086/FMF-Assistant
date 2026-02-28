using API.Extensions;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // <-- required

builder.Services.ConfigureJwtTokenProvider(builder.Configuration);
builder.Services.ConfigureTimeSpanTokenProvider();
builder.Services.ConfigureSwagger();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIApplicationDbContext();

builder.Services.ConfigureIIdentityRoleService();
builder.Services.ConfigureIIdentityAuthService();

builder.Services.ConfigureMediatR();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureIPipelineBehavior();

builder.Services.ConfigureCors();

builder.Services.ConfigureExceptionHandler();

builder.Services.ConfigureEmailService();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await AdminSeeder.SeedAsync(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();          // Enable Swagger generator
    app.UseSwaggerUI();        // Enable Swagger UI at /swagger
}

app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();
app.UseCors("AllowAll");
app.MapGet("/", () => "Hello World!");

app.Run();
