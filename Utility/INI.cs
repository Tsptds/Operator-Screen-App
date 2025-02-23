using System.Runtime.InteropServices;
using System.Text;

namespace Operator_Screen_App
{
    internal class Utility
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(
        string section, string key, string defaultValue,
        StringBuilder retVal, int size, string filePath);

        public static string ReadIniValue(string filePath, string section, string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", temp, 1024, filePath);
            return temp.ToString();
        }
    }
}
