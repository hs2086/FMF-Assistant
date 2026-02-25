using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureMediatR();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureIPipelineBehavior();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
