using System.Collections.Generic;
using System.Linq;
using AccuWeather.Models;

namespace AccuWeather.Models
{
    public class WeatherRepository : IWeatherRepository
    {
        private List<WeatherData> _WeatherList;

        public WeatherRepository()
        {
            _WeatherList = new List<WeatherData>();
        }

        public void AddWeatherData(WeatherData weatherData)
        {
            int index = _WeatherList.FindIndex(x => x.Id == weatherData.Id);
            if(index == -1)
                _WeatherList.Add(weatherData);
            else
            _WeatherList[index] = weatherData;
        }

        public IList<WeatherData> GetAllWeather()
        {
            return _WeatherList;
        }

        public WeatherData GetWeatherByID(int ID) => _WeatherList.FirstOrDefault(w => w.Id == ID);
    }
}