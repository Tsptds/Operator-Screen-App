using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Screen_App.Connections
{
    public static class Mail
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Send()
        {
            logger.Info("Attempting to send mail");

            try
            {
                // TODO: Implement mailing
                throw new Exception("TEST EXCEPTION");
                logger.Info("Successfully Sent the Mail to Supervisor");
            }
            catch (Exception ex)
            {
                throw new Exception("Error During Sending Mail");
            }
        }
    }
}
