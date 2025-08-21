using System;
using System.Timers;

namespace UIPlayground
{
    public class MouseManager
    {
        private Logger _logger;
        private Timer _batteryTimer;
        private Random _random = new Random();
        private int _currentBattery = 85;
        private bool _isInitialized;

        public event Action<string, int> MouseStatusChanged;

        public MouseManager(Logger logger)
        {
            _logger = logger;
        }

        public void Init()
        {
            if (_isInitialized) return;

            _logger.Log("Mouse simulation started");
            StartBatterySimulation();
            _isInitialized = true;
        }

        private void StartBatterySimulation()
        {
            _batteryTimer = new Timer(5000);
            _batteryTimer.Elapsed += (s, e) =>
            {
                if (_random.Next(0, 100) < 20)
                {
                    _currentBattery = Math.Max(0, _currentBattery - _random.Next(1, 3));
                    MouseStatusChanged?.Invoke("Battery", _currentBattery);
                    _logger.Log($"Battery level: {_currentBattery}%");
                }
            };
            _batteryTimer.Start();

            MouseStatusChanged?.Invoke("Battery", _currentBattery);
            _logger.Log($"Initial battery level: {_currentBattery}%");
        }

        public void Dispose()
        {
            _batteryTimer?.Stop();
            _batteryTimer?.Dispose();
        }
    }
}