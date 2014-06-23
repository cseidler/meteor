namespace MeteoRClient
{
    using System.Threading.Tasks;

    using MeteoRInterfaceModel;

    public interface IMeteorServiceClient
    {
        Task<WeatherInfo> GetWeatherInfo(int id, long timestamp);
    }
}