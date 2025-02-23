using System.Text.Json;
using Operator_Screen_App.Connections;
using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Items.Node;

namespace Operator_Screen_App
{
    internal static class Program
    {
        private static readonly string versionString = "1.0.0";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string iniFilePath = ".\\Connections\\Mail\\Settings.ini";

            if (!File.Exists(iniFilePath))
            {
                MessageBox.Show("Settings.ini file not found, APP Will Not Start");
            }
            else
            {

                ApplicationConfiguration.Initialize();

                NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

                logger.Info("Operator Screen App v{0}", versionString);
                logger.Info("App Initialized");

                Application.Run(new Display());
            }
        }
    }
}