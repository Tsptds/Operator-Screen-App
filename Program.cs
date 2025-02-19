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
            ApplicationConfiguration.Initialize();

            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            logger.Info("Operator Screen App v{0}", versionString);
            logger.Info("App Initialized");

            Application.Run(new Display());
        }
    }
}