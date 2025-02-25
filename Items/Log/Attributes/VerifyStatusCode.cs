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
}