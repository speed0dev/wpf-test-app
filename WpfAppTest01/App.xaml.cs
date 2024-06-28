using NLog;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfAppTest01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Event
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // NLog 설정
            NLogSetting();
        }

        private void NLogSetting()
        {
            string configFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config", "NLog.config");
            //LogManager.Configuration = new XmlLoggingConfiguration(configFilePath);
            LogFactory logFactory = LogManager.LoadConfiguration(configFilePath);

            //var config = LogManager.Configuration;
            //var logconsole = new NLog.Targets.ConsoleTarget("logConsole");
            //config.AddRule(LogLevel.Debug, LogLevel.Fatal, logconsole);
            //LogManager.Configuration = config;
        }
    }

}
