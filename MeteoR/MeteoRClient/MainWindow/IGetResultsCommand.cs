namespace MeteoRClient.MainWindow
{
    using System;
    using System.Windows.Input;

    public interface IGetResultsCommand : ICommand
    {
        event EventHandler ResultsChanged;

        double Temperature { get; }

        double Pressure { get; }

        int Humidity { get; }
    }
}