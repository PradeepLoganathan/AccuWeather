using AccuWeather.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AccuWeather.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherRepository weatherRepository, IWeatherService weatherService)
        {
            _weatherRepository = weatherRepository;
            _weatherService = weatherService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CityViewModel cityViewModel)
        {
            return View();
        }

        //WeatherData weather = await _weatherService.GetWeatherByCity("Singapore");
        //    return View(weather);
    }
}
