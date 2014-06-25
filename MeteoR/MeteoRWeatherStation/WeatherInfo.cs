namespace MeteoRInterfaceModel
{
    public class WeatherInfo
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public long Timestamp { get; set; }

        public double Temperature { get; set; }

        public double Pressure { get; set; }

        public int Humidity { get; set; }
    }
}
