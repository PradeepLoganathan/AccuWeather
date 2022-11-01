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
    public IActionResult Index()
    {
        _weatherService.GetWeatherByCity("Singapore");
        return View(_weatherRepository.GetAllWeather());
    }
}