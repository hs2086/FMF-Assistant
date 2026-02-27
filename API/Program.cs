using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // <-- required
builder.Services.AddSwaggerGen();           // <-- add Swagger

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

app.UseExceptionHandler();
app.MapControllers();
app.UseCors("AllowAll");
app.MapGet("/", () => "Hello World!");

app.Run();
