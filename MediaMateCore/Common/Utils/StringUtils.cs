using System.Text.RegularExpressions;

namespace MediaMate.Common.Utils
{
    public static class StringUtils
    {
        public static string Sanitize(string input)
        {
            return Regex.Replace(input, @"[/\\?%*:|""<>]", "");
        }
    }
}
