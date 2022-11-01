using AccuWeather.Models;
using Microsoft.AspNetCore.Mvc;
namespace AccuWeather.Controllers;

public class WeatherController:Controller
{
    private readonly IWeatherRepository _weatherRepository;
    private readonly IWeatherService    _weatherService;

    public WeatherController(IWeatherRepository weatherRepository, IWeatherService weatherService)
    {
        _weatherRepository = weatherRepository;
        _weatherService    = weatherService;
    }
    public async Task<IActionResult> Index()
    {
        WeatherData weather = await _weatherService.GetWeatherByCity("Singapore");
        return View(weather);
    }
}