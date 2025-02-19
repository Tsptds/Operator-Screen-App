using System.Runtime.CompilerServices;
using Operator_Screen_App.Logics;

namespace Operator_Screen_App.Items.Log.Attributes
{
    public enum VerifyStatusCode : UInt16
    {
        kSuccess = 0,
        kNot_Found = 1,
        kNot_Enrolled = 2,
        kNot_Allowed_Bio_Type = 3,
        kNot_Verified = 4,
        kCard_Not_Supported = 5
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