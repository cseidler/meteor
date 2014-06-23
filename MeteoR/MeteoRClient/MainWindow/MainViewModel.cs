namespace MeteoRClient.MainWindow
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using MeteoRClient.Annotations;

    public class MainViewModel : INotifyPropertyChanged
    {
        private double temperature;

        private int humidity;

        private double pressure;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            this.Temperature = 20.94;
            this.Pressure = 99.9;
            this.Humidity = 42;
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
