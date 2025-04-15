var builder = WebApplication.CreateBuilder(args);

// CORS engedélyezése
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseCors("AllowAll"); // CORS aktiválása
app.Urls.Add("http://localhost:8080");


app.UseAuthorization();
app.MapControllers();

app.Run();
