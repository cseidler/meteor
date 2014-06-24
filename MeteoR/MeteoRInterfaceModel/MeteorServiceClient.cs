using System;

namespace MeteoRInterfaceModel
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using MeteoRClient;

    public class MeteorServiceClient : IMeteorServiceClient
    {
        private const string ServiceUri = "http://169.254.200.201:3074/api/weatherinfo";

        public async Task<WeatherInfo> GetWeatherInfo(int id, long timestamp)
        {
            var uri = string.Format("{0}/?id={1}&timestamp={2}", ServiceUri, id, timestamp);
            HttpResponseMessage response = null;

            Task serviceCall = Task.Factory.StartNew(() =>
            {
                using (var httpClient = new HttpClient())
                {
                    response = httpClient.GetAsync(uri).Result;
                }
            });

            //Task.Factory.StartNew(() =>
            //{
            //    using (var httpClient = new HttpClient())
            //    {
            //        response = httpClient.GetAsync(uri).Result;
            //    }
            //});

            try
            {
                serviceCall.Wait();
            }
            catch (Exception)
            {
                
                throw;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<WeatherInfo>().ConfigureAwait(false);

        }
    }
}