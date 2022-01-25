using MediatR;
using mediatr_features.Features;
using Microsoft.AspNetCore.Mvc;
using models;

namespace aspnet_core_mediatr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IList<WeatherForecast>> Get()
        {
            var query = new GetListFeatures.Query
            {
                Id = Guid.NewGuid()
            };

            return await this._mediator.Send(query);
        }
    }
}