using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ���������� ������������
builder.Services.AddControllers();

// ���������� Swagger
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
    // ����������� Swagger
    app.UseSwagger();

    // ����������� Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MySwaggerApi v1");
        // ��������� /swagger ��� ����
        // c.RoutePrefix = string.Empty; // ���� ������, ����� ��� ������ �� �����
    });
}

app.UseRouting();

// ����������� �������� �����
app.MapControllers();

app.Run();
