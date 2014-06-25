namespace MeteoRInterfaceModel
{
    public class Station
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public override bool Equals(object obj)
        {
            Station station = (Station)obj;

            return station != null && station.Id == this.Id && station.CityName == this.CityName;
        }
    }
}
