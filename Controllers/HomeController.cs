using AccuWeather.Models;
using AccuWeather.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AccuWeather.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherRepository _weatherRepository;
        private readonly IWeatherService _weatherService;

        public HomeController(ILogger<HomeController> logger, IWeatherRepository weatherRepository, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherRepository = weatherRepository;
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("City")] CityViewModel cityViewModel)
        {
            if (ModelState.IsValid)
            {
                WeatherData weather = await _weatherService.GetWeatherByCity(cityViewModel.City);
                if (weather != null)
                    _weatherRepository.AddWeatherData(weather);
                var SavedWeather = _weatherRepository.GetAllWeather();
                ViewBag.Weathers = SavedWeather;
                return View();
             
            }
            else
            {
                var SavedWeather = _weatherRepository.GetAllWeather();
                ViewBag.Weathers = SavedWeather;
                return View();
            }
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}