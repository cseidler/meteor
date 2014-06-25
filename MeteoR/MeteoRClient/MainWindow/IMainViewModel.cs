namespace MeteoRClient.MainWindow
{
    using System;
    using System.ComponentModel;

    public interface IMainViewModel : INotifyPropertyChanged
    {
        double? Temperature { get; set; }

        int? Humidity { get; set; }

        double? Pressure { get; set; }

        string CityName { get; set; }

        string Status { get; set; }

        DateTime? Time { get; set; }

        IGetResultsCommand GetResultsCommand { get; }
    }
}