using interfaces;
using models;

namespace services
{
    public class MapWeather : IMapper<IList<WeatherCondition>, IList<WeatherForecast>>
    {
        public async Task<IList<WeatherForecast>> Map(IList<WeatherCondition> input)
        {
            return await Task.FromResult(Enumerable.Range(1, 25).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = input[Random.Shared.Next(input.Count)].ToString()
            }).ToList());
        }
    }
}