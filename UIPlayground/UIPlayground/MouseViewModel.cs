using System.ComponentModel;
using System.Windows.Media;


namespace UIPlayground
{
    public class MouseViewModel : INotifyPropertyChanged
    {

        private double _batteryLevel;
        public double BatteryLevel
        {
            get => _batteryLevel;
            set
            {
                if ((int)_batteryLevel != (int)value)
                {
                    _batteryLevel = value;
                    OnPropertyChanged(nameof(BatteryLevel));
                    OnPropertyChanged(nameof(BatteryColor));
                }
            }
        }

        public Brush BatteryColor
        {
            get
            {
                if (BatteryLevel > 60) return Brushes.Green;
                if (BatteryLevel > 30) return Brushes.Yellow;
                return Brushes.Red;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

}
