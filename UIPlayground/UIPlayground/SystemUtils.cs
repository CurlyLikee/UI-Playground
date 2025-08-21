using System.Diagnostics;
using System.IO;
using System.Windows;


namespace UIPlayground
{
    public static class SystemUtils
    {
        public static void OpenLogger()
        {
            var psi = new ProcessStartInfo
            {
                FileName = @"C:\Users\Альона\source\repos\softserve csharp\final_project\UIPlayground\UIPlayground\bin\Debug\log.json",
                UseShellExecute = true
            };
            Process.Start(psi);
        }


        public static void OpenFolder()
        {
            string folderPath = @"C:\Users\Альона\source\repos\softserve csharp\final_project";

            if (Directory.Exists(folderPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = folderPath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Folder does not exist");
            }
        }


        public static void OpenNotepad()
        {
            Process.Start("notepad");
        }


        public static void OpenWeatherWebsite()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://sinoptik.ua/pohoda/kyiv/10-dniv",
                UseShellExecute = true
            });
        }

        public static void CurrencyPage()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://minfin.com.ua/ua/currency/usd/",
                UseShellExecute = true
            });
        }
    }
}
