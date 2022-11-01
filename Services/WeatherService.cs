using AccuWeather.Models;
using Newtonsoft.Json;

namespace AccuWeather.Services;
public class WeatherService: IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string OpenWeatherURL = "https://api.openweathermap.org/data/2.5/weather";
    private readonly string APIKey = "54880c125693096ed43dc2fd0f5ceba4";
    private readonly string UnitType = "metric";

    public WeatherService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;
    

    public async Task<WeatherData> GetWeatherByCity(string City)
    {
        string endpoint = OpenWeatherURL + "?q=" + City + "&units=" + UnitType + "&appid=" + APIKey;
        WeatherData? weatherData = null;

        try
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
           
        
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }

        return weatherData;
    }
}