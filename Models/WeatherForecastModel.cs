namespace WeatherForecast.Web.Api.Models
{
    public class WeatherForecastModel
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
        public string? AllWords { get; set; }
        public string? SingleWord { get; set; }
        public string? SortedWords { get; set; }
    }
}