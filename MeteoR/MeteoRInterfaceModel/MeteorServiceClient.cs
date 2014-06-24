namespace MeteoRInterfaceModel
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    using MeteoRClient;

    using Newtonsoft.Json;

    using RestSharp.Portable;

    public class MeteorServiceClient : IMeteorServiceClient
    {
        private const string ServiceUri = "http://169.254.200.201:3074/api/weatherinfo";

        public async Task<WeatherInfo> GetWeatherInfo(int id, long timestamp)
        {
            var uri = string.Format("{0}/?id={1}&timestamp={2}", ServiceUri, id, timestamp);

            //var restRequest = new RestRequest(uri, HttpMethod.Get);
            //IRestResponse restResponse = new RestClient().Execute(restRequest).Result;
            //TextReader reader = new StringReader(Convert.ToBase64String(restResponse.RawBytes));
            //return new JsonSerializer().Deserialize<WeatherInfo>(new JsonTextReader(reader));

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<WeatherInfo>().ConfigureAwait(false);
            }

            
        }
    }
}