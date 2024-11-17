using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавление контроллеров
builder.Services.AddControllers();

// Добавление Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MySwaggerApi",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Подключение Swagger
    app.UseSwagger();

    // Подключение Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MySwaggerApi v1");
        // Оставляем /swagger как путь
        // c.RoutePrefix = string.Empty; // Если хочешь, чтобы был доступ по корню
    });
}

app.UseRouting();

// Подключение конечных точек
app.MapControllers();

app.Run();
