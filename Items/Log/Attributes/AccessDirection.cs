namespace Operator_Screen_App.Items.Log.Attributes
{
    public enum AccessDirection : UInt16
    {
        kOut = 0,
        kIn
    }
    public static class AccessDirectionExtension
    {
        //public static UInt16 val<T>(this T num) where T: Enum
        //{
        //    return Convert.ToUInt16(num);
        //}

        public static string dir<T>(this T num) where T : Enum
        {
            return num.ToString().Replace("_", " ").Substring(1);
        }
    }
}