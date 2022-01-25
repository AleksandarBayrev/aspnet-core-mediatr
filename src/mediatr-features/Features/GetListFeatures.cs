using interfaces;
using MediatR;
using models;

namespace mediatr_features.Features
{
    public class GetListFeatures
    {
        public class Query : IRequest<WeatherForecastResponse>
        {
            public Guid Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, WeatherForecastResponse>
        {
            private readonly IMapper<IList<WeatherCondition>, IList<WeatherForecast>> _mapper;
            private readonly IList<WeatherCondition> _weatherConditions = new List<WeatherCondition>()
            {
                WeatherCondition.Freezing,
                WeatherCondition.Bracing,
                WeatherCondition.Chilly,
                WeatherCondition.Cool,
                WeatherCondition.Mild,
                WeatherCondition.Warm,
                WeatherCondition.Balmy,
                WeatherCondition.Hot,
                WeatherCondition.Sweltering,
                WeatherCondition.Scorching
            };

            public QueryHandler(IMapper<IList<WeatherCondition>, IList<WeatherForecast>> mapper)
            {
                _mapper = mapper;
            }
            public async Task<WeatherForecastResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(new WeatherForecastResponse
                {
                    WeatherForecast = await _mapper.Map(_weatherConditions),
                    RequestId = request.Id
                });
            }
        }
    }
}
