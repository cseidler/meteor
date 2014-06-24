namespace MeteoRClient.MainWindow
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

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
            return !this.isUpdating;
        }

        public async void Execute(object parameter)
        {
            try
            {
                this.SetIsUpdating(true);
                this.viewModel.Status = Resources.GetResultsCommandUpdatingValues;

                var weatherInfo = await this.GetWeatherInfoFromService();

                this.UpdateViewModel(weatherInfo);
                this.viewModel.Status = string.Empty;
            }
            catch (HttpRequestException e)
            {
                this.viewModel.Status = e.Message;
            }
            finally
            {
                this.SetIsUpdating(false);
            }
        }

        private async Task<WeatherInfo> GetWeatherInfoFromService()
        {
            var utcNowAsUnixTimestamp = this.dateTimeToUnixConverter.DateTimeToUnixTimeStamp(DateTime.UtcNow);
            var weatherInfo = await this.meteorServiceClient.GetWeatherInfo(StationId, utcNowAsUnixTimestamp);
            return weatherInfo;
        }

        private void UpdateViewModel(WeatherInfo weatherInfo)
        {
            this.viewModel.Temperature = weatherInfo.Temperature;
            this.viewModel.Pressure = weatherInfo.Pressure;
            this.viewModel.Humidity = weatherInfo.Humidity;
            this.viewModel.CityName = weatherInfo.CityName;
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