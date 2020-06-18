using System.Linq;

namespace WaterMark1.Helpers
{
    public class TextHelper
    {
        public static string ConvertPositionValue(string value)
        {
            if (value.Length > 2)
                return string.Concat(value.Split('-').Select(x => x[0]));
            return value;
        }
    }
}