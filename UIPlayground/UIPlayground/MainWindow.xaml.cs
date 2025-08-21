using System;
using System.Windows;
using System.Windows.Threading;


namespace UIPlayground
{
    public partial class MainWindow
    {
        private Logger _logger;
        private QuoteManager _quoteManager = new QuoteManager();

        public MainWindow(Logger logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.Log("Application started");

            _quoteManager = new QuoteManager();
            QuoteText.Text = _quoteManager.GetRandomQuote();

            var viewModel = new MouseViewModel();
            DataContext = viewModel;

            var manager = new MouseManager(_logger);
            manager.MouseStatusChanged += (type, value) =>
            {
                if (type == "Battery")
                    viewModel.BatteryLevel = value;
            };
            manager.Init();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                ClockText.Text = DateTime.Now.ToString("HH:mm");
                DayText.Text = DateTime.Now.ToString("dddd");
                DateText.Text = DateTime.Now.ToString("dd.MM.yyyy");
            };
            timer.Start();
        }


        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            SystemUtils.OpenLogger();
            _logger.Log("Open Logger");
        }

        private void Folder_Click(object sender, RoutedEventArgs e)
        {
            SystemUtils.OpenFolder();
            _logger.Log("Opened project folder");
        }

        private void OpenNotepad_Click(object sender, RoutedEventArgs e)
        {
            SystemUtils.OpenNotepad();
            _logger.Log("Opened Notepad");
        }

        private void Weather_Click(object sender, RoutedEventArgs e)
        {
            SystemUtils.OpenWeatherWebsite();
            _logger.Log("Opened weather website");
        }

        private void Currency_Click(object sender, RoutedEventArgs e)
        {
            SystemUtils.CurrencyPage();
            _logger.Log("Opened currency page");
        }
    }
}
