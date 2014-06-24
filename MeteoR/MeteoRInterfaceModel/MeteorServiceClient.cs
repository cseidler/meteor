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
            var restRequest = new RestRequest(string.Format("?id={0}&timestamp={1}", id, timestamp), HttpMethod.Get);
            var restClient = new RestClient(ServiceUri);
            IRestResponse restResponse = await restClient.Execute(restRequest).ConfigureAwait(false);
            TextReader reader = new StringReader(Convert.ToBase64String(restResponse.RawBytes));
            return new JsonSerializer().Deserialize<WeatherInfo>(new JsonTextReader(reader));
        }
    }
}