using System.Collections.Generic;
using System.Web.Http;

namespace MeteoRServer.Controllers
{
    using System.Linq;

    using MeteoRInterfaceModel;

    public class StationController : ApiController
    {
        // GET api/station
        public IEnumerable<Station> Get()
        {
            return WeatherInfoController.WeatherInfo.Select(x => new Station { Id = x.Id, CityName = x.CityName }).Distinct();
        }
    }
}
