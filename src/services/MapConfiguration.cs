using interfaces;
using Microsoft.Extensions.Configuration;
using models;

namespace services
{
    public class MapConfiguration : IMapper<IConfiguration, AppConfig>
    {
        public async Task<AppConfig> Map(IConfiguration input)
        {
            return await Task.FromResult(new AppConfig
            {
                AppName = input["AppName"]
            });
        }
    }
}
