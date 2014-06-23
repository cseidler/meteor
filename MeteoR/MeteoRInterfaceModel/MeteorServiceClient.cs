namespace MeteoRInterfaceModel
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using MeteoRClient;

    public class MeteorServiceClient : IMeteorServiceClient
    {
        private const string ServiceUri = "http://localhost:3074/api/weatherinfo";

        public async Task<WeatherInfo> GetWeatherInfo(int id, long timestamp)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(string.Format("{0}id={1}&timestamp={2}", ServiceUri, id, timestamp)).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<WeatherInfo>().ConfigureAwait(false);
            }
        }
    }
}