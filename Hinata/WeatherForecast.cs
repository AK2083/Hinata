namespace Hinata
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / (5 / 9));

        public string? Summary { get; set; }
    }
}
