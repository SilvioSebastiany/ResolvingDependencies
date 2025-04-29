using ResolvingDependencies.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

// Caso precise do serviço em outro lugar, como no Program.cs
// ou em um middleware, você pode usar o CreateScope para criar um escopo
using (var scope = app.Services.CreateScope())
{
    var service = scope
        .ServiceProvider
        .GetRequiredService<IWeatherService>();
    service.Get();
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();
