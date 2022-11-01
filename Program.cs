using AccuWeather.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IWeatherRepository, WeatherRepository> ();
builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();

app.MapDefaultControllerRoute();
app.Run();
