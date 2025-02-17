using System.Runtime.CompilerServices;
using Operator_Screen_App.Logics;

namespace Operator_Screen_App.Items.Log.Attributes
{
    public enum VerifyStatusCode : UInt16
    {
        kSuccess = 0,
        kNot_Found,
        kNot_Enrolled,
        kNot_Allowed_Bio_Type,
        kNot_Verified,
        kCard_Not_Supported
    }
    public static class VerifyStatusCodeExtension
    {
        //public static UInt16 val<T>(this T num) where T: Enum
        //{
        //    return Convert.ToUInt16(num);
        //}

        public static string context<T>(this T num) where T : Enum
        {
            return num.ToString().Replace("_", " ").Substring(1);
        }
    }
}