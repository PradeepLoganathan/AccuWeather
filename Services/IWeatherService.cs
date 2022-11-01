using AccuWeather.Models;

public interface IWeatherService
{
  public Task<WeatherData> GetWeatherByCity(string City);
    
}