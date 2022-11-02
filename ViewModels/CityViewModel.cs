using System.ComponentModel.DataAnnotations;

namespace AccuWeather.ViewModels
{
    public class CityViewModel
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? City { get; set; }
    }
}
