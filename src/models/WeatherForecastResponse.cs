using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class WeatherForecastResponse
    {
        public IList<WeatherForecast> WeatherForecast { get; set; }
        public Guid RequestId { get; set; }
    }
}
