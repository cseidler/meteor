﻿namespace MeteoRInterfaceModel
{
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;

    using MeteoRClient;

    public class MeteorServiceClient : IMeteorServiceClient
    {
        private const string ServiceUri = "http://192.168.1.31:3074/api/weatherinfo";

        public async Task<WeatherInfo> GetWeatherInfo(int id, long timestamp)
        {
            var uri = string.Format("{0}/?id={1}&timestamp={2}", ServiceUri, id, timestamp);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<WeatherInfo>().ConfigureAwait(false);
            }
        }

        public async Task PostWeatherInfo(WeatherInfo weatherInfo)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(ServiceUri, weatherInfo, new JsonMediaTypeFormatter()).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}