using System.Web.Http;

namespace MeteoRServer.Controllers
{
    using MeteoRInterfaceModel;

    public class WeatherInfoController : ApiController
    {
        // GET api/weatherinfo/5
        public WeatherInfo Get(int id, long timestamp)
        {
            return new WeatherInfo
                       {
                           Id = id,
                           Timestamp = timestamp,
                           CityName = "Davos",
                           Temperature = 30,
                           Pressure = 10,
                           Humidity = 22
                       };
        }

        // POST api/weatherinfo
        public void Post([FromBody]string value)
        {
        }
    }
}
