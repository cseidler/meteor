namespace MeteoRClient.MainWindow
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using MeteoRClient.Annotations;

    using MeteoRInterfaceModel;

    public class MainViewModel : IMainViewModel
    {
        private readonly ICommandFactory commandFactory;

        private double? temperature;

        private int? humidity;

        private double? pressure;

        private string cityName;

        private string status;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
            this.CityName = null;
            this.GetResultsCommand = this.commandFactory.CreateCommand(this);
        }

        public double? Temperature
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

        public int? Humidity
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

        public double? Pressure
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

        public string CityName
        {
            get
            {
                return this.cityName;
            }

            set
            {
                if (value == this.cityName)
                {
                    return;
                }

                this.cityName = value;
                this.OnPropertyChanged();
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                if (value == this.status)
                {
                    return;
                }

                this.status = value;
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
