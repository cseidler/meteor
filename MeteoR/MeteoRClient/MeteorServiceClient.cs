namespace MeteoRClient
{
    using System.IO;
    using System.Net.Http;

    using System.Threading.Tasks;

    using MeteoRInterfaceModel;

    public class MeteorServiceClient : IMeteorServiceClient
    {
        private const string ServiceUri = "http://localhost:3074/api/weatherinfo";

        public async Task<WeatherInfo> GetWeatherInfo(int id, long timestamp)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(Path.Combine(ServiceUri, string.Format("id={0}&timestamp={1}", id, timestamp))).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<WeatherInfo>().ConfigureAwait(false);
            }
        }
    }
}