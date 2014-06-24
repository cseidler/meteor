namespace MeteoRClient.MainWindow
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using MeteoRClient.Annotations;

    using MeteoRInterfaceModel;

    public class MainViewModel : INotifyPropertyChanged
    {
        private double temperature;

        private int humidity;

        private double pressure;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            this.GetResultsCommand = new GetResultsCommand(new MeteorServiceClient(), new DateTimeToUnixConverter());
            this.GetResultsCommand.ResultsChanged += this.HandleResultsChanged;
        }

        void HandleResultsChanged(object sender, System.EventArgs e)
        {
            this.Temperature = this.GetResultsCommand.Temperature;
            this.Humidity = this.GetResultsCommand.Humidity;
            this.Pressure = this.GetResultsCommand.Pressure;
        }

        public double Temperature
        {
            get
            {
                return this.temperature;
            }

            set
            {
                if (value.Equals(this.temperature))
                {
                    return;
                }

                this.temperature = value;
                this.OnPropertyChanged();
            }
        }

        public int Humidity
        {
            get
            {
                return this.humidity;
            }

            set
            {
                if (value == this.humidity)
                {
                    return;
                }

                this.humidity = value;
                this.OnPropertyChanged();
            }
        }

        public double Pressure
        {
            get
            {
                return this.pressure;
            }

            set
            {
                if (value.Equals(this.pressure))
                {
                    return;
                }

                this.pressure = value;
                this.OnPropertyChanged();
            }
        }

        public IGetResultsCommand GetResultsCommand { get; private set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
