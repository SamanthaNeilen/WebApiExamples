namespace Utilities
{
    public static class Extensions
    {
        public static bool IsEmail(this string value)
        {
            return value.Contains("@");
        }
    }
}
