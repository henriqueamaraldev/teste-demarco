using Api.Middlewares;
using Application.Config;
using Infrastructure.Config;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDB Configuration
builder.Services.AddMongoConfig(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Clientes API", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Api.xml"));
});

// Services Dependency Injections
builder.Services.AddServicesDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clientes API v1");
        c.RoutePrefix = string.Empty; // Para acessar o Swagger diretamente na raiz
    });
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowAll");

// Middlewares
app.UseMiddleware<CustomExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
