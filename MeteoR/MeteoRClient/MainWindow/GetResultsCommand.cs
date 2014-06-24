namespace MeteoRClient.MainWindow
{
    using System;

    using MeteoRInterfaceModel;

    public class GetResultsCommand : IGetResultsCommand
    {
        private const int StationId = 1234;

        private readonly IMeteorServiceClient meteorServiceClient;

        private readonly IDateTimeToUnixConverter dateTimeToUnixConverter;

        public GetResultsCommand(IMeteorServiceClient meteorServiceClient, IDateTimeToUnixConverter dateTimeToUnixConverter)
        {
            this.meteorServiceClient = meteorServiceClient;
            this.dateTimeToUnixConverter = dateTimeToUnixConverter;
        }

        public event EventHandler CanExecuteChanged;

        public event EventHandler ResultsChanged;

        public double Temperature { get; private set; }

        public double Pressure { get; private set; }

        public int Humidity { get; private set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var utcNowAsUnixTimestamp = this.dateTimeToUnixConverter.DateTimeToUnixTimeStamp(DateTime.UtcNow);
            var weatherInfo = await this.meteorServiceClient.GetWeatherInfo(StationId, utcNowAsUnixTimestamp);

            this.Temperature = weatherInfo.Temperature;
            this.Pressure = weatherInfo.Pressure;
            this.Humidity = weatherInfo.Humidity;

            this.OnResultsChanged();
        }

        private void OnResultsChanged()
        {
            if (this.ResultsChanged != null)
            {
                this.ResultsChanged(this, EventArgs.Empty);
            }
        }
    }
}