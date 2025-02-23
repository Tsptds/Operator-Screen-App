using Operator_Screen_App.Items.Log.Attributes;

namespace Operator_Screen_App
{
    public static class Json_response
    {
        private static Random rng = new Random();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private static readonly string json1 = "{\"logID\":\"1739358826001\",\"computerHash\":\"a1b2c\",\"ipAddress\":\"127.168.1.1\",\"userID\":\"qwertyuasdfghjklzxcvbnm\",\"username\":\"Demo User1\",\"accessLocation\":\"Demo Location1\",\"accessDirection\":1,\"verifyStatusCode\":0,\"additionalInfo\":\"Something Something Additional\",\"logTime\":\"2021-03-06T00:00:00\"}";
        private static readonly string json2 = "{\"logID\":\"1739776069965\",\"computerHash\":\"a1b2c\",\"ipAddress\":\"127.168.1.1\",\"userID\":\"qwertyuasdfghjklzxcvbnm\",\"username\":\"Demo User2\",\"accessLocation\":\"Demo Location2\",\"accessDirection\":0,\"verifyStatusCode\":1,\"additionalInfo\":\"Something Something Additional\",\"logTime\":\"2000-09-22T00:00:00\"}";
        private static readonly string json3 = "{\"logID\":\"1739795439187\",\"computerHash\":\"a1b2c\",\"ipAddress\":\"127.168.1.1\",\"userID\":\"qwertyuasdfghjklzxcvbnm\",\"username\":\"Demo User3\",\"accessLocation\":\"Demo Location3\",\"accessDirection\":1,\"verifyStatusCode\":2,\"additionalInfo\":\"Something Something Additional\",\"logTime\":\"2017-11-05T00:00:00\"}";
        private static readonly string json4 = "{\"logID\":\"1739795439187\",\"computerHash\":\"a1b2c\",\"ipAddress\":\"127.168.1.1\",\"userID\":\"qwertyuasdfghjklzxcvbnm\",\"username\":\"Demo User4\",\"accessLocation\":\"Demo Location4\",\"accessDirection\":1,\"verifyStatusCode\":3,\"additionalInfo\":\"Something Something Additional\",\"logTime\":\"2017-11-05T00:00:00\"}";
        private static readonly string json5 = "{\"logID\":\"1739795439187\",\"computerHash\":\"a1b2c\",\"ipAddress\":\"127.168.1.1\",\"userID\":\"qwertyuasdfghjklzxcvbnm\",\"username\":\"Demo User5\",\"accessLocation\":\"Demo Location5\",\"accessDirection\":1,\"verifyStatusCode\":4,\"additionalInfo\":\"Something Something Additional\",\"logTime\":\"2017-11-05T00:00:00\"}";
        private static readonly string json6 = "{\"logID\":\"1739795439187\",\"computerHash\":\"a1b2c\",\"ipAddress\":\"127.168.1.1\",\"userID\":\"qwertyuasdfghjklzxcvbnm\",\"username\":\"Demo User6\",\"accessLocation\":\"Demo Location6\",\"accessDirection\":1,\"verifyStatusCode\":5,\"additionalInfo\":\"Something Something Additional\",\"logTime\":\"2017-11-05T00:00:00\"}";
        public static string getString()
        {
            string toReturn = "";
            int val = (int)(rng.NextSingle() / 1 * 5);

            MessageBox.Show(((VerifyStatusCode)val).ToString() + val.ToString(), "Random Debug Verify Code Selected");
            logger.Info(((VerifyStatusCode)val).ToString() + val.ToString(), "Random Debug Verify Code Selected");
            switch (val)
            {
                case 0:
                    toReturn = json1;
                    break;
                case 1:
                    toReturn = json2;
                    break;
                case 2:
                    toReturn = json3;
                    break;
                case 3:
                    toReturn = json4;
                    break;
                case 4:
                    toReturn = json5;
                    break;
                case 5:
                    toReturn = json6;
                    break;
            }

            return toReturn;
        }
    }
}
