using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ac_webscraper.utilies {
    public static class Util {

        private static readonly HashSet<string> TrueValues = new(StringComparer.OrdinalIgnoreCase)
        {
            "provided",
            "yes",
            "true",
            "1",
            "enabled",
            "on"
        };

        public static bool ConvertStringToBool(string input) {
            return input != null && TrueValues.Contains(input.Trim());
        }

        public static int ParseInt(string input) {
            // Remove all non-numeric characters
            string numericPart = new string(input.Where(char.IsDigit).ToArray());

            // Try parsing the numeric part
            return int.TryParse(numericPart, out int result) ? result : 0;
        }
    }
}
