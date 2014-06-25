using Gadgeteer.Modules.Seeed;
using Gadgeteer.Modules.GHIElectronics;

namespace MeteoRWeatherStation
{
    using System;
    using System.IO;
    using System.Net;
    using MeteoRInterfaceModel;
    using Microsoft.SPOT;
    using GT = Gadgeteer;
    using GTM = Gadgeteer.Modules;
    using Gadgeteer.Modules.Seeed;

    public partial class Program
    {
        private const string ServiceUri = "http://192.168.1.31:3074/api/weatherinfo";

        private readonly WeatherInfo weatherInfo = new WeatherInfo();

        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started: *******************************************************************************************");

            // Setup weather station
            this.weatherInfo.CityName = "Davos";
            this.weatherInfo.Id = 0;

            // Event that fires when a measurement is ready
            temperatureHumidity.MeasurementComplete += this.TemperatureHumidity_MeasurementComplete;
            barometer.MeasurementComplete += this.Barometer_MeasurementComplete;

            // Start continuous measurements.
            temperatureHumidity.StartContinuousMeasurements();
            barometer.ContinuousMeasurementInterval = new TimeSpan(0, 0, 0, 1, 0);
            barometer.StartContinuousMeasurements();

            // Start notifying server
            GT.Timer timer = new GT.Timer(10000); // every 10 seconds
            timer.Tick += this.NotifyServer;
            timer.Start();
        }

        private void NotifyServer(GT.Timer timer)
        {
            HttpWebRequest httpWebRequest = this.CreateRequest();

            string jsonString = "{ \"Id\" : \""+this.weatherInfo.Id 
                + "\", \"CityName\" : \"" + this.weatherInfo.CityName
                + "\",\"Timestamp\" : \""+ this.weatherInfo.Timestamp
                + "\",\"Temperature\" : \""+ this.weatherInfo.Temperature
                + "\",\"Humidity\" : \""+ this.weatherInfo.Humidity
                + "\",\"Pressure\" : \""+ this.weatherInfo.Pressure + "\" }";
            httpWebRequest.ContentLength = jsonString.Length;

            try
            {
                 this.GetResponse(httpWebRequest, jsonString);
            }
            catch (Exception e)
            {
                
            }
        }

        void TemperatureHumidity_MeasurementComplete(TemperatureHumidity sender, double temperature, double relativeHumidity)
        {
            Debug.Print("Temperature: " + temperature + " Relative Humidity: " + relativeHumidity);

            this.weatherInfo.Temperature = temperature;
            this.weatherInfo.Humidity = (int)relativeHumidity;
        }

        void Barometer_MeasurementComplete(Barometer sender, Barometer.SensorData sensorData)
        {
            Debug.Print("Current Temperature: " + sensorData.Temperature + " Current Pressure: " + sensorData.Pressure);

            this.weatherInfo.Pressure = sensorData.Pressure;
        }

        private HttpWebRequest CreateRequest()
        {
            Uri serviceEndPoint = new Uri(ServiceUri);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceEndPoint);
            request.Method = "POST";
            // Set the APIKey as the Authorization header field to use for this request.
            //request.Headers.Add("Authorization", "APIKey " + this.apiKey);
            //request.Headers.Add("Authorization", "APIKey " + this.apiKey);
            request.ContentType = "application/json; charset=utf-8";
            return request;
        }

        // Gets the HTTP response based on the request and the content, 
        // typically for POST or PUT method
        private HttpWebResponse GetResponse(HttpWebRequest request, string jsonData)
        {
            using (StreamWriter requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(jsonData);
            }

            return (HttpWebResponse)request.GetResponse();
        }
    }
}
