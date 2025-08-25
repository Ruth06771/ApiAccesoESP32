using Microsoft.EntityFrameworkCore;
using ApiAccesoESP32.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configurar DbContext con SQL Server
builder.Services.AddDbContext<AccesoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Habilitar CORS
builder.Services.AddCors();

// ✅ Agregar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Habilitar Swagger en Desarrollo y Producción
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Habilitar CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Middleware para capturar y devolver errores detallados en JSON
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (error != null)
        {
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
            {
                message = error.Error.Message,
                stackTrace = error.Error.StackTrace
            }));
        }
    });
});

app.UseAuthorization();

app.MapControllers();

app.Run();
