using System.Web.Http;

namespace MeteoRServer.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using MeteoRInterfaceModel;

    public class WeatherInfoController : ApiController
    {
        private static IList<WeatherInfo> weatherInfo = new List<WeatherInfo>();
        // GET api/weatherinfo/5
        public WeatherInfo Get(int id, long timestamp)
        {
            WeatherInfo firstOrDefault = weatherInfo.OrderByDescending(x => x.Timestamp).FirstOrDefault(x => x.Id == id && x.Timestamp <= timestamp);
            if (firstOrDefault == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return firstOrDefault;
            //return new WeatherInfo
            //           {
            //               Id = id,
            //               Timestamp = timestamp,
            //               CityName = "Davos",
            //               Temperature = 30,
            //               Pressure = 10,
            //               Humidity = 22
            //           };
        }

        // POST api/weatherinfo
        public void Post([FromBody]WeatherInfo value)
        {
            weatherInfo.Add(value);
        }
    }
}
