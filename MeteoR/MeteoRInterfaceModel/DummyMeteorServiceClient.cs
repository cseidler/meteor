namespace MeteoRInterfaceModel
{
    using System.Threading.Tasks;

    using MeteoRClient;

    public class DummyMeteorServiceClient : IMeteorServiceClient
    {
        public Task<WeatherInfo> GetWeatherInfo(int id, long timestamp)
        {
            return
                Task.Factory.StartNew(
                    () =>
                    new WeatherInfo()
                        {
                            CityName = "Dummy Town",
                            Humidity = 20,
                            Id = 0,
                            Pressure = 87663.4545456,
                            Temperature = 20.7343255,
                            Timestamp = 1403703707
                        });
        }

        public Task PostWeatherInfo(WeatherInfo weatherInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}