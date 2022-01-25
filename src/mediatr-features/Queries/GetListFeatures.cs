using interfaces;
using MediatR;
using models;

namespace mediatr_features.Queries
{
    public class GetListFeatures
    {
        public class Query : IRequest<IList<WeatherForecast>>
        {
            public Guid Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IList<WeatherForecast>>
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
            public async Task<IList<WeatherForecast>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _mapper.Map(_weatherConditions);
            }
        }
    }
}
