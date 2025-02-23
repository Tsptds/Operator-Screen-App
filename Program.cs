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
            string iniFilePath = ".\\Settings.ini";
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            if (!File.Exists(iniFilePath))
            {
                logger.Error("Settings.ini was not found, app terminated");
                MessageBox.Show("Settings.ini file not found, APP Will Not Start");
                return;
            }
            else
            {
                ApplicationConfiguration.Initialize();

                logger.Info("Operator Screen App v{0}", versionString);
                logger.Info("App Initialized");

                Application.Run(new Display());
            }
        }
    }
}