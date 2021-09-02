using System;
using System.Text.RegularExpressions;

namespace EstateControl.Utils
{
    class Utils
    {
        public static double getNumber(string text)
        {
            try
            {
                return Convert.ToDouble(new Regex(@"(\d|\.|\,|\-)*").Match(text).Value.Replace(".", ","));
            }
            catch { return 0; }
        }
    }
}
