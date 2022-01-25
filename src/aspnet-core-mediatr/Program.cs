using interfaces;
using MediatR;
using mediatr_features;
using models;
using services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMapper<IConfiguration, AppConfig>, MapConfiguration>();
builder.Services.AddSingleton<AppConfig>((serviceProvider) =>
{
    return serviceProvider.GetService<IMapper<IConfiguration, AppConfig>>().Map(serviceProvider.GetService<IConfiguration>()).GetAwaiter().GetResult();
});
builder.Services.AddMediatR(Init.GetMediatR());
builder.Services.AddSingleton<IMapper<IList<WeatherCondition>, IList<WeatherForecast>>, MapWeather>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI((options) =>
    {
        var appConfig = app.Services.GetService<AppConfig>();
        options.DocumentTitle = (appConfig != null ? appConfig.AppName : options.DocumentTitle);
    });
}

app.UseCors((s) => s.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
