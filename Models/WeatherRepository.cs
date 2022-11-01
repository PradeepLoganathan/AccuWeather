using System.Collections.Generic;
using System.Linq;
using AccuWeather.Models;

public class WeatherRepository : IWeatherRepository
{
    private List<WeatherData> _WeatherList; 

    public WeatherRepository()
    {
        _WeatherList = new List<WeatherData>();
    }

    public void AddWeatherData(WeatherData weatherData)
    {
        _WeatherList.Add(weatherData);
    }

    public IList<WeatherData> GetAllWeather()
    {
        return _WeatherList;
    }

    public WeatherData GetWeatherByID(int ID)
    {
        return _WeatherList.FirstOrDefault( w => w.Id == ID);
    }
}