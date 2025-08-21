using System.Windows;

namespace UIPlayground{
    public partial class App
    {
        private Logger _logger;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _logger = new Logger("log.json");
            _logger.Log("Application started");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _logger = new Logger("log.json");
            var mainWindow = new MainWindow(_logger);
            mainWindow.Show();
        }
    }
}