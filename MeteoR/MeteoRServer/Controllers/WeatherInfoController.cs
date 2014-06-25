using System.Web.Http;

namespace MeteoRServer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using MeteoRInterfaceModel;

    public class WeatherInfoController : ApiController
    {
        public static readonly IList<WeatherInfo> WeatherInfo = new List<WeatherInfo>();
        // GET api/weatherinfo/5
        public WeatherInfo Get(int id, long timestamp)
        {
            WeatherInfo firstOrDefault = WeatherInfo.OrderByDescending(x => x.Timestamp).FirstOrDefault(x => x.Id == id && x.Timestamp <= timestamp);
            if (firstOrDefault == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return firstOrDefault;
        }

        public IEnumerable<WeatherInfo> Get()
        {
            return WeatherInfo;
        } 

        // POST api/weatherinfo
        public void Post([FromBody]WeatherInfo value)
        {
            value.Timestamp = new DateTimeToUnixConverter().DateTimeToUnixTimeStamp(DateTime.Now);
            WeatherInfo.Add(value);
        }
    }
}
