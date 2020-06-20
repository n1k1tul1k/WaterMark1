using System.Linq;

namespace WaterMark1.Helpers
{
    public static class TextHelper
    {
        public static string ConvertPositionValue(this string value)
        {
            if (value.Length > 2 && value.Contains('-'))
                return string.Concat(value.Split('-').Select(x => x[0]));
            return value;
        }
    }
}