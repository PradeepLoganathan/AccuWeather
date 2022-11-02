namespace AccuWeather.Models
{
    public interface IWeatherRepository
    {
        public void AddWeatherData(WeatherData weatherData);
        public IList<WeatherData> GetAllWeather();
        public WeatherData GetWeatherByID(int ID);
    }
}