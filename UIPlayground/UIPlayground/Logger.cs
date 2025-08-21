using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace UIPlayground
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }


    public class Logger
    {
        public Logger()
        {
            _logFilePath = "log.json";
            LoadFromFile();
        }

        private string _logFilePath;
        private List<LogEntry> _entries = new List<LogEntry>();

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (File.Exists(_logFilePath))
            {
                string json = File.ReadAllText(_logFilePath);
                _entries = JsonConvert.DeserializeObject<List<LogEntry>>(json) ?? new List<LogEntry>();
            }
            else
            {
                _entries = new List<LogEntry>();
            }
        }

        public void Log(string message)
        {
            _entries.Add(new LogEntry { Timestamp = DateTime.Now, Message = message });
            SaveToJson();
        }

        public IReadOnlyList<LogEntry> Entries => _entries;

        public void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(_entries, Formatting.Indented);
            File.WriteAllText(_logFilePath, json);
        }
    }
}
