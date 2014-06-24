namespace MeteoRClient.MainWindow
{
    using System;

    using MeteoRClient.Properties;

    using MeteoRInterfaceModel;

    public class GetResultsCommand : IGetResultsCommand
    {
        private const int StationId = 1234;

        private readonly MainViewModel viewModel;

        private readonly IMeteorServiceClient meteorServiceClient;

        private readonly IDateTimeToUnixConverter dateTimeToUnixConverter;

        private bool isUpdating = false;

        public GetResultsCommand(MainViewModel viewModel, IMeteorServiceClient meteorServiceClient, IDateTimeToUnixConverter dateTimeToUnixConverter)
        {
            this.viewModel = viewModel;
            this.meteorServiceClient = meteorServiceClient;
            this.dateTimeToUnixConverter = dateTimeToUnixConverter;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !isUpdating;
        }

        public async void Execute(object parameter)
        {
            try
            {
                this.SetIsUpdating(true);
                this.viewModel.Status = Resources.GetResultsCommandUpdatingValues;

                var utcNowAsUnixTimestamp = this.dateTimeToUnixConverter.DateTimeToUnixTimeStamp(DateTime.UtcNow);
                var weatherInfo = await this.meteorServiceClient.GetWeatherInfo(StationId, utcNowAsUnixTimestamp);

                this.viewModel.Temperature = weatherInfo.Temperature;
                this.viewModel.Pressure = weatherInfo.Pressure;
                this.viewModel.Humidity = weatherInfo.Humidity;
                this.viewModel.CityName = weatherInfo.CityName;
            }
            finally
            {
                this.viewModel.Status = string.Empty;
                this.SetIsUpdating(false);
            }
        }

        private void SetIsUpdating(bool updating)
        {
            this.isUpdating = updating;
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}