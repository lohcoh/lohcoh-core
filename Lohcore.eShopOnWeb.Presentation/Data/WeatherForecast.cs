using System;
using System.ComponentModel.DataAnnotations;

namespace Lohcode.eShopOnWeb.Presentation.Data
{
    public class WeatherForecast
    {
        [Display(
            Name = "Date", 
            Order = 1, 
            Prompt = "Enter Date", 
            Description = "Date")]
        public DateTime Date { get; set; }

        [Display(
            Name = "Temperature(C)", 
            Order = 2, 
            Prompt = "Enter Temperature(C)", 
            Description = "Temperature - Celsius")]
        public int TemperatureC { get; set; }

        [Required]
        [Display(
            Name = "Temperature(F)", 
            Order = 3, 
            Prompt = "Enter Temperature(F)", 
            Description = "Temperature - Fahrenheit")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Display(
            Name = "Summary", 
            Order = 4, 
            Prompt = "Enter Summary", 
            Description = "Summary")]
        public string Summary { get; set; }
    }
}
