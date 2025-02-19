using System.Text.Json;
using Operator_Screen_App.Connections;
using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Items.Node;

namespace Operator_Screen_App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Display());
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("HELLLOO");

            //TODO: Add Logs with NLog
        }
    }
}