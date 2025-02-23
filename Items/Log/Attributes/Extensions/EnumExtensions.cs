namespace Operator_Screen_App.Items.Log.Attributes
{
    public static class EnumExtensions
    {
        public static string Format<T>(this T num) where T : Enum
        {
            return num.ToString().Replace("_", " ").Substring(1);
        }
    }
}
