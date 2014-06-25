namespace MeteoRInterfaceModel
{
    using System.Collections.Generic;

    public class Station
    {
        public int Id { get; set; }

        public string CityName { get; set; }
    }

    public class StationEqualityComparer : IEqualityComparer<Station>
    {
        public bool Equals(Station x, Station y)
        {
            return x.Id == y.Id && x.CityName == y.CityName;
        }

        public int GetHashCode(Station obj)
        {
            return (obj.Id + obj.CityName).GetHashCode();
        }
    }
}
